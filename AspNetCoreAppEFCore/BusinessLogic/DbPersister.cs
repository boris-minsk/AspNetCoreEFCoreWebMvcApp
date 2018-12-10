using System.Collections.Generic;
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

        public void Save(IEnumerable<DataModel> data)
        {
            foreach (var model in data)
            {
                _context.DataModels.Add(model);
            }
            _context.SaveChanges();
        }
    }
}
