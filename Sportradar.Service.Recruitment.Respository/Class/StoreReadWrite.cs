using Sportradar.Service.Recruitment.Objects;
using Sportradar.Service.Recruitment.Respository.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Sportradar.Service.Recruitment.Respository.Class
{
    /// <summary>
    /// Read & write from the store
    /// </summary>
    public class StoreReadWrite : IStoreReadWrite
    {
        private IStoreData fileStore;

        /// <summary>
        /// Constructor to setup required objects
        /// </summary>
        public StoreReadWrite()
        {
            fileStore = new StoreData();
        }

        /// <summary>
        /// Constructor to setup required objects
        /// </summary>
        /// <param name="storeData">Store data object to use</param>
        public StoreReadWrite(IStoreData storeData)
        {
            this.fileStore = storeData;
        }

        /// <summary>
        /// Read json from store & output as list of match's
        /// </summary>
        /// <param name="season">Season store to check</param>
        /// <returns>List of match objects</returns>
        public List<Match> ReadFromStore(String season)
        {
            if (fileStore.CheckStoreAlreadyExists(season))
            {
                var jsonString = File.ReadAllText(FileNameHelper.GetFileName(season));
                return JsonSerializer.Deserialize<List<Match>>(jsonString);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Read json from store & output as list of match's for multiple years
        /// </summary>
        /// <param name="startYear">start of season</param>
        /// <param name="endYear">end of season</param>
        /// <returns>list of match objects</returns>
        public List<Match> ReadFromStore(int startYear, int endYear)
        {
            return this.ReadFromStore(FileNameHelper.GetSeasonIdentifier(startYear, endYear));
        }

        /// <summary>
        /// Read json from store & output as list of match's for single year
        /// </summary>
        /// <param name="startYear">season year</param>
        /// <returns>list of match objects</returns>
        public List<Match> ReadFromStore(int startYear)
        {
            return this.ReadFromStore(startYear.ToString());
        }

        /// <summary>
        /// Write to store as json list of match's
        /// </summary>
        /// <param name="matches">Match's to add to store</param>
        /// <param name="season">store season id</param>
        /// <returns>if add was successful</returns>
        public bool WriteToStore(List<Match> matches, string season)
        {
            if (matches == null || !matches.Any())
            {
                return false;
            }

            try
            {


                var jsonString = JsonSerializer.Serialize(matches);
                File.WriteAllText(FileNameHelper.GetFileName(season), jsonString);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Write to store as Json list of match's for multiple years
        /// </summary>
        /// <param name="matches">Match's to add to store</param>
        /// <param name="startYear">store start year</param>
        /// <param name="endYear">Store end year</param>
        /// <returns>If add was successful</returns>
        public bool WriteToStore(List<Match> matches, int startYear, int endYear)
        {
            return this.WriteToStore(matches, FileNameHelper.GetSeasonIdentifier(startYear, endYear));
        }

        /// <summary>
        /// Write to store as Json List of match's for single year
        /// </summary>
        /// <param name="matches">Match's to add to store</param>
        /// <param name="startYear">Store year id</param>
        /// <returns>if add was successful</returns>
        public bool WriteToStore(List<Match> matches, int startYear)
        {
            return this.WriteToStore(matches, startYear.ToString());
        }
    }
}
