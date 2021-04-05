using ChustaSoft.Releasy.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy.FileParser.Tests
{
    public class ReleaseFileParserTests
    {

        private ReleaseFileParser ServiceUnderTest;


        [SetUp]
        public void Setup()
        {
            ServiceUnderTest = new ReleaseFileParser(new FileParserSettings(FileParserConstants.DEFAULT_CHANGELOG_FILENAME));
        }

        [Test]
        public async Task Given_changelog_When_GetReleaseLines_Then_ReleaseLinesParsed()
        {
            var result = await ServiceUnderTest.GetReleaseLines();

            Assert.AreEqual(13, result.Length);
        }

    }
}