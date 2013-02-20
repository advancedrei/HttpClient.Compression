using System.IO;
using System.Threading.Tasks;


namespace System.Net.Http.Compression
{

    public sealed class GZipHttpContent : HttpContent
    {

        private readonly Ionic.Zlib.GZipStream m_stream;


        public GZipHttpContent(Stream stream)
        {
            m_stream = new Ionic.Zlib.GZipStream(stream, Ionic.Zlib.CompressionMode.Decompress, true);
        }

        protected override Task SerializeToStreamAsync(System.IO.Stream stream, System.Net.TransportContext context)
        {
            return m_stream.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            //length = m_stream.Length;
            //return true;
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