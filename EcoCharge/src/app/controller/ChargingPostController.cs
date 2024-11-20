using Microsoft.AspNetCore.Mvc;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.model;
using EcoCharge.infra.exception;

namespace EcoCharge.app.controller
{
    [ApiController]
    [Route("api/chargingPost")]
    public class ChargingPostController : ControllerBase
    {
        private readonly IChargingPostAdapter _chargingPostAdapter;

        public ChargingPostController(IChargingPostAdapter chargingPostAdapter)
        {
            _chargingPostAdapter = chargingPostAdapter;
        }

        [HttpGet("{id}")]
        public ActionResult<ChargingPost> FindById(string id)
        {
            try
            {
                var chargingPost = _chargingPostAdapter.FindById(id);
                return Ok(chargingPost);
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
        public ActionResult<ChargingPost> Create([FromBody] ChargingPost chargingPost)
        {
            try
            {
                _chargingPostAdapter.Create(chargingPost);
                return CreatedAtAction(nameof(FindById), new { id = chargingPost.Id }, chargingPost);
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
        public ActionResult<ChargingPost> Update(string id, [FromBody] ChargingPost chargingPost)
        {
            try
            {
                var updatedChargingPost = _chargingPostAdapter.Update(id, chargingPost);
                return Ok(updatedChargingPost);
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
                _chargingPostAdapter.Delete(id);
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
