using Sportradar.Service.Recruitment.Application.Class.Rest;
using Sportradar.Service.Recruitment.Application.Interface.BusinessLogic;
using Sportradar.Service.Recruitment.Application.Interface.Rest;
using Sportradar.Service.Recruitment.Objects;
using Sportradar.Service.Recruitment.Respository.Class;
using Sportradar.Service.Recruitment.Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Application.Class.BusinessLogic
{
    /// <summary>
    /// Get List of matches from either api or store
    /// </summary>
    public class FetchService : IFetchService
    {
        private IAPIRestClient restClient;
        private IStoreData storeData;
        private IStoreReadWrite readWrite;
        public FetchService()
        {
            restClient = new APIRestClient();
            storeData = new StoreData();
            readWrite = new StoreReadWrite(storeData);
        }

        public FetchService(IAPIRestClient restClient, IStoreData storetData, IStoreReadWrite readWrite)
        {
            this.restClient = restClient;
            this.storeData = storetData;
            this.readWrite = readWrite;
        }

        /// <summary>
        /// Get list of matches from either store or API of exists
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <param name="teamId">team id</param>
        /// <returns>List of matches</returns>
        public List<Match> GetListOfMatchsFromEitherStoreOrAPI(int startYear, int teamId)
        {
            List<Match> matches = new();
            if (storeData.CheckStoreAlreadyExists(startYear))
            {
                matches = readWrite.ReadFromStore(startYear);
            }

            if (matches.Any(x => x.TeamLogoFileName.Contains(teamId.ToString())))
            {
                return matches.Where(x => x.TeamLogoFileName.Contains(teamId.ToString())).ToList();
            }
            else
            {
                var apiResult = restClient.GetAllMatchesForSeason(startYear, teamId);
                matches.AddRange(apiResult.Where(x => !matches.Any(y => y.MatchId == x.MatchId)));
                readWrite.WriteToStore(matches, startYear);
                return matches.Where(x => x.TeamLogoFileName.Contains(teamId.ToString())).ToList();
            }
        }

        /// <summary>
        /// Get list of matches from either store or API if exists
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <param name="teamId">Team id</param>
        /// <returns>List of matches</returns>
        public List<Match> GetListOfMatchsFromEitherStoreOrAPI(int startYear, int endYear, int teamId)
        {
            List<Match> matches = new();
            if (storeData.CheckStoreAlreadyExists(startYear, endYear))
            {
                matches = readWrite.ReadFromStore(startYear, endYear);
            }

            if (matches.Any(x => x.TeamLogoFileName.Contains(teamId.ToString())))
            {
                return matches.Where(x => x.TeamLogoFileName.Contains(teamId.ToString())).ToList();
            }
            else
            {
                var apiResult = restClient.GetAllMatchesForSeason(startYear, endYear, teamId);
                matches.AddRange(apiResult.Where(x => !matches.Any(y => y.MatchId == x.MatchId)));
                readWrite.WriteToStore(matches, startYear, endYear);
                return matches.Where(x => x.TeamLogoFileName.Contains(teamId.ToString())).ToList();
            }
        }

        /// <summary>
        /// Get Match that appears in Season
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <param name="teamId">team id</param>
        /// <param name="matchId"> match Id</param>
        /// <returns>Match requested</returns>
        public Match GetMatchInSeason(int startYear, int teamId, int matchId)
        {
            List<Match> matches = new();
            if (storeData.CheckStoreAlreadyExists(startYear))
            {
                matches = readWrite.ReadFromStore(startYear);
            }

            if (matches.Any(x => x.TeamLogoFileName.Contains(teamId.ToString()) && x.MatchId == matchId))
            {
                return matches.FirstOrDefault(x => x.TeamLogoFileName.Contains(teamId.ToString()) && x.MatchId == matchId);
            }
            else
            {
                var apiResult = restClient.GetAllMatchesForSeason(startYear, teamId);
                matches.AddRange(apiResult.Where(x => !matches.Any(y => y.MatchId == x.MatchId)));
                readWrite.WriteToStore(matches, startYear);
                return matches.FirstOrDefault(x => x.TeamLogoFileName.Contains(teamId.ToString()) && x.MatchId == matchId);
            }
        }

        /// <summary>
        /// Get match taht appears in a season across multiple years
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <param name="teamId">Team id</param>
        /// <param name="matchId">Match Id</param>
        /// <returns>matche requested</returns>
        public Match GetMatchInSeason(int startYear, int endYear, int teamId, int matchId)
        {
            List<Match> matches = new();
            if (storeData.CheckStoreAlreadyExists(startYear, endYear))
            {
                matches = readWrite.ReadFromStore(startYear, endYear);
            }

            if (matches.Any(x => x.TeamLogoFileName.Contains(teamId.ToString()) && x.MatchId == matchId))
            {
                return matches.FirstOrDefault(x => x.TeamLogoFileName.Contains(teamId.ToString()) && x.MatchId == matchId);
            }
            else
            {
                var apiResult = restClient.GetAllMatchesForSeason(startYear, endYear, teamId);
                matches.AddRange(apiResult.Where(x => !matches.Any(y => y.MatchId == x.MatchId)));
                readWrite.WriteToStore(matches, startYear, endYear);
                return matches.FirstOrDefault(x => x.TeamLogoFileName.Contains(teamId.ToString()) && x.MatchId == matchId);
            }
        }
    }
}
