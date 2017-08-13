﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voxels {
    /// <summary>
    /// Represents a value with X,Y and Z integer values.
    /// This can represent an integer based 3D coordinate or an area of 3D space.
    /// NOTE: XY is the horizontal plane and Z is the vertical axis.
    /// </summary>
    public struct XYZ : IEquatable<XYZ> {
        public int X;
        public int Y;
        public int Z;

        public XYZ(int x, int y, int z) {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int MaxDimension {
            get { return Math.Max(X, Math.Max(Y, Z)); }
        }

        public int Volume {
            get { return X * Y * Z; }
        }

        public static readonly XYZ Empty = new XYZ(0,0,0);
        public static readonly XYZ One = new XYZ(1,1,1);
        public static readonly XYZ OneX = new XYZ(1, 0, 0);
        public static readonly XYZ OneY = new XYZ(0, 1, 0);
        public static readonly XYZ OneZ = new XYZ(0, 0, 1);
        public static readonly XYZ OneXY = new XYZ(1, 1, 0);
        public static readonly XYZ OneXZ = new XYZ(1, 0, 1);
        public static readonly XYZ OneYZ = new XYZ(0, 1, 1);


        public static XYZ operator *(XYZ a, int b) {
            return new XYZ(a.X * b, a.Y * b, a.Z * b);
        }
        public static XYZ operator /(XYZ a, int b) {
            return new XYZ(a.X / b, a.Y / b, a.Z / b);
        }
        public static XYZ operator +(XYZ a, XYZ b) {
            return new XYZ(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static XYZ operator -(XYZ a, XYZ b) {
            return new XYZ(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static XYZ operator -(XYZ a) {
            return new XYZ(-a.X, -a.Y, -a.Z);
        }

        public XYZ[] GetAdjacent() {
            var adjacent = new XYZ[4];
            XYZ d0;
            XYZ d1;
            if (X != 0) {
                d0 = XYZ.OneY;
                d1 = XYZ.OneZ;
            }
            else 
            if (Y != 0) {
                d0 = XYZ.OneZ;
                d1 = XYZ.OneX;

            }
            else {
                d0 = XYZ.OneX;
                d1 = XYZ.OneY;
            }
            adjacent[0] = d0;
            adjacent[1] = d1;
            adjacent[2] = -d0;
            adjacent[3] = -d1;
            return adjacent;
        }

        public bool Equals(XYZ other) {
            return this.X == other.X
                && this.Y == other.Y
                && this.Z == other.Z;
        }

        public override bool Equals(object other) {
            return Equals((XYZ) other);
        }

        public override int GetHashCode() {
            return (int)(X ^ (X >> 32) ^ Y ^ (Y >> 32) ^ Z ^ (Z >> 32));
        }

        public override string ToString() {
            return $"{X}|{Y}|{Z}";
        }
    }
}
