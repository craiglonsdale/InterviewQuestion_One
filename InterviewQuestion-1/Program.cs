using System;
using System.Collections.Generic;
using System.Linq;
using MinimalLinkList;

namespace ReadifyInterviewQuestions
{
    /// <summary>
    /// I have implemented a VERY MINIMAL linked list.
    /// There are a couple of additional methods that were not necessary for this implementation, but I
    /// wanted the list to be atleast partially functional.
    /// I was able to demonstrate some breadth and depth of testing by having these couple of extra mmethods.
    /// </summary>
    class ReadifyInterviewQuestionOne
    {
        //Test data to seed to linked list with
        private static List<int> m_inputData = new List<int>{ 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        static void Main(string[] args)
        {
            var linkedList = new SimpleLinkedList<int>();

            m_inputData.ForEach(x => linkedList.Add(x));

            Console.Out.WriteLine("Element at 5 via Index Operator {0}", linkedList[index: 5]);
            Console.Out.WriteLine("Element at 5 via Linq Operator {0}", FindElementViaLinq(linkedList, entryNumber: 5));

            Console.ReadLine();
        }

        /// <summary>
        /// I wasn't sure that if the 'No Collection Components' included Linq.
        /// I put this in here just in case, but also implement the Index Operator on my linked list to to it another way.
        /// </summary>
        /// <param name="linkedList">LinkedList to search through</param>
        /// <param name="entryNumber">Element number in the list to find.</param>
        /// <returns>The value of the item at entryNumber</returns>
        private static int FindElementViaLinq(ILinkedList<int> linkedList, int entryNumber)
        {
            return linkedList.ElementAt(entryNumber);
        }
    }
}
