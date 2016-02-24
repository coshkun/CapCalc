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
        public static ContainerInfo  Default = new ContainerInfo("13.6 Semitrailer", 13.60d, 2.40d, 2.80d);

        public string Name      { get; private set; }
        public double Long      { get; private set; }
        public double Height    { get; private set; }
        public double Width     { get; private set; }
        public double CBM       { get { return _getCBM(); } private set { } }
        public double Weight    { get; set; }

        //constructor (can be public or private depending on your needs)
        public ContainerInfo() { }
        public ContainerInfo(string Name, double Long, double Height, double Width)
        { this.Name = Name; this.Long = Long; this.Height = Height; this.Width = Width; this.Weight = 0; }

        private double _getCBM()
        {
            return (this.Long * this.Height * this.Width);
        }
    }

}
