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
    }
}
