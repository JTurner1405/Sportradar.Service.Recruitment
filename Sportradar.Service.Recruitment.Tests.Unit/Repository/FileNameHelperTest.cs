using NUnit.Framework;
using Sportradar.Service.Recruitment.Respository.Class;

namespace Sportradar.Service.Recruitment.Tests.Unit.Repository
{
    public class FileNameHelperTest
    {
        [Test]
        public void GetFileNameTest()
        {
            var result = FileNameHelper.GetFileName("2019");

            Assert.AreEqual("SportsRadarStore-2019.json", result);
        }

        [Test]
        public void GetFileName2YearsTest()
        {
            var result = FileNameHelper.GetFileName("2019-2020");

            Assert.AreEqual("SportsRadarStore-2019-2020.json", result);
        }

        [Test]
        public void GetFileNameEmptyStringTest()
        {
            var result = FileNameHelper.GetFileName(string.Empty);

            Assert.AreEqual("SportsRadarStore-.json", result);
        }

        [Test]
        public void GetSeasonIdentifierTest()
        {
            var result = FileNameHelper.GetSeasonIdentifier(10, 12);

            Assert.AreEqual("10-12", result);
        }
    }
}
