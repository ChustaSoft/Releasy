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

            var result =  ServiceUnderTest.ParseReleaseText(releaseDataExample);

            Assert.AreEqual("1.0.0", result.Identifier);
            Assert.AreEqual(new DateTime(2017, 6, 20), result.Date);
            Assert.AreEqual(23, result.Additions.Count());
            Assert.AreEqual(13, result.Changes.Count());
            Assert.AreEqual(1, result.Eliminated.Count());
            Assert.AreEqual(0, result.Deprecations.Count());
            Assert.AreEqual(0, result.Fixes.Count());
            Assert.AreEqual(0, result.Secured.Count());
        }

    }
}