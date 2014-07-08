using System;
using System.Collections.Generic;
using System.Linq;
using MinimalLinkList;
using NUnit.Framework;

namespace ReadifyInterviewQuestion_1_Tests
{
    /// <summary>
    /// I attempt to have all of my tests behave in a 'Who', 'Then', 'Then' Pattern in method naming scheme as well as behavior.
    /// It makes the method name clear enough that it should avoid the need to overdocumentation in the
    /// test code as well as keep the codes as short as possible
    /// </summary>
    [TestFixture]
    public class Question1_Tests
    {
        //Test data
        private static List<int> TEST_DATA = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        [Test, ExpectedException(typeof(ArgumentException))]
        public void LinkedList_InsertNull_Throws()
        {
            var linkedList = new SimpleLinkedList<object>();

            linkedList.Add(null);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void LinkedList_RemoveNull_Throws()
        {
            var linkedList = new SimpleLinkedList<object>();

            linkedList.Remove(null);
        }

        [Test, ExpectedException(typeof(IndexOutOfRangeException))]
        public void LinkedList_IndexOpOutOfRangeLow_Throws()
        {
            var linkedList = new SimpleLinkedList<int>();
            linkedList.Add(1);

            var result = linkedList[-1];
        }

        [Test, ExpectedException(typeof(IndexOutOfRangeException))]
        public void LinkedList_IndexOpOutOfRangeHigh_Throws()
        {
            var linkedList = new SimpleLinkedList<int>();
            linkedList.Add(1);

            var result = linkedList[1];
        }

        [Test]
        public void LinkedList_AddItems_CorrectCount()
        {
            var linkedList = new SimpleLinkedList<int>();
            TEST_DATA.ForEach(x => linkedList.Add(x));

            Assert.AreEqual(TEST_DATA.Count, linkedList.Count);
        }

        [Test]
        public void LinkedList_RemoveItem_CorrectCount()
        {
            var linkedList = new SimpleLinkedList<int>();
            TEST_DATA.ForEach(x => linkedList.Add(x));

            linkedList.Remove(TEST_DATA.First());
            TEST_DATA.Remove(TEST_DATA.First());

            Assert.AreEqual(TEST_DATA.Count, linkedList.Count);
        }

        [Test]
        public void LinkedList_IndexOpLowerLimit_CorrectReturn()
        {
            var linkedList = new SimpleLinkedList<int>();
            TEST_DATA.ForEach(x => linkedList.Add(x));

            Assert.AreEqual(TEST_DATA.First(), linkedList[0]);
        }

        [Test]
        public void LinkedList_IndexOpUpperLimit_CorrectReturn()
        {
            var linkedList = new SimpleLinkedList<int>();
            TEST_DATA.ForEach(x => linkedList.Add(x));

            Assert.AreEqual(TEST_DATA.Last(), linkedList[TEST_DATA.Count - 1]);
        }

        [Test]
        public void LinkedList_RemoveFirstItem_ItemRemoved()
        {
            var linkedList = new SimpleLinkedList<int>();
            TEST_DATA.ForEach(x => linkedList.Add(x));

            int valueToRemove = TEST_DATA.First();
            int listCurrentCount = linkedList.Count;

            Assert.IsTrue(linkedList.Remove(valueToRemove));
            Assert.IsFalse(linkedList.Contains(valueToRemove)); //Linq
            Assert.IsFalse(linkedList.ContainsValue(valueToRemove)); //Own Implementation
        }

        [Test]
        public void LinkedList_RemoveLastItem_ItemRemoved()
        {
            var linkedList = new SimpleLinkedList<int>();
            TEST_DATA.ForEach(x => linkedList.Add(x));

            int valueToRemove = TEST_DATA.Last();
            int listCurrentCount = linkedList.Count;

            Assert.IsTrue(linkedList.Remove(valueToRemove));
            Assert.IsFalse(linkedList.ContainsValue(valueToRemove)); //Linq
            Assert.IsFalse(linkedList.ContainsValue(valueToRemove)); //Own Implementation
        }

        [Test]
        public void LinkedList_ClearList_ListEmpty()
        {
            var linkedList = new SimpleLinkedList<int>();
            TEST_DATA.ForEach(x => linkedList.Add(x));

            linkedList.Clear();

            Assert.AreEqual(0, linkedList.Count);
        }
    }
}
