using IOIDataAccess.IReporsitories;
using IOIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IOIDataAccess.Implementations
{
    public class RepositoryIOI : IRepositoryIOI
    {
        private readonly IOIContext context;

        public RepositoryIOI(IOIContext context)
        {
            this.context = context;
        }
        public void Add(IOI item)
        {
            context.IOI.Add(item);
        }

        public void Delete(IOI item)
        {
            context.IOI.Remove(item);
        }

        public IOI FindById(int id)
        {
            return context.IOI.Find(id);
        }

        public List<IOI> GetAll()
        {
            return context.IOI.ToList();
        }

        public List<IOI> Search(Expression<Func<IOI, bool>> pred)
        {
            return context.IOI.Where(pred).ToList();
        }
    }
}
