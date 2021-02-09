using NUnit.Framework;
using RestSharp;
using System.Net;

namespace RestSharpExamples.Tests
{
    [TestFixture]
    public class DataDrivenTests
    {
        //poprawny - niepoprawny request
        [TestCase("pl", "80-803", HttpStatusCode.OK, TestName = "Sprawdzanie statusu skrutu miescowosci NL dla kodu pocztowego 7411")]
        [TestCase("pl", "80-999", HttpStatusCode.NotFound, TestName = "Sprawdzanie statusu skrutu miescowosci dla kodu pocztowego 1050")]
        public void StatusCodeTest(string countryCode, string zipCode, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest($"{countryCode}/{zipCode}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }
    }
}
