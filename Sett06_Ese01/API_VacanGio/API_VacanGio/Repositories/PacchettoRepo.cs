using API_VacanGio.Context;
using API_VacanGio.Models;

namespace API_VacanGio.Repositories
{
    public class PacchettoRepo : IRepoLettura<Pacchetto>, IRepoScrittura<Pacchetto>
    {
        private readonly VaContext _context;

        public PacchettoRepo(VaContext context)
        {
            _context = context;
        }
        public bool Create(Pacchetto entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pacchetto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pacchetto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pacchetto entity)
        {
            throw new NotImplementedException();
        }
    }
}
