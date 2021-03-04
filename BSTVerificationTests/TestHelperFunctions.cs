using BSTVerification;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTVerificationTests
{
    public static class TestHelperFunctions
    {
        /// <summary>
        /// Converts the Polish Notation of Int BST used in Unit tests to create a tree
        /// </summary>
        /// <param name="tree">The string representation of the tree</param>
        /// <returns></returns>
        public static Node<int> ParseIntTree(string tree)
        {
            if(tree.Length == 0)
            {
                throw new Exception("Subtree was not found");
            }

            if(!tree.Contains('(')) //tree is either a valid number or a space
            {
                if(tree == " ") //spaces used to represent empty nodes
                {
                    return null;
                }
                return new Node<int>() { Value = int.Parse(tree) };
            }

            int value = int.Parse(tree.Substring(0, 1));

            string left = "";
            string right = "";
            int parenBalance = 0;
            for(int i = tree.IndexOf('(') + 1;i<tree.Length;i++) //looks for the relevant comma to build subtrees
            {
                if(tree[i] == '(')
                {
                    parenBalance++;
                }
                else if(tree[i] == ')')
                {
                    parenBalance--;
                }
                else if(tree[i] == ',' && parenBalance == 0) //finds the subtrees of the given tree using the position of the comma
                {
                    left = tree.Substring(tree.IndexOf('(') + 1, i - tree.IndexOf('(') - 1); 
                    right = tree.Substring(i + 1, tree.Length - i - 2);
                    break;
                }
            }

            return new Node<int>() { Value = value, Left = ParseIntTree(left), Right = ParseIntTree(right) };
        }
    }
}
