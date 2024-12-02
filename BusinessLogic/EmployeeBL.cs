using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeBL
    {
        EmployeeDA EmployeeDA = new EmployeeDA();
        public List<Employee> GetAll()
        {
            return EmployeeDA.GetAll();
        }
        public int Insert(Employee employee)
        { return EmployeeDA.Insert_Update_Delete(employee, 0); }
        public int Update(Employee employee)
        { return EmployeeDA.Insert_Update_Delete(employee, 1); }
        public int Delete(Employee employee)
        { return EmployeeDA.Insert_Update_Delete(employee, 2); }
    }
}
