using Microsoft.AspNetCore.Mvc;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.model;
using EcoCharge.infra.exception;

namespace EcoCharge.app.controller
{
    [ApiController]
    [Route("api/chargingHistory")]
    public class ChargingHistoryController : ControllerBase
    {
        private readonly IChargingHistoryAdapter _chargingHistoryAdapter;

        public ChargingHistoryController(IChargingHistoryAdapter chargingHistoryAdapter)
        {
            _chargingHistoryAdapter = chargingHistoryAdapter;
        }

        [HttpGet("{id}")]
        public ActionResult<ChargingHistory> FindById(int id)
        {
            try
            {
                var chargingHistory = _chargingHistoryAdapter.FindById(id);
                return Ok(chargingHistory);
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
        public ActionResult<ChargingHistory> Create([FromBody] ChargingHistory chargingHistory)
        {
            try
            {
                _chargingHistoryAdapter.Create(chargingHistory);
                return CreatedAtAction(nameof(FindById), new { id = chargingHistory.Id }, chargingHistory);
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
        public ActionResult<ChargingHistory> Update(int id, [FromBody] ChargingHistory chargingHistory)
        {
            try
            {
                var updatedChargingHistory = _chargingHistoryAdapter.Update(id, chargingHistory);
                return Ok(updatedChargingHistory);
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
                _chargingHistoryAdapter.Delete(id);
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
