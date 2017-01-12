using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MyBlog.Filters
{
    public class SiteStatResponseFilter : AbstractHttpResponseFilter
    {
        private static readonly string END_HTML_TAG_NAME = "</body>";

        private static readonly string SCRIPT_PATH = "MyBlog.Filters.site-tongji.htm";

        private static readonly string SITE_STAT_SCRIPT_CONTENT = "";

        static SiteStatResponseFilter()
        {
            Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(SCRIPT_PATH);
            if (stream == null)
            {
                throw new FileNotFoundException(string.Format("The file \"{0}\" not found in assembly", SCRIPT_PATH));
            }
            using (StreamReader reader = new StreamReader(stream))
            {
                SITE_STAT_SCRIPT_CONTENT = reader.ReadToEnd();
                reader.Close();
            }
        }

        public SiteStatResponseFilter(Stream responseStream)
            : base(responseStream)
        {

        }


        protected override void WriteCore(byte[] buffer, int offset, int count)
        {
            string strBuffer = Encoding.UTF8.GetString(buffer, offset, count);
            strBuffer = AppendSiteStatScript(strBuffer);
            byte[] data = Encoding.UTF8.GetBytes(strBuffer);
            _responseStream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// 附加站点统计脚本
        /// </summary>
        /// <param name="strBuffer"></param>
        /// <returns></returns>
        protected virtual string AppendSiteStatScript(string strBuffer)
        {
            if (string.IsNullOrEmpty(strBuffer))
            {
                return strBuffer;
            }
            int endHtmlTagIndex = strBuffer.IndexOf(END_HTML_TAG_NAME, StringComparison.InvariantCultureIgnoreCase);
            if (endHtmlTagIndex <= 0)
            {
                return strBuffer;
            }
            return strBuffer.Insert(endHtmlTagIndex, SITE_STAT_SCRIPT_CONTENT);
        }
    }
}