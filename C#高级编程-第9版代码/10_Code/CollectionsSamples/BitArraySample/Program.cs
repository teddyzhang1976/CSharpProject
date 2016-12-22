using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace BitArraySample
{
  class Program
  {
    static void BitArrayDemo()
    {
      var bits1 = new BitArray(8);
      bits1.SetAll(true);
      bits1.Set(1, false);
      bits1[5] = false;
      bits1[7] = false;
      Console.Write("initialized: ");
      DisplayBits(bits1);
      Console.WriteLine();


      DisplayBits(bits1);
      bits1.Not();
      Console.Write(" not ");
      DisplayBits(bits1);
      Console.WriteLine();

      var bits2 = new BitArray(bits1);
      bits2[0] = true;
      bits2[1] = false;
      bits2[4] = true;
      DisplayBits(bits1);
      Console.Write(" or ");
      DisplayBits(bits2);
      Console.Write(" : ");
      bits1.Or(bits2);
      DisplayBits(bits1);
      Console.WriteLine();


      DisplayBits(bits2);
      Console.Write(" and ");
      DisplayBits(bits1);
      Console.Write(" : ");
      bits2.And(bits1);
      DisplayBits(bits2);
      Console.WriteLine();

      DisplayBits(bits1);
      Console.Write(" xor ");
      DisplayBits(bits2);
      bits1.Xor(bits2);
      Console.Write(" : ");
      DisplayBits(bits1);
      Console.WriteLine();
    }

    static void BitVectorDemo()
    {

      var bits1 = new BitVector32();
      int bit1 = BitVector32.CreateMask();
      int bit2 = BitVector32.CreateMask(bit1);
      int bit3 = BitVector32.CreateMask(bit2);
      int bit4 = BitVector32.CreateMask(bit3);
      int bit5 = BitVector32.CreateMask(bit4);

      bits1[bit1] = true;
      bits1[bit2] = false;
      bits1[bit3] = true;
      bits1[bit4] = true;
      Console.WriteLine(bits1);

      bits1[0xabcdef] = true;
      Console.WriteLine(bits1);


      int received = 0x79abcdef;

      var bits2 = new BitVector32(received);
      Console.WriteLine(bits2);
      // sections: FF EEE DDD CCCC BBBBBBBB AAAAAAAAAAAA
      BitVector32.Section sectionA = BitVector32.CreateSection(0xfff);
      BitVector32.Section sectionB = BitVector32.CreateSection(0xff, sectionA);
      BitVector32.Section sectionC = BitVector32.CreateSection(0xf, sectionB);
      BitVector32.Section sectionD = BitVector32.CreateSection(0x7, sectionC);
      BitVector32.Section sectionE = BitVector32.CreateSection(0x7, sectionD);
      BitVector32.Section sectionF = BitVector32.CreateSection(0x3, sectionE);



      Console.WriteLine("Section A: " + IntToBinaryString(bits2[sectionA], true));
      Console.WriteLine("Section B: " + IntToBinaryString(bits2[sectionB], true));
      Console.WriteLine("Section C: " + IntToBinaryString(bits2[sectionC], true));
      Console.WriteLine("Section D: " + IntToBinaryString(bits2[sectionD], true));
      Console.WriteLine("Section E: " + IntToBinaryString(bits2[sectionE], true));
      Console.WriteLine("Section F: " + IntToBinaryString(bits2[sectionF], true));


    }

    static string IntToBinaryString(int bits, bool removeTrailingZero)
    {
      var sb = new StringBuilder(32);

      for (int i = 0; i < 32; i++)
      {
        if ((bits & 0x80000000) != 0)
        {
          sb.Append("1");
        }
        else
        {
          sb.Append("0");
        }
        bits = bits << 1;
      }
      string s = sb.ToString();
      if (removeTrailingZero)
        return s.TrimStart('0');
      else
        return s;
    }

    static void Main()
    {
      // BitArrayDemo();
      BitVectorDemo();
    }


    static void DisplayBits(BitArray bits)
    {
      foreach (bool bit in bits)
      {
        Console.Write(bit ? 1 : 0);
      }
    }
  }
}
