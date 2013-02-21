using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http.Compression
{

    public class CompressedHttpClientHandler : HttpClientHandler
    {

        #region Properties

        public override bool SupportsAutomaticDecompression
        {
            get { return true; }
        }

        #endregion

        #region Methods

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            var response = await base.SendAsync(request, cancellationToken);

            if (response.Content.Headers.ContentEncoding.Contains("deflate"))
            {
                var content = new DeflateHttpContent(await response.Content.ReadAsStreamAsync(), response.Content.Headers);
                response.Content = content;
            }
            else if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                var content = new GZipHttpContent(await response.Content.ReadAsStreamAsync(), response.Content.Headers);
                response.Content = content;
            }
            return response;
        }


        #endregion

    }
}