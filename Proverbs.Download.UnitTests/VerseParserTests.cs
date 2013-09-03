﻿using FluentAssertions;
using NUnit.Framework;

namespace Proverbs.Download.UnitTests
{
    [TestFixture]
    public class VerseParserTests
    {
        [Test]
        public void given_single_verse_when_parsing_should_return_correct_verse()
        {
            const string text = @"[12:15]The way of a fool is right in his own eyes,
    but a wise man listens to advice.";

            var parser = new VerseParser();
            var verses = parser.Parse(text);

            var verse = verses[0];
            verse.ChapterNumber.Should().Be(12);
            verse.VerseNumber.Should().Be(15);
            verse.Text.Should().Be(@"The way of a fool is right in his own eyes,
    but a wise man listens to advice.");
        }

        [Test]
        public void given_multiple_verses_when_parsing_should_return_correct_number_of_verses()
        {
            const string text = @"[1:1]The proverbs of Solomon, son of David, king of Israel:

  [2]To know wisdom and instruction,
    to understand words of insight,
  [3]to receive instruction in wise dealing,
    in righteousness, justice, and equity;
  [4]to give prudence to the simple,
    knowledge and discretion to the youth--
  [5]Let the wise hear and increase in learning,
    and the one who understands obtain guidance,
  [6]to understand a proverb and a saying,
    the words of the wise and their riddles.

  [7]The fear of the LORD is the beginning of knowledge;
    fools despise wisdom and instruction.";

            var parser = new VerseParser();
            var verses = parser.Parse(text);

            verses.Count.Should().Be(7);
        }

        [Test]
        public void given_multiple_verses_when_parsing_should_return_correct_verse_information()
        {
            const string text = @"[12:1]Whoever loves discipline loves knowledge,
    but he who hates reproof is stupid.
  [2]A good man obtains favor from the LORD,
    but a man of evil devices he condemns.
  [3]No one is established by wickedness,
    but the root of the righteous will never be moved.
  [4]An excellent wife is the crown of her husband,
    but she who brings shame is like rottenness in his bones.
  [5]The thoughts of the righteous are just;
    the counsels of the wicked are deceitful.
  [6]The words of the wicked lie in wait for blood,
    but the mouth of the upright delivers them.
  [7]The wicked are overthrown and are no more,
    but the house of the righteous will stand.
  [8]A man is commended according to his good sense,
    but one of twisted mind is despised.
  [9]Better to be lowly and have a servant
    than to play the great man and lack bread.
  [10]Whoever is righteous has regard for the life of his beast,
    but the mercy of the wicked is cruel.
  [11]Whoever works his land will have plenty of bread,
    but he who follows worthless pursuits lacks sense.
  [12]Whoever is wicked covets the spoil of evildoers,
    but the root of the righteous bears fruit.
  [13]An evil man is ensnared by the transgression of his lips,
    but the righteous escapes from trouble.
  [14]From the fruit of his mouth a man is satisfied with good,
    and the work of a man's hand comes back to him.
  [15]The way of a fool is right in his own eyes,
    but a wise man listens to advice.
  [16]The vexation of a fool is known at once,
    but the prudent ignores an insult.
  [17]Whoever speaks the truth gives honest evidence,
    but a false witness utters deceit.
  [18]There is one whose rash words are like sword thrusts,
    but the tongue of the wise brings healing.
  [19]Truthful lips endure forever,
    but a lying tongue is but for a moment.
  [20]Deceit is in the heart of those who devise evil,
    but those who plan peace have joy.
  [21]No ill befalls the righteous,
    but the wicked are filled with trouble.
  [22]Lying lips are an abomination to the LORD,
    but those who act faithfully are his delight.
  [23]A prudent man conceals knowledge,
    but the heart of fools proclaims folly.
  [24]The hand of the diligent will rule,
    while the slothful will be put to forced labor.
  [25]Anxiety in a man's heart weighs him down,
    but a good word makes him glad.
  [26]One who is righteous is a guide to his neighbor,
    but the way of the wicked leads them astray.
  [27]Whoever is slothful will not roast his game,
    but the diligent man will get precious wealth.
  [28]In the path of righteousness is life,
    and in its pathway there is no death.";

            var parser = new VerseParser();
            var verses = parser.Parse(text);

            var eleventhVerse = verses[10];
            eleventhVerse.ChapterNumber.Should().Be(12);
            eleventhVerse.VerseNumber.Should().Be(11);
            eleventhVerse.Text.Should().Be(@"Whoever works his land will have plenty of bread,
    but he who follows worthless pursuits lacks sense.");
        }
    }
}
