using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UstaPlatform.Domain.Models
{
    // IEnumerable<(int X,int Y)> implementasyonu ve Add metodu
    public class Route : IEnumerable<(int X, int Y)>
    {
        private readonly List<(int X, int Y)> _stops = new();

        public void Add(int X, int Y) => _stops.Add((X, Y));
        public IEnumerator<(int X, int Y)> GetEnumerator() => _stops.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => string.Join(" -> ", _stops.Select(p => $"({p.X},{p.Y})"));
    }
}

