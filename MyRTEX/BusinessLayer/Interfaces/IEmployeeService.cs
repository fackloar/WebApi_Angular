using MyRTEX.BusinessLayer.DTOs;
using MyRTEX.BusinessLayer.Validation;

namespace MyRTEX.BusinessLayer.Interfaces
{
    public interface IEmployeeService
    {
        Task<IOperationResult<EmployeeDTO>> Create(EmployeeDTO employeeDTO);
        Task<IList<EmployeeDTO>> GetAllEmployees();
        Task<IOperationResult<EmployeeDTO>> GetEmployeeById(int id);
        Task<IOperationResult<EmployeeDTO>> GetEmployeeByName(string name);
        Task<IList<EmployeeDTO>> GetEmployeesByDateOfJoining(string date);
        Task<IList<EmployeeDTO>> GetEmployeesByDateOfBirth(string date);
        Task Update(int id, EmployeeDTO employeeDTO);
        Task Delete(int id);

    }
}
