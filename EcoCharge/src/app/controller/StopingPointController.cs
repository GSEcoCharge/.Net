using Microsoft.AspNetCore.Mvc;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.model;
using EcoCharge.infra.exception;

namespace EcoCharge.app.controller
{
    [ApiController]
    [Route("api/stopingPoint")]
    public class StopingPointController : ControllerBase
    {
        private readonly IStopingPointAdapter _stopingPointAdapter;

        public StopingPointController(IStopingPointAdapter stopingPointAdapter)
        {
            _stopingPointAdapter = stopingPointAdapter;
        }

        [HttpGet("{id}")]
        public ActionResult<StopingPoint> FindById(string id)
        {
            try
            {
                var stopingPoint = _stopingPointAdapter.FindById(id);
                return Ok(stopingPoint);
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
        public ActionResult<StopingPoint> Create([FromBody] StopingPoint stopingPoint)
        {
            try
            {
                _stopingPointAdapter.Create(stopingPoint);
                return CreatedAtAction(nameof(FindById), new { id = stopingPoint.Id }, stopingPoint);
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
        public ActionResult<StopingPoint> Update(string id, [FromBody] StopingPoint stopingPoint)
        {
            try
            {
                var updatedStopingPoint = _stopingPointAdapter.Update(id, stopingPoint);
                return Ok(updatedStopingPoint);
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
        public IActionResult Delete(string id)
        {
            try
            {
                _stopingPointAdapter.Delete(id);
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
