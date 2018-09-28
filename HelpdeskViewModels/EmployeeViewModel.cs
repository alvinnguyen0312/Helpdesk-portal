using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HelpdeskDAL;

namespace HelpdeskViewModels
{
    public class EmployeeViewModel
    {
        private EmployeeModel _model;
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public string Timer { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Id { get; set; }
        public bool IsTech { get; set; }
        public string StaffPicture64 { get; set; }

        //constructor
        public EmployeeViewModel()
        {
            _model = new EmployeeModel();
        }
        //Retrieve all the employees

        public List<EmployeeViewModel> GetAll()
        {
            List<EmployeeViewModel> allVms = new List<EmployeeViewModel>();
            try
            {
                List<Employee> allEmployees = _model.GetAll();
                foreach (Employee emp in allEmployees)
                {
                    EmployeeViewModel empVm = new EmployeeViewModel();
                    empVm.Title = emp.Title;
                    empVm.Firstname = emp.FirstName;
                    empVm.Lastname = emp.LastName;
                    empVm.Phoneno = emp.PhoneNo;
                    empVm.Email = emp.Email;
                    empVm.Id = emp.Id;
                    empVm.DepartmentId = emp.DepartmentId;
                    empVm.DepartmentName = emp.Department.DepartmentName;
                    empVm.Timer = Convert.ToBase64String(emp.Timer);
                    allVms.Add(empVm);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name +
                   " " + ex.Message);
                throw ex;
            }

            return allVms;
        }
        //Find employee using Lastname Property

        public void GetByLastname()
        {
            try
            {
                Employee emp = _model.GetByLastname(Lastname);
                Title = emp.Title;
                Firstname = emp.FirstName;
                Lastname = emp.LastName;
                Phoneno = emp.PhoneNo;
                Email = emp.Email;
                Id = emp.Id;
                DepartmentId = emp.DepartmentId;
                if (emp.StaffPicture != null)
                {
                    StaffPicture64 = Convert.ToBase64String(emp.StaffPicture);
                }
                Timer = Convert.ToBase64String(emp.Timer);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name +
                    " " + ex.Message);
                throw ex;
            }
        }

        // Add an employee
        public void Add()
        {
            Id = -1;
            try
            {
                Employee emp = new Employee();
                emp.Title = Title;
                emp.FirstName = Firstname;
                emp.LastName = Lastname;
                emp.PhoneNo = Phoneno;
                emp.Email = Email;
                emp.DepartmentId = DepartmentId;
                Id = _model.Add(emp);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name +
                    " " + ex.Message);
                throw ex;
            }
        }

        //Update an employee
        public int Update()
        {
            int upStatus = -1;
            try
            {
                Employee emp = new Employee();
                emp.Title = Title;
                emp.FirstName = Firstname;
                emp.LastName = Lastname;
                emp.PhoneNo = Phoneno;
                emp.Email = Email;
                emp.Id = Id;
                emp.DepartmentId = DepartmentId;
                if (StaffPicture64 != null)
                {
                    emp.StaffPicture = Convert.FromBase64String(StaffPicture64);
                }
                emp.Timer = Convert.FromBase64String(Timer);
                upStatus = _model.Update(emp);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name +
                    " " + ex.Message);
                throw ex;
            }
            return upStatus;
        }

        //Delete an employee
        public int Delete()
        {
            int studentsDeleted = -1;
            try
            {
                studentsDeleted = _model.Delete(Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name +
                    " " + ex.Message);
                throw ex;
            }
            return studentsDeleted;
        }

        //find an employee using Is property
        public void GetById()
        {
            try
            {
                Employee emp = _model.GetById(Id);
                Title = emp.Title;
                Firstname = emp.FirstName;
                Lastname = emp.LastName;
                Phoneno = emp.PhoneNo;
                Email = emp.Email;
                Id = emp.Id;
                DepartmentId = emp.DepartmentId;
                if (emp.StaffPicture != null)
                {
                    StaffPicture64 = Convert.ToBase64String(emp.StaffPicture);
                }
                Timer = Convert.ToBase64String(emp.Timer);
            }
            catch (NullReferenceException nex)
            {
                Lastname = "not found";
            }
            catch (Exception ex)
            {
                Lastname = "not found";
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name +
                    " " + ex.Message);
                throw ex;
            }
        }
    }
}
