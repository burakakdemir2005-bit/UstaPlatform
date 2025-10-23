using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UstaPlatform.Pricing;
using UstaPlatform.Domain.Models;

public class LoyaltyDiscountRule : IPricingRule
{
    public string Name => "LoyaltyDiscountRule";

    public decimal Apply(decimal price, PricingContext context)
    {
        // Örnek: eğer usta puanı > 4.5 ise %5 indirim
        if (context.Usta != null && context.Usta.Puan > 4.5)
        {
            return price * 0.95m;
        }
        return price;
    }
}
