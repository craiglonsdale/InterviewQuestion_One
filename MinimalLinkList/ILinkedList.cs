using System.Collections.Generic;

namespace MinimalLinkList
{
    /// <summary>
    /// Interface for a very basic LinkList class.
    /// There is much functionality not implemented, just enough to demonstrate that the basics work.
    /// </summary>
    /// <typeparam name="T">Type of values for this LinkedList to contain.</typeparam>
    public interface ILinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Adds an value to the tail of the linked list.
        /// </summary>
        /// <param name="value">Value of type 'T' that needs to be added to the tail.</param>
        void Add(T value);

        /// <summary>
        /// Removes an value from the linked list.
        /// Note: That the first matching value will be removed.
        /// </summary>
        /// <param name="value">Value of type 'T' that needs to be removed.</param>
        bool Remove(T value);

        /// <summary>
        /// The number of elements in the collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Clear the list of all contents
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns whether this LinkedList contains the given value.
        /// </summary>
        /// <param name="value">Value of type 'T' to look for.</param>
        /// <returns>True if the value is found, false othewrwise.</returns>
        bool ContainsValue(T value);

        /// <summary>
        /// Implementation of the index operator for the LinkedList.
        /// </summary>
        /// <param name="index">The index from which you want to get a value.</param>
        /// <returns>Value of type 'T' that was at 'index'</returns>
        T this[int index] { get; }
    }
}
