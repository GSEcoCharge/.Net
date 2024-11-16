using Microsoft.AspNetCore.Mvc;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.model;
using EcoCharge.infra.exception;
using Microsoft.ML;

namespace EcoCharge.app.controllerk
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserAdapter _userAdapter;
        private readonly MLContext _mlContext;

        public UserController(IUserAdapter userAdapter)
        {
            _userAdapter = userAdapter;
            _mlContext = new MLContext();
        }

        [HttpGet("{id}")]
        public ActionResult<User> FindById(int id)
        {
            try
            {
                var user = _userAdapter.FindById(id);
                return Ok(user);
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
        public ActionResult<User> Create([FromBody] User user)
        {
            try
            {
                _userAdapter.Create(user);
                return CreatedAtAction(nameof(FindById), new { id = user.Id }, user);
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
        public ActionResult<User> Update(int id, [FromBody] User user)
        {
            try
            {
                var updatedUser = _userAdapter.Update(id, user);
                return Ok(updatedUser);
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
                _userAdapter.Delete(id);
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

        [HttpPost("analyze-sentiment")]
        public ActionResult AnalyzeSentiment([FromBody] string text)
        {
            try
            {
                var data = new[] { new User.SentimentData { Text = text } };
                var dataView = _mlContext.Data.LoadFromEnumerable(data);

                var model = _mlContext.Model.Load("Models/SentimentModel.zip", out _);

                var predictionEngine =
                    _mlContext.Model.CreatePredictionEngine<User.SentimentData, User.SentimentPrediction>(model);
                var prediction = predictionEngine.Predict(new User.SentimentData { Text = text });

                return Ok(new
                {
                    Sentiment = prediction.Prediction ? "Positivo" : "Negativo",
                    Confidence = prediction.Probability
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("{id}/recommend-charging")]
        public ActionResult RecommendChargingStations(int id)
        {
            try
            {
                var user = _userAdapter.FindById(id);
                if (user == null)
                {
                    return NotFound(new { message = "Usuário não encontrado" });
                }

                var data = new[]
                {
                    new User.ChargingHistoryData { Distance = 5.0f, BatteryLevel = 30.0f },
                    new User.ChargingHistoryData { Distance = 10.0f, BatteryLevel = 20.0f }
                };

                var dataView = _mlContext.Data.LoadFromEnumerable(data);

                var model = _mlContext.Model.Load("Models/ChargingRecommendationModel.zip", out _);

                var predictionEngine =
                    _mlContext.Model.CreatePredictionEngine<User.ChargingHistoryData, User.ChargingRecommendation>(model);

                var recommendations = data
                    .Select<User.ChargingHistoryData, User.ChargingRecommendation>(d => predictionEngine.Predict(d))
                    .ToList();

                return Ok(recommendations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
