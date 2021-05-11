using Microsoft.AspNetCore.Mvc;
using Sportradar.Service.Recruitment.Application.Class.BusinessLogic;
using Sportradar.Service.Recruitment.Application.Class.Rest;
using Sportradar.Service.Recruitment.Application.Interface.BusinessLogic;
using Sportradar.Service.Recruitment.Objects;
using Sportradar.Service.Recruitment.Respository.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sportradar.Service.Recruitment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllRugbyMatchController : ControllerBase
    {
        private IFetchService service;
        public AllRugbyMatchController()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");
            var dataStore = new StoreData();
            var readWrite = new StoreReadWrite(dataStore);

            service = new FetchService(client, dataStore, readWrite);
        }

        /// <summary>
        /// Get all match details for teh given team across multiple years
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <param name="teamId">Team id</param>
        /// <returns>List of all matches in season</returns>
        [HttpGet("GetAllMatchesForTeamForSeason")]
        public IEnumerable<Match> GetAllMatchesForTeam(int startYear, int endYear, int teamId)
        {
            var v1 = service.GetListOfMatchsFromEitherStoreOrAPI(startYear, endYear, teamId);
            return v1;
        }

        /// <summary>
        /// Get all match details for the given team
        /// </summary>
        /// <param name="startYear">Season year</param>
        /// <param name="teamId">Team Id</param>
        /// <returns>List of all matches in season</returns>
        [HttpGet("GetAllMatchesForTeamForSingleYear")]
        public IEnumerable<Match> GetAllMatchesForTeam(int startYear, int teamId)
        {
            return service.GetListOfMatchsFromEitherStoreOrAPI(startYear, teamId);
        }

    }
}
