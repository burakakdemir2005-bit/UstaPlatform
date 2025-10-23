using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UstaPlatform.Infrastructure.Helpers
{
    public static class MoneyFormatter
    {
        public static string Format(decimal amount)
            => string.Format(CultureInfo.GetCultureInfo("tr-TR"), "{0:C}", amount);
    }
}
