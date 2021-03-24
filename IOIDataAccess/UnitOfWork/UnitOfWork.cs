using IOIDataAccess.Implementations;
using IOIDataAccess.IReporsitories;
using IOIModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOIDataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOIContext context;

        public UnitOfWork(IOIContext context)
        {
            this.context = context;
            IOI = new RepositoryIOI(context);
            Warranty = new RepositoryWarranty(context);
        }
        public IRepositoryIOI IOI { get; set; }
        public IRepositoryWarranty Warranty { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
