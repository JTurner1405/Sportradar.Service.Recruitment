using Sportradar.Service.Recruitment.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Application.Interface.Rest
{
    /// <summary>
    /// Interface for Rest API Calls
    /// </summary>
    public interface IAPIRestClient
    {
        /// <summary>
        /// Get all matches played by a team in the given year
        /// </summary>
        /// <param name="startYear">Year to search</param>
        /// <param name="teamId">Team to search for</param>
        /// <returns>List of matches played</returns>
        List<Match> GetAllMatchesForSeason(int startYear, int teamId);

        /// <summary>
        /// Get List of all matches played between given years/season for a team
        /// </summary>
        /// <param name="startYear">start of season year</param>
        /// <param name="endYear">end of season year</param>
        /// <param name="teamId">Team id</param>
        /// <returns>List of matches played</returns>
        List<Match> GetAllMatchesForSeason(int startYear, int endYear, int teamId);
    }
}
