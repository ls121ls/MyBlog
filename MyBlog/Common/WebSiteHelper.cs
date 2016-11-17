using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Common
{
    public static class WebSiteHelper
    {

        public static string GetIP()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }

        public static string GetCityFromIp(string ip)
        {
            try
            {
                var str = "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                string result = new StreamReader(stream, System.Text.Encoding.UTF8).ReadToEnd();
                string[] temp = result.Split('"');
                if (temp.Length < 10 || String.IsNullOrEmpty(temp[31]))
                {
                    return "内网地址";
                }
                return Unicode(temp[31]);
            }
            catch (Exception e)
            {
                return "地址获取错误";
            }
        }

        public static string Unicode(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                string[] strlist = str.Replace("\\", "").Split('u');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        //将unicode字符转为10进制整数，然后转为char中文字符  
                        outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                    }
                }
                catch (FormatException ex)
                {
                    outStr = ex.Message;
                }
            }
            return outStr;
        }

    }
}
