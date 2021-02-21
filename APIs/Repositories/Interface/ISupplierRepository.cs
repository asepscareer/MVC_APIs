using APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIs.Repositories.Interface
{
    interface ISupplierRepository
    {
        IEnumerable<Supplier> Get();
        Task<IEnumerable<Supplier>> GetById(int Id);
        int Create(Supplier supplier);
        int Update(Supplier supplier, int Id);
        int Delete(int Id);

    }
}
