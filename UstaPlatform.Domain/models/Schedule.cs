using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public class Schedule
    {
        private readonly Dictionary<DateOnly, List<WorkOrder>> _dict = new();

        // Indexer: Schedule[DateOnly] => List<WorkOrder>
        public List<WorkOrder> this[DateOnly day]
        {
            get
            {
                if (!_dict.TryGetValue(day, out var list))
                {
                    list = new List<WorkOrder>();
                    _dict[day] = list;
                }
                return list;
            }
        }

        public void Add(WorkOrder wo)
        {
            this[wo.Tarih].Add(wo);
        }
    }
}
