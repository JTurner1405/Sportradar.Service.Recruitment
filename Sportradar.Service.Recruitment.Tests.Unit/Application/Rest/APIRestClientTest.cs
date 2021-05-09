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
        public void Test()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");

            var result = client.GetAllMatchesForSeason(2019, 2020, 103969);

            Assert.IsNotNull(result);
        }
    }
}
