﻿using EcoCharge.domain.model;
using EcoCharge.domain.repository;

namespace EcoCharge.adapter.output.database
{
    public class StopingPointRepository : IStopingPointRepository
    {
        private readonly ApplicationDbContext _context;

        public StopingPointRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public StopingPoint FindById(int id)
        {
            var stopingPoint = _context.StopingPoints.FirstOrDefault(c => c.Id == id);

            if (stopingPoint == null)
            {
                throw new KeyNotFoundException($"StopingPoint with ID {id} not found.");
            }

            return stopingPoint;
        }

        public void Create(StopingPoint stopingPoint)
        {
            _context.StopingPoints.Add(stopingPoint);
            _context.SaveChanges();
        }

        public StopingPoint Update(int id, StopingPoint stopingPoint)
        {
            var existingStopingPoint = _context.StopingPoints.FirstOrDefault(c => c.Id == id);

            if (existingStopingPoint == null)
            {
                throw new KeyNotFoundException($"StopingPoint with ID {id} not found.");
            }

            existingStopingPoint.TravelId = stopingPoint.TravelId;
            existingStopingPoint.ChargingPointId = stopingPoint.ChargingPointId;
            existingStopingPoint.Order = stopingPoint.Order;

            _context.StopingPoints.Update(existingStopingPoint);
            _context.SaveChanges();

            return existingStopingPoint;
        }
        
        public void Delete(int id)
        {
            var stopingPoint = _context.StopingPoints.FirstOrDefault(c => c.Id == id);

            if (stopingPoint != null)
            {
                _context.StopingPoints.Remove(stopingPoint);
                _context.SaveChanges();
            }
        }
    }
}