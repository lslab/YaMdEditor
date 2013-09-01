using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace YaMdEditor
{
    /// <summary>
    /// 用于取得一个文本文件的编码方式(Encoding)。
    /// </summary>
    public class TextFileEncodingDetector
    {
        public TextFileEncodingDetector()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 取得一个文本文件的编码方式。如果无法在文件头部找到有效的前导符，Encoding.Default将被返回。
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string fileName)
        {
            return GetEncoding(fileName, Encoding.Default);
        }
        /// <summary>
        /// 取得一个文本文件流的编码方式。
        /// </summary>
        /// <param name="stream">文本文件流。</param>
        /// <returns></returns>
        private static Encoding GetEncoding(FileStream stream)
        {
            Encoding enc = GetEncodingWithBOM(stream);
            if (enc == null)
                enc = GetEncodingWithoutBOM(stream);
            return enc == null ? Encoding.Default : enc;
        }
        /// <summary>
        /// 取得一个文本文件的编码方式。
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>
        /// <returns></returns>
        private static Encoding GetEncoding(string fileName, Encoding defaultEncoding)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                Encoding enc = GetEncodingWithBOM(fs);
                if (enc == null)
                    enc = GetEncodingWithoutBOM(fs);
                return enc == null ? Encoding.Default : enc;
            }
        }
        /// <summary>
        /// 取得一个文本文件流的编码方式。
        /// </summary>
        /// <param name="stream">文本文件流。</param>
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>
        /// Representations of byte order marks by encoding
        /// https://en.wikipedia.org/wiki/Byte_order_mark
        /// Encoding	Representation (hexadecimal)
        /// UTF-8       	 EF BB BF
        /// UTF-16 (BE)	     FE FF
        /// UTF-16 (LE)	     FF FE
        /// UTF-32 (BE)	     00 00 FE FF
        /// UTF-32 (LE)	     FF FE 00 00
        /// UTF-7            2B 2F 76 38
        ///                  2B 2F 76 39
        ///                  2B 2F 76 2B
        ///                  2B 2F 76 2F
        ///                  2B 2F 76 38 2D
        /// UTF-1            F7 64 4C
        /// UTF-EBCDIC       DD 73 66 73
        /// SCSU             0E FE FF
        /// BOCU-1           FB EE 28
        /// GB-18030         84 31 95 33

        /// <returns></returns>
        private static Encoding GetEncodingWithBOM(FileStream stream)
        {
            Encoding targetEncoding = null;
            if (stream != null && stream.Length >= 2)
            {
                //保存文件流的前4个字节
                byte byte1 = 0;
                byte byte2 = 0;
                byte byte3 = 0;
                byte byte4 = 0;
                //保存当前Seek位置
                long origPos = stream.Seek(0, SeekOrigin.Begin);
                stream.Seek(0, SeekOrigin.Begin);

                int nByte = stream.ReadByte();
                byte1 = Convert.ToByte(nByte);
                byte2 = Convert.ToByte(stream.ReadByte());
                if (stream.Length >= 3)
                {
                    byte3 = Convert.ToByte(stream.ReadByte());
                }
                if (stream.Length >= 4)
                {
                    byte4 = Convert.ToByte(stream.ReadByte());
                }
                //根据文件流的前4个字节判断Encoding
                //Unicode {0xFF, 0xFE};
                //BE-Unicode {0xFE, 0xFF};
                //UTF8 = {0xEF, 0xBB, 0xBF};
                if (byte1 == 0xEF && byte2 == 0xBB && byte3 == 0xBF)//UTF8
                {
                    targetEncoding = Encoding.UTF8;
                }
                else if (byte1 == 0xFF && byte2 == 0xFE && byte3 != 0x0)//UTF16LE
                {
                    targetEncoding = Encoding.Unicode;
                }
                else if (byte1 == 0xFF && byte2 == 0xFE && byte3 == 0x0 && byte4 == 0x0) //UTF32LE
                {
                    targetEncoding = Encoding.UTF32;
                }
                else if (byte1 == 0xFE && byte2 == 0xFF)    //UTF16BE
                {
                    targetEncoding = Encoding.BigEndianUnicode;
                }
                else if (byte1 == 0x0 && byte2 == 0x0 && byte3 == 0xFE && byte4 == 0xFF)//UTF32BE
                {
                    //targetEncoding = Encoding.GetEncoding("UTF-32BE");
                    targetEncoding = Encoding.GetEncoding(12001);
                }
                else if (byte1 == 0x2B && byte2 == 0x2F && byte3 == 0x76)  //utf-7
                {
                    targetEncoding = Encoding.UTF7;
                }
                else if (byte1 == 0x84 && byte2 == 0x31 && byte3 == 0x95 && byte4 == 0x33)
                {
                    targetEncoding = Encoding.GetEncoding("GB18030");
                }
                //GB-18030         84 31 95 33
                //恢复Seek位置 
                stream.Seek(origPos, SeekOrigin.Begin);
            }
            return targetEncoding;
        }

        /// <summary>
        /// 通过给定的文件流，判断文件的编码类型
        /// </summary>
        /// <param name="fs">文件流</param>
        /// <returns>文件的编码类型</returns>
        private static System.Text.Encoding GetEncodingWithoutBOM(FileStream fs)
        {

            Encoding reVal = null;

            BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);

            if (IsUTF8Bytes(ss))
            {
                reVal = Encoding.UTF8;
            }
            else if(UTF8_probability(ss) > 80)
            {
                reVal = Encoding.UTF8;
            }
            
            r.Close();
            return reVal;
        }

        /// <summary>
        /// 判断是否是不带 BOM 的 UTF8 格式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式!");
            }
            return true;
        }

        static int UTF8_probability(byte[] rawtext)
        {
            int score = 0;
            int i, rawtextlen = 0;
            int goodbytes = 0, asciibytes = 0;

            // Maybe also use UTF8 Byte Order Mark:  EF BB BF

            // Check to see if characters fit into acceptable ranges
            rawtextlen = rawtext.Length;
            for (i = 0; i < rawtextlen; i++)
            {
                if ((rawtext[i] & (byte)0x7F) == rawtext[i])
                {  // One byte
                    asciibytes++;
                    // Ignore ASCII, can throw off count
                }
                else
                {
                    int m_rawInt0 = Convert.ToInt16(rawtext[i]);
                    int m_rawInt1 = Convert.ToInt16(rawtext[i + 1]);
                    int m_rawInt2 = Convert.ToInt16(rawtext[i + 2]);

                    if (256 - 64 <= m_rawInt0 && m_rawInt0 <= 256 - 33 && // Two bytes
                     i + 1 < rawtextlen &&
                     256 - 128 <= m_rawInt1 && m_rawInt1 <= 256 - 65)
                    {
                        goodbytes += 2;
                        i++;
                    }
                    else if (256 - 32 <= m_rawInt0 && m_rawInt0 <= 256 - 17 && // Three bytes
                     i + 2 < rawtextlen &&
                     256 - 128 <= m_rawInt1 && m_rawInt1 <= 256 - 65 &&
                     256 - 128 <= m_rawInt2 && m_rawInt2 <= 256 - 65)
                    {
                        goodbytes += 3;
                        i += 2;
                    }
                }
            }

            if (asciibytes == rawtextlen) { return 0; }

            score = (int)(100 * ((float)goodbytes / (float)(rawtextlen - asciibytes)));

            // If not above 98, reduce to zero to prevent coincidental matches
            // Allows for some (few) bad formed sequences
            if (score > 98)
            {
                return score;
            }
            else if (score > 95 && goodbytes > 30)
            {
                return score;
            }
            else
            {
                return 0;
            }

        }

    }
}
