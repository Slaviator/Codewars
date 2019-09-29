using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.CSharp
{
    public class SpeedControl
    {
        public static int Gps(int period, IEnumerable<double> distances)
            => distances.Aggregate(new {value = .0, speed = 1},
                (speedAndValue, nextValue) => new
                {
                    value = nextValue,
                    speed = Math.Max((int) (3600 * (nextValue - speedAndValue.value) / period), speedAndValue.speed)
                }, speedAndValue => speedAndValue.speed);
    }
}