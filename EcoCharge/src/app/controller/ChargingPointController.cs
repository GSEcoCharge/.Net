using Microsoft.AspNetCore.Mvc;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.model;
using EcoCharge.infra.exception;

namespace EcoCharge.app.controller
{
    [ApiController]
    [Route("api/chargingPoint")]
    public class ChargingPointController : ControllerBase
    {
        private readonly IChargingPointAdapter _chargingPointAdapter;

        public ChargingPointController(IChargingPointAdapter chargingPointAdapter)
        {
            _chargingPointAdapter = chargingPointAdapter;
        }

        [HttpGet("{id}")]
        public ActionResult<ChargingPoint> FindById(int id)
        {
            try
            {
                var chargingPoint = _chargingPointAdapter.FindById(id);
                return Ok(chargingPoint);
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
        public ActionResult<ChargingPoint> Create([FromBody] ChargingPoint chargingPoint)
        {
            try
            {
                _chargingPointAdapter.Create(chargingPoint);
                return CreatedAtAction(nameof(FindById), new { id = chargingPoint.Id }, chargingPoint);
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
        public ActionResult<ChargingPoint> Update(int id, [FromBody] ChargingPoint chargingPoint)
        {
            try
            {
                var updatedChargingPoint = _chargingPointAdapter.Update(id, chargingPoint);
                return Ok(updatedChargingPoint);
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
                _chargingPointAdapter.Delete(id);
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
