using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.Security
{
  class Program
  {
    static CngKey aliceKey;
    static CngKey bobKey;
    static byte[] alicePubKeyBlob;
    static byte[] bobPubKeyBlob;

    static void Main()
    {
      Run();
      Console.ReadLine();
    }

    private async static void Run()
    {
      try
      {
        CreateKeys();
        byte[] encrytpedData = await AliceSendsData("secret message");
        await BobReceivesData(encrytpedData);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }



    private static void CreateKeys()
    {
      aliceKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);
      bobKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);
      alicePubKeyBlob = aliceKey.Export(CngKeyBlobFormat.EccPublicBlob);
      bobPubKeyBlob = bobKey.Export(CngKeyBlobFormat.EccPublicBlob);
    }

    private async static Task<byte[]> AliceSendsData(string message)
    {
      Console.WriteLine("Alice sends message: {0}", message);
      byte[] rawData = Encoding.UTF8.GetBytes(message);
      byte[] encryptedData = null;

      using (var aliceAlgorithm = new ECDiffieHellmanCng(aliceKey))
      using (CngKey bobPubKey = CngKey.Import(bobPubKeyBlob,
            CngKeyBlobFormat.EccPublicBlob))
      {
        byte[] symmKey = aliceAlgorithm.DeriveKeyMaterial(bobPubKey);
        Console.WriteLine("Alice creates this symmetric key with " +
              "Bobs public key information: {0}",
              Convert.ToBase64String(symmKey));

        using (var aes = new AesCryptoServiceProvider())
        {
          aes.Key = symmKey;
          aes.GenerateIV();
          using (ICryptoTransform encryptor = aes.CreateEncryptor())
          using (MemoryStream ms = new MemoryStream())
          {
            // create CryptoStream and encrypt data to send
            var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

            // write initialization vector not encrypted
            await ms.WriteAsync(aes.IV, 0, aes.IV.Length);
            await cs.WriteAsync(rawData, 0, rawData.Length);
            cs.Close();
            encryptedData = ms.ToArray();
          }
          aes.Clear();
        }
      }
      Console.WriteLine("Alice: message is encrypted: {0}", Convert.ToBase64String(encryptedData)); ;
      Console.WriteLine();
      return encryptedData;
    }

    private async static Task BobReceivesData(byte[] encryptedData)
    {
      Console.WriteLine("Bob receives encrypted data");
      byte[] rawData = null;

      var aes = new AesCryptoServiceProvider();

      int nBytes = aes.BlockSize >> 3;
      byte[] iv = new byte[nBytes];
      for (int i = 0; i < iv.Length; i++)
        iv[i] = encryptedData[i];

      using (var bobAlgorithm = new ECDiffieHellmanCng(bobKey))
      using (CngKey alicePubKey = CngKey.Import(alicePubKeyBlob,
            CngKeyBlobFormat.EccPublicBlob))
      {
        byte[] symmKey = bobAlgorithm.DeriveKeyMaterial(alicePubKey);
        Console.WriteLine("Bob creates this symmetric key with " +
              "Alices public key information: {0}",
              Convert.ToBase64String(symmKey));

        aes.Key = symmKey;
        aes.IV = iv;

        using (ICryptoTransform decryptor = aes.CreateDecryptor())
        using (MemoryStream ms = new MemoryStream())
        {
          var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
          await cs.WriteAsync(encryptedData, nBytes, encryptedData.Length - nBytes);
          cs.Close();

          rawData = ms.ToArray();

          Console.WriteLine("Bob decrypts message to: {0}",
                Encoding.UTF8.GetString(rawData));
        }
        aes.Clear();
      }
    }
  }
}
