using Example.DomainLayer;
using System.Linq;
using System.Linq.Expressions;

namespace Example.Database.Repositories.Personnels
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private readonly Context _context;

        public PersonnelRepository(Context context)
        {
            _context = context;
        }

        public async Task<Personnel> AddAsync(Personnel personnel)
        {
            return (await _context.Set<Personnel>().AddAsync(personnel)).Entity;
        }

        public async Task<Personnel> Get(int id)
        {
            var record=await _context.Set<Personnel>().FindAsync(id);
            return record;
        }

        public Personnel Update(Personnel personnel)
        {
            return (_context.Set<Personnel>().Update(personnel)).Entity;
        }


        public IQueryable<Personnel> GetPersonnelQueryble(Expression<Func<Personnel,bool>>? expression=null)
        {
            var query= _context.Set<Personnel>();

            if(expression!=null)
                return query.Where(expression);

            return query;
        }


    }
}
