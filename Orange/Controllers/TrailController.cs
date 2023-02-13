using Microsoft.AspNetCore.Mvc;
using Orange.Model;
using Orange.Repository.Interfaces;

namespace Orange.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TrailController : ControllerBase
    {

        private readonly ITrailRepository _trailRepository;

        public TrailController(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }

        /// <summary>
        /// Pega Todas as Trilhas cadastradas no banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpGet]
        public async Task<ActionResult<List<Trail>>> GetAll()
        {
            List<Trail> trails = await _trailRepository.GetAllTrails();
            return Ok(trails);
        }
        /// <summary>
        /// Pega uma Trilha a partir do ID no Banco de dados
        /// </summary>
        /// <param name="id">campo necessário para pegar uma trilha</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Trail>> GetById(int id)
        {
            Trail trail = await _trailRepository.GetTrailById(id);
            return Ok(trail);

        }
        /// <summary>
        /// Adiciona uma Trilha ao banco de dados
        /// </summary>
        /// <param name="trailModel">Objeto com os campos necessários para criação de uma Trilha</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        public async Task<ActionResult<Trail>> Add([FromBody] Trail trailModel)
        {
            Trail trail = await _trailRepository.AddTrail(trailModel);
            return Ok(trail);
        }
        /// <summary>
        /// Atualiza uma Trilha a partir do ID e passando o objeto no body para atualizar no Banco de dados
        /// </summary>
        /// <param name="id">campo necessário para Atualizar uma trilha</param>
        ///  <param name="trailModel">Objeto com os campos necessários para Atualizar uma trilha</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Trail>> Update(int id, [FromBody] Trail trailModel)
        {
            trailModel.Id = id;
            Trail trail = await _trailRepository.UpdateTrail(id, trailModel);
            return Ok(trail);
        }
        /// <summary>
        /// Deleta uma Trilha a partir do ID no Banco de dados
        /// </summary>
        /// <param name="id">campo necessários para Deletar uma trilha</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Trail>> Remove(int id)
        {
            bool deleted = await _trailRepository.DeleteTrail(id);
            return Ok(deleted);
        }
    }
}
