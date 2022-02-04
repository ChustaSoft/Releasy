using ChustaSoft.Releasy.Tests;
using NUnit.Framework;
using System;
using System.Linq;

namespace ChustaSoft.Releasy.FileParser.Tests
{
    public class ChangelogTextParserTests
    {

        private ChangelogTextParser ServiceUnderTest;


        [SetUp]
        public void Setup()
        {
            ServiceUnderTest = new ChangelogTextParser();
        }


        [Test]
        public void Given_ReleasePlainText_When_GetReleaseHeader_Then_VersionAndReleaseRetrived()
        {
            string releaseDataExample = ChangelogTestHelper.GetReleaseLineText();

            var result = ServiceUnderTest.GetReleaseHeader(releaseDataExample);

            Assert.AreEqual("1.0.0", result.Version);
            Assert.AreEqual(new DateTime(2017, 6, 20), result.Date);
        }

        [Test]
        public void Given_ReleasePlainText_When_GetChanges_Then_ChangesCollectionRetrived()
        {
            string releaseDataExample = ChangelogTestHelper.GetReleaseLineText();

            var result = ServiceUnderTest.GetChanges(releaseDataExample);

            Assert.AreEqual(23, result[ChangeType.Added].Count());
            Assert.AreEqual(13, result[ChangeType.Changed].Count());
            Assert.AreEqual(1, result[ChangeType.Removed].Count());
        }

        [Test]
        public void Given_ReleasePlainText_When_ParseReleaseText_Then_ReleaseLinesParsed()
        {
            string releaseDataExample = ChangelogTestHelper.GetReleaseLineText();

            var result = ServiceUnderTest.ParseReleaseText(releaseDataExample);

            Assert.AreEqual("1.0.0", result.Identifier);
            Assert.AreEqual(new DateTime(2017, 6, 20), result.Date);
            Assert.AreEqual(23, result.Additions.Count());
            Assert.AreEqual(13, result.Changes.Count());
            Assert.AreEqual(1, result.Eliminated.Count());
            Assert.AreEqual(0, result.Deprecations.Count());
            Assert.AreEqual(0, result.Fixes.Count());
            Assert.AreEqual(0, result.Secured.Count());
        }

        [Test]
        public void Given_ChangelogTextWithUnreleasedSection_When_HasUnreleasedSection_Then_TrueRetrived()
        {
            string releaseDataExample = ChangelogTestHelper.GetChangelogStringWithUnreleasedSection();

            var result = ServiceUnderTest.HasUnreleasedSection(releaseDataExample);

            Assert.IsTrue(result);
        }

        [Test]
        public void Given_ChangelogTextWithoutUnreleasedSection_When_HasUnreleasedSection_Then_FalseRetrived()
        {
            string releaseDataExample = ChangelogTestHelper.GetChangelogStringWithoutUnreleasedSection();

            var result = ServiceUnderTest.HasUnreleasedSection(releaseDataExample);

            Assert.IsFalse(result);
        }
        
        [Test]
        public void Given_ChangelogTextWithoutUnreleasedSection_When_Parse_Then_ReleaseInfoRetrived() 
        {
            string releaseDataExample = ChangelogTestHelper.GetChangelogStringWithoutUnreleasedSection();

            var result = ServiceUnderTest.Parse(releaseDataExample);

            Assert.AreEqual(1, result.ReleasesInfo.Count());
            Assert.IsNull(result.UnreleasedInfo);
        }

        [Test]
        public void Given_ChangelogTextWithUnreleasedSection_When_Parse_Then_ReleaseInfoWithUnreleasedSectionRetrived()
        {
            string releaseDataExample = ChangelogTestHelper.GetChangelogStringWithUnreleasedSection();

            var result = ServiceUnderTest.Parse(releaseDataExample);

            Assert.AreEqual(1, result.ReleasesInfo.Count());
            Assert.IsNotNull(result.UnreleasedInfo);
        }

    }
}