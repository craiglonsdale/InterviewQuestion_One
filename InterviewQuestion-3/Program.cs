using System;
using StringManipulation;

namespace ReadifyInterviewQuestions
{
    class ReadifyInterviewQuestionThree
    {
        private static String testString = "cat and dog";

        static void Main(string[] args)
        {
            Console.Out.WriteLine("'{0}' inverts to '{1}'", testString, testString.InvertWords());
            Console.ReadLine();
        }
    }
}
