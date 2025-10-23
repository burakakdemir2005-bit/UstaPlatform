using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public class Talep
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Vatandas Sahip { get; init; } = null!;
        public string Aciklama { get; init; } = string.Empty;
        public DateOnly IstenenGun { get; init; }
        public TimeOnly IstenenSaat { get; init; }
        public decimal TahminiFiyat { get; set; } = 0m;
    }
}
