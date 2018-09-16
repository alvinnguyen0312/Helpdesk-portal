using System;
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
    }
}
