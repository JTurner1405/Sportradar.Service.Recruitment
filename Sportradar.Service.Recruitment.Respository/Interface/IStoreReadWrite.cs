using Sportradar.Service.Recruitment.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Respository.Interface
{
    /// <summary>
    /// Interface for Read write operations on the store
    /// </summary>
    public interface IStoreReadWrite
    {
        /// <summary>
        /// Read json from store & output as list of match's
        /// </summary>
        /// <param name="season">Season store to check</param>
        /// <returns>List of match objects</returns>
        List<Match> ReadFromStore(String season);

        /// <summary>
        /// Read json from store & output as list of match's for multiple years
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <returns>list of match objects</returns>
        List<Match> ReadFromStore(int startYear, int endYear);
        
        /// <summary>
        /// Read json from store & output as list of match's for single year
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <returns>list of match objects</returns>
        List<Match> ReadFromStore(int startYear);

        /// <summary>
        /// Write to store as json list of match's
        /// </summary>
        /// <param name="matches">Match's to add to store</param>
        /// <param name="season">store season id</param>
        /// <returns>if add was successful</returns>
        bool WriteToStore(List<Match> matches, string season);

        /// <summary>
        /// Write to store as Json list of match's for multiple years
        /// </summary>
        /// <param name="matches">Match's to add to store</param>
        /// <param name="startYear">store start year</param>
        /// <param name="endYear">Store end year</param>
        /// <returns>If add was successful</returns>
        bool WriteToStore(List<Match> matches, int startYear, int endYear);

        /// <summary>
        /// Write to store as Json List of match's for single year
        /// </summary>
        /// <param name="matches">Match's to add to store</param>
        /// <param name="startYear">Store year id</param>
        /// <returns>if add was successful</returns>
        bool WriteToStore(List<Match> matches, int startYear);
    }
}
