using NUnit.Framework;
using RestSharp;
using System.Net;

namespace RestSharpExamples.Tests
{
    [TestFixture]
    public class BasicTests
    {
        //zawartość poprawnego requestu - czy istnieje czy format jonson
        [Test]
        public void StatusCodeTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("pl/80-803", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        //zwartość contentu czy odpowiedz API to  application/json
        [Test]
        public void ContentTypeTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("pl/80-803", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }
    }
}
