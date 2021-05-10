using RestSharp;
using RestSharp.Serialization.Xml;
using RestSharp.Serializers.SystemTextJson;
using Sportradar.Service.Recruitment.Application.Interface.Rest;
using Sportradar.Service.Recruitment.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Application.Class.Rest
{
    public class APIRestClient : IAPIRestClient
    {
        private RestClient client;
        private string authToken = "7C0F9D36-15A6-4F7B-98CF-301AB2A7DBEF";

        public APIRestClient()
        {
            client = new RestClient();
            client.UseSystemTextJson();
        }

        public APIRestClient(string url)
        {
            client = new RestClient(url);
            client.UseSystemTextJson();
        }

        /// <summary>
        /// Get all matches played by a team in the given year
        /// </summary>
        /// <param name="startYear">Year to search</param>
        /// <param name="teamId">Team to search for</param>
        /// <returns>List of matches played</returns>
        public List<Match> GetAllMatchesForSeason(int startYear, int teamId)
        {
            if(teamId == 0 || startYear < 2000 || startYear > DateTime.Now.Year)
            {
                return null;
            }
            try
            {
                var response = client.Get<List<Match>>(BuildRestRequest(teamId, startYear.ToString()));
                return response.Data;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }


            return null;
        }

        /// <summary>
        /// Get List of all matches played between given years/season for a team
        /// </summary>
        /// <param name="startYear">start of season year</param>
        /// <param name="endYear">end of season year</param>
        /// <param name="teamId">Team id</param>
        /// <returns>List of matches played</returns>
        public List<Match> GetAllMatchesForSeason(int startYear, int endYear, int teamId)
        {
            if (teamId == 0 || endYear < 2000 || endYear > DateTime.Now.Year || endYear < 2000 || endYear > DateTime.Now.Year || startYear > endYear)
            {
                return null;
            }

            try
            {
                var response = client.Get<List<Match>>(BuildRestRequest(teamId, startYear + "-" + endYear));
                return response.Data;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }


            return null;
        }

        private RestRequest BuildRestRequest(int teamId, string season)
        {
            if(teamId == 0 || string.IsNullOrEmpty(season))
            {
                return null;
            }

            
            var request = new RestRequest("v1/Match/List/{teamId}/{season}");
            request.AddUrlSegment("teamId", teamId);
            request.AddUrlSegment("season", season);
            request.AddHeader("AuthToken", authToken);

            return request;
        }
    }
}
 