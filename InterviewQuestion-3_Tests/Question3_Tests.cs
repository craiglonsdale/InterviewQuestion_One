using System;
using System.Linq;
using NUnit.Framework;
using StringManipulation;
using System.Collections.Generic;

namespace ReadifyInterviewQuestion_3_Tests
{
    /// <summary>
    /// I attempt to have all of my tests behave in a 'Who', 'Then', 'Then' Pattern in method naming scheme as well as behavior.
    /// It makes the method name clear enough that it should avoid the need to overdocumentation in the
    /// test code as well as keep the codes as short as possible
    /// </summary>
    [TestFixture]
    public class Question3_Tests
    {
        [Test]
        public void FindWord_NoPunctuation_ListOfWordsReturned()
        {
            var testString = "One Two Three";
            
            var result = testString.FindWords();
            var expectedResult = testString.Split(' ');

            Assert.AreEqual(expectedResult.Count(), result.Count);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindWord_Punctuation_ListOfWordsReturned()
        {
            var testString = "One, Two, Three";

            var result = testString.FindWords();
            var expectedResult = testString.Split(' ');

            Assert.AreEqual(expectedResult.Count(), result.Count);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindWord_TrailingPunctuation_ListOfWordsReturned()
        {
            var testString = "One, Two, Three!";

            var result = testString.FindWords();
            var expectedResult = testString.Split(' ');

            Assert.AreEqual(expectedResult.Count(), result.Count);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindWord_LeadingPunctuation_ListOfWordsReturned()
        {
            var testString = "!One, Two, Three";

            var result = testString.FindWords();
            var expectedResult = testString.Split(' ');

            Assert.AreEqual(expectedResult.Count(), result.Count);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindWord_TrailingWhitespace_ListOfWordsReturned()
        {
            var testString = "One Two Three ";

            var result = testString.FindWords();
            var expectedResult = testString.Split(' ');

            Assert.AreEqual(expectedResult.Count(), result.Count);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindWord_LeadingWhitespace_ListOfWordsReturned()
        {
            var testString = " One Two Three";

            var result = testString.FindWords();
            var expectedResult = testString.Split(' ');

            Assert.AreEqual(expectedResult.Count(), result.Count);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindWord_N_Whitespace_ListOfWordsReturned()
        {
            var testString = "One     Two        Three";

            var result = testString.FindWords();
            var expectedResult = testString.Split(' ');

            Assert.AreEqual(expectedResult.Count(), result.Count);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindWord_EmptyString_EmptyList()
        {
            var test = String.Empty;

            Assert.IsEmpty(test.FindWords());
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void FindWord_NullString_EmptyListReturned()
        {
            String test = null;
            test.FindWords();
        }

        [Test]
        public void ReverseWord_NoPunctuation_ReversedWordReturned()
        {
            var testString = "Reverse";
            Assert.AreEqual(testString.Reverse(), testString.ReverseString());
        }

        [Test]
        public void ReverseString_Punctuation_ReversedWordReturned()
        {
            var testString = "!Reverse¡";
            Assert.AreEqual(testString.Reverse(), testString.ReverseString());
        }

        [Test]
        public void ReverseString_SingleLetter_ReversedWordReturned()
        {
            var testString = "R";
            Assert.AreEqual(testString.Reverse(), testString.ReverseString());
        }

        [Test]
        public void ReverseString_EmptyString_EmptyStringReturned()
        {
            var testString = String.Empty;
            Assert.AreEqual(String.Empty, testString.ReverseString());
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ReverseString_NullString_Throws()
        {
            string testString = null;
            testString.ReverseString();
        }

        [Test]
        public void JoinStrings_NoPunctuation_CorrectStringReturned()
        {
            var testStringList = new List<String> { "One", "Two", "Three" };

            var result = testStringList.JoinStrings(" ");
            var expectedResult = String.Join(" ", testStringList);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void JoinStrings_EmptyList_EmptyStringReturned()
        {
            var testStringList = new List<String>();

            var result = testStringList.JoinStrings(" ");

            Assert.AreEqual(String.Empty, result);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void JoinStrings_NullList_Throws()
        {
            List<string> testStringList = null;

            var result = testStringList.JoinStrings(" ");
        }

    }
}
