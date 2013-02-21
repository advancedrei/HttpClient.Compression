using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;


namespace System.Net.Http.Compression
{

    public sealed class GZipHttpContent : HttpContent
    {

        #region Private Members

        private readonly Ionic.Zlib.GZipStream m_stream;

        #endregion

        #region Methods

        public GZipHttpContent(Stream stream)
        {
            m_stream = new Ionic.Zlib.GZipStream(stream, Ionic.Zlib.CompressionMode.Decompress);
        }

        public GZipHttpContent(Stream stream, HttpContentHeaders headers) : this(stream)
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