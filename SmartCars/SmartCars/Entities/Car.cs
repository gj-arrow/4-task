using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCars.Entities
{
    public class Car
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string Year { get; private set; }

        public Car(string make, string model, string year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public static bool Equals(Car expectedCar, Car actualCar)
        {
            return expectedCar.Make == actualCar.Make && expectedCar.Model == actualCar.Model
                   && expectedCar.Year == actualCar.Year;
        }
    }
}
