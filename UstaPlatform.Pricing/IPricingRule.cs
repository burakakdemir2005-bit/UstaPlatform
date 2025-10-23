using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Pricing;

namespace UstaPlatform.Pricing
{
    public interface IPricingRule
    {
        // Kurallar sırasıyla uygulanacak. Price bir önceki kuraldan gelen fiyattır.
        decimal Apply(decimal price, PricingContext context);
        string Name { get; }
    }
}
