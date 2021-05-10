using NUnit.Framework;
using Sportradar.Service.Recruitment.Respository.Class;
using Sportradar.Service.Recruitment.Respository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Tests.Unit.Repository
{
    public class StoreDataTests 
    {
        private IStoreData storeData;
        private string fileName1 = "SportsRadarStore-2019-2020.json";
        private string fileName2 = "SportsRadarStore-2019.json";
        private string fileName3 = "SportsRadarStore-test.json";

        [SetUp]
        public void Setup()
        {
            storeData = new StoreData();
        }

        [TearDown]
        public void Dispose()
        {
            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }

            if(File.Exists(fileName2))
            {
                File.Delete(fileName2);
            }

            if(File.Exists(fileName3))
            {
                File.Delete(fileName3);
            }
        }

        [Test]
        public void CheckStoreAlreadyExistsMultipleYearsFileExistsTest()
        {
            File.Create(fileName1).Close();

            var result = storeData.CheckStoreAlreadyExists(2019, 2020);

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckStoreAlreadyExistsMultipleYearsFileDoesNotExistsTest()
        {
            var result = storeData.CheckStoreAlreadyExists(2019, 2020);

            Assert.IsFalse(result);
        }

        [Test]
        public void CheckStoreAlreadyExistsSingleYearFileExistsTest()
        {
            File.Create(fileName2).Close(); ;

            var result = storeData.CheckStoreAlreadyExists(2019);

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckStoreAlreadyExistsSingleYearFileDoesNotExistsTest()
        {
            var result = storeData.CheckStoreAlreadyExists(2019);

            Assert.IsFalse(result);
        }

        [Test]
        public void CheckStoreAlreadyExistsTestStringFileExistsTest()
        {
            File.Create(fileName3).Close();

            var result = storeData.CheckStoreAlreadyExists("test");

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckStoreAlreadyExistsTestStringFileDoesNotExistsTest()
        {
            var result = storeData.CheckStoreAlreadyExists("test");

            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveExistingStoreDoubleYearFileExistsTest()
        {
            File.Create(fileName1).Close();

            var result = storeData.RemoveExistingStore(2019, 2020);

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveExistingStoreDoubleYearFileDoesNotExistsTest()
        {
            var result = storeData.RemoveExistingStore(2019, 2020);

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveExistingStoreSingleYearFileExistsTest()
        {
            File.Create(fileName2).Close();

            var result = storeData.RemoveExistingStore(2019);

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveExistingStoreSingleYearFileDoesNotExistsTest()
        {
            var result = storeData.RemoveExistingStore(2019);

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveExistingStoreTestStringFileExistsTest()
        {
            File.Create(fileName3).Close();

            var result = storeData.RemoveExistingStore("test");

            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveExistingStoreTestStringFileDoesNotExistsTest()
        {
            var result = storeData.RemoveExistingStore("test");

            Assert.IsTrue(result);
        }

        [Test]
        public void CreateNewStoreForSeasonDoubleYearTest()
        {
            var result = storeData.CreateNewStoreForSeason(2019, 2020);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name.Contains(fileName1));
            result.Close();
        }

        [Test]
        public void CreateNewStoreForSeasonSingleYearTest()
        {
            var result = storeData.CreateNewStoreForSeason(2019);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name.Contains(fileName2));
            result.Close();
        }

        [Test]
        public void CreateNewStoreForSeasonTestStringTest()
        {
            var result = storeData.CreateNewStoreForSeason("test");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name.Contains(fileName3));
            result.Close();
        }
    }
}
