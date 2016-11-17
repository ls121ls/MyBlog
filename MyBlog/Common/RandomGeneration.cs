using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RandomGeneration
    {
        /// <summary>
        /// 此函数为生成指定数目的汉字
        /// </summary>
        /// <param name="charLen">汉字数目</param>
        /// <returns>所有汉字</returns>
        public static string[] CreateGBChar(int charLen)
        {
            int area, code;//汉字由区位和码位组成(都为0-94,其中区位16-55为一级汉字区,56-87为二级汉字区,1-9为特殊字符区)
            string[] charArrary = new string[charLen];
            Random rand = new Random();
            for (int i = 0; i < charLen; i++)
            {
                area = rand.Next(16, 88);
                if (area == 55)//第55区只有89个字符
                {
                    code = rand.Next(1, 90);
                }
                else
                {
                    code = rand.Next(1, 94);
                }
                charArrary[i] = Encoding.GetEncoding("GB2312").GetString(new byte[] { Convert.ToByte(area + 160), Convert.ToByte(code + 160) });
            }
            return charArrary;
        }
    }
}
