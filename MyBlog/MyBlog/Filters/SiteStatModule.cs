using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Filters
{
    public class SiteStatModule : IHttpModule
    {
        private const string Html_CONTENT_TYPE = "text/html";

        #region IHttpModule Members

        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.ReleaseRequestState += OnReleaseRequestState;
        }

        #endregion

        public void OnReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpResponse response = app.Response;
            string contentType = response.ContentType.ToLowerInvariant();
            if (response.StatusCode == 200 && !string.IsNullOrEmpty(contentType) && contentType.Contains(Html_CONTENT_TYPE))
            {
                response.Filter = new SiteStatResponseFilter(response.Filter);
            }
        }
    }
}