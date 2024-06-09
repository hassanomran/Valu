using valu.BLL.DTOS;
using valu.BLL.Implementation.Services;
using valu.BLL.InterFaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace valu.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService )
        {
            _employeeService = employeeService;
        }
        [Microsoft.AspNetCore.Mvc.Route("AddEmployee")]
        [HttpPost]
        public async Task<ActionResult> AddEmployee(IFormCollection form)
        {
            try
            {
                //Retrieve values from the form

                var name = form["name"];
                var DepartmentID = form["departmentID"];
                var hireDate = DateTime.Parse(form["hireDate"]);
                var Identification = form["identification"];
                var phone = form["phone"];
                var mobileNumber = form["mobileNumber"];
                var Position = form["Position"];

                EmployeeDTO employedto = new EmployeeDTO()
                {
                    Name = name,
                    DepartmentID = int.Parse(DepartmentID),
                    HireDate = hireDate,
                    Identification = Identification,
                    phone = phone,
                    mobileNumber = mobileNumber,
                    Position = Position

                };
                var employee = await _employeeService.AddEmployee(employedto);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Microsoft.AspNetCore.Mvc.Route("DeleteEmployee")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var Employee = await _employeeService.DeleteEmployee(id);
                if (Employee == null)
                {
                    return NotFound();
                }
                return Ok(Employee);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Microsoft.AspNetCore.Mvc.Route("GetAllEmployee")]
        [HttpGet]
        public async Task<ActionResult> GetAllEmployee()
        {
            try
            {
                var Employee = await _employeeService.GetAllEmployee();
                if (Employee == null)
                {
                    return NotFound();
                }
                return Ok(Employee);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Microsoft.AspNetCore.Mvc.Route("UpdateEmployee")]
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(IFormCollection form)
        {
            try
            {
                // Retrieve values from the form
                var id = form["id"];
                var name = form["name"];
                var DepartmentID = form["departmentID"];
                var hireDate = DateTime.Parse(form["hireDate"]);
                var Identification = form["identification"];
                var phone = form["phone"];
                var mobileNumber = form["mobileNumber"];
                var Position = form["Position"];

                EmployeeDTO employedto = new EmployeeDTO()
                {
                    Id = int.Parse(id),
                    Name = name,
                    DepartmentID = int.Parse(DepartmentID),
                    HireDate = hireDate,
                    Identification = Identification,
                    phone = phone,
                    mobileNumber = mobileNumber,
                    Position = Position

                };
                var Task = await _employeeService.UpdateEmployee(employedto);
                if (Task == null)
                {
                    return NotFound();
                }
                return Ok(Task);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
