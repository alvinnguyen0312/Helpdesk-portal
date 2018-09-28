using System;
using System.Collections.Generic;
using HelpdeskViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseStudyTests
{
    [TestClass]
    public class EmployeeViewModelTests
    {
        [TestMethod]        //A test for the Add method
        public void EmployeeViewModelAddShouldReturnId()
        {
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Title = "Mr";
            vm.Firstname = "Kiet";
            vm.Lastname = "Nguyen";
            vm.Email = "kietnguyen@abc.com";
            vm.Phoneno = "(555)555-9999";
            vm.DepartmentId = 400;
            vm.Add();
            Assert.IsTrue(vm.Id > 0);
        }

        [TestMethod]
        //A test for the GetByName method
        public void EmployeeViewModelGetByNameShouldPopulatePropertyFirstName()
        {
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Lastname = "Nguyen"; 
            vm.GetByLastname();
            Assert.IsNotNull(vm.Firstname);
        }

        [TestMethod]
        //A test for the GetAll method
        public void EmployeeViewModelGetAllShouldReturnAtLeastOneVM()
        {
            EmployeeViewModel vm = new EmployeeViewModel();
            List<EmployeeViewModel> allEmployeesVms = vm.GetAll();
            Assert.IsTrue(allEmployeesVms.Count > 0);
        }

        [TestMethod]
        //A test for the GetById method
        public void EmployeeViewModelGetByIdShouldPopulatePropertyFirstname()
        {
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Lastname = "Nguyen";
            vm.GetByLastname();
            vm.GetById();
            Assert.IsNotNull(vm.Firstname);
        }

        [TestMethod]
        //A test for the Update method
        public void EmployeeViewModelUpdateShouldReturnOkStatus()
        {
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Lastname = "Nguyen";
            vm.GetByLastname(); 
            vm.Email = (vm.Email.IndexOf(".com") > 0) ? "kietnguyen@abc.org" : "kietnguyen@abc.com";
            int EmployeeUpdated = vm.Update();
            Assert.IsTrue(EmployeeUpdated > 0);
        }

        [TestMethod]
        //A test for the Delete method 
        public void EmployeeViewModelDeleteShouldReturnOne()
        {
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Lastname = "Nguyen";
            vm.GetByLastname();
            int EmployeeViewModel = vm.Delete();
            Assert.IsTrue(EmployeeViewModel == 1);
        }
    }
}
