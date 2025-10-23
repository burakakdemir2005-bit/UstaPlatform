using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Pricing
{
    public class PricingContext
    {
        public Talep Talep { get; init; } = null!;
        public Usta? Usta { get; init; }
        public DateTime RequestTime { get; init; } = DateTime.UtcNow;
    }
}
