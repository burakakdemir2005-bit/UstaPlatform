using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UstaPlatform.Pricing;

namespace UstaPlatform.Infrastructure
{
    public class PricingEngine
    {
        private readonly List<IPricingRule> _rules = new();

        public IReadOnlyList<IPricingRule> Rules => _rules;

        public PricingEngine() { }

        // Pluginları belirtilen klasörden yükle
        public void LoadPluginsFrom(string pluginsFolder)
        {
            if (!Directory.Exists(pluginsFolder)) return;

            var dlls = Directory.GetFiles(pluginsFolder, "*.dll");
            foreach (var dll in dlls)
            {
                try
                {
                    var asm = Assembly.LoadFrom(dll);
                    var types = asm.GetTypes().Where(t => typeof(IPricingRule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
                    foreach (var t in types)
                    {
                        // parametresiz ctor varsayımı
                        if (Activator.CreateInstance(t) is IPricingRule rule)
                        {
                            _rules.Add(rule);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Plugin yüklenemedi {dll}: {ex.Message}");
                }
            }
        }

        public decimal CalculatePrice(decimal basePrice, PricingContext context)
        {
            decimal price = basePrice;
            foreach (var rule in _rules)
            {
                price = rule.Apply(price, context);
            }
            return price;
        }

        // İç kurallar eklemek istersen:
        public void RegisterRule(IPricingRule r) => _rules.Add(r);
    }
}
