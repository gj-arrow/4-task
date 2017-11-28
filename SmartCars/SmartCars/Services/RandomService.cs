using System;
using System.Collections.Generic;

namespace SmartCars.Services
{
    public static class RandomService
    {
        private static readonly Random Random = new Random();

        public static string RandomValue(List<string> options)
        {
            var randomIndex = Random.Next(1, options.Count);
            return options[randomIndex]; 
        }
    }
}
