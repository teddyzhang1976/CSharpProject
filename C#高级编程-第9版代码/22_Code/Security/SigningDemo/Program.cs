using System;
using System.Security.Cryptography;
using System.Text;

namespace Wrox.ProCSharp.Security
{
  class Program
  {
    internal static CngKey aliceKeySignature;
    internal static byte[] alicePubKeyBlob;

    static void Main()
    {
      CreateKeys();

      byte[] aliceData = Encoding.UTF8.GetBytes("Alice");
      byte[] aliceSignature = CreateSignature(aliceData, aliceKeySignature);
      Console.WriteLine("Alice created signature: {0}",
        Convert.ToBase64String(aliceSignature));

      if (VerifySignature(aliceData, aliceSignature, alicePubKeyBlob))
      {
        Console.WriteLine("Alice signature verified successfully");
      }
    }

    static void CreateKeys()
    {
      aliceKeySignature = CngKey.Create(CngAlgorithm.ECDsaP256);
      alicePubKeyBlob = aliceKeySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
    }

    static byte[] CreateSignature(byte[] data, CngKey key)
    {
      byte[] signature;
      using (var signingAlg = new ECDsaCng(key))
      {
        signature = signingAlg.SignData(data);
        signingAlg.Clear();
      }
      return signature;
    }

    static bool VerifySignature(byte[] data, byte[] signature, byte[] pubKey)
    {
      bool retValue = false;
      using (CngKey key = CngKey.Import(pubKey, CngKeyBlobFormat.GenericPublicBlob))
      using (var signingAlg = new ECDsaCng(key)) 
      {
        retValue = signingAlg.VerifyData(data, signature);
        signingAlg.Clear();
      }
      return retValue;
    }
  }
}


