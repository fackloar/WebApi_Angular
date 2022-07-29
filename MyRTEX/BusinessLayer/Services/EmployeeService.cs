using AutoMapper;
using FluentValidation;
using MyRTEX.BusinessLayer.DTOs;
using MyRTEX.BusinessLayer.Interfaces;
using MyRTEX.BusinessLayer.Validation;
using MyRTEX.DataLayer.Interfaces;
using MyRTEX.DataLayer.Models;
using MyRTEX.BusinessLayer.Mapper;

namespace MyRTEX.BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;
        private IValidator<EmployeeDTO> _validator;
        private IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IValidator<EmployeeDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<IOperationResult<EmployeeDTO>> Create(EmployeeDTO employee)
        {
            var check = await _validator.ValidateAsync(employee);
            if (!check.IsValid)
            {
                var failures = check.Errors.Select(e => new OperationFailure
                {
                    PropertyName = e.PropertyName,
                    Code = e.ErrorCode,
                    Message = e.ErrorMessage
                }).ToArray();
                return new OperationResult<EmployeeDTO>(failures);
            }
            else
            {
                var employeeToCreate = _mapper.Map<Employee>(employee);
                await _repository.CreateEmployee(employeeToCreate);
                return new OperationResult<EmployeeDTO>(employee);
            }
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IOperationResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employeeGot = await _repository.GetEmployeeById(id);
            var employeeDTO = HandMapper.EmployeeToDTO(employeeGot);
            var check = await _validator.ValidateAsync(employeeDTO);
            if (!check.IsValid)
            {
                var failures = check.Errors.Select(e => new OperationFailure
                {
                    PropertyName = e.PropertyName,
                    Code = e.ErrorCode,
                    Message = e.ErrorMessage
                }).ToArray();
                return new OperationResult<EmployeeDTO>(failures);
            }
            else
            {
                return new OperationResult<EmployeeDTO>(employeeDTO);
            }
        }

        public async Task<IOperationResult<EmployeeDTO>> GetEmployeeByName(string name)
        {
            var employeeGot = await _repository.GetEmployeeByName(name);
            var employeeDTO = HandMapper.EmployeeToDTO(employeeGot);
            var check = await _validator.ValidateAsync(employeeDTO);
            if (!check.IsValid)
            {
                var failures = check.Errors.Select(e => new OperationFailure
                {
                    PropertyName = e.PropertyName,
                    Code = e.ErrorCode,
                    Message = e.ErrorMessage
                }).ToArray();
                return new OperationResult<EmployeeDTO>(failures);
            }
            else
            {
                return new OperationResult<EmployeeDTO>(employeeDTO);
            }
        }

        public async Task<IList<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _repository.GetAllEmployees();
            List<EmployeeDTO> employeeDTOList = new List<EmployeeDTO>();
            foreach (Employee employee in employees)
            {
                EmployeeDTO convertedEmployee = HandMapper.EmployeeToDTO(employee);
                employeeDTOList.Add(convertedEmployee);
            }
            return employeeDTOList;
        }

        public async Task<IList<EmployeeDTO>> GetEmployeesByDateOfBirth(string date)
        {
            var employees = await _repository.GetEmployeesByDateOfBirth(date);
            List<EmployeeDTO> employeeDTOList = new List<EmployeeDTO>();
            foreach (Employee employee in employees)
            {
                EmployeeDTO convertedEmployee = HandMapper.EmployeeToDTO(employee);
                employeeDTOList.Add(convertedEmployee);
            }
            return employeeDTOList;
        }

        public async Task<IList<EmployeeDTO>> GetEmployeesByDateOfJoining(string date)
        {
            var employees = await _repository.GetEmployeesByDateOfJoining(date);
            List<EmployeeDTO> employeeDTOList = new List<EmployeeDTO>();
            foreach (Employee employee in employees)
            {
                EmployeeDTO convertedEmployee = HandMapper.EmployeeToDTO(employee);
                employeeDTOList.Add(convertedEmployee);
            }
            return employeeDTOList;
        }

        public async Task Update(int id, EmployeeDTO employeeDTO)
        {
            var updatedEmployee = _mapper.Map<Employee>(employeeDTO);
            await _repository.Update(id, updatedEmployee);
        }
    }
}
