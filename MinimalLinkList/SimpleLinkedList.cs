using System;
using System.Collections.Generic;
namespace MinimalLinkList
{
    /// <summary>
    /// Internal class that holds a single value as a node in the linked list
    /// </summary>
    /// <typeparam name="K">Type to be stored in this node</typeparam>
    class LinkedListNode<K>
    {
        /// <summary>
        /// Read-only value for this node.
        /// </summary>
        public readonly K Value;

        /// <summary>
        /// Constructor for a LinkedListNode.
        /// Once value has been set it *CAN NOT* be modified
        /// </summary>
        /// <param name="value">Value to assign to this node.</param>
        public LinkedListNode(K value)
        {
            Value = value;
        }

        /// <summary>
        /// Link to the next value to follows this one.
        /// Defaults to 'null'
        /// </summary>
        public LinkedListNode<K> Next = null; 
    }

    /// <summary>
    /// Interface for a very basic LinkList class.
    /// There is much functionality not implemented, just enough to demonstrate that the basics work.
    /// </summary>
    /// <typeparam name="T">Type of values for this LinkedList to contain.</typeparam>
    public class SimpleLinkedList<T> : ILinkedList<T>
    {
        /// <summary>
        /// Root node for the linked list.
        /// </summary>
        private LinkedListNode<T> m_rootNode = null;

        /// <summary>
        /// Last node in the linked list.
        /// </summary>
        private LinkedListNode<T> m_tailNode = null;

        /// <summary>
        /// Adds an value to the tail of the linked list.
        /// </summary>
        /// <param name="value">Value of type 'T' that needs to be added to the tail.</param>
        public void Add(T value)
        {
            if (null == value)
            {
                throw new ArgumentException("Can not add a null value to the linked list.");
            }

            var item = new LinkedListNode<T>(value);
            
            //Check it we need to update the root or tail node
            if (null == m_rootNode)
            {
                m_rootNode = item;
            }

            if (null != m_tailNode)
            {
                m_tailNode.Next = item;
            }

            m_tailNode = item;
            ++Count;
        }

        /// <summary>
        /// Removes an value from the linked list.
        /// Note: That the first matching value will be removed.
        /// </summary>
        /// <param name="value">Value of type 'T' that needs to be removed.</param>
        public bool Remove(T value)
        {
            //Some basic error checks to make sure we have a value to remove and that there are
            //values in the list.
            if (null == value)
            {
                throw new ArgumentException("Can not remove a null value to the linked list.");
            }

            if (null == m_rootNode)
            {
                return false;
            }

            //Check first value
            var item = m_rootNode;

            if (item.Value.Equals(value))
            {
                //If we find that the first value matches, remove it.
                m_rootNode = item.Next;
                --Count;

                //If we are out of items, set the tail to null
                if (Count == 0)
                {
                    m_tailNode = null;
                }

                return true;
            }

            //If we didn't hit on the first node, check the rest.
            while (null != item.Next)
            {
                if (item.Next.Value.Equals(value))
                {
                    //Since we are looking at the 'Next' value of the current node, we will need to
                    //create a link to the Link that follows that.
                    item.Next = item.Next.Next;
                    --Count;

                    //If there are no items, this needs to be the tail
                    if (null == item.Next)
                    {
                        m_tailNode = item;
                    }

                    return true;
                }

                //Continue the search.
                item = item.Next;
            }

            return false;
        }

        /// <summary>
        /// The number of elements in the collection.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Removes all nodes from the LinkedList.
        /// Sets all values back to default values;
        /// </summary>
        public void Clear()
        {
            m_rootNode = null;
            m_tailNode = null;
            Count = 0;
        }

        /// <summary>
        /// Returns whether this LinkedList contains the given value.
        /// </summary>
        /// <param name="value">Value of type 'T' to look for.</param>
        /// <returns>True if the value is found, false othewrwise.</returns>
        public bool ContainsValue(T value)
        {
            //Get the root node
            var item = m_rootNode;

            while (null != item)
            {
                if (item.Value.Equals(value))
                {
                    return true;
                }

                item = item.Next;
            }

            return false;
        }

        /// <summary>
        /// Implementation of the index operator for the LinkedList.
        /// </summary>
        /// <param name="index">The index from which you want to get a value.</param>
        /// <returns>Value of type 'T' that was at 'index'</returns>
        public T this[int index] 
        { 
            get
            {
                //Check that the index fall within a value range
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                //Get the root node
                var item = m_rootNode;

                //If we only want the first item, return it
                if (0 == index)
                {
                    return item.Value;
                }

                for (int i = 0; i < index; i++)
                {                      
                    item = item.Next;
                }

                return item.Value;
            }
        }

        /// <summary>
        /// Enumerate through all nodes in the LinkedList
        /// </summary>
        /// <returns>Current value in the LinkedList</returns>
        public IEnumerator<T> GetEnumerator()
        {
            //Get the root node
            var item = m_rootNode;

            //Traverse the list until we have no more elements
            while (null != item.Next)
            {
                yield return item.Value;

                item = item.Next;
            }
        }

        /// <summary>
        /// Enumerate through all nodes in the LinkedList
        /// </summary>
        /// <returns>Current value in the LinkedList</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
