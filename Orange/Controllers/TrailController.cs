﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<List<Trail>>> GetAll()
        {
            List<Trail> trails = await _trailRepository.GetAllTrails();
            return Ok(trails);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Trail>> GetById(int id)
        {
            Trail trail = await _trailRepository.GetTrailById(id);
            return Ok(trail);

        }
        [HttpPost]
        public async Task<ActionResult<Trail>> Add([FromBody] Trail trailModel)
        {
            Trail trail = await _trailRepository.AddTrail(trailModel);
            return Ok(trail);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Trail>> Update(int id, [FromBody] Trail trailModel)
        {
            trailModel.Id = id;
            Trail trail = await _trailRepository.UpdateTrail(id, trailModel);
            return Ok(trail);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Trail>> Remove(int id)
        {
            bool deleted = await _trailRepository.DeleteTrail(id);
            return Ok(deleted);
        }
    }
}
