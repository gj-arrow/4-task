using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCars.Utils
{
    public static class RandomUtil
    {
        private static readonly Random Random = new Random();

        public static string RandomValue(List<string> options)
        {
            var randomIndex = Random.Next(1, options.Count);
            return options[randomIndex]; 
        }
    }
}
