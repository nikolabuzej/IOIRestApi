using IOIModel;
using System.Collections.Generic;

namespace IOIDataAccess.IReporsitories
{
    public interface IRepositoryWarranty : IRepository<Warranty>
    {
        IEnumerable<int> getAllId();
    }
}
