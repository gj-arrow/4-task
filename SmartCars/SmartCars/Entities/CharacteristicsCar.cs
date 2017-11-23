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

        public string GetEngine
        {
            get
            {
                return _engine;
            }
        }

        public string GetTransmission
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
    }
}
