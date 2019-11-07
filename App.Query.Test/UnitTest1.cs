using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace App.Query.Test
{
    [TestFixture]
    public class Tests
    {
        public static List<int> originalList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, 7)]
        [TestCase(3, 5)]
        public void Test_Div_Lenght(int divisur, int numberOfResults)
        {
            Assert.AreEqual(numberOfResults, originalList.GetNumberDivider(divisur).Count(), "Division par 2 ne retourne pas les bonnes valeurs");
        }

        [Test]
        public void Test_Divide_By_2()
        {
            Assert.AreEqual(new List<int> {2, 4, 6, 8, 10, 12, 14}, originalList.GetNumberDivider(2), "Division par 2 ne retourne pas les bonnes valeurs");
        }

        [Test]
        public void Test_Divide_By_2_By_2()
        {
            Assert.AreEqual(new List<int> {6, 12}, originalList.GetNumberDivider(2).GetNumberDivider(3), "Division par 2 chainé ne retourne pas les bonnes valeurs");
        }

        [Test]
        public void Test_Divide_By_0()
        {
            Assert.Throws<DivideByZeroException>(() => originalList.GetNumberDivider(0).ToList(), "la division par0 ne plante pas ");
        }
    }
}