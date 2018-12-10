using System;
using AspNetCoreAppEFCore.Data;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.BusinessLogic
{
    public class DbPersister : IDbPersister
    {
        private readonly DataContext _context;

        public DbPersister(DataContext context)
        {
            _context = context;
        }

        public bool Save(DataModel data)
        {
            try
            {
                _context.DataModels.Add(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
