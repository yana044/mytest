using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System.Linq;
using Test_API_Json.Models;
using Test_API_Json.Utils;

namespace Test_API_Json
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            AqualityServices.Logger.Info("Step 1: Send GET Request to get all posts");
            ResponseModel<PostModel> allposts = APIAppRequest<PostModel>.GetData();
            int statuscodeposts = allposts.StatusCode;
            int expStatusforposts = (int)Status—ode.Step1;
            Assert.IsTrue(statuscodeposts == expStatusforposts, $"Status code is NOT {expStatusforposts}");

            string? contentType = allposts.TypeResponseBody;
            Assert.That(contentType.Contains("json"));

            var expectedsort = allposts.Data.OrderBy(x => x.Id);
            Assert.AreEqual(expectedsort, allposts.Data);
            AqualityServices.Logger.Info($"Step 2: Send GET request to get post with id=99");
            ResponseModel<PostModel> post99resp = APIAppRequest<PostModel>.GetData("99");
            int statuscodepost99 = post99resp.StatusCode;
            int expStatusforpost99 = (int)Status—ode.Step2;
            Assert.IsTrue(statuscodepost99 == expStatusforpost99, $"Status code is NOT {expStatusforpost99}");

            PostModel expectedpost99 = TestDataUtils<PostModel>.GetTestData("testDataPost99.json");
            Assert.AreEqual(expectedpost99, post99resp.Data.First());
            Assert.IsTrue(post99resp.Data[0].Equals(expectedpost99));
            AqualityServices.Logger.Info($"Step 3: Send GET request to get post with id=150");
            ResponseModel<PostModel> post150resp = APIAppRequest<PostModel>.GetData("150");
            Assert.AreEqual((int)Status—ode.Step3, post150resp.StatusCode, $"Status code is NOT {(int)Status—ode.Step3}");

            Assert.True(post150resp.Data.First().IsResponseBodyEmpty(), "Response body is NOT empty");
            AqualityServices.Logger.Info("Step 4: Send POST request");
            PostModel newPost = TestDataUtils<PostModel>.GetTestData("testDataNewPost.json");
            ResponseModel<PostModel> newPostresp = APIAppRequest<PostModel>.PostData(newPost);
            int expStatusfornewPost = (int)Status—ode.Step4;
            Assert.AreEqual(expStatusfornewPost, newPostresp.StatusCode, $"Status code is NOT {expStatusfornewPost}");
            Assert.IsTrue(newPostresp.Data.First().Equals(newPost), "Post information is NOT correct or id is NOT present in response");
            AqualityServices.Logger.Info("Step 5: Send GET request to get users");
            ResponseModel<UserModel> allusers = APIAppRequest<UserModel>.GetData("","/users/");
            int statuscodeusers = allusers.StatusCode;
            int expStatusforusers = (int)Status—ode.Step5;
            Assert.IsTrue(statuscodeusers == expStatusforusers, $"Status code is NOT {expStatusforusers}");
            Assert.That(allusers.TypeResponseBody.Contains("json"));
            AqualityServices.Logger.Info($"Step 6: Send GET request to get user with id=5");
            UserModel expexteduser5 = TestDataUtils<UserModel>.GetTestData("testDataUser5.json");
            UserModel user5fromlist = allusers.Data.Find(p => p.Id == 5);
            Assert.That(expexteduser5.Equals(user5fromlist), "User (id=5) data NOT equals to test data");

            ResponseModel<UserModel> user5 = APIAppRequest<UserModel>.GetData("5", "/users/");
            int statuscodeuser5 = user5.StatusCode;
            int expStatusforuser5 = (int)Status—ode.Step6;
            Assert.IsTrue(statuscodeuser5 == expStatusforuser5, $"Status code is NOT {expStatusforuser5}");
            Assert.That(user5fromlist.Equals(user5.Data.First()), "User data don't matches with user data in the previous step");
        }
        enum Status—ode
        {
            Step1 = 200,
            Step2 = 200,
            Step3 = 404,
            Step4 = 201,
            Step5 = 200,
            Step6 = 200
        }
    }
}