using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Infrastructure.Repositories
{
    public class InMemoryWorkOrderRepository : IWorkOrderRepository
    {
        private readonly List<WorkOrder> _list = new();

        public void Add(WorkOrder wo)
        {
            _list.Add(wo);
        }

        public IEnumerable<WorkOrder> GetAll() => _list;

        public IEnumerable<WorkOrder> GetByUsta(Guid ustaId) => _list.Where(w => w.AtananUsta.Id == ustaId);
    }
}

