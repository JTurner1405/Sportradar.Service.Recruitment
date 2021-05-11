using Moq;
using NUnit.Framework;
using Sportradar.Service.Recruitment.Application.Class.BusinessLogic;
using Sportradar.Service.Recruitment.Application.Interface.BusinessLogic;
using Sportradar.Service.Recruitment.Application.Interface.Rest;
using Sportradar.Service.Recruitment.Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportradar.Service.Recruitment.Tests.Unit.Application.BusinessLogic
{
    public class FetchServiceTests
    {
        private IFetchService service;
        private Mock<IStoreReadWrite> mockReadWrite;
        private Mock<IStoreData> mockStoreData;
        private Mock<IAPIRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockReadWrite = new Mock<IStoreReadWrite>();
            mockStoreData = new Mock<IStoreData>();
            mockClient = new Mock<IAPIRestClient>();

            service = new FetchService(mockClient.Object, mockStoreData.Object, mockReadWrite.Object);
        }

        [TearDown]
        public void Dispose()
        {
            mockClient = null;
            mockStoreData = null;
            mockReadWrite = null;
            service = null;
        }

        [Test]
        public void GetListOfMatchsFromEitherStoreOrAPIFromStoreTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "54321.png"},
            });

            var result = service.GetListOfMatchsFromEitherStoreOrAPI(2019, 12345);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void GetListOfMatchsFromEitherStoreOrAPIFromStoreNoMatchTeamIdTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123545.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1233545.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12322445.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12534545.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765 , TeamLogoFileName = "5432241.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(), It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "129345.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "129345.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "129345.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "129345.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true,  OpponentTeamId = 98765, TeamLogoFileName = "129345.png"},
            });

            var result = service.GetListOfMatchsFromEitherStoreOrAPI(2019, 12345);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [Test]
        public void GetListOfMatchsFromEitherStoreOrAPIFromStoreNoMatchAPIhasMatchesTeamIdTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123945.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123945.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123945.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123945.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "127345.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(), It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true,   OpponentTeamId = 98765, TeamLogoFileName = "123345.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "123545.png"},
            });

            var result = service.GetListOfMatchsFromEitherStoreOrAPI(2019, 12345);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void GetListOfMatchsFromEitherStoreOrAPIDoubleYearFromStoreTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1244345.png"},
            });

            var result = service.GetListOfMatchsFromEitherStoreOrAPI(2019,2020, 12345);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void GetListOfMatchsFromEitherStoreOrAPIDoubleYearFromStoreNoMatchTeamIdTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "666125345.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "666123445.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "666123445.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "666123345.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1332345.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1235445.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123545.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123545.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123545.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1244345.png"},
            });

            var result = service.GetListOfMatchsFromEitherStoreOrAPI(2019, 2020, 12345);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [Test]
        public void GetListOfMatchsFromEitherStoreOrAPIDoubleYearFromStoreNoMatchAPIhasMatchesTeamIdTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1235.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1235.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1235.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1235.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123445.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true,   OpponentTeamId = 98765, TeamLogoFileName = "1d2345.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true,    OpponentTeamId = 98765, TeamLogoFileName = "124345.png"},
            });

            var result = service.GetListOfMatchsFromEitherStoreOrAPI(2019, 2020, 12345);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void GetMatchInSeasonFromStoreTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchId = 1,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1.png"},
                new Objects.Match{ MatchId = 2,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "2.png"},
                new Objects.Match{ MatchId = 3,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchId = 4,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "4.png"},
                new Objects.Match{ MatchId = 5,MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "5.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "234.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1234.png"},
                new Objects.Match{ MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "123424.png"},
                new Objects.Match{ MatchTeamId = 129345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1234243.png"},
                new Objects.Match{ MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "124243.png"},
            });

            var result = service.GetMatchInSeason(2019, 2020, 12345,3);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.MatchId);
            Assert.IsTrue(result.IsAtHome);
        }

        [Test]
        public void GetMatchInSeasonFromAPITest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchId = 1,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1.png"},
                new Objects.Match{ MatchId = 2,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "2.png"},
                new Objects.Match{ MatchId = 3,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "3.png"},
                new Objects.Match{ MatchId = 4,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "4.png"},
                new Objects.Match{ MatchId = 5,MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "5.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchId = 6, TeamLogoFileName = "6.png", MatchTeamId = 12345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 7, TeamLogoFileName = "7.png", MatchTeamId = 12345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 8, TeamLogoFileName = "12345.png", MatchTeamId = 12345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 9, TeamLogoFileName = "9.png", MatchTeamId = 129345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 10,TeamLogoFileName = "10.png",  MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765},
            });

            var result = service.GetMatchInSeason(2019, 2020, 12345, 8);

            Assert.IsNotNull(result);
            Assert.AreEqual(8, result.MatchId);
            Assert.IsFalse(result.IsAtHome);
        }

        [Test]
        public void GetMatchInSeasonFromStoreSingleYearTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchId = 1,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1.png"},
                new Objects.Match{ MatchId = 2,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "21.png"},
                new Objects.Match{ MatchId = 3,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "12345.png"},
                new Objects.Match{ MatchId = 4,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "4.png"},
                new Objects.Match{ MatchId = 5,MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "5.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(), It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchTeamId = 12345, TeamLogoFileName = "6.png", IsAtHome = true, OpponentTeamId = 98765},
                new Objects.Match{ MatchTeamId = 12345, TeamLogoFileName = "78.png", IsAtHome = true, OpponentTeamId = 98765},
                new Objects.Match{ MatchTeamId = 12345, TeamLogoFileName = "8.png", IsAtHome = true, OpponentTeamId = 98765},
                new Objects.Match{ MatchTeamId = 129345,TeamLogoFileName = "9.png",  IsAtHome = true, OpponentTeamId = 98765},
                new Objects.Match{ MatchTeamId = 54321, TeamLogoFileName = "10.png", IsAtHome = true, OpponentTeamId = 98765},
            });

            var result = service.GetMatchInSeason(2019, 12345, 3);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.MatchId);
            Assert.IsTrue(result.IsAtHome);
        }

        [Test]
        public void GetMatchInSeasonFromAPISingleYearTest()
        {
            mockStoreData.Setup(x => x.CheckStoreAlreadyExists(It.IsAny<int>())).Returns(true);
            mockReadWrite.Setup(x => x.ReadFromStore(It.IsAny<int>())).Returns(new List<Objects.Match>()
            {
                new Objects.Match{ MatchId = 1,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "1.png"},
                new Objects.Match{ MatchId = 2,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "2.png"},
                new Objects.Match{ MatchId = 3,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "3.png"},
                new Objects.Match{ MatchId = 4,MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "45.png"},
                new Objects.Match{ MatchId = 5,MatchTeamId = 54321, IsAtHome = true, OpponentTeamId = 98765, TeamLogoFileName = "5.png"},
            });
            mockClient.Setup(x => x.GetAllMatchesForSeason(It.IsAny<int>(),  It.IsAny<int>())).Returns(
                new List<Objects.Match>()
            {
                new Objects.Match{ MatchId = 6, TeamLogoFileName = "6.png", MatchTeamId = 12345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 7, TeamLogoFileName = "7.png", MatchTeamId = 12345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 8, TeamLogoFileName = "8.png", MatchTeamId = 12345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 9, TeamLogoFileName = "9.png", MatchTeamId = 129345, IsAtHome = false, OpponentTeamId = 98765},
                new Objects.Match{ MatchId = 10,TeamLogoFileName = "12345.png",  MatchTeamId = 12345, IsAtHome = true, OpponentTeamId = 98765},
            });

            var result = service.GetMatchInSeason(2019, 12345, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.MatchId);
            Assert.IsTrue(result.IsAtHome);
        }
    }
}
