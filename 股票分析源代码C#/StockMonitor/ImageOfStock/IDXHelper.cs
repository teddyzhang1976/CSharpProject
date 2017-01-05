using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace StockMonitor.DayLineReader
{
    public class IDXformat
    {
        public char Chksum;
        public string Code1;
        public string Code2;
        public string Code3;
        public string Code4;
        public string DateTime;
        public string FilePath;
        public char Group;
        public int Length;
        public char Market;
        public int Offset;
        public byte[] Reserved;
        public string Title;
        public char Type;
        public string UpdateTime;

        public IDXInfo ArrayToIDX(byte[] IdxByte, string txtPath)
        {

            //标题
            byte[] buffer2 = new byte[0x40];
            Array.Copy(IdxByte, 11, buffer2, 0, 0x40);
            this.Title = Encoding.GetEncoding("gb2312").GetString(buffer2);
            int index = this.Title.IndexOf("\0");
            this.Title = this.Title.Remove(index, this.Title.Length - index);

            //路径
            byte[] buffer3 = new byte[80];
            Array.Copy(IdxByte, 0x4b, buffer3, 0, 80);
            this.FilePath = Encoding.GetEncoding("gb2312").GetString(buffer3);
            int indexFP = this.FilePath.IndexOf("\0");
            this.FilePath = this.FilePath.Remove(indexFP, this.FilePath.Length - indexFP);

            //Offset
            byte[] buffer8 = new byte[4];
            Array.Copy(IdxByte, 0x9b, buffer8, 0, 4);
            this.Offset = BitConverter.ToInt32(buffer8, 0);

            //Length
            byte[] buffer9 = new byte[4];
            Array.Copy(IdxByte, 0x9f, buffer9, 0, 4);
            this.Length = BitConverter.ToInt32(buffer9, 0);

            //Chksum
            byte[] buffer10 = new byte[1];
            Array.Copy(IdxByte, 0xff, buffer9, 0, 1);
            this.Chksum = Encoding.GetEncoding("gb2312").GetChars(buffer10, 0, 1)[0];
            string FileFullName = txtPath + "\\" + FilePath;

            //日期
            byte[] buffer11 = new byte[4];
            Array.Copy(IdxByte, 3, buffer11, 0, 4);
            int date = BitConverter.ToInt32(buffer11, 0);

            //全部内容
            FileStream Myidxidx = new FileStream(FileFullName, FileMode.Open);
            BinaryReader Myidxidxr = new BinaryReader(Myidxidx, Encoding.Default);
            int Tlength = (int)Myidxidxr.BaseStream.Length;
            //全部字节
            byte[] TheWhole = new byte[Tlength];
            Myidxidxr.Read(TheWhole, 0, Tlength);

            byte[] Content = new byte[this.Length];
            Array.Copy(TheWhole, this.Offset, Content, 0, this.Length);
            string ContentStr = Encoding.GetEncoding("gb2312").GetString(Content);
            Myidxidx.Close();
            Myidxidxr.Close();
            IDXInfo Idxinf = new IDXInfo();
            Idxinf.Content = ContentStr;
            Idxinf.Title = this.Title;
            string DateInfo = date.ToString();
            if (date == 00)
            {
                DateInfo = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                Idxinf.DateTime = DateInfo.Substring(0, 4) + "-" + DateInfo.Substring(4, 2) + "-" + DateInfo.Substring(6, 2);
            }
            Idxinf.Offset = this.Offset;
            Idxinf.Length = this.Length;
            Idxinf.FilePath = this.FilePath;

            return Idxinf;
        }


        public byte[] ToByteArray()
        {
            byte[] array = new byte[0x40];
            byte[] buffer3 = new byte[80];
            byte[] buffer4 = new byte[9];
            byte[] buffer5 = new byte[9];
            byte[] buffer6 = new byte[9];
            byte[] buffer7 = new byte[9];
            Encoding.GetEncoding("gb2312").GetBytes(this.Title).CopyTo(array, 0);
            Encoding.GetEncoding("gb2312").GetBytes(this.FilePath).CopyTo(buffer3, 0);
            if (this.Code1.Length > 0)
            {
                buffer4[0] = (byte)this.Market;
            }
            else
            {
                buffer4[0] = 0;
            }
            Encoding.GetEncoding("gb2312").GetBytes(this.Code1).CopyTo(buffer4, 1);
            if (this.Code2.Length > 0)
            {
                buffer5[0] = (byte)this.Market;
            }
            else
            {
                buffer5[0] = 0;
            }
            Encoding.GetEncoding("gb2312").GetBytes(this.Code2).CopyTo(buffer5, 1);
            if (this.Code3.Length > 0)
            {
                buffer6[0] = (byte)this.Market;
            }
            else
            {
                buffer6[0] = 0;
            }
            Encoding.GetEncoding("gb2312").GetBytes(this.Code3).CopyTo(buffer6, 1);
            if (this.Code4.Length > 0)
            {
                buffer7[0] = (byte)this.Market;
            }
            else
            {
                buffer7[0] = 0;
            }
            Encoding.GetEncoding("gb2312").GetBytes(this.Code4).CopyTo(buffer7, 1);
            char[] separator = new char[] { 'T', '-', ':' };
            string[] strArray = this.UpdateTime.Split(separator);
            this.UpdateTime = strArray[0] + strArray[1] + strArray[2] + strArray[3] + strArray[4] + strArray[5];
            Encoding.GetEncoding("gb2312").GetBytes(this.UpdateTime).CopyTo(this.Reserved, 0);
            char[] chArray2 = new char[] { ' ', '-', ':' };
            strArray = this.DateTime.Split(chArray2);
            int num = ((Convert.ToInt16(strArray[0]) * 0x2710) + (Convert.ToInt16(strArray[1]) * 100)) + Convert.ToInt16(strArray[2]);
            int num2 = ((Convert.ToInt16(strArray[3]) * 0x2710) + (Convert.ToInt16(strArray[4]) * 100)) + Convert.ToInt16(strArray[5]);
            byte[] buffer8 = new byte[0x100];
            buffer8[0] = (byte)this.Type;
            buffer8[1] = (byte)this.Group;
            buffer8[2] = (byte)this.Market;
            BitConverter.GetBytes(num).CopyTo(buffer8, 3);
            BitConverter.GetBytes(num2).CopyTo(buffer8, 7);
            array.CopyTo(buffer8, 11);
            buffer3.CopyTo(buffer8, 0x4b);
            BitConverter.GetBytes(this.Offset).CopyTo(buffer8, 0x9b);
            BitConverter.GetBytes(this.Length).CopyTo(buffer8, 0x9f);
            buffer4.CopyTo(buffer8, 0xa3);
            buffer5.CopyTo(buffer8, 0xac);
            buffer6.CopyTo(buffer8, 0xb5);
            buffer7.CopyTo(buffer8, 190);
            this.Reserved.CopyTo(buffer8, 0xc7);
            buffer8[0xff] = (byte)this.Chksum;
            return buffer8;
        }

        private enum DateFormat
        {
            Year,
            Month,
            Day,
            Hour,
            Minute,
            Second
        }

        private enum IDXposition//开始位置
        {
            Chksum = 0xff,
            Code1 = 0xa3,
            Code2 = 0xac,
            Code3 = 0xb5,
            Code4 = 190,
            Date = 3,
            FilePath = 0x4b,
            Group = 1,
            Length = 0x9f,
            Market = 2,
            Offset = 0x9b,
            Reserved = 0xc7,
            Time = 7,
            Title = 11,
            Type = 0
        }
    }
    public class IDX
    {
        public byte[] Buffer;
        public string ErrorMsg;
        public FileStream idx;
        public string IDXpath;
        public BinaryReader idxr;
        public BinaryWriter idxw;
        public IDXformat myIDXformat;
        public int Offset;
        public FileStream txt;
        public string TXTpath;
        public BinaryWriter txtw;

        public IDX(string idxpath)
        {
            this.IDXpath = idxpath;
        }

        public IDX(string idxpath, string txtpath)
        {
            this.IDXpath = idxpath;
            this.TXTpath = txtpath;
        }

        public void Close()
        {
            this.idx.Close();
            this.idxw.Close();
            this.txt.Close();
            this.txtw.Close();
        }

        public void CreateHead()
        {
            string str = "QIANLONG";
            char ch = '\x0001';
            char ch2 = '\x0001';
            short num = 1;
            char[] chars = new char[4];
            this.idxw.Write(str.ToCharArray());
            this.idxw.Write(ch);
            this.idxw.Write(ch2);
            this.idxw.Write(num);
            this.idxw.Write(chars);
        }

        public bool CreateIDX(char Type, char Group, char Market, string DateTime, string Title, string Content, string[] Code, string UpdateTime)
        {
            this.myIDXformat = new IDXformat();
            this.myIDXformat.Type = Type;
            this.myIDXformat.Group = Group;
            this.myIDXformat.Market = Market;
            this.myIDXformat.DateTime = DateTime;
            this.myIDXformat.UpdateTime = UpdateTime;
            this.myIDXformat.Title = Title;
            int startIndex = this.TXTpath.LastIndexOf('\\') + 1;
            this.myIDXformat.FilePath = this.TXTpath.Substring(startIndex, this.TXTpath.Length - startIndex);
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(Content);
            this.myIDXformat.Length = bytes.Length;
            if (File.Exists(this.TXTpath))
            {
                FileInfo info = new FileInfo(this.TXTpath);
                this.myIDXformat.Offset = (int)info.Length;
                this.txt = new FileStream(this.TXTpath, FileMode.Append);
                this.txtw = new BinaryWriter(this.txt, Encoding.Default);
            }
            else
            {
                this.txt = new FileStream(this.TXTpath, FileMode.CreateNew);
                this.txtw = new BinaryWriter(this.txt, Encoding.Default);
                this.myIDXformat.Offset = 0;
            }
            this.txtw.Write(bytes);
            this.myIDXformat.Code1 = Code[0];
            this.myIDXformat.Code2 = Code[1];
            this.myIDXformat.Code3 = Code[2];
            this.myIDXformat.Code4 = Code[3];
            this.myIDXformat.Reserved = new byte[0x38];
            this.myIDXformat.Chksum = '\0';
            try
            {
                if (this.Buffer != null)
                {
                    this.idxw.Write(this.Buffer);
                }
                this.idxw.Write(this.myIDXformat.ToByteArray());
            }
            catch (Exception exception)
            {
                this.ErrorMsg = exception.Message;
                return false;
            }
            return true;
        }

        public bool Disable(string UpdateTime, string Title)
        {
            bool flag = false;
            if (File.Exists(this.IDXpath))
            {
                this.idx = new FileStream(this.IDXpath, FileMode.Open);
            }
            else
            {
                return false;
            }
            this.idxr = new BinaryReader(this.idx, Encoding.Default);
            int length = (int)this.idxr.BaseStream.Length;
            int num2 = (length - 0x10) / 0x100;
            this.Buffer = new byte[length];
            this.idxr.Read(this.Buffer, 0, length);
            int num3 = 0;
            byte[] destinationArray = new byte[0x100];
            while ((num3 < num2) && !flag)
            {
                if (this.Buffer[0x10 + (num3 * 0x100)] != 0x80)
                {
                    Array.Copy(this.Buffer, 0x10 + (num3 * 0x100), destinationArray, 0, 0x100);
                    this.myIDXformat = new IDXformat();
                    this.myIDXformat.ArrayToIDX(destinationArray, this.TXTpath);
                    if ((this.myIDXformat.UpdateTime == UpdateTime) && (this.myIDXformat.Title == Title))
                    {
                        this.Buffer[0x10 + (num3 * 0x100)] = 0x80;
                        flag = true;
                    }
                }
                num3++;
            }
            this.idxr.Close();
            this.idx.Close();
            this.idx = new FileStream(this.IDXpath, FileMode.Create);
            this.idxw = new BinaryWriter(this.idx, Encoding.Default);
            this.idxw.Write(this.Buffer);
            this.idxw.Close();
            this.idx.Close();
            return flag;
        }

        public int GetOffset()
        {
            return this.Offset;
        }

        public bool Init()
        {
            try
            {
                if (File.Exists(this.IDXpath))
                {
                    this.UpdateIDX();
                    this.idx = new FileStream(this.IDXpath, FileMode.Create);
                    this.idxw = new BinaryWriter(this.idx, Encoding.Default);
                }
                else
                {
                    this.idx = new FileStream(this.IDXpath, FileMode.CreateNew);
                    this.idxw = new BinaryWriter(this.idx, Encoding.Default);
                    this.CreateHead();
                }
            }
            catch (Exception exception)
            {
                this.ErrorMsg = exception.Message;
                return false;
            }
            return true;
        }

        public void UpdateIDX()
        {
            this.idx = new FileStream(this.IDXpath, FileMode.Open);
            this.idxr = new BinaryReader(this.idx, Encoding.Default);
            int length = (int)this.idxr.BaseStream.Length;
            this.Offset = (length - 0x10) / 0x100;
            this.Buffer = new byte[length];
            this.idxr.Read(this.Buffer, 0, length);
            short num2 = (short)(BitConverter.ToInt16(this.Buffer, 10) + 1);
            byte[] bytes = new byte[2];
            bytes = BitConverter.GetBytes(num2);
            this.Buffer[10] = bytes[0];
            this.Buffer[11] = bytes[1];
            this.idxr.Close();
            this.idx.Close();
        }
    }
    /// <summary>
    /// 索引带动的信息
    /// </summary>
    public class IDXInfo
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string DateTime;
        /// <summary>
        /// 路径
        /// </summary>
        public string FilePath;
        /// <summary>
        /// 长度
        /// </summary>
        public int Length;
        /// <summary>
        /// 偏移地址
        /// </summary>
        public int Offset;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content;

    }
}
