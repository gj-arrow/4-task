using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCars.Entities
{
    public class Car
    {
        private readonly string _make;
        private readonly string _model;
        private readonly string _year;

        public string Make
        {
            get
            {
                return _make;
            }
        }
    
        public string Model
        {
            get
            {
                return _model;
            }
        }

        public string Year
        {
            get
            {
                return _year;
            }
        }

        public Car(string make, string model, string year)
        {
            _make = make;
            _model = model;
            _year = year;
        }

        public static bool Equals(Car expectedCar, Car actualCar)
        {
            return expectedCar.Make == actualCar.Make && expectedCar.Model == actualCar.Model
                   && expectedCar.Year == actualCar.Year;
        }
    }
}
