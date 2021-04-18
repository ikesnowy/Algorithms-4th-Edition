using System;

namespace _1._2._18
{
    public class Accumulator
    {
        private double _m;
        private double _s;
        private int _n;

        public void AddDataValue(double x)
        {
            _n++;
            _s = _s + 1.0 * (_n - 1) / _n * (x - _m) * (x - _m);
            _m = _m + (x - _m) / _n;
        }
        public double Mean()
        {
            return _m;
        }
        public double Var()
        {
            return _s / (_n - 1);
        }
        public double Stddev()
        {
            return Math.Sqrt(Var());
        }
        public override string ToString()
        {
            return "Mean (" + _n + " values): " + string.Format("{0, 7:F5}", Mean());
        }
    }
}
