using IOIDataAccess.IReporsitories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOIDataAccess.UnitOfWork
{
  public interface IUnitOfWork: IDisposable
    {
        public IRepositoryIOI IOI{ get; set; }
        public IRepositoryWarranty Warranty { get; set; }
        public void Commit();
    }
}
