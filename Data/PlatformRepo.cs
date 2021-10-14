using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : PlatformService.Data.IPlatformRepo
    {
        public PlatformRepo(DataBaseContext context)
        {
            _context = context;
        }
        private DataBaseContext _context { get; }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null) throw new ArgumentNullException();
            _context.Platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAll()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(plat => plat.Id == id);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}