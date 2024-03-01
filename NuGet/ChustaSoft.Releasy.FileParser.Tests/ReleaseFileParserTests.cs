using ChustaSoft.Releasy.Configuration;
using NUnit.Framework;
using System;
using System.Linq;
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

        [Test]
        public void Given_ReleasePlainText_When_GetReleaseHeader_Then_VersionAndReleaseRetrived()
        {
            var releaseDataExample = "[1.0.0] - 2017-06-20\r\n### Added\r\n- New visual identity by [@tylerfortune8](https://github.com/tylerfortune8).\r\n- Version navigation.\r\n- Links to latest released version in previous versions.\r\n- \"Why keep a changelog?\" section.\r\n- \"Who needs a changelog?\" section.\r\n- \"How do I make a changelog?\" section.\r\n- \"Frequently Asked Questions\" section.\r\n- New \"Guiding Principles\" sub-section to \"How do I make a changelog?\".\r\n- Simplified and Traditional Chinese translations from [@tianshuo](https://github.com/tianshuo).\r\n- German translation from [@mpbzh](https://github.com/mpbzh) & [@Art4](https://github.com/Art4).\r\n- Italian translation from [@azkidenz](https://github.com/azkidenz).\r\n- Swedish translation from [@magol](https://github.com/magol).\r\n- Turkish translation from [@karalamalar](https://github.com/karalamalar).\r\n- French translation from [@zapashcanon](https://github.com/zapashcanon).\r\n- Brazilian Portugese translation from [@Webysther](https://github.com/Webysther).\r\n- Polish translation from [@amielucha](https://github.com/amielucha) & [@m-aciek](https://github.com/m-aciek).\r\n- Russian translation from [@aishek](https://github.com/aishek).\r\n- Czech translation from [@h4vry](https://github.com/h4vry).\r\n- Slovak translation from [@jkostolansky](https://github.com/jkostolansky).\r\n- Korean translation from [@pierceh89](https://github.com/pierceh89).\r\n- Croatian translation from [@porx](https://github.com/porx).\r\n- Persian translation from [@Hameds](https://github.com/Hameds).\r\n- Ukrainian translation from [@osadchyi-s](https://github.com/osadchyi-s).\r\n\r\n### Changed\r\n- Start using \"changelog\" over \"change log\" since it's the common usage.\r\n- Start versioning based on the current English version at 0.3.0 to help\r\ntranslation authors keep things up-to-date.\r\n- Rewrite \"What makes unicorns cry?\" section.\r\n- Rewrite \"Ignoring Deprecations\" sub-section to clarify the ideal\r\n  scenario.\r\n- Improve \"Commit log diffs\" sub-section to further argument against\r\n  them.\r\n- Merge \"Why can’t people just use a git log diff?\" with \"Commit log\r\n  diffs\"\r\n- Fix typos in Simplified Chinese and Traditional Chinese translations.\r\n- Fix typos in Brazilian Portuguese translation.\r\n- Fix typos in Turkish translation.\r\n- Fix typos in Czech translation.\r\n- Fix typos in Swedish translation.\r\n- Improve phrasing in French translation.\r\n- Fix phrasing and spelling in German translation.\r\n\r\n### Removed\r\n- Section about \"changelog\" vs \"CHANGELOG\".\r\n\r";

            var result = ServiceUnderTest.GetReleaseHeader(releaseDataExample);

            Assert.AreEqual("1.0.0", result.Version);
            Assert.AreEqual(new DateTime(2017, 6, 20), result.Date);
        }

        [Test]
        public void Given_ReleasePlainText_When_GetChanges_Then_ChangesCollectionRetrived()
        {
            var releaseDataExample = "[1.0.0] - 2017-06-20\r\n### Added\r\n- New visual identity by [@tylerfortune8](https://github.com/tylerfortune8).\r\n- Version navigation.\r\n- Links to latest released version in previous versions.\r\n- \"Why keep a changelog?\" section.\r\n- \"Who needs a changelog?\" section.\r\n- \"How do I make a changelog?\" section.\r\n- \"Frequently Asked Questions\" section.\r\n- New \"Guiding Principles\" sub-section to \"How do I make a changelog?\".\r\n- Simplified and Traditional Chinese translations from [@tianshuo](https://github.com/tianshuo).\r\n- German translation from [@mpbzh](https://github.com/mpbzh) & [@Art4](https://github.com/Art4).\r\n- Italian translation from [@azkidenz](https://github.com/azkidenz).\r\n- Swedish translation from [@magol](https://github.com/magol).\r\n- Turkish translation from [@karalamalar](https://github.com/karalamalar).\r\n- French translation from [@zapashcanon](https://github.com/zapashcanon).\r\n- Brazilian Portugese translation from [@Webysther](https://github.com/Webysther).\r\n- Polish translation from [@amielucha](https://github.com/amielucha) & [@m-aciek](https://github.com/m-aciek).\r\n- Russian translation from [@aishek](https://github.com/aishek).\r\n- Czech translation from [@h4vry](https://github.com/h4vry).\r\n- Slovak translation from [@jkostolansky](https://github.com/jkostolansky).\r\n- Korean translation from [@pierceh89](https://github.com/pierceh89).\r\n- Croatian translation from [@porx](https://github.com/porx).\r\n- Persian translation from [@Hameds](https://github.com/Hameds).\r\n- Ukrainian translation from [@osadchyi-s](https://github.com/osadchyi-s).\r\n\r\n### Changed\r\n- Start using \"changelog\" over \"change log\" since it's the common usage.\r\n- Start versioning based on the current English version at 0.3.0 to help\r\ntranslation authors keep things up-to-date.\r\n- Rewrite \"What makes unicorns cry?\" section.\r\n- Rewrite \"Ignoring Deprecations\" sub-section to clarify the ideal\r\n  scenario.\r\n- Improve \"Commit log diffs\" sub-section to further argument against\r\n  them.\r\n- Merge \"Why can’t people just use a git log diff?\" with \"Commit log\r\n  diffs\"\r\n- Fix typos in Simplified Chinese and Traditional Chinese translations.\r\n- Fix typos in Brazilian Portuguese translation.\r\n- Fix typos in Turkish translation.\r\n- Fix typos in Czech translation.\r\n- Fix typos in Swedish translation.\r\n- Improve phrasing in French translation.\r\n- Fix phrasing and spelling in German translation.\r\n\r\n### Removed\r\n- Section about \"changelog\" vs \"CHANGELOG\".\r\n\r";

            var result = ServiceUnderTest.GetChanges(releaseDataExample);

            Assert.AreEqual(23, result[ChangeType.Added].Count());
            Assert.AreEqual(13, result[ChangeType.Changed].Count());
            Assert.AreEqual(1, result[ChangeType.Removed].Count());
        }

        [Test]
        public void Given_ReleasePlainText_When_ParseReleaseText_Then_ReleaseLinesParsed()
        {
            var releaseDataExample = "[1.0.0] - 2017-06-20\r\n### Added\r\n- New visual identity by [@tylerfortune8](https://github.com/tylerfortune8).\r\n- Version navigation.\r\n- Links to latest released version in previous versions.\r\n- \"Why keep a changelog?\" section.\r\n- \"Who needs a changelog?\" section.\r\n- \"How do I make a changelog?\" section.\r\n- \"Frequently Asked Questions\" section.\r\n- New \"Guiding Principles\" sub-section to \"How do I make a changelog?\".\r\n- Simplified and Traditional Chinese translations from [@tianshuo](https://github.com/tianshuo).\r\n- German translation from [@mpbzh](https://github.com/mpbzh) & [@Art4](https://github.com/Art4).\r\n- Italian translation from [@azkidenz](https://github.com/azkidenz).\r\n- Swedish translation from [@magol](https://github.com/magol).\r\n- Turkish translation from [@karalamalar](https://github.com/karalamalar).\r\n- French translation from [@zapashcanon](https://github.com/zapashcanon).\r\n- Brazilian Portugese translation from [@Webysther](https://github.com/Webysther).\r\n- Polish translation from [@amielucha](https://github.com/amielucha) & [@m-aciek](https://github.com/m-aciek).\r\n- Russian translation from [@aishek](https://github.com/aishek).\r\n- Czech translation from [@h4vry](https://github.com/h4vry).\r\n- Slovak translation from [@jkostolansky](https://github.com/jkostolansky).\r\n- Korean translation from [@pierceh89](https://github.com/pierceh89).\r\n- Croatian translation from [@porx](https://github.com/porx).\r\n- Persian translation from [@Hameds](https://github.com/Hameds).\r\n- Ukrainian translation from [@osadchyi-s](https://github.com/osadchyi-s).\r\n\r\n### Changed\r\n- Start using \"changelog\" over \"change log\" since it's the common usage.\r\n- Start versioning based on the current English version at 0.3.0 to help\r\ntranslation authors keep things up-to-date.\r\n- Rewrite \"What makes unicorns cry?\" section.\r\n- Rewrite \"Ignoring Deprecations\" sub-section to clarify the ideal\r\n  scenario.\r\n- Improve \"Commit log diffs\" sub-section to further argument against\r\n  them.\r\n- Merge \"Why can’t people just use a git log diff?\" with \"Commit log\r\n  diffs\"\r\n- Fix typos in Simplified Chinese and Traditional Chinese translations.\r\n- Fix typos in Brazilian Portuguese translation.\r\n- Fix typos in Turkish translation.\r\n- Fix typos in Czech translation.\r\n- Fix typos in Swedish translation.\r\n- Improve phrasing in French translation.\r\n- Fix phrasing and spelling in German translation.\r\n\r\n### Removed\r\n- Section about \"changelog\" vs \"CHANGELOG\".\r\n\r";

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
        public async Task Given_ReleasePlainText_When_Load_Then_ReleasesRetrived()
        {
            var result = await ServiceUnderTest.Load();

            Assert.AreEqual(12, result.Count());

            var version100 = result.First(x => x.Identifier == "1.0.0");
            Assert.AreEqual("1.0.0", version100.Identifier);
            Assert.AreEqual(new DateTime(2017, 6, 20), version100.Date);
            Assert.AreEqual(23, version100.Additions.Count());
            Assert.AreEqual(13, version100.Changes.Count());
            Assert.AreEqual(1, version100.Eliminated.Count());
            Assert.AreEqual(0, version100.Deprecations.Count());
            Assert.AreEqual(0, version100.Fixes.Count());
            Assert.AreEqual(0, version100.Secured.Count());

            var version030 = result.First(x => x.Identifier == "0.3.0");
            Assert.AreEqual("0.3.0", version030.Identifier);
            Assert.AreEqual(new DateTime(2015, 12, 3), version030.Date);
            Assert.AreEqual(3, version030.Additions.Count());
            Assert.AreEqual(0, version030.Changes.Count());
            Assert.AreEqual(0, version030.Eliminated.Count());
            Assert.AreEqual(0, version030.Deprecations.Count());
            Assert.AreEqual(0, version030.Fixes.Count());
            Assert.AreEqual(0, version030.Secured.Count());

            var version020 = result.First(x => x.Identifier == "0.2.0");
            Assert.AreEqual("0.2.0", version020.Identifier);
            Assert.AreEqual(new DateTime(2015, 10, 06), version020.Date);
            Assert.AreEqual(0, version020.Additions.Count());
            Assert.AreEqual(1, version020.Changes.Count());
            Assert.AreEqual(0, version020.Eliminated.Count());
            Assert.AreEqual(0, version020.Deprecations.Count());
            Assert.AreEqual(0, version020.Fixes.Count());
            Assert.AreEqual(0, version020.Secured.Count());

            var version010 = result.First(x => x.Identifier == "0.1.0");
            Assert.AreEqual("0.1.0", version010.Identifier);
            Assert.AreEqual(new DateTime(2015, 10, 06), version010.Date);
            Assert.AreEqual(1, version010.Additions.Count());
            Assert.AreEqual(2, version010.Changes.Count());
            Assert.AreEqual(0, version010.Eliminated.Count());
            Assert.AreEqual(0, version010.Deprecations.Count());
            Assert.AreEqual(0, version010.Fixes.Count());
            Assert.AreEqual(0, version010.Secured.Count());

            var version008 = result.First(x => x.Identifier == "0.0.8");
            Assert.AreEqual("0.0.8", version008.Identifier);
            Assert.AreEqual(new DateTime(2015, 02, 17), version008.Date);
            Assert.AreEqual(0, version008.Additions.Count());
            Assert.AreEqual(2, version008.Changes.Count());
            Assert.AreEqual(0, version008.Eliminated.Count());
            Assert.AreEqual(0, version008.Deprecations.Count());
            Assert.AreEqual(2, version008.Fixes.Count());
            Assert.AreEqual(0, version008.Secured.Count());

            var version007 = result.First(x => x.Identifier == "0.0.7");
            Assert.AreEqual("0.0.7", version007.Identifier);
            Assert.AreEqual(new DateTime(2015, 02, 16), version007.Date);
            Assert.AreEqual(1, version007.Additions.Count());
            Assert.AreEqual(1, version007.Changes.Count());
            Assert.AreEqual(0, version007.Eliminated.Count());
            Assert.AreEqual(0, version007.Deprecations.Count());
            Assert.AreEqual(1, version007.Fixes.Count());
            Assert.AreEqual(0, version007.Secured.Count());

            var version006 = result.First(x => x.Identifier == "0.0.6");
            Assert.AreEqual("0.0.6", version006.Identifier);
            Assert.AreEqual(new DateTime(2014, 12, 12), version006.Date);
            Assert.AreEqual(1, version006.Additions.Count());
            Assert.AreEqual(0, version006.Changes.Count());
            Assert.AreEqual(0, version006.Eliminated.Count());
            Assert.AreEqual(0, version006.Deprecations.Count());
            Assert.AreEqual(0, version006.Fixes.Count());
            Assert.AreEqual(0, version006.Secured.Count());

            var version005 = result.First(x => x.Identifier == "0.0.5");
            Assert.AreEqual("0.0.5", version005.Identifier);
            Assert.AreEqual(new DateTime(2014, 8, 9), version005.Date);
            Assert.AreEqual(2, version005.Additions.Count());
            Assert.AreEqual(0, version005.Changes.Count());
            Assert.AreEqual(0, version005.Eliminated.Count());
            Assert.AreEqual(0, version005.Deprecations.Count());
            Assert.AreEqual(0, version005.Fixes.Count());
            Assert.AreEqual(0, version005.Secured.Count());

            var version004 = result.First(x => x.Identifier == "0.0.4");
            Assert.AreEqual("0.0.4", version004.Identifier);
            Assert.AreEqual(new DateTime(2014, 8, 9), version004.Date);
            Assert.AreEqual(1, version004.Additions.Count());
            Assert.AreEqual(1, version004.Changes.Count());
            Assert.AreEqual(1, version004.Eliminated.Count());
            Assert.AreEqual(0, version004.Deprecations.Count());
            Assert.AreEqual(0, version004.Fixes.Count());
            Assert.AreEqual(0, version004.Secured.Count());

            var version003 = result.First(x => x.Identifier == "0.0.3");
            Assert.AreEqual("0.0.3", version003.Identifier);
            Assert.AreEqual(new DateTime(2014, 8, 9), version003.Date);
            Assert.AreEqual(1, version003.Additions.Count());
            Assert.AreEqual(0, version003.Changes.Count());
            Assert.AreEqual(0, version003.Eliminated.Count());
            Assert.AreEqual(0, version003.Deprecations.Count());
            Assert.AreEqual(0, version003.Fixes.Count());
            Assert.AreEqual(0, version003.Secured.Count());

            var version002 = result.First(x => x.Identifier == "0.0.2");
            Assert.AreEqual("0.0.2", version002.Identifier);
            Assert.AreEqual(new DateTime(2014, 7, 10), version002.Date);
            Assert.AreEqual(1, version002.Additions.Count());
            Assert.AreEqual(0, version002.Changes.Count());
            Assert.AreEqual(0, version002.Eliminated.Count());
            Assert.AreEqual(0, version002.Deprecations.Count());
            Assert.AreEqual(0, version002.Fixes.Count());
            Assert.AreEqual(0, version002.Secured.Count());

            var version001 = result.First(x => x.Identifier == "0.0.1");
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
            ServiceUnderTest = new ReleaseFileParser(new FileParserSettings("wrongfile.md"));

            Assert.ThrowsAsync<ReleaseRetrievingException>(() => ServiceUnderTest.Load());
        }

    }
}