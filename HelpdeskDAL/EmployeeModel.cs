using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;


namespace HelpdeskDAL
{
    public class EmployeeModel
    {
        IRepository<Employee> repo;

        public EmployeeModel()
        {
            repo = new HelpdeskRepository<Employee>();
        }
        public Employee GetByEmail(string email)
        {
            //Employee selectedEmployee = null;
            List<Employee> selectedEmployee = null;

            try
            {
                //HelpdeskContext ctx = new HelpdeskContext();
                //selectedEmployee = ctx.Employees.FirstOrDefault(emp => emp.Email == email);
                selectedEmployee = repo.GetByExpression(emp => emp.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            //return selectedEmployee;
            return selectedEmployee.FirstOrDefault();
        }

        public Employee GetById(int id)
        {
            //Employee selectedEmployee = null;
            List<Employee> selectedEmployee = null;

            try
            {
                //HelpdeskContext ctx = new HelpdeskContext();
                //selectedEmployee = ctx.Employees.FirstOrDefault(emp=> emp.Id == id);
                selectedEmployee = repo.GetByExpression(emp => emp.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            // return selectedEmployee;
            return selectedEmployee.FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            List<Employee> allEmployees = new List<Employee>();

            try
            {
                //HelpdeskContext ctx = new HelpdeskContext();
                //allEmployees = ctx.Employees.ToList();
                allEmployees = repo.GetAll();   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return allEmployees;
        }

        public int Add(Employee newEmployee)
        {
            try
            {
                //HelpdeskContext ctx = new HelpdeskContext();
                //ctx.Employees.Add(newEmployee);
                //ctx.SaveChanges();
                repo.Add(newEmployee);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return newEmployee.Id;
        }

        public Employee GetByLastname(string lastname)
        {
            //Employee selectedEmployee = null;
            List<Employee> selectedEmployee = null;

            try
            {
                // HelpdeskContext ctx = new HelpdeskContext();
                //selectedEmployee = ctx.Employees.FirstOrDefault(emp => emp.LastName == lastname);
                selectedEmployee = repo.GetByExpression(emp => emp.LastName == lastname);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            //return selectedEmployee;
            return selectedEmployee.FirstOrDefault();
        }

        //public int Update(Employee updatedEmployee)
        public UpdateStatus Update(Employee updatedEmployee)
        {
            // int employeesUpdated = -1;
            UpdateStatus upStatus = UpdateStatus.Failed;
            try
            {
                //HelpdeskContext ctx = new HelpdeskContext();
                //Employee currentEmployee = ctx.Employees.FirstOrDefault(emp => emp.Id == updatedEmployee.Id);
                //ctx.Entry(currentEmployee).CurrentValues.SetValues(updatedEmployee);
                //employeesUpdated = ctx.SaveChanges();
                upStatus = repo.Update(updatedEmployee);
            }
            catch (DbUpdateConcurrencyException dbx)
            {
                upStatus = UpdateStatus.Stale;
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + dbx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return upStatus;
            //return employeesUpdated;
        }

        public int Delete(int id)
        {
            int employeesDeleted = -1;

            try
            {
                //HelpdeskContext ctx = new HelpdeskContext();
                //Employee currentEmployee = ctx.Employees.FirstOrDefault(emp => emp.Id == id);
                //ctx.Employees.Remove(currentEmployee);
                //employeesDeleted = ctx.SaveChanges();
                employeesDeleted = repo.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return employeesDeleted;
        }


    }
}
