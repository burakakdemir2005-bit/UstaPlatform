using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Infrastructure.Repositories
{
    public interface IWorkOrderRepository
    {
        void Add(WorkOrder wo);
        IEnumerable<WorkOrder> GetAll();
        IEnumerable<WorkOrder> GetByUsta(Guid ustaId);
    }
}
