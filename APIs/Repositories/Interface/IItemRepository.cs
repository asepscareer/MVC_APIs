using APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIs.Repositories.Interface
{
    interface IItemRepository
    {
        IEnumerable<ViewItem> Get();
        Task<IEnumerable<ViewItem>> GetById(int Id);
        int Create(Item item);
        int Update(Item item, int Id);
        int Delete(int Id);
    }
}
