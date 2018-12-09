using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void VariablesHoldAReference()
        {
            //I want to instantiate a Gradebook
            Gradebook g1 = new Gradebook();
            //I want two variables that are pointing to the same grade book
            Gradebook g2 = g1;
            //So I'll set the name through one variable -- g1
            g1.Name = "Scott's grade book";

            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
