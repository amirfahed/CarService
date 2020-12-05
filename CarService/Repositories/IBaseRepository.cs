using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IBaseRepository<TDbModel>
    {
        public List<TDbModel> GetAll();

        public TDbModel Get(Guid id);

        public TDbModel Create(TDbModel model);

        public TDbModel Update(TDbModel model);

        public void Delete(Guid id);
    }
}
