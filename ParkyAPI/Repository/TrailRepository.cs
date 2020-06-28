using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _db;
        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateTrail(Trail trail)
        {
            _db.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _db.Entry(trail).State = EntityState.Deleted;
            return Save();
        }

        public bool DeleteTrail(int id)
        {
            var trail = GetTrail(id);
            DeleteTrail(trail);
            return Save();
        }

        public ICollection<Trail> GetAllTrails()
        {
            return _db.Trails.OrderBy(n => n.Name).ToList();
        }

        public Trail GetTrail(int id)
        {
            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == id);
        }

        public bool TrailExists(string name)
        {
            bool value = _db.Trails.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            return _db.Trails.Any(n => n.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Entry(trail).State = EntityState.Modified;
            return Save();
        }

        public ICollection<Trail> GetTrailsInNationalPark(int nationalPatkId)
        {
            return _db.Trails.Include(c => c.NationalPark).Where(c => c.NationalParkId == nationalPatkId).ToList();
        }
    }
}
