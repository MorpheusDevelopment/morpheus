using BusinessImplementationZone.Extenders;
using NUnit.Framework;

namespace BusinessImplementationZone_Tests.Extenders
{
    [TestFixture, Category("StringExtenders Tests")]
    public class StringExtenders_Tests
    {
        [TestCase("", true), Category("StringExtenders SimplePalindromeCheck")]
        [TestCase("bob", true), Category("StringExtenders SimplePalindromeCheck")]
        [TestCase("john", false), Category("StringExtenders SimplePalindromeCheck")]
        [TestCase("abba", true), Category("StringExtenders SimplePalindromeCheck")]
        [TestCase("Bob", true), Category("StringExtenders SimplePalindromeCheck")]
        public void StringExtenders_SimplePalindromeCheck(string input, bool expectedResult)
        {
            Assert.AreEqual(input.SimplePalindromeCheck(), expectedResult);
        }
    }
}
