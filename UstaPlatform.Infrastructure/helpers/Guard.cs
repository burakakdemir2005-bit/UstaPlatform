using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Infrastructure.Helpers
{
    public static class Guard
    {
        public static void AgainstNull(object? o, string name)
        {
            if (o is null) throw new ArgumentNullException(name);
        }

        public static void AgainstNegative(decimal value, string name)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(name);
        }
    }
}
