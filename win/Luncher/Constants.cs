﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
        public double SQR       { get { return _getSQR(); } private set { } } // in square meter
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
        string[] cargoes;
        Rectangle space;
        int _SQR, _CBM, z=1;
        CM3 c3 = new CM3();
        int restCBM, restSQR;
        Point currentIndex = Point.Empty; bool _firstIndexAssigned = false;
        List<Point> startIndexes = new List<Point>();

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

        public string[] Cargoes
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
            int x = data.GetLength(0); // Get first dimention
            int y = data.GetLength(1); // Get second dimention
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var node = data[i, j];
                    if (node.IsLoaded) { continue; }
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
                            // if there is a start index in your same clumn before
                            break; // to the next row of your container
                        }
                    }
                } // end of columns
            } // end of rows
        }
        public void ClearData()
        {
            foreach (CM2 node in data) 
            { node.StartIndex = false; node.EndIndex = false; node.IsLoaded = false; }
        }
        public void ReCreateMatrix(int x,int y)
        {
            data = new CM2[x, y];
            initialize(x, y);
            space = new System.Drawing.Rectangle(0, 0, x, y);
            _SQR = x * y; _CBM = x * y * 1;
            restSQR = _SQR; RestCBM = _CBM;
            data[0, 0].StartIndex = true;
        }
        public void ReCreateMatrix(ContainerInfo Container)
        {
            data = new CM2[(int)Container.Long, (int)Container.Width];
            initialize((int)Container.Long, (int)Container.Width);
            space = new System.Drawing.Rectangle(0, 0, (int)Container.Long, (int)Container.Width);
            _SQR = (int)Container.SQR; _CBM = (int)Container.CBM;
            restSQR = _SQR; RestCBM = _CBM;
            data[0, 0].StartIndex = true;
        }

        public ContainerMatrix(int x, int y)
        {
            data = new CM2[x,y];
            initialize(x, y);
            space = new System.Drawing.Rectangle(0, 0, x, y);
            _SQR = x * y; _CBM = x*y*z;
            restSQR = _SQR; RestCBM = _CBM;
            data[0, 0].StartIndex = true;
        }
        public ContainerMatrix(int x, int y, int z)
        {
            data = new CM2[x, y];
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
            data = new CM2[(int)Container.Width, (int)Container.Long];
            initialize((int)Container.Width, (int)Container.Long);
            space = new System.Drawing.Rectangle(0, 0, (int)Container.Width, (int)Container.Long);
            _SQR = (int)Container.SQR; _CBM = (int)Container.CBM;
            restSQR = _SQR; RestCBM = _CBM;
            ResetIndexes();// data[0, 0].StartIndex = true;
        }
        private void initialize(int x, int y)
        {
            _firstIndexAssigned = false;
            for (long i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    data[i, j] = new CM2();
                }
            }
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
