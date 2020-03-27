using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using Assert = NUnit.Framework.Assert;
using System.Net;
using PetStoreTests.Models;
using Newtonsoft.Json;
using PetStoreTests.Entities;

namespace PetStoreTests
{
    [TestClass]
    public class PetShopTests
    {
        RestClient petStoreClient = new RestClient("https://petstore.swagger.io/v2/");

        [TestMethod]
        public void getPetPropertiesTest()
        {
            RestRequest request = new RestRequest("pet/5", Method.GET);
            //request.AddJsonBody(new PetOrder(21434235, 5, 1, DateTime.Now, "complete", true));
           
            IRestResponse response = petStoreClient.Execute(request);
            Pet responsePet = JsonConvert.DeserializeObject<Pet>(response.Content);
            

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.NotNull(responsePet);
            Assert.AreEqual(responsePet.id, 5);
            Assert.AreEqual(responsePet.name, "doggie");
            Assert.IsTrue(responsePet.photoUrls[0].Contains("https://"));
            Assert.IsTrue(responsePet.photoUrls[0].EndsWith(".jpg"));
            Assert.AreEqual(responsePet.status, "sold");
        }

        [TestMethod]
        public void updatePetPropertiesTest()
        {
            RestRequest postUserRequest = new RestRequest("user", Method.POST);
            postUserRequest.AddJsonBody(new User(123,"Godek", "Maerten", "Icki", "aa@aa.xca", "abca123", "123123123", 0));
            RestRequest deleteUserRequest = new RestRequest("user/Godek", Method.DELETE);
            RestRequest getUserRequest = new RestRequest("user/Godek", Method.GET);

            IRestResponse postPetResponse = petStoreClient.Execute(postUserRequest);
            IRestResponse deletePetResponse = petStoreClient.Execute(deleteUserRequest);
            IRestResponse getUserResponse = petStoreClient.Execute(getUserRequest);

            Assert.That(deletePetResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(getUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}