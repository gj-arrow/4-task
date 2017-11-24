using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCars.Entities
{
    public class CharacteristicsCar
    {
        private readonly string _engine;
        private readonly string _transmission;

        public string Engine
        {
            get
            {
                return _engine;
            }
        }

        public string Transmission
        {
            get
            {
                return _transmission;
            }
        }

        public CharacteristicsCar(string engine, string transmission)
        {
            _engine = engine;
            _transmission = transmission;
        }

        public static bool Equals(CharacteristicsCar expectedCharacteristicsCar, CharacteristicsCar actualCharacteristicsCar)
        {
            return expectedCharacteristicsCar.Engine == actualCharacteristicsCar.Engine 
                && expectedCharacteristicsCar.Transmission == actualCharacteristicsCar.Transmission;
        }
    }
}
