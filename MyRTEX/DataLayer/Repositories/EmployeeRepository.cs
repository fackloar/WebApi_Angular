using Microsoft.EntityFrameworkCore;
using MyRTEX.DataLayer.Interfaces;
using MyRTEX.DataLayer.Models;
using System.Globalization;

namespace MyRTEX.DataLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        DataContext dataContext;

        public EmployeeRepository(DataContext context)
        {
            dataContext = context;
        }
        public async Task CreateEmployee(Employee employee)
        {
            using (dataContext)
            {
                await dataContext.AddAsync(employee);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (dataContext)
            {
                var employeeToDelete = dataContext.Employee.Find(id);

                if (employeeToDelete != null)
                {
                    dataContext.Employee.Remove(employeeToDelete);
                }

                await dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await dataContext.Employee.OrderBy(dc => dc.EmployeeID).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var result = await dataContext.Employee
                .Where(employee => employee.EmployeeID == id)
                .SingleOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("No employees with this ID");
            }
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
            var result = await dataContext.Employee
                .Where(employee => employee.EmployeeName == name)
                .SingleOrDefaultAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("No employees with this name");
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDateOfBirth(string date)
        {
            var result = await dataContext.Employee
                .Where(employee => employee.DateOfBirth == DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.CurrentCulture))
                .ToListAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("No employees with this date of birth");
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDateOfJoining(string date)
        {
            var result = await dataContext.Employee
                .Where(employee => employee.DateOfJoining == DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.CurrentCulture))
                .ToListAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("No employees with this date of joining");
            }
        }

        public async Task Update(int id, Employee employee)
        {
            using (dataContext)
            {
                var employeeToChange = dataContext.Employee.Find(id);
                if (employeeToChange != null)
                {
                    employeeToChange.EmployeeSalary = employee.EmployeeSalary;
                    employeeToChange.DateOfBirth = employee.DateOfBirth;
                    employeeToChange.DateOfJoining = employee.DateOfJoining;
                    employeeToChange.EmployeeDepartment = employee.EmployeeDepartment;
                    employeeToChange.EmployeeName = employee.EmployeeName;
                }
                dataContext.Update(employeeToChange);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
