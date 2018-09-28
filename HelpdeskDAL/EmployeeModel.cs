using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace HelpdeskDAL
{
    public class EmployeeModel
    {
        public Employee GetByEmail(string email)
        {
            Employee selectedEmployee = null;

            try
            {
                HelpdeskContext ctx = new HelpdeskContext();
                selectedEmployee = ctx.Employees.FirstOrDefault(emp => emp.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return selectedEmployee;

        }

        public Employee GetById(int id)
        {
            Employee selectedEmployee = null;

            try
            {
                HelpdeskContext ctx = new HelpdeskContext();
                selectedEmployee = ctx.Employees.FirstOrDefault(emp=> emp.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return selectedEmployee;

        }

        public List<Employee> GetAll()
        {
            List<Employee> allEmployees = new List<Employee>();

            try
            {
                HelpdeskContext ctx = new HelpdeskContext();
                allEmployees = ctx.Employees.ToList();
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
                HelpdeskContext ctx = new HelpdeskContext();
                ctx.Employees.Add(newEmployee);
                ctx.SaveChanges();
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
            Employee selectedEmployee = null;

            try
            {
                HelpdeskContext ctx = new HelpdeskContext();
                selectedEmployee = ctx.Employees.FirstOrDefault(emp => emp.LastName == lastname);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }
            return selectedEmployee;
        }

        public int Update(Employee updatedEmployee)
        {
            int employeesUpdated = -1;

            try
            {
                HelpdeskContext ctx = new HelpdeskContext();
                Employee currentEmployee = ctx.Employees.FirstOrDefault(emp => emp.Id == updatedEmployee.Id);
                ctx.Entry(currentEmployee).CurrentValues.SetValues(updatedEmployee);
                employeesUpdated = ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in " + GetType().Name + " " + MethodBase.GetCurrentMethod().Name + " " + ex.Message);
                throw ex;
            }

            return employeesUpdated;
        }

        public int Delete(int id)
        {
            int employeesDeleted = -1;

            try
            {
                HelpdeskContext ctx = new HelpdeskContext();
                Employee currentEmployee = ctx.Employees.FirstOrDefault(emp => emp.Id == id);
                ctx.Employees.Remove(currentEmployee);
                employeesDeleted = ctx.SaveChanges();
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
