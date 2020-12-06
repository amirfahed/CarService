using CarService.Database;
using CarService.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Repositories
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel: BaseModel
    {
        private ApplicationContext _context;
        private DbSet<TDbModel> _dbSet { get; set; }

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TDbModel>();
        }

        public TDbModel Create(TDbModel model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
            return model;
        }

        public List<TDbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public TDbModel Get(Guid id)
        {
            return _dbSet.FirstOrDefault(a => a.Id == id);
        }
        
        public void Update(TDbModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var toDelete = _dbSet.FirstOrDefault(m => m.Id == id);
            _dbSet.Remove(toDelete);
            _context.SaveChanges();
        }
    }
}
