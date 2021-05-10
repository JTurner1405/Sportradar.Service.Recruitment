using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Respository.Interface
{
    /// <summary>
    /// Interface for File/store creation
    /// </summary>
    public interface IStoreData
    {
        /// <summary>
        /// Check if store file already Exists for season
        /// </summary>
        /// <param name="startYear">Start year of season</param>
        /// <param name="endYear">End year of season</param>
        /// <returns>If files already exists</returns>
        bool CheckStoreAlreadyExists(int startYear, int endYear);

        /// <summary>
        /// Check If store file already exists for season in single year
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <returns>If file already exists</returns>
        bool CheckStoreAlreadyExists(int startYear);

        /// <summary>
        /// Check If store files already exists for season passed
        /// </summary>
        /// <param name="season">Season to check for</param>
        /// <returns>if file already exists</returns>
        bool CheckStoreAlreadyExists(string season);

        /// <summary>
        /// Remove Store for season between years passed
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <returns>if Remove was successful</returns>
        bool RemoveExistingStore(int startYear, int endYear);

        /// <summary>
        /// Remove store for season in single year
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <returns>if remove was successful</returns>
        bool RemoveExistingStore(int startYear);

        /// <summary>
        /// Remove store for season passed
        /// </summary>
        /// <param name="season">season to remove</param>
        /// <returns>if remove was succcessful</returns>
        bool RemoveExistingStore(string season);

        /// <summary>
        /// Create new file store beteen given years
        /// </summary>
        /// <param name="startYear">Start of season</param>
        /// <param name="endYear">end of season</param>
        /// <returns>If Create store was successful</returns>
        string CreateNewStoreForSeason(int startYear, int endYear);

        /// <summary>
        /// Create new File store for season in a year
        /// </summary>
        /// <param name="startYear">Season year</param>
        /// <returns>if store created successfully</returns>
        string CreateNewStoreForSeason(int startYear);

        /// <summary>
        /// Create new File store for season
        /// </summary>
        /// <param name="season">season to create store for</param>
        /// <returns>if store is created successfully</returns>
        string CreateNewStoreForSeason(string season);

    }
}
