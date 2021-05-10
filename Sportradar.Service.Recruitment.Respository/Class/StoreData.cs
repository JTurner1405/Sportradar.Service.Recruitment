using Sportradar.Service.Recruitment.Respository.Interface;
using System;
using System.Diagnostics;
using System.IO;

namespace Sportradar.Service.Recruitment.Respository.Class
{
    public class StoreData : IStoreData
    {
        /// <summary>
        /// Check if store file already Exists for season
        /// </summary>
        /// <param name="startYear">Start year of season</param>
        /// <param name="endYear">End year of season</param>
        /// <returns>If files already exists</returns>
        public bool CheckStoreAlreadyExists(int startYear, int endYear)
        {
            return CheckStoreAlreadyExists(startYear + "-" + endYear);
        }

        /// <summary>
        /// Check If store file already exists for season in single year
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <returns>If file already exists</returns>
        public bool CheckStoreAlreadyExists(int startYear)
        {
            return CheckStoreAlreadyExists(startYear.ToString());
        }

        /// <summary>
        /// Check If store files already exists for season passed
        /// </summary>
        /// <param name="season">Season to check for</param>
        /// <returns>if file already exists</returns>
        public bool CheckStoreAlreadyExists(string season)
        {
            if (string.IsNullOrEmpty(season))
            {
                return false;
            }

            return File.Exists(FileNameHelper.GetFileName(season));
        }

        /// <summary>
        /// Remove Store for season between years passed
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <returns>if Remove was successful</returns>
        public bool RemoveExistingStore(int startYear, int endYear)
        {
            return this.RemoveExistingStore(startYear + "-" + endYear);
        }

        /// <summary>
        /// Remove store for season in single year
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <returns>if remove was successful</returns>
        public bool RemoveExistingStore(int startYear)
        {
            return this.RemoveExistingStore(startYear.ToString());
        }

        /// <summary>
        /// Remove store for season passed
        /// </summary>
        /// <param name="season">season to remove</param>
        /// <returns>if remove was succcessful</returns>
        public bool RemoveExistingStore(string season)
        {
            string fileName = FileNameHelper.GetFileName(season);
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch(Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// Create new file store beteen given years
        /// </summary>
        /// <param name="startYear">Start of season</param>
        /// <param name="endYear">end of season</param>
        /// <returns>If Create store was successful</returns>
        public FileStream CreateNewStoreForSeason(int startYear, int endYear)
        {
            return this.CreateNewStoreForSeason(startYear + "-" + endYear);
        }

        /// <summary>
        /// Create new File store for season in a year
        /// </summary>
        /// <param name="startYear">Season year</param>
        /// <returns>if store created successfully</returns>
        public FileStream CreateNewStoreForSeason(int startYear)
        {
            return this.CreateNewStoreForSeason(startYear.ToString());
        }

        /// <summary>
        /// Create new File store for season
        /// </summary>
        /// <param name="season">season to create store for</param>
        /// <returns>if store is created successfully</returns>
        public FileStream CreateNewStoreForSeason(string season)
        {
            try
            {
                return File.Create(FileNameHelper.GetFileName(season));
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
