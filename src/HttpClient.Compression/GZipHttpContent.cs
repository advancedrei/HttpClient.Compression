using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdvancedREI.Net.Http.Compression
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
            //RWM: Changed based on recommendation of @davkean: http://www.twitter.com/davkean/status/304977154515533824
            foreach (var pair in headers)
            {
                Headers.TryAddWithoutValidation(pair.Key, pair.Value);
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