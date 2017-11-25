using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool Equals(CharacteristicsCar expectedCharacteristicsCar, CharacteristicsCar actualCharacteristicsCar)
        {
            return actualCharacteristicsCar.Engine.Contains(expectedCharacteristicsCar.Engine)
                && actualCharacteristicsCar.Transmission.Contains(expectedCharacteristicsCar.Transmission);
        }
    }
}
