using NUnit.Framework;
using Sportradar.Service.Recruitment.Objects;
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
    public class StoreReadWriteTests
    {
        private IStoreReadWrite readWrite;
        private string fileName1 = "SportsRadarStore-2019-2020.json";
        private string fileName2 = "SportsRadarStore-2019.json";
        private string fileName3 = "SportsRadarStore-test.json";

        [SetUp]
        public void Setup()
        {
            readWrite = new StoreReadWrite();
        }

        [TearDown]
        public void Dispose()
        {
            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }

            if (File.Exists(fileName2))
            {
                File.Delete(fileName2);
            }

            if (File.Exists(fileName3))
            {
                File.Delete(fileName3);
            }
        }

        [Test]
        public void WriteToStoreTestStringTest()
        {
            var matches = new List<Match>()
            {
                new Match()
                {
                    MatchId = 1,
                    SportradarMatchId = 2,
                    MatchStatusId = 1,
                    matchStatus = "Cancelled",
                }
            };

            var result = readWrite.WriteToStore(matches, "test");
            Assert.IsTrue(result);
        }

        [Test]
        public void WriteToStoreDoubleYearTest()
        {
            var matches = new List<Match>()
            {
                new Match()
                {
                    MatchId = 1,
                    SportradarMatchId = 2,
                    MatchStatusId = 1,
                    matchStatus = "Cancelled",
                }
            };

            var result = readWrite.WriteToStore(matches, 2019,2020);
            Assert.IsTrue(result);
        }

        [Test]
        public void WriteToStoreSingleYearTest()
        {
            var matches = new List<Match>()
            {
                new Match()
                {
                    MatchId = 1,
                    SportradarMatchId = 2,
                    MatchStatusId = 1,
                    matchStatus = "Cancelled",
                },
                new Match()
                {
                    MatchId = 2,
                    SportradarMatchId = 3,
                    MatchStatusId = 2,
                    matchStatus = "Won",
                }
            };

            var result = readWrite.WriteToStore(matches, 2019);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReadFromStoreTestStringNoFileTest()
        {
            var result = readWrite.ReadFromStore("test");

            Assert.IsNull(result);
        }

        [Test]
        public void ReadFromStoreTestStringFileExistsTest()
        {
            var jsonString = "[{\"matchId\":1,\"sportradarMatchId\":2,\"matchStatusId\":1,\"matchTeamID\":0,\"opponentMatchTeamID\":0,\"matchStatus\":\"Cancelled\",\"kickOff\":null,\"kickOffGmt\":null,\"displayOverDate\":null,\"opponentTeamId\":0,\"opponentName\":null,\"opponentNameShort\":null,\"stadiumId\":null,\"stadiumName\":null,\"placeId\":null,\"placeName\":null,\"isTeam1\":false,\"isAtHome\":false,\"isTest\":false,\"isResult\":false,\"result\":null,\"pointsFor\":0,\"PointsAgainst\":0,\"teamLogoFilename\":null,\"oppenentTeamLogoFilename\":null,\"teamLogoFilenameDark\":null,\"oppenentTeamLogoFilenameDark\":null,\"attendance\":null,\"isInProgress\":false,\"matchUpdated\":null},{\"matchId\":2,\"sportradarMatchId\":3,\"matchStatusId\":2,\"matchTeamID\":0,\"opponentMatchTeamID\":0,\"matchStatus\":\"Won\",\"kickOff\":null,\"kickOffGmt\":null,\"displayOverDate\":null,\"opponentTeamId\":0,\"opponentName\":null,\"opponentNameShort\":null,\"stadiumId\":null,\"stadiumName\":null,\"placeId\":null,\"placeName\":null,\"isTeam1\":false,\"isAtHome\":false,\"isTest\":false,\"isResult\":false,\"result\":null,\"pointsFor\":0,\"PointsAgainst\":0,\"teamLogoFilename\":null,\"oppenentTeamLogoFilename\":null,\"teamLogoFilenameDark\":null,\"oppenentTeamLogoFilenameDark\":null,\"attendance\":null,\"isInProgress\":false,\"matchUpdated\":null}]";
            File.WriteAllText(fileName3, jsonString);

            var result = readWrite.ReadFromStore("test");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(2, result.Count);
        }

        /*
        List<Match> ReadFromStore(String season);
        List<Match> ReadFromStore(int startYear, int endYear);
        List<Match> ReadFromStore(int startYear);
        bool WriteToStore(List<Match> matches, string season);
        bool WriteToStore(List<Match> matches, int startYear, int endYear);
        bool WriteToStore(List<Match> matches, int startYear)
         * 
         */
    }
}
