using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelpdeskDAL;

namespace CaseStudyTests
{
    [TestClass]
    public class EmployeeModelTests
    {
        [TestMethod]
        public void EmployeeModelGetbyEmailShouldReturnEmployee()
        {
            EmployeeModel model = new EmployeeModel();
            Employee someEmployee = model.GetByEmail("bs@abc.com");
            Assert.IsNotNull(someEmployee);
        }

        [TestMethod]
        public void EmployeeModelGetbyEmailShouldNotReturnEmployee()
        {
            EmployeeModel model = new EmployeeModel();
            Employee someEmployee = model.GetByEmail("kietnguyen@abc.com");
            Assert.IsNull(someEmployee);
        }
    }
}
