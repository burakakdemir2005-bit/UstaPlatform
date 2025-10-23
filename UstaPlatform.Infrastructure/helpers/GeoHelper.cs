using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Infrastructure.Helpers
{
    public static class GeoHelper
    {
        // Basit heuristik: adres stringinden rastgele koordinat üret (örnek)
        public static (int X, int Y) GetCoordinates(string address)
        {
            unchecked
            {
                int h = address.GetHashCode();
                return (Math.Abs(h) % 100, Math.Abs(h / 100) % 100);
            }
        }
    }
}
