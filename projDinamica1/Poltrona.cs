using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projDinamica1
{
    class Poltrona
    {
        private bool ocupada;

        public bool Ocupada
        {
            get { return ocupada; }
            set { ocupada = value; }
        }

        public Poltrona()
        {
            this.ocupada = false;
        }

    }
}
