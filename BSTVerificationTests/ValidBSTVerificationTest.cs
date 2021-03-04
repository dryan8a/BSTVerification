using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using BSTVerification;

namespace BSTVerificationTests
{
    public class ValidBSTVerificationTest
    {
        [Theory]
        [InlineData("4(2(1,3),6(5,7))")]
        [InlineData("2(1,3)")]
        [InlineData("2(1(0, ),3( ,4))")]
        [InlineData("1( ,2( ,3( ,4)))")]
        [InlineData("1( ,2( ,5(4(3, ), )))")]
        [InlineData("1( ,3(2,4( ,5)))")]
        [InlineData("1")]
        public void ValidBSTVerifiesTest(string tree)
        {
            var head = TestHelperFunctions.ParseIntTree(tree);
            var actualResult = BSTVerificator.IsValidBST(head);
            Assert.True(actualResult);
        }
    }
}
