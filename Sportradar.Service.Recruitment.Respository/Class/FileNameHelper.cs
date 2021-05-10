using Sportradar.Service.Recruitment.Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Respository.Class
{
    public static class FileNameHelper
    {
        private static readonly string prefix = "SportsRadarStore-";
        private static readonly string fileType = ".json";

        /// <summary>
        /// Generate FileName based on season
        /// </summary>
        /// <param name="season">Season for file name</param>
        /// <returns>Generated File Name</returns>
        public static string GetFileName(string season)
        {
            return prefix + season + fileType;
        }

        /// <summary>
        /// combine start & end year of season for store identification
        /// </summary>
        /// <param name="startYear">season start year</param>
        /// <param name="endYear">season end year</param>
        /// <returns>season identifier</returns>
        public static string GetSeasonIdentifier(int startYear, int endYear)
        {
            return startYear + "-" + endYear;
        }
    }
}
