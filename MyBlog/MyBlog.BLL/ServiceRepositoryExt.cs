
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.BLL
{
    public partial class ServiceRepository
    {
	
        private BlogBLL _BlogBLL;
        public BlogBLL BlogBLL
        {
            get
            {
                if (_BlogBLL == null)
                {
                    _BlogBLL = new BlogBLL();
                }
                return _BlogBLL;
            }
            set { _BlogBLL = value; }
        }

        private BlogTypeBLL _BlogTypeBLL;
        public BlogTypeBLL BlogTypeBLL
        {
            get
            {
                if (_BlogTypeBLL == null)
                {
                    _BlogTypeBLL = new BlogTypeBLL();
                }
                return _BlogTypeBLL;
            }
            set { _BlogTypeBLL = value; }
        }

        private PictureBLL _PictureBLL;
        public PictureBLL PictureBLL
        {
            get
            {
                if (_PictureBLL == null)
                {
                    _PictureBLL = new PictureBLL();
                }
                return _PictureBLL;
            }
            set { _PictureBLL = value; }
        }

        private AccountBLL _AccountBLL;
        public AccountBLL AccountBLL
        {
            get
            {
                if (_AccountBLL == null)
                {
                    _AccountBLL = new AccountBLL();
                }
                return _AccountBLL;
            }
            set { _AccountBLL = value; }
        }

        private QQModelBLL _QQModelBLL;
        public QQModelBLL QQModelBLL
        {
            get
            {
                if (_QQModelBLL == null)
                {
                    _QQModelBLL = new QQModelBLL();
                }
                return _QQModelBLL;
            }
            set { _QQModelBLL = value; }
        }

        private MessageBLL _MessageBLL;
        public MessageBLL MessageBLL
        {
            get
            {
                if (_MessageBLL == null)
                {
                    _MessageBLL = new MessageBLL();
                }
                return _MessageBLL;
            }
            set { _MessageBLL = value; }
        }

        private ImageBLL _ImageBLL;
        public ImageBLL ImageBLL
        {
            get
            {
                if (_ImageBLL == null)
                {
                    _ImageBLL = new ImageBLL();
                }
                return _ImageBLL;
            }
            set { _ImageBLL = value; }
        }

        private WebSiteBLL _WebSiteBLL;
        public WebSiteBLL WebSiteBLL
        {
            get
            {
                if (_WebSiteBLL == null)
                {
                    _WebSiteBLL = new WebSiteBLL();
                }
                return _WebSiteBLL;
            }
            set { _WebSiteBLL = value; }
        }

        private FolderBLL _FolderBLL;
        public FolderBLL FolderBLL
        {
            get
            {
                if (_FolderBLL == null)
                {
                    _FolderBLL = new FolderBLL();
                }
                return _FolderBLL;
            }
            set { _FolderBLL = value; }
        }



	}
}