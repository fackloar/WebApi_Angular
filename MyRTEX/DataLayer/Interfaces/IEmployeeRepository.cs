using MyRTEX.DataLayer.Models;

namespace MyRTEX.DataLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        Task CreateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> GetEmployeeByName(string name);
        Task<IEnumerable<Employee>> GetEmployeesByDateOfJoining(string date);
        Task<IEnumerable<Employee>> GetEmployeesByDateOfBirth (string date);
        Task Update(int id, Employee employee);
        Task Delete(int id);
    }
}
