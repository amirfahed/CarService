using CarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public interface IBaseRepository<TDbModel> where TDbModel: BaseModel
    {
        public List<TDbModel> GetAll();

        public TDbModel Get(Guid id);

        public TDbModel Create(TDbModel model);

        public void Update(TDbModel model);

        public void Delete(Guid id);
    }
}
