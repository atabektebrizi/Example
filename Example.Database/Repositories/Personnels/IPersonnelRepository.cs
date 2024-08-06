using Example.DomainLayer;
using System.Linq.Expressions;

namespace Example.Database.Repositories.Personnels
{
    public interface IPersonnelRepository
    {
        Task<Personnel> AddAsync(Personnel personnel);
        Task<Personnel> Get(int id);
        Personnel Update(Personnel personnel);

        IQueryable<Personnel> GetPersonnelQueryble(Expression<Func<Personnel, bool>>? expression = null);
    }
}
