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
    public class SingleRugbyMatchController : ControllerBase
    {
        private IFetchService service;
        public SingleRugbyMatchController()
        {
            var client = new APIRestClient("http://test-api.statrugby.com/");
            var dataStore = new StoreData();
            var readWrite = new StoreReadWrite(dataStore);

            service = new FetchService(client, dataStore, readWrite);
        }

        

        /// <summary>
        /// Get all match details for teh given team & match across multiple years
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <param name="teamId">Team id</param>
        /// <param name="matchId"> match Id</param>
        /// <returns>List of all matches in season</returns>
        [HttpGet("GetMatchForTeam")]
        public Match GetMatchForTeam(int startYear, int endYear, int teamId, int matchId)
        {
            return service.GetMatchInSeason(startYear, endYear, teamId, matchId);
        }

        /// <summary>
        /// Get match details for the given team & match
        /// </summary>
        /// <param name="startYear">Season year</param>
        /// <param name="teamId">Team Id</param>
        /// <param name="matchId">match Id</param>
        /// <returns>List of all matches in season</returns>
        [HttpGet("GetMatchForTeamSingleYear")]
        public Match GetMatchForTeam(int startYear, int teamId, int matchId)
        {
            return service.GetMatchInSeason(startYear, teamId, matchId);
        }
    }
}
