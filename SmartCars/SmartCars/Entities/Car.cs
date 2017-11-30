namespace SmartCars.Entities
{
    public class Car
    {
        private const char Separator = ',';
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public CharacteristicsCar CharacteristicsCar = new CharacteristicsCar();

        public Car(string make, string model, string year)
        {
            Make = make;
            Model = model;
            Year = year;
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
                   && Year.Equals(car.Year)
                   && CharacteristicsCar.Equals(car.CharacteristicsCar);
        }

        public override string ToString()
        {
            return Make + Separator +
                   Model + Separator +
                   Year + Separator +
                   CharacteristicsCar;
        }
    }
}
