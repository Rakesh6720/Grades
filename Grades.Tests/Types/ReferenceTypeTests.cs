using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void AddDAysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "scott";
            name = name.ToUpper();

            Assert.AreEqual("SCOTT", name);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number = +1;
            // this number is ONLY A COPY of the original x INT value
            // so whatever change I make to it in this method will ONLY 
            // occur to the copy of the value type variable IN THIS PRIVATE METHOD
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            Gradebook book1 = new Gradebook();
            Gradebook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A Gradebook", book1.Name);

            // this test passes because all 3 gradebook reference variables 
            // point to the same gradebook object in memory.
            // therefore, if i change the name field in one reference variable, 
            // i am changing the value of the 1 object all 3 reference types point to
        }

        private void GiveBookAName(Gradebook book)
        {
            book.Name = "A Gradebook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            // x2 willi still hold the value 100
            // Assert AreEqual test WILL FAIL
            //Assert.AreEqual(x1, x2);
            Assert.AreNotEqual(x1, x2);
        }

        //[TestMethod]
        //public void GradeBookVariablesHoldAReference()
        //{
        //    //I want to instantiate a Gradebook
        //    Gradebook g1 = new Gradebook();
        //    //I want two variables that are pointing to the same grade book
        //    Gradebook g2 = g1;
        //    //So I'll set the name through one variable -- g1
        //    g1.Name = "Scott's grade book";

        //    Assert.AreEqual(g1.Name, g2.Name);
        //}

        [TestMethod]
        public void GradeBookVariablesHoldAReference2()
        {
            Gradebook g1 = new Gradebook();
            Gradebook g2 = g1;

            g1 = new Gradebook();
            g1.Name = "Scott's GradeBook";

            Assert.AreNotEqual(g1.Name, g2.Name);
        }
    }
}
