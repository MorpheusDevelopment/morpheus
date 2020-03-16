using BusinessImplementationZone.Extenders;
using NUnit.Framework;

namespace BusinessImplementationZone_Tests.Extenders
{
    [TestFixture, Category("StringExtenders Tests")]
    public class StringExtenders_Tests
    {
        [TestCase("", true), Category("StringExtenders RecipeDataInterface")]
        [TestCase("bob", true), Category("StringExtenders RecipeDataInterface")]
        [TestCase("john", false), Category("StringExtenders RecipeDataInterface")]
        [TestCase("abba", true), Category("StringExtenders RecipeDataInterface")]
        public void StringExtenders_SimplePalindromeCheck(string input, bool expectedResult)
        {
            Assert.AreEqual(input.SimplePalindromeCheck(), expectedResult);
        }
    }
}
