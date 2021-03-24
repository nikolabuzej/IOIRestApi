using IOIDataAccess.IReporsitories;
using IOIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IOIDataAccess.Implementations
{
    public class RepositoryWarranty : IRepositoryWarranty
    {
        private readonly IOIContext context;

        public RepositoryWarranty(IOIContext context)
        {
            this.context = context;
        }
        public void Add(Warranty item)
        {
            context.Warranties.Add(item);
        }

        public void Delete(Warranty item)
        {
            context.Warranties.Remove(item);
        }

        public Warranty FindById(int id)
        {
           return context.Warranties.Find(id);
        }

        public List<Warranty> GetAll()
        {
            return context.Warranties.ToList();
        }

        public IEnumerable<int> getAllId()
        {
            return context.Warranties.Select(w => w.WarrantyId);
        }

        public List<Warranty> Search(Expression<Func<Warranty, bool>> pred)
        {
            return context.Warranties.Where(pred).ToList();
        }
    }
}
