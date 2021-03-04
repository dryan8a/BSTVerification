using System;
using System.Collections.Generic;
using System.Text;

namespace BSTVerification
{
    public static class BSTVerificator
    {
        /// <summary>
        /// Verifies if a given Tree using the Node class is a valid BST
        /// </summary>
        /// <typeparam name="T">The IComparable type that the Tree holds</typeparam>
        /// <param name="tree">The head of the Tree</param>
        /// <returns></returns>
        public static bool IsValidBST<T>(Node<T> tree) where T : IComparable<T>
        {
            return IsValidSubtree<T>(tree, null, null);
        }

        /// <summary>
        /// Recursively validates subtrees using a minimum and maximum node to tell what range of values the current Node can be in
        /// </summary>
        /// <typeparam name="T">The IComparable type that Tree holds</typeparam>
        /// <param name="currentNode">The node to validate</param>
        /// <param name="minimumNode">The node that holds the minimum value that currentNode can have; null indicates no minimum</param>
        /// <param name="maximumNode">The node that holds the maximum value that currentNode can have; null indicates no maximum</param>
        /// <returns></returns>
        private static bool IsValidSubtree<T>(Node<T> currentNode, Node<T> minimumNode, Node<T> maximumNode) where T : IComparable<T>
        {
            if(currentNode == null)
            {
                return true;
            }

            //returns false if the node's value exceeds the current minimum or maximum
            if((minimumNode != null && currentNode.Value.CompareTo(minimumNode.Value) <= 0) || (maximumNode != null && currentNode.Value.CompareTo(maximumNode.Value) >= 0))
            {
                return false;
            }

            return IsValidSubtree(currentNode.Left, minimumNode, currentNode) && IsValidSubtree(currentNode.Right, currentNode, maximumNode);
        }
    }
}
