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

        /// <summary>
        /// Pega Todos os Cursos cadastrados no banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAll()
        {
            List<Course> courses = await _courseRepository.AllCourses();
            return Ok(courses);
        }
        /// <summary>
        /// Pega um Curso a partir do ID no Banco de dados
        /// </summary>
        /// <param name="id">campo necessário para pegar um Curso</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            Course course = await _courseRepository.GetCourseById(id);
            return Ok(course);
        }
        /// <summary>
        /// Adiciona um Curso ao banco de dados
        /// </summary>
        /// <param name="courseModel">Objeto com os campos necessários para criação de um Curso</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        public async Task<ActionResult<Course>> Add([FromBody] Course courseModel)
        {
            Course course = await _courseRepository.AddCourse(courseModel);
            return Ok(course);
        }


        /// <summary>
        /// Atualiza um curso a partir do ID e um objeto no body para atualizar no Banco de dados
        /// </summary>
        /// <param name="id">campo necessário para Atualizar uma curso</param>
        ///  <param name="courseModel">Objeto necessário para Atualizar um curso</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Course>> Update(int id, [FromBody] Course courseModel)
        {
            courseModel.Id = id;
            Course course = await _courseRepository.UpdateCourse(id, courseModel);
            return Ok(course);
        }
        /// <summary>
        /// Deleta um Curso a partir do ID no Banco de dados
        /// </summary>
        /// <param name="id">campo necessário para Deletar um Curso</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Course>> Remove(int id)
        {
            bool deleted = await _courseRepository.DeleteCourse(id);
            return Ok(deleted);
        }
    }
}

