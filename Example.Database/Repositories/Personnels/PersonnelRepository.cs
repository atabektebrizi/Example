using Example.DomainLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Example.Database.Repositories.Personnels
{
    public class PersonnelRepository :BaseRepository<Personnel>, IPersonnelRepository
    {        
        public PersonnelRepository(Context context):base(context)
        {            
        }

        public async Task<Personnel> AddAsync(Personnel personnel)
        {
            await AddAsync(personnel);
            return personnel;
        }

        public async Task<Personnel> Update(Personnel personnel)
        {
            await UpdateAsync(personnel);
            return personnel;
        }

        public IQueryable<Personnel> GetPersonnelQueryble(Expression<Func<Personnel,bool>>? expression=null)
        {
            return expression==null? Queryable():Queryable(expression);
        }


    }
}
