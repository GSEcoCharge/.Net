using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly ApplicationDbContext _context;

        public EvaluationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Evaluation FindById(string id)
        {
            return _context.Evaluations.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Evaluation booking)
        {
            _context.Evaluations.Add(booking);
            _context.SaveChanges();
        }

        public Evaluation Update(string id, Evaluation booking)
        {
            var existingEvaluation = _context.Evaluations.FirstOrDefault(c => c.Id == id);

            if (existingEvaluation == null)
            {
                throw new KeyNotFoundException($"Evaluation with ID {id} not found.");
            }

            existingEvaluation.UserId = booking.UserId;
            existingEvaluation.ChargingPostId = booking.ChargingPostId;
            existingEvaluation.Rating = booking.Rating;
            existingEvaluation.EvaluationComment = booking.EvaluationComment;
            existingEvaluation.RatingDate = booking.RatingDate;

            _context.Evaluations.Update(existingEvaluation);
            _context.SaveChanges();

            return existingEvaluation;
        }
        
        public void Delete(string id)
        {
            var booking = _context.Evaluations.FirstOrDefault(c => c.Id == id);

            if (booking != null)
            {
                _context.Evaluations.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}