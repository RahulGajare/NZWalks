using Microsoft.AspNetCore.Mvc;

namespace NZWalker.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllStudents()
        { 
            string[] students = new string[] { "John Doe", "Jane Smith", "Alice Johnson" };

            return Ok(students);
        }

        [HttpGet("student")]
        public IActionResult GetSingleStudents()
        {
            string[] students = new string[] { "John Doe" };

            return Ok(students);
        }
    }
}
