using NUnit.Framework;
using Sportradar.Service.Recruitment.Application.Class.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Tests.Unit.Application.Rest
{
    public class APIRestClientTest
    {

        [Test]
        public void GetAllMatchForSeasonTest()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");

            var result = client.GetAllMatchesForSeason(2019, 2020, 103969);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(22, result.Count());
        }

        [Test]
        public void GetAllMatchForSeasonEndyearLessThanStartTest()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");

            var result = client.GetAllMatchesForSeason(2020, 2019, 103969);

            Assert.IsNull(result);
        }

        [Test]
        public void GetAllMatchesForSeasonYearInvalidTest()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");

            var result = client.GetAllMatchesForSeason(1, 2020, 103969);

            Assert.IsNull(result);


            var result1 = client.GetAllMatchesForSeason(2019, 1, 103969);

            Assert.IsNull(result1);
        }

        [Test]
        public void GetAllMatchesForSeasonInvalidTeamIdTest()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");

            var result = client.GetAllMatchesForSeason(2019, 2020, 0);

            Assert.IsNull(result);
        }

        [Test]
        public void GetAllMatchesForSeasonNonExistantTeamTest()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");

            var result = client.GetAllMatchesForSeason(2019, 2020, 5);

            Assert.IsNull(result);
        }

    }
}
