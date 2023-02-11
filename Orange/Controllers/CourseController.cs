using Microsoft.AspNetCore.Mvc;
using Orange.Model;
using Orange.Repository.Interfaces;

namespace Orange.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAll()
        {
            List<Course> courses = await _courseRepository.AllCourses();
            return Ok(courses);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            Course course = await _courseRepository.GetCourseById(id);
            return Ok(course);
        }
        [HttpPost]
        public async Task<ActionResult<Course>> Add([FromBody] Course courseModel)
        {
            Course course = await _courseRepository.AddCourse(courseModel);
            return Ok(course);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Course>> Update(int id, [FromBody] Course courseModel)
        {
            courseModel.Id = id;
            Course course = await _courseRepository.UpdateCourse(id, courseModel);
            return Ok(course);
        }
        [HttpDelete]
        public async Task<ActionResult<Course>> Remove(int id)
        {
            bool deleted = await _courseRepository.DeleteCourse(id);
            return Ok(deleted);
        }
    }
}

