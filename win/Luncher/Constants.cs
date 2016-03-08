using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Luncher
{
    public static class Constants
    {
        public const int VERTICAL_CARGO_MARGIN = 10;  // in cm.
        public const int HORIZONTAL_CARGO_MARGIN = 10;// in cm.
    }

    public class ContainerInfo
    {
        public static ContainerInfo  Default = new ContainerInfo("13.6 Semitrailer", 13.60d, 2.80d, 2.40d, 22.0d);

        public string Name      { get; protected set; }
        public double Long      { get; protected set; } // in meter
        public double Height    { get; protected set; } // in meter
        public double Width     { get; protected set; } // in meter
        public double CBM       { get { return _getCBM(); } protected set { } } // in cubic meter
        public double SQR       { get { return _getSQR(); } protected set { } } // in square meter
        public double Weight    { get; set; } // in tons

        //constructor (can be public or private depending on your needs)
        public ContainerInfo() { }
        public ContainerInfo(string Name, double Long, double Height, double Width, double Weight)
        { this.Name = Name; this.Long = Long; this.Height = Height; this.Width = Width; this.Weight = Weight; }

        private double _getCBM()
        {
            return (this.Long * this.Height * this.Width);
        }

        private double _getSQR()
        {
            return (this.Long * this.Width);
        }
    }

    public class ContainerMatrix
    {
        CM2[,] data;
        List<string> cargoes = new List<string>();
        Rectangle space;
        int _SQR, _CBM, z=1;
        //CM3 c3 = new CM3();
        int restCBM, restSQR;
        Point currentIndex = Point.Empty; bool _firstIndexAssigned = false;
        List<Point> startIndexes = new List<Point>();
        ContainerInfo _owner;

        public ContainerInfo Owner
        {
            get { return _owner; }
            private set { _owner = value; }
        }

        public Point CurrentIndex
        {
            get { return currentIndex; }
            private set { currentIndex = value; }
        }
        public List<Point> StartIndexes
        {
            get { return startIndexes; }
            private set { startIndexes = value; }
        }

        public int RestSQR
        {
            get { return restSQR; }
            set { restSQR = value; }
        }
        public int RestCBM
        {
            get { return restCBM; }
            set { restCBM = value; }
        }
 
        public Rectangle Space
        {
            get { return space; }
            set { space = value; }
        }

        public List<string> Cargoes
        {
            get { return cargoes; }
            set { cargoes = value; }
        }

        public CM2[,] Data
        {
            get { return data; }
            set { data = value; }
        }

        private int getRestSQR()
        {
            return 1;
        }
        private int getRestCBM()
        {
            return 1;
        }
        
        public void SetIndex(CM2 Node, string IndexType, bool value)
        {
            switch (IndexType)
            {
                case "START":
                    Node.StartIndex = value; break;
                case "END":
                    Node.EndIndex = value; break;
                default:
                    break;
            }
        }
        public int  GetIndex(CM2 Node, string IndexType)
        {
            int snc = -1;
            switch (IndexType)
            {
                case "START":
                    snc = (Node.StartIndex)?1:0; break;
                case "END":
                    snc = (Node.EndIndex)?1:0; break;
                default:
                    snc = -1; break;
            }
            return snc;
        }

        public void ClearIndexses()
        {
            foreach (CM2 node in data) 
            { node.StartIndex = false; node.EndIndex = false; }
        }
        public void ResetIndexes()
        {
            ClearIndexses();
            startIndexes.Clear();
            _firstIndexAssigned = false;
            currentIndex = Point.Empty;
            int row = data.GetLength(0); // Get first dimention as rows
            int col = data.GetLength(1); // Get second dimention as columns
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var node = data[i, j];
                    if (node.IsLoaded) { continue; } // those areas are loaded with some cargo, skip your loop
                    else 
                    {   // There is no colission here
                        // Check if there is another index before:
                        if (currentIndex == Point.Empty && _firstIndexAssigned == false)
                        {   // If this is the first assignment
                            node.StartIndex = true;
                            currentIndex = new Point(i, j);
                            startIndexes.Add(currentIndex);
                            _firstIndexAssigned = true;
                            break; // to the next row of your container
                        }
                        if (currentIndex != Point.Empty && currentIndex.Y == j)
                        {
                            // if there is a start index in your same column before
                            break; // to the next row of your container
                        }
                        if (currentIndex != Point.Empty && currentIndex.Y != j)  //Here to make new assigments for secondary and next indexes
                        {
                            int line = i, column = j;
                            // Now check the boundaries of container and destroy index if too close
                            if (column > (col - Constants.HORIZONTAL_CARGO_MARGIN))
                            {/* Destroy index here */ node.StartIndex = false; continue; /* to the next column */ }
                            if (line > (row - Constants.VERTICAL_CARGO_MARGIN))
                            {/* Destroy index here again to prevent any overflow */ node.StartIndex = false; continue; /* to the next row */ }

                            else // you are still in availible space, so it is safe to place a new start index again.
                            { 
                            node.StartIndex = true;
                            currentIndex = new Point(i, j);
                            startIndexes.Add(currentIndex);
                            break; // to the next row of your container
                            }
                        }
                    }
                } // end of columns
            } // end of rows
              // Now Assing the first element of Index cache as the CurrentIndex; // we will change here for different Gravity offsets.
            
            //int k = 0;
            //while (data[startIndexes[k].X, startIndexes[k].Y].IsLoaded)
            //{
            //    startIndexes.RemoveAt(k);
            //    k++;
            //}
            //currentIndex = startIndexes.First();

        }
        public void ClearData()
        {
            foreach (CM2 node in data) 
            { node.StartIndex = false; node.EndIndex = false; node.IsLoaded = false; }
        }
        public void ReCreateMatrix(int x,int y)
        {
            data = new CM2[x + 1 , y + 1];
            initialize(x, y);
            space = new System.Drawing.Rectangle(0, 0, x, y);
            _SQR = x * y; _CBM = x * y * z;
            restSQR = _SQR; RestCBM = _CBM;
            data[0, 0].StartIndex = true;
        }
        public void ReCreateMatrix(ContainerInfo Container)
        {
            data = new CM2[(int)Container.Width + 1, (int)Container.Long + 1];
            initialize((int)Container.Long, (int)Container.Width);
            space = new System.Drawing.Rectangle(0, 0, (int)Container.Long, (int)Container.Width);
            _SQR = (int)Container.SQR; _CBM = (int)Container.CBM;
            restSQR = _SQR; RestCBM = _CBM;
            data[0, 0].StartIndex = true;
        }
        public bool AddCargo(CargoInfo Cargo, Point Index)
        {
            int row = 0, col = 0;
            int dimY = data.GetLength(0); // Max height of the container
            int dimX = data.GetLength(1); // Max width of the container

            if (Index.Y + Cargo.Space.Width < dimX && Index.X + Cargo.Space.Height < dimY) // if it fits to container
            { // While Index.Y is the column number of index.. Index.X is the row number
                for (int i = 0; i < Cargo.Space.Height; i++) // start scanfor rows
                {
                    for (int j = 0; j < Cargo.Space.Width; j++) // start scan for columns
                    {
                        row = i + Index.X; col = j + Index.Y;
                        data[row, col].StartIndex = false;
                        data[row, col].IsLoaded = true;
                        data[row, col].Owner = Cargo.Name;
                    }
                }
                // data[Cargo.Space.X, col + 1].StartIndex = true;
                ResetIndexes();
                cargoes.Add(Cargo.Name);
                Cargo.IsLoaded = true;
                return true;
            }
            else
            { // give out of size err.here
                return false;
            }

        }
        public bool TestCargo(CargoInfo Cargo, Point Index)
        {
            //int row=0, col=0;
            int dimY = data.GetLength(0); // Max width of the container
            int dimX = data.GetLength(1); // Max heigth of the container

            if (Index.Y + Cargo.Space.Width < dimX && Index.X + Cargo.Space.Height < dimY) // if it fits to container
            { // While Index.Y is the column number of index.. Index.X is the row number
                
                return true;
            }
            else 
            { // give out of size err.here
                return false;
            }

        }
        public void FlipHorizontal()
        {
            int row = 0, col = 0;
            int dimY = data.GetLength(0) - 1; // Max height of the container
            int dimX = data.GetLength(1) - 1; // Max width of the container
            // CM2[,] buffer = new CM2[dimY, dimX];
            // CM2 swap = new CM2();

            // initialize(ref buffer, dimY, dimX);

            for (int i = 0; i < dimY; i++) // start scanfor rows
            {
                for (int j = 0; j < dimX / 2; j++) // start scan for columns
                {
                    row = i; col = dimX - j;
                    var swap = this.data[row, col];
                    this.data[row, col] = data[row, j];
                    this.data[row, j] = swap;
                }
            }

            // data[Cargo.Space.X, col + 1].StartIndex = true;
            // ResetIndexes();
        }

        public ContainerMatrix(int x, int y)
        {
            data = new CM2[x + 1 , y + 1];
            initialize(x, y);
            space = new System.Drawing.Rectangle(0, 0, x, y);
            _SQR = x * y; _CBM = x*y*z;
            restSQR = _SQR; RestCBM = _CBM;
            data[0, 0].StartIndex = true;
        }
        public ContainerMatrix(int x, int y, int z)
        {
            data = new CM2[x + 1 , y + 1 ];
            initialize(x,y);
            space = new System.Drawing.Rectangle(0, 0, x, y);
            _SQR = x * y; _CBM = x * y * z;
            restSQR = _SQR; RestCBM = _CBM;
            data[0, 0].StartIndex = true;
        }
        /// <summary>
        /// Pay attention to use "cm" as base unit. No convertion funtion included for scaling.
        /// </summary>
        /// <param name="Container"></param>
        public ContainerMatrix(ContainerInfo Container)
        {
            _owner = Container;
            data = new CM2[(int)Container.Width + 1, (int)Container.Long + 1 ];
            initialize((int)Container.Width, (int)Container.Long);
            space = new System.Drawing.Rectangle(0, 0, (int)Container.Width, (int)Container.Long);
            _SQR = (int)Container.SQR; _CBM = (int)Container.CBM;
            restSQR = _SQR; RestCBM = _CBM;
            ResetIndexes();// data[0, 0].StartIndex = true;
        }
        private void initialize(int x, int y)
        {
            _firstIndexAssigned = false;
            for (long i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    data[i, j] = new CM2();
                }
            }
        }
        public void initialize(ref CM2[,] buffer ,int x, int y)
        {
            for (long i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    buffer[i, j] = new CM2();
                }
            }
        }
    }

    public class CargoInfo
    {
        public static CargoInfo Default = new CargoInfo(string.Empty, 0d, 0d, 0d, 0d);

        double _height, _width, _long;
        bool isLoaded = false;
        Rectangle space = new Rectangle();

        public string Name      { get; set; }
        public double Long      { get { return _long; }
                                  set { _long = value; space = 
                                  new Rectangle(space.X, space.Y, (int)value,(int) _width); } } // in meter
        public double Height    { get { return _height; } set { _height = value; } } // in meter
        public double Width     { get { return _width; }
                                  set { _width = value; space = 
                                  new Rectangle(space.X, space.Y, (int)_long,(int) value); } }  // in meter
        public double CBM       { get { return _getCBM(); } private set { } } // in cubic meter
        public double SQR       { get { return _getSQR(); } private set { } } // in square meter
        public double Weight    { get; set; } // in tons
        public int Level        { get; set; } // as quantity/count

        public bool IsLoaded    { get { return isLoaded; } set { isLoaded = value; } }
        public Rectangle Space  { get { return space; }
                                  set { space = value; _long = value.Width; _width = value.Height; } }

        public CargoInfo() { }
        public CargoInfo(string Name, double Long, double Height, double Width, double Weight)
        { this.Name = Name; _long = Long; this._height = Height; this._width = Width; this.Weight = Weight;
        SetPosition(0,0); }
        public CargoInfo(string Name, double Long, double Height, double Width, double Weight, int x, int y)
        { this.Name = Name; _long = Long; this._height = Height; this._width = Width; this.Weight = Weight;
            SetPosition(x, y); }

        public void SetPosition(int x, int y)
        {
            this.space = new Rectangle(x, y, (int)this.Long, (int)this.Width);
        }

        private double _getCBM()
        {
            return (this.Long * this.Height * this.Width);
        }

        private double _getSQR()
        {
            return (this.Long * this.Width);
        }
    }

    public class CM2
    {
        public static CM2 Default = new CM2();

        bool isLoaded, startIndex, endIndex;
        string owner;

        public CM2()
        { isLoaded = false; startIndex = false; endIndex = false; owner = string.Empty; }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public bool EndIndex
        {
            get { return endIndex; }
            set { endIndex = value; }
        }

        public bool StartIndex
        {
            get { return startIndex; }
            set { startIndex = value; }
        }

        public bool IsLoaded
        {
            get { return isLoaded; }
            set { isLoaded = value; }
        }
    }

    public class CM3 : CM2
    {
        public static CM3 Default = new CM3();

        bool zIndex = false;

        public bool ZIndex
        {
            get { return zIndex; }
            set { zIndex = value; }
        }

        public CM3() : base() { }
    }
}
