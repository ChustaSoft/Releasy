using ChustaSoft.Releasy.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy.GitHub.Tests.Tests
{
    public class GitHubChangelogFileParserTests
    {

        private const string TEST_CHANGELOG_KEY = "SQLClient";
        
        private GitHubChangelogFileParser ServiceUnderTest;


        [SetUp]
        public void Setup()
        {
            ServiceUnderTest = new GitHubChangelogFileParser(
                new GitHubChangelogSettings(TEST_CHANGELOG_KEY, "dotnet", "SqlClient", "CHANGELOG.md"),
                new ChangelogTextParser()
                );
        }


        [Test]
        public async Task Given_PlainTextChangelogFileWithUnreleasedSection_When_Load_Then_ReleasesRetrived()
        {
            var result = await ServiceUnderTest.GetAsync(TEST_CHANGELOG_KEY);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Given_Wrongchangelog_When_Load_Then_ReleaseRetrievingExceptionThrown()
        {
            Assert.ThrowsAsync<ChangelogRetrievingException>(() => ServiceUnderTest.GetAsync("wrongfile.md"));
        }

    }
}