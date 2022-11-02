using MyRTEX.BusinessLayer.DTOs;
using MyRTEX.DataLayer.Models;

namespace MyRTEX.BusinessLayer.Mapper
{
    public class HandMapper
    {
        public static EmployeeDTO EmployeeToDTO(Employee employee)
        {
            var convertedEmployee = new EmployeeDTO
            {
                EmployeeID = employee.EmployeeID,
                EmployeeDepartment = employee.EmployeeDepartment,
                EmployeeName = employee.EmployeeName,
                EmployeeSalary = employee.EmployeeSalary,
                DateOfBirth = employee.DateOfBirth.ToShortDateString(),
                DateOfJoining = employee.DateOfJoining.ToShortDateString()
            };
            return convertedEmployee;
        }
    }
}
