﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BSTVerification;

namespace BSTVerificationTests
{
    public class InvalidBSTRejectionTest
    {
        [Theory]
        [InlineData("4(3(1,3),6(5,7))")]
        [InlineData("4(2(1,3),6(4,7))")]
        [InlineData("2(3,1)")]
        [InlineData("1( ,1)")]
        [InlineData("5(4(2, ),6(5, )")]
        public void InvalidBSTRejects(string tree)
        {
            var head = TestHelperFunctions.ParseTree<int>(tree);
            var actualResult = BSTVerificator.IsValidBST(head);
            Assert.False(actualResult);
        }
    }
}
