using IOIModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOIDataAccess.IReporsitories
{
  public  interface IRepositoryWarranty: IRepository<Warranty>
    {
        IEnumerable<int> getAllId();
    }
}
