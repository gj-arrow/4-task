namespace SmartCars.Entities
{
    public class CharacteristicsCar
    {
        private const char Separator = ',';
        public string Engine { get; private set; }
        public string Transmission { get; private set; }

        public CharacteristicsCar()
        {
            Engine = "";
            Transmission = "";
        }

        public CharacteristicsCar(string engine, string transmission)
        {
            Engine = engine;
            Transmission = transmission;
        }

        public override string ToString()
        {
            return Engine + Separator + 
                   Transmission;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            var characteristicsCar = obj as CharacteristicsCar;
            return characteristicsCar != null && Equals(characteristicsCar);
        }

        protected bool Equals(CharacteristicsCar characteristicsCar)
        {
            return characteristicsCar.Engine.Contains(Engine)
                   && characteristicsCar.Transmission.Contains(Transmission);
        }
    }
}
