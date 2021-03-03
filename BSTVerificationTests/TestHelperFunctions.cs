using BSTVerification;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSTVerificationTests
{
    public static class TestHelperFunctions
    {
        public static Node<int> ParseIntTree(string tree)
        {
            if(tree.Length == 0)
            {
                throw new Exception("Subtree was not found");
            }

            if(!tree.Contains('('))
            {
                if(tree == " ")
                {
                    return null;
                }
                return new Node<int>() { Value = int.Parse(tree) };
            }

            int value = int.Parse(tree.Substring(0, 1));

            string left = "";
            string right = "";
            int parenBalance = 0;
            for(int i = tree.IndexOf('(') + 1;i<tree.Length;i++)
            {
                if(tree[i] == '(')
                {
                    parenBalance++;
                }
                else if(tree[i] == ')')
                {
                    parenBalance--;
                }
                else if(tree[i] == ',' && parenBalance == 0)
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
