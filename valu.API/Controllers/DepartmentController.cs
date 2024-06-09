using valu.BLL.DTOS;
using valu.BLL.InterFaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace valu.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService1;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService1 = departmentService;
        }
        [Microsoft.AspNetCore.Mvc.Route("GetAllDepartments")]
        [HttpGet]
        public async Task<ActionResult> GetAllDepartments()
        {
            try
            {
                var Departments = await _departmentService1.GetAllDepartment();
                if (Departments == null)
                {
                    return NotFound();
                }
                return Ok(Departments);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Microsoft.AspNetCore.Mvc.Route("AddDepartment")]
        [HttpPost]
        public async Task<ActionResult> AddAddDepartment(IFormCollection form)
        {

            try
            {
                //Retrieve values from the form

               var Name = form["name"];
                var Details = form["details"];
                var Order = int.Parse(form["order"]);
                DepartmentDTO departmenDTO = new DepartmentDTO()
                {
                    Name = Name,
                    Details = Details,
                    Order = Order
                };
                var Department = await _departmentService1.AddDepartment(departmenDTO);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok(Department);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Microsoft.AspNetCore.Mvc.Route("EditDepartment")]
        [HttpPut]
        public async Task<ActionResult> EditDepartment(IFormCollection form)
        {
            try
            {
                /// Retrieve values from the form
                var id = form["id"];
                var Name = form["name"];
                var Details = form["details"];
                var Order = int.Parse(form["order"]);
                DepartmentDTO departmenDTO = new DepartmentDTO()
                {
                    Id=int.Parse(id),
                    Name = Name,
                    Details = Details,
                    Order = Order
                };
                var User = await _departmentService1.UpdateDepartment(departmenDTO);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok(User);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Microsoft.AspNetCore.Mvc.Route("DeleteDepartment")]
        [HttpDelete]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            try
            {
                var User = await _departmentService1.DeleteDepartment(id);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok(User);
            }
            catch (Exception ex)
            {

                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
