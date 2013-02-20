using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace System.Net.Http.Compression.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {

            var handler = new CompressedHttpClientHandler();
            var client = new HttpClient(handler);
            var result = await client.GetStringAsync("https://nuget.org/api/v2/Packages()?$filter=tolower(Id)%20eq%20'microsoft.bcl.async'&$orderby=Id&$skip=0&$top=30");
            Assert.IsNotNull(result);
        }
    }
}
