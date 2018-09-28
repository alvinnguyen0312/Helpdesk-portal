using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelpdeskDAL;
using System.Collections.Generic;

namespace CaseStudyTests
{
    [TestClass]
    public class EmployeeModelTests
    {
        //[TestMethod]
        //public void EmployeeModelGetbyEmailShouldReturnEmployee()
        //{
        //    EmployeeModel model = new EmployeeModel();
        //    Employee someEmployee = model.GetByEmail("bs@abc.com");
        //    Assert.IsNotNull(someEmployee);
        //}

        //[TestMethod]
        //public void EmployeeModelGetbyEmailShouldNotReturnEmployee()
        //{
        //    EmployeeModel model = new EmployeeModel();
        //    Employee someEmployee = model.GetByEmail("kietnguyen@abc.com");
        //    Assert.IsNull(someEmployee);
        //}

        [TestMethod]
        //A test for the GetAll method
        public void EmployeeModelGetAllShouldReturnList()
        {
            EmployeeModel model = new EmployeeModel();
            List<Employee> allEmployees = model.GetAll();
            Assert.IsTrue(allEmployees.Count > 0);
        }

        [TestMethod]        //A test for the Add method
        public void EmployeeModelAddShouldReturnNewId()
        {
            EmployeeModel model = new EmployeeModel();
            Employee newEmployee = new Employee();
            newEmployee.Title = "Mr";
            newEmployee.FirstName = "Tom";
            newEmployee.LastName = "Smith";
            newEmployee.Email = "TS@gmail.com";
            newEmployee.PhoneNo = "(555)000-0001";
            newEmployee.DepartmentId = 200;
            int newId = model.Add(newEmployee);
            Assert.IsTrue(newId > 0);
        }

        [TestMethod]
        //A test for the GetById method
        public void EmployeeModelGetByIdShouldReturnEmployee()
        {
            EmployeeModel model = new EmployeeModel();
            Employee someEmployee = model.GetByEmail("TS@gmail.com");
            Employee anotherEmployee = model.GetById(someEmployee.Id);
            Assert.IsNotNull(anotherEmployee);
        }

        [TestMethod]
        //A test for the Update method
        public void EmployeeModelUpdateShouldReturnOne()
        {
            EmployeeModel model = new EmployeeModel();
            Employee updateEmployee = model.GetByEmail("TS@gmail.com");
            updateEmployee.Email = "TS_update@gmail.com";
            int EmployeeUpdated = model.Update(updateEmployee);
            Assert.IsTrue(EmployeeUpdated == 1);
        }

        [TestMethod]
        //A test for the Delete method 
        public void EmployeeModelDeleteShouldReturnOne()
        {
            EmployeeModel model = new EmployeeModel();
            Employee deleteEmployee = model.GetByEmail("TS_update@gmail.com");
            int EmployeeDeleted = model.Delete(deleteEmployee.Id);
            Assert.IsTrue(EmployeeDeleted == 1);
        }
    }
}
