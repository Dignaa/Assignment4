using Assignment4.Manager;
using MandatoryAssignment;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersControler : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: api/<FootballPlayersControler>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<FootbalPlayer>> GetAll()
        {
            List<FootbalPlayer> result = _manager.GetAll();
            if (result.Count == 0) return NoContent();
            return Ok(_manager.GetAll());
        }

        // GET api/<FootballPlayersControler>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootbalPlayer> Get(int id)
        {
            FootbalPlayer player = _manager.GetById(id);
            if (player == null) return BadRequest();

            return Ok(player);
        }

        // POST api/<FootballPlayersControler>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] FootbalPlayer newPlayer)
        {
            if(newPlayer == null) return BadRequest();

            FootbalPlayer player = _manager.Add(newPlayer);
            return Created($"api/FootballPlayers", newPlayer);
        }

        // PUT api/<FootballPlayersControler>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] FootbalPlayer updates)
        {
            try { _manager.Update(id, updates); }
            catch(Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE api/<FootballPlayersControler>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try { _manager.Delete(id); }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
