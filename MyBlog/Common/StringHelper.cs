using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class StringHelper
    {
        public static string ShortString(this string title,int count,bool isNoHtml=true)
        {
            
            if (String.IsNullOrEmpty(title))
            {
                return "无标题";
            }
            if (isNoHtml)
            {
                title = RemoveHtmlTags(title);
            }
            if (title.Length > count)
            {
                return title.Substring(0, count)+"...";
            }
            return title;
        }



        public static string RemoveHtmlTags(string htmlStream)
        {
            if (htmlStream == null)
            {
                throw new Exception("Your input html stream is null!");
                return null;
            }
            /*
             * 最好把所有的特殊HTML标记都找出来，然后把与其相对应的Unicode字符一起影射到Hash表内，最后一起都替换掉
             */
            //先单独测试,成功后,再把所有模式合并
            //注:这两个必须单独处理
            //去掉嵌套了HTML标记的JavaScript:(<script)[\\s\\S]*(</script>)
            //去掉css标记:(<style)[\\s\\S]*(</style>)
            //去掉css标记:\\..*\\{[\\s\\S]*\\}
            htmlStream = Regex.Replace(htmlStream, "(<script)[\\s\\S]*?(</script>)|(<style)[\\s\\S]*?(</style>)", " ", RegexOptions.IgnoreCase);
            //htmlStream = RemoveTag(htmlStream, "script");
            //htmlStream = RemoveTag(htmlStream, "style");
            //去掉普通HTML标记:<[^>]+>
            //替换空格:&nbsp;|&amp;|&shy;|&#160;|&#173;
            htmlStream = Regex.Replace(htmlStream, "<[^>]+>|&nbsp;|&amp;|&shy;|&#160;|&#173;|&bull;|&lt;|&gt;", " ", RegexOptions.IgnoreCase);
            //htmlStream = RemoveTag(htmlStream);
            //替换左尖括号
            //htmlStream = Regex.Replace(htmlStream, "&lt;", "<");
            //替换右尖括号
            //htmlStream = Regex.Replace(htmlStream, "&gt;", ">");
            //替换空行
            //htmlStream = Regex.Replace(htmlStream, "[\n|\r|\t]", " ");//[\n|\r][\t*| *]*[\n|\r]
            htmlStream = Regex.Replace(htmlStream, "(\r\n[\r|\n|\t| ]*\r\n)|(\n[\r|\n|\t| ]*\n)", "\r\n");
            htmlStream = Regex.Replace(htmlStream, "[\t| ]{1,}", " ");
            return htmlStream.Trim();
        }
    }
}
