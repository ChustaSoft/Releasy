namespace ChustaSoft.Releasy.Tests
{
    internal class ChangelogTestHelper
    {

        internal static string GetChangelogStringWithUnreleasedSection()
        {
            return @"
                # Changelog
                All notable changes to this project will be documented in this file.

                The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
                and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).
                
                
                ## [Unreleased]
                ### Added
                - Unreleased feature 1
                - Unreleased feature 2
                ### Fixed
                - Fix done 1

                ## [1.0.0] - 2017-06-20
                ### Added
                - New visual identity by [@tylerfortune8](https://github.com/tylerfortune8).
                - Version navigation.
                - Links to latest released version in previous versions.
                - Why keep a changelog? section.
                - Who needs a changelog? section.
                - How do I make a changelog? section.
                - Frequently Asked Questions section.
                - New Guiding Principles sub - section to How do I make a changelog?.
                - Simplified and Traditional Chinese translations from[@tianshuo](https://github.com/tianshuo).
                - German translation from[@mpbzh](https://github.com/mpbzh) & [@Art4](https://github.com/Art4).
                - Italian translation from[@azkidenz](https://github.com/azkidenz).
                - Swedish translation from[@magol](https://github.com/magol).
                - Turkish translation from[@karalamalar](https://github.com/karalamalar).
                - French translation from[@zapashcanon](https://github.com/zapashcanon).
                - Brazilian Portugese translation from[@Webysther](https://github.com/Webysther).
                - Polish translation from[@amielucha](https://github.com/amielucha) & [@m-aciek](https://github.com/m-aciek).
                - Russian translation from[@aishek](https://github.com/aishek).
                - Czech translation from[@h4vry](https://github.com/h4vry).
                - Slovak translation from[@jkostolansky](https://github.com/jkostolansky).
                - Korean translation from[@pierceh89](https://github.com/pierceh89).
                - Croatian translation from[@porx](https://github.com/porx).
                - Persian translation from[@Hameds](https://github.com/Hameds).
                - Ukrainian translation from[@osadchyi - s](https://github.com/osadchyi-s).
                ";
        }

        internal static string GetChangelogStringWithoutUnreleasedSection()
        {
            return @"
                # Changelog
                All notable changes to this project will be documented in this file.

                The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
                and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


                ## [1.0.0] - 2017-06-20
                ### Added
                - New visual identity by [@tylerfortune8](https://github.com/tylerfortune8).
                - Version navigation.
                - Links to latest released version in previous versions.
                - Why keep a changelog? section.
                - Who needs a changelog? section.
                - How do I make a changelog? section.
                - Frequently Asked Questions section.
                - New Guiding Principles sub - section to How do I make a changelog?.
                - Simplified and Traditional Chinese translations from[@tianshuo](https://github.com/tianshuo).
                - German translation from[@mpbzh](https://github.com/mpbzh) & [@Art4](https://github.com/Art4).
                - Italian translation from[@azkidenz](https://github.com/azkidenz).
                - Swedish translation from[@magol](https://github.com/magol).
                - Turkish translation from[@karalamalar](https://github.com/karalamalar).
                - French translation from[@zapashcanon](https://github.com/zapashcanon).
                - Brazilian Portugese translation from[@Webysther](https://github.com/Webysther).
                - Polish translation from[@amielucha](https://github.com/amielucha) & [@m-aciek](https://github.com/m-aciek).
                - Russian translation from[@aishek](https://github.com/aishek).
                - Czech translation from[@h4vry](https://github.com/h4vry).
                - Slovak translation from[@jkostolansky](https://github.com/jkostolansky).
                - Korean translation from[@pierceh89](https://github.com/pierceh89).
                - Croatian translation from[@porx](https://github.com/porx).
                - Persian translation from[@Hameds](https://github.com/Hameds).
                - Ukrainian translation from[@osadchyi - s](https://github.com/osadchyi-s).
                ";
        }

        internal static string GetReleaseLineText()
        {
            return "[1.0.0] - 2017-06-20\r\n### Added\r\n- New visual identity by [@tylerfortune8](https://github.com/tylerfortune8).\r\n- Version navigation.\r\n- Links to latest released version in previous versions.\r\n- \"Why keep a changelog?\" section.\r\n- \"Who needs a changelog?\" section.\r\n- \"How do I make a changelog?\" section.\r\n- \"Frequently Asked Questions\" section.\r\n- New \"Guiding Principles\" sub-section to \"How do I make a changelog?\".\r\n- Simplified and Traditional Chinese translations from [@tianshuo](https://github.com/tianshuo).\r\n- German translation from [@mpbzh](https://github.com/mpbzh) & [@Art4](https://github.com/Art4).\r\n- Italian translation from [@azkidenz](https://github.com/azkidenz).\r\n- Swedish translation from [@magol](https://github.com/magol).\r\n- Turkish translation from [@karalamalar](https://github.com/karalamalar).\r\n- French translation from [@zapashcanon](https://github.com/zapashcanon).\r\n- Brazilian Portugese translation from [@Webysther](https://github.com/Webysther).\r\n- Polish translation from [@amielucha](https://github.com/amielucha) & [@m-aciek](https://github.com/m-aciek).\r\n- Russian translation from [@aishek](https://github.com/aishek).\r\n- Czech translation from [@h4vry](https://github.com/h4vry).\r\n- Slovak translation from [@jkostolansky](https://github.com/jkostolansky).\r\n- Korean translation from [@pierceh89](https://github.com/pierceh89).\r\n- Croatian translation from [@porx](https://github.com/porx).\r\n- Persian translation from [@Hameds](https://github.com/Hameds).\r\n- Ukrainian translation from [@osadchyi-s](https://github.com/osadchyi-s).\r\n\r\n### Changed\r\n- Start using \"changelog\" over \"change log\" since it's the common usage.\r\n- Start versioning based on the current English version at 0.3.0 to help\r\ntranslation authors keep things up-to-date.\r\n- Rewrite \"What makes unicorns cry?\" section.\r\n- Rewrite \"Ignoring Deprecations\" sub-section to clarify the ideal\r\n  scenario.\r\n- Improve \"Commit log diffs\" sub-section to further argument against\r\n  them.\r\n- Merge \"Why can’t people just use a git log diff?\" with \"Commit log\r\n  diffs\"\r\n- Fix typos in Simplified Chinese and Traditional Chinese translations.\r\n- Fix typos in Brazilian Portuguese translation.\r\n- Fix typos in Turkish translation.\r\n- Fix typos in Czech translation.\r\n- Fix typos in Swedish translation.\r\n- Improve phrasing in French translation.\r\n- Fix phrasing and spelling in German translation.\r\n\r\n### Removed\r\n- Section about \"changelog\" vs \"CHANGELOG\".\r\n\r";
        }

    }
}
