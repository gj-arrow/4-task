namespace SmartCars.Entities
{
    public class Car
    {
        public string Make { get;  set; }
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

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            var car = obj as Car;
            return car != null && Equals(car);
        }

        protected bool Equals(Car car)
        {
            return Make.Equals(car.Make)
                   && Model.Equals(car.Model)
                   && Year.Equals(car.Year);
        }

        public override string ToString()
        { 
            return Make + ", " + Model + ", " + Year;
        }
    }
}
