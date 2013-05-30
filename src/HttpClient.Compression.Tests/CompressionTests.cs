using Ionic.Zlib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvancedREI.Net.Http.Compression.Tests
{

    [TestClass]
    public class CompressionTests
    {

        private const string NuGetString =
            "https://nuget.org/api/v2/Packages()?$filter=tolower(Id)%20eq%20'microsoft.bcl.async'&$orderby=Id&$skip=0&$top=30";

        [TestMethod]
        public async Task GetStringAsync()
        {

            var handler = new CompressedHttpClientHandler();
            var client = new HttpClient(handler);
            var result = await client.GetStringAsync(NuGetString);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task SendAsyncWithHeaders()
        {
            var handler = new CompressedHttpClientHandler();
            var client = new HttpClient(handler);
            var message = new HttpRequestMessage(HttpMethod.Get, new Uri(NuGetString, UriKind.RelativeOrAbsolute));
            var result = await client.SendAsync(message);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsNotNull(result.Content.Headers);
        }

        [TestMethod]
        public async Task GetStreamStreams()
        {
            var handler = new CompressedHttpClientHandler();
            var client = new HttpClient(handler);
            var result = await client.GetStreamAsync(NuGetString);

            Assert.IsInstanceOfType(result, typeof(GZipStream));
        }
    }
}