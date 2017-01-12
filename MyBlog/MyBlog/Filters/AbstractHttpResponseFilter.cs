using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MyBlog.Filters
{
    public abstract class AbstractHttpResponseFilter : Stream
    {
        protected readonly Stream _responseStream;

        protected long _position;

        protected AbstractHttpResponseFilter(Stream responseStream)
        {
            _responseStream = responseStream;
        }

        public override bool CanRead { get { return true; } }

        public override bool CanSeek { get { return true; } }

        public override bool CanWrite { get { return true; } }

        public override long Length { get { return 0; } }

        public override long Position { get { return _position; } set { _position = value; } }

        public override void Write(byte[] buffer, int offset, int count)
        {
            WriteCore(buffer, offset, count);
        }

        protected abstract void WriteCore(byte[] buffer, int offset, int count);

        public override void Close()
        {
            _responseStream.Close();
        }

        public override void Flush()
        {
            _responseStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _responseStream.Seek(offset, origin);
        }

        public override void SetLength(long length)
        {
            _responseStream.SetLength(length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _responseStream.Read(buffer, offset, count);
        }
    }
}