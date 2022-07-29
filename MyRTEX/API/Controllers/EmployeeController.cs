using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRTEX.API.Responses;
using MyRTEX.BusinessLayer.DTOs;
using MyRTEX.BusinessLayer.Interfaces;

namespace MyRTEX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<GetEmployeesResponse>> GetAllEmployees()
        {
            var response = new GetEmployeesResponse()
            {
                Employees = new List<EmployeeDTO>()
            };
            var employees = await _employeeService.GetAllEmployees();
            foreach (var employee in employees)
            {
                response.Employees.Add(employee);
            }
            return Ok(response.Employees);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<GetEmployeeResponse>> GetEmployeeById(int id)
        {
            var response = await _employeeService.GetEmployeeById(id);
            if (response.Succeed)
            {
                return Ok(response.Result);
            }
            else
            {
                return UnprocessableEntity(response.Failures);
            }
        }
        [HttpGet("name/{name}")]
        public async Task<ActionResult<GetEmployeeResponse>> GetEmployeeByName(string name)
        {
            var response = await _employeeService.GetEmployeeByName(name);
            if (response.Succeed)
            {
                return Ok(response.Result);
            }
            else
            {
                return UnprocessableEntity(response.Failures);
            }
        }
        [HttpGet("dateOfBirth/{dateOfBirth}")]
        public async Task<ActionResult<GetEmployeesResponse>> GetEmployeesByDateOfBirth(string dateOfBirth)
        {
            var response = new GetEmployeesResponse()
            {
                Employees = new List<EmployeeDTO>()
            };
            var employees = await _employeeService.GetEmployeesByDateOfBirth(dateOfBirth);
            foreach (var employee in employees)
            {
                response.Employees.Add(employee);
            }
            return Ok(response.Employees);
        }
        [HttpGet("dateOfJoining/{dateOfJoining}")]
        public async Task<ActionResult<GetEmployeesResponse>> GetEmployeesByDateOfJoining(string dateOfJoining)
        {
            var response = new GetEmployeesResponse()
            {
                Employees = new List<EmployeeDTO>()
            };
            var employees = await _employeeService.GetEmployeesByDateOfJoining(dateOfJoining);
            foreach (var employee in employees)
            {
                response.Employees.Add(employee);
            }
            return Ok(response.Employees);
        }
        [HttpPut("id/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int id, [FromBody] EmployeeDTO updatedEmployee)
        {
            await _employeeService.Update(id, updatedEmployee);
            return Ok();
        }
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Create([FromBody] EmployeeDTO employee)
        {
            var response = await _employeeService.Create(employee);
            if (response.Succeed)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity(response.Failures);
            }

        }
    }
}
