namespace SmartCars.Entities
{
    public class CharacteristicsCar
    {
        public string Engine { get; private set; }
        public string Transmission { get; private set; }

        public CharacteristicsCar(string engine, string transmission)
        {
            Engine = engine;
            Transmission = transmission;
        }

        public override string ToString()
        {
            return Engine + ", " + Transmission;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            var carCharacteristics = obj as CharacteristicsCar;
            return carCharacteristics != null && Equals(carCharacteristics);
        }

        protected bool Equals(CharacteristicsCar carCharacteristics)
        {
            return carCharacteristics.Engine.Contains(Engine)
                   && carCharacteristics.Transmission.Contains(Transmission);
        }

    }
}
