using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringManipulation
{
    /// <summary>
    /// Untility class containing methods to help with the manipulation of the String class.
    /// </summary>
    public static class StringManipulationUtilities
    {
        /// <summary>
        /// Method to create a list of all words in a given string.
        /// Note: Punctuation is considered part of the 'word'.
        /// </summary>
        /// <param name="input">String form which to finds the words.</param>
        /// <returns>List of words found in the string.</returns>
        public static List<String> FindWords (this string input)
        {
            if (null == input)
            {
                throw new ArgumentNullException();
            }

            var stringList = new List<String>();

            if (0 != input.Length)
            {
                var charArray = input.ToCharArray();
                var stringBuilder = new StringBuilder();

                for (int i = 0; i < charArray.Length; ++i)
                {
                    //Keep appending until we run into a space character.
                    if (' ' != charArray[i])
                    {
                        stringBuilder.Append(charArray[i]);
                    }
                    else
                    {
                        stringList.Add(stringBuilder.ToString());
                        stringBuilder.Clear();
                    }
                }

                //Purge the last word out that may be in the string builder.
                stringList.Add(stringBuilder.ToString());
            }

            return stringList;
        }

        /// <summary>
        /// Method to reverse the characters in a string.
        /// </summary>
        /// <param name="input">String to reverse.</param>
        /// <returns>The given string, reversed.</returns>
        public static String ReverseString(this string input)
        {
            if (null == input)
            {
                throw new ArgumentNullException();
            }

            return new String(input.ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// Method that joins all the strings in an IEnumerable<String> with the given seperator 
        /// </summary>
        /// <param name="input">The collection of strings to join together.</param>
        /// <returns>The collection of strings joined together with the seperator.</returns>
        public static String JoinStrings(this IEnumerable<String> input, string seperator)
        {
            if (null == input)
            {
                throw new ArgumentNullException();
            }

            if (0 == input.Count())
            {
                return String.Empty;
            }

            var stringBuilder = new StringBuilder();
            var lastEntry = input.Last();

            foreach (var str in input)
            {
                stringBuilder.Append(str);
                
                //We only want to apply the seperator if we are not on the last word in the collection
                if(lastEntry != str)
                {
                    stringBuilder.Append(seperator);
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Inverts all of the words in a string.
        /// The order of the words will stay the same, but the characters will be inversed.
        /// </summary>
        /// <param name="input">String you want to inverse the words in.</param>
        /// <returns>String with all the characters in each word inversed.</returns>
        public static String InvertWords(this string input)
        {
            var wordsInString = input.FindWords();
            var reversedWords = new List<String>();

            foreach (var word in input.FindWords())
            {
                reversedWords.Add(word.ReverseString());
            }

            return reversedWords.JoinStrings(" ");
        }
    }
}
