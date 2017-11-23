using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCars.Entities
{
    public class Car
    {
        private readonly string _car;
        private readonly string _model;
        private readonly string _year;

        public string GetCar
        {
            get
            {
                return _car;
            }
        }

        public string GetModel
        {
            get
            {
                return _model;
            }
        }

        public string GetYear
        {
            get
            {
                return _year;
            }
        }

        public Car(string car, string model, string year)
        {
            _car = car;
            _model = model;
            _year = year;
        }

        public static bool Equals(Car expectedCar, Car actualCar)
        {
            return expectedCar.GetCar == actualCar.GetCar && expectedCar.GetModel == actualCar.GetModel
                   && expectedCar.GetYear == actualCar.GetYear;
        }
    }
}
