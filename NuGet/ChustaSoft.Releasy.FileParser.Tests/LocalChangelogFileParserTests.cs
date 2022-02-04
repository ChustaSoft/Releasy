using ChustaSoft.Releasy.Configuration;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.Releasy.FileParser.Tests
{
    public class LocalChangelogFileParserTests
    {

        private LocalChangelogFileParser ServiceUnderTest;

        private const string WITH_UNRELEASED_KEY = "with-unreleased";
        private const string WITHOUT_UNRELEASED_KEY = "without-unreleased";


        [SetUp]
        public void Setup()
        {
            ServiceUnderTest = new LocalChangelogFileParser(
                new LocalChangelogSettings(WITHOUT_UNRELEASED_KEY, "changelog-without-unreleased.md")
                    .Add(WITH_UNRELEASED_KEY, "changelog-with-unreleased.md"),
                new ChangelogTextParser()
                );
        }


        [Test]
        public async Task Given_PlainTextChangelogFileWithUnreleasedSection_When_Load_Then_ReleasesRetrived()
        {
            var result = await ServiceUnderTest.GetAsync(WITH_UNRELEASED_KEY);
            
            PerformUnreleasedAsserts(result);
            PerformReleasesAsserts(result);
        }       

        [Test]
        public async Task Given_PlainTextChangelogFileWithoutUnreleasedSection_When_Load_Then_ReleasesRetrived()
        {
            var result = await ServiceUnderTest.GetAsync(WITHOUT_UNRELEASED_KEY);

            PerformReleasesAsserts(result);
        }


        private static void PerformUnreleasedAsserts(ChangelogFile result)
        {
            Assert.IsNotNull(result.UnreleasedInfo);
            Assert.AreEqual(2, result.UnreleasedInfo.Additions.Count());
            Assert.AreEqual(0, result.UnreleasedInfo.Changes.Count());
            Assert.AreEqual(0, result.UnreleasedInfo.Eliminated.Count());
            Assert.AreEqual(0, result.UnreleasedInfo.Deprecations.Count());
            Assert.AreEqual(1, result.UnreleasedInfo.Fixes.Count());
            Assert.AreEqual(0, result.UnreleasedInfo.Secured.Count());
        }

        private static void PerformReleasesAsserts(ChangelogFile result)
        {
            Assert.AreEqual(12, result.ReleasesInfo.Count());

            var version100 = result.ReleasesInfo.First(x => x.Identifier == "1.0.0");
            Assert.AreEqual("1.0.0", version100.Identifier);
            Assert.AreEqual(new DateTime(2017, 6, 20), version100.Date);
            Assert.AreEqual(23, version100.Additions.Count());
            Assert.AreEqual(13, version100.Changes.Count());
            Assert.AreEqual(1, version100.Eliminated.Count());
            Assert.AreEqual(0, version100.Deprecations.Count());
            Assert.AreEqual(0, version100.Fixes.Count());
            Assert.AreEqual(0, version100.Secured.Count());

            var version030 = result.ReleasesInfo.First(x => x.Identifier == "0.3.0");
            Assert.AreEqual("0.3.0", version030.Identifier);
            Assert.AreEqual(new DateTime(2015, 12, 3), version030.Date);
            Assert.AreEqual(3, version030.Additions.Count());
            Assert.AreEqual(0, version030.Changes.Count());
            Assert.AreEqual(0, version030.Eliminated.Count());
            Assert.AreEqual(0, version030.Deprecations.Count());
            Assert.AreEqual(0, version030.Fixes.Count());
            Assert.AreEqual(0, version030.Secured.Count());

            var version020 = result.ReleasesInfo.First(x => x.Identifier == "0.2.0");
            Assert.AreEqual("0.2.0", version020.Identifier);
            Assert.AreEqual(new DateTime(2015, 10, 06), version020.Date);
            Assert.AreEqual(0, version020.Additions.Count());
            Assert.AreEqual(1, version020.Changes.Count());
            Assert.AreEqual(0, version020.Eliminated.Count());
            Assert.AreEqual(0, version020.Deprecations.Count());
            Assert.AreEqual(0, version020.Fixes.Count());
            Assert.AreEqual(0, version020.Secured.Count());

            var version010 = result.ReleasesInfo.First(x => x.Identifier == "0.1.0");
            Assert.AreEqual("0.1.0", version010.Identifier);
            Assert.AreEqual(new DateTime(2015, 10, 06), version010.Date);
            Assert.AreEqual(1, version010.Additions.Count());
            Assert.AreEqual(2, version010.Changes.Count());
            Assert.AreEqual(0, version010.Eliminated.Count());
            Assert.AreEqual(0, version010.Deprecations.Count());
            Assert.AreEqual(0, version010.Fixes.Count());
            Assert.AreEqual(0, version010.Secured.Count());

            var version008 = result.ReleasesInfo.First(x => x.Identifier == "0.0.8");
            Assert.AreEqual("0.0.8", version008.Identifier);
            Assert.AreEqual(new DateTime(2015, 02, 17), version008.Date);
            Assert.AreEqual(0, version008.Additions.Count());
            Assert.AreEqual(2, version008.Changes.Count());
            Assert.AreEqual(0, version008.Eliminated.Count());
            Assert.AreEqual(0, version008.Deprecations.Count());
            Assert.AreEqual(2, version008.Fixes.Count());
            Assert.AreEqual(0, version008.Secured.Count());

            var version007 = result.ReleasesInfo.First(x => x.Identifier == "0.0.7");
            Assert.AreEqual("0.0.7", version007.Identifier);
            Assert.AreEqual(new DateTime(2015, 02, 16), version007.Date);
            Assert.AreEqual(1, version007.Additions.Count());
            Assert.AreEqual(1, version007.Changes.Count());
            Assert.AreEqual(0, version007.Eliminated.Count());
            Assert.AreEqual(0, version007.Deprecations.Count());
            Assert.AreEqual(1, version007.Fixes.Count());
            Assert.AreEqual(0, version007.Secured.Count());

            var version006 = result.ReleasesInfo.First(x => x.Identifier == "0.0.6");
            Assert.AreEqual("0.0.6", version006.Identifier);
            Assert.AreEqual(new DateTime(2014, 12, 12), version006.Date);
            Assert.AreEqual(1, version006.Additions.Count());
            Assert.AreEqual(0, version006.Changes.Count());
            Assert.AreEqual(0, version006.Eliminated.Count());
            Assert.AreEqual(0, version006.Deprecations.Count());
            Assert.AreEqual(0, version006.Fixes.Count());
            Assert.AreEqual(0, version006.Secured.Count());

            var version005 = result.ReleasesInfo.First(x => x.Identifier == "0.0.5");
            Assert.AreEqual("0.0.5", version005.Identifier);
            Assert.AreEqual(new DateTime(2014, 8, 9), version005.Date);
            Assert.AreEqual(2, version005.Additions.Count());
            Assert.AreEqual(0, version005.Changes.Count());
            Assert.AreEqual(0, version005.Eliminated.Count());
            Assert.AreEqual(0, version005.Deprecations.Count());
            Assert.AreEqual(0, version005.Fixes.Count());
            Assert.AreEqual(0, version005.Secured.Count());

            var version004 = result.ReleasesInfo.First(x => x.Identifier == "0.0.4");
            Assert.AreEqual("0.0.4", version004.Identifier);
            Assert.AreEqual(new DateTime(2014, 8, 9), version004.Date);
            Assert.AreEqual(1, version004.Additions.Count());
            Assert.AreEqual(1, version004.Changes.Count());
            Assert.AreEqual(1, version004.Eliminated.Count());
            Assert.AreEqual(0, version004.Deprecations.Count());
            Assert.AreEqual(0, version004.Fixes.Count());
            Assert.AreEqual(0, version004.Secured.Count());

            var version003 = result.ReleasesInfo.First(x => x.Identifier == "0.0.3");
            Assert.AreEqual("0.0.3", version003.Identifier);
            Assert.AreEqual(new DateTime(2014, 8, 9), version003.Date);
            Assert.AreEqual(1, version003.Additions.Count());
            Assert.AreEqual(0, version003.Changes.Count());
            Assert.AreEqual(0, version003.Eliminated.Count());
            Assert.AreEqual(0, version003.Deprecations.Count());
            Assert.AreEqual(0, version003.Fixes.Count());
            Assert.AreEqual(0, version003.Secured.Count());

            var version002 = result.ReleasesInfo.First(x => x.Identifier == "0.0.2");
            Assert.AreEqual("0.0.2", version002.Identifier);
            Assert.AreEqual(new DateTime(2014, 7, 10), version002.Date);
            Assert.AreEqual(1, version002.Additions.Count());
            Assert.AreEqual(0, version002.Changes.Count());
            Assert.AreEqual(0, version002.Eliminated.Count());
            Assert.AreEqual(0, version002.Deprecations.Count());
            Assert.AreEqual(0, version002.Fixes.Count());
            Assert.AreEqual(0, version002.Secured.Count());

            var version001 = result.ReleasesInfo.First(x => x.Identifier == "0.0.1");
            Assert.AreEqual("0.0.1", version001.Identifier);
            Assert.AreEqual(new DateTime(2014, 5, 31), version001.Date);
            Assert.AreEqual(5, version001.Additions.Count());
            Assert.AreEqual(0, version001.Changes.Count());
            Assert.AreEqual(0, version001.Eliminated.Count());
            Assert.AreEqual(0, version001.Deprecations.Count());
            Assert.AreEqual(0, version001.Fixes.Count());
            Assert.AreEqual(0, version001.Secured.Count());
        }

        [Test]
        public void Given_Wrongchangelog_When_Load_Then_ReleaseRetrievingExceptionThrown()
        {
            Assert.ThrowsAsync<ChangelogRetrievingException>(() => ServiceUnderTest.GetAsync("wrongfile.md"));
        }

    }
}