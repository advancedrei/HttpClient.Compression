using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace System.Net.Http.Compression
{

    public sealed class DeflateHttpContent : HttpContent
    {

        #region Private Members

        private readonly Ionic.Zlib.DeflateStream m_stream;

        #endregion

        #region Methods

        public DeflateHttpContent(Stream stream)
        {
            m_stream = new Ionic.Zlib.DeflateStream(stream, Ionic.Zlib.CompressionMode.Decompress);
        }

        public DeflateHttpContent(Stream stream, HttpContentHeaders headers) : this(stream)
        {
            var contentType = typeof(HttpContent);
            var fieldInfo = contentType.GetField("headers", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(this, headers);
            }
        }

        protected override Task SerializeToStreamAsync(System.IO.Stream stream, System.Net.TransportContext context)
        {
            return m_stream.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = 0;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            m_stream.Dispose();
            base.Dispose(disposing);
        }

        #endregion

    }

}