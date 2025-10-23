using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UstaPlatform.Domain.Models
{
    public class WorkOrder
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Talep Talep { get; init; } = null!;
        public Usta AtananUsta { get; init; } = null!;
        public decimal Fiyat { get; set; }
        public DateOnly Tarih { get; init; }
        public TimeOnly Saat { get; init; }
        public (int X, int Y)? RotaDurak { get; set; }
    }
}
