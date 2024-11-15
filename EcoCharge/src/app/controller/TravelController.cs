using Microsoft.AspNetCore.Mvc;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.model;
using EcoCharge.infra.exception;

namespace EcoCharge.app.controller
{
    [ApiController]
    [Route("api/travel")]
    public class TravelController : ControllerBase
    {
        private readonly ITravelAdapter _travelAdapter;

        public TravelController(ITravelAdapter travelAdapter)
        {
            _travelAdapter = travelAdapter;
        }

        [HttpGet("{id}")]
        public ActionResult<Travel> FindById(int id)
        {
            try
            {
                var travel = _travelAdapter.FindById(id);
                return Ok(travel);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidIdFormatException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<Travel> Create([FromBody] Travel travel)
        {
            try
            {
                _travelAdapter.Create(travel);
                return CreatedAtAction(nameof(FindById), new { id = travel.Id }, travel);
            }
            catch (InvalidException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Travel> Update(int id, [FromBody] Travel travel)
        {
            try
            {
                var updatedTravel = _travelAdapter.Update(id, travel);
                return Ok(updatedTravel);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidIdFormatException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _travelAdapter.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidIdFormatException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
