using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.Entry(nationalPark).State = EntityState.Deleted;
            return Save();
        }

        public bool DeleteNationalPArk(int id)
        {
            var nationalPark = GetNationalPark(id);
            DeleteNationalPark(nationalPark);
            return Save();
        }

        public ICollection<NationalPark> GetAllNationalParks()
        {
            return _db.NationalParks.OrderBy(n => n.Name).ToList();
        }

        public NationalPark GetNationalPark(int id)
        {
            return _db.NationalParks.Find(id);
        }

        public bool NationalParkExists(string name)
        {
            bool value = _db.NationalParks.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _db.NationalParks.Any(n => n.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.Entry(nationalPark).State = EntityState.Modified;
            return Save();
        }
    }
}
