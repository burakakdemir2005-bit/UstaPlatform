using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public class Usta
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Ad { get; init; } = string.Empty;
        public string Uzmanlik { get; init; } = string.Empty;
        public double Puan { get; set; }
        public int AktifIsSayisi { get; set; } = 0; // yük dengeleme için
    }
}
