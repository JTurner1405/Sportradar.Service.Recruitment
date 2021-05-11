using Sportradar.Service.Recruitment.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Application.Interface.BusinessLogic
{
    /// <summary>
    /// Interface for getting list of matches from either store or API
    /// </summary>
    public interface IFetchService
    {
        /// <summary>
        /// Get list of matches from either store or API of exists
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <param name="teamId">team id</param>
        /// <returns>List of matches</returns>
        List<Match> GetListOfMatchsFromEitherStoreOrAPI(int startYear, int teamId);

        /// <summary>
        /// Get list of matches from either store or API if exists
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <param name="teamId">Team id</param>
        /// <returns>List of matches</returns>
        List<Match> GetListOfMatchsFromEitherStoreOrAPI(int startYear, int endYear, int teamId);

        /// <summary>
        /// Get Match that appears in Season
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <param name="teamId">team id</param>
        /// <param name="matchId">Match Id</param>
        /// <returns>Match requested</returns>
        Match GetMatchInSeason(int startYear, int teamId, int matchId);

        /// <summary>
        /// Get match taht appears in a season across multiple years
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <param name="teamId">Team id</param>
        /// <param name="matchId">Match Id</param>
        /// <returns>matche requested</returns>
        Match GetMatchInSeason(int startYear, int endYear, int teamId, int matchId);
    }
}
