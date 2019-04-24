using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFastPortScanner.Ports
{
    internal class Port
    {
        private const int PORT_MIN_VALUE = 1;
        private const int PORT_MAX_VALUE = 65535;

        internal Port(int nb)
        {
            if (!Enumerable.Range(1, 65535).Contains(nb))
                throw new ArgumentException("Port is out of range!");
            this.Nb = nb;
        }

        internal int Nb { get; private set; }
    }
}
