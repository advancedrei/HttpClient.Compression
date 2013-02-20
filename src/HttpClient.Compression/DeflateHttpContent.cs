using System.IO;
using System.Threading.Tasks;

namespace System.Net.Http.Compression
{

    public sealed class DeflateHttpContent : HttpContent
    {

        private readonly Ionic.Zlib.DeflateStream m_stream;

        public DeflateHttpContent(Stream stream)
        {
            m_stream = new Ionic.Zlib.DeflateStream(stream, Ionic.Zlib.CompressionMode.Decompress);
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
    }
}