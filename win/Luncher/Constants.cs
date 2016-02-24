using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luncher
{
    public static class Constants
    {
    }

    public class ContainerInfo
    {
        public static ContainerInfo  Default = new ContainerInfo("13.6 Semitrailer", 13.60d, 2.80d, 2.40d, 22.0d);

        public string Name      { get; private set; }
        public double Long      { get; private set; } // in meter
        public double Height    { get; private set; } // in meter
        public double Width     { get; private set; } // in meter
        public double CBM       { get { return _getCBM(); } private set { } } // in cubic meter
        public double Weight    { get; set; } // in tons

        //constructor (can be public or private depending on your needs)
        public ContainerInfo() { }
        public ContainerInfo(string Name, double Long, double Height, double Width, double Weight)
        { this.Name = Name; this.Long = Long; this.Height = Height; this.Width = Width; this.Weight = Weight; }

        private double _getCBM()
        {
            return (this.Long * this.Height * this.Width);
        }
    }

}
