using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading_Angle
{
    public class Angle : IEnumerable, IComparable
    {
        private int minutes;
        private int seconds; 
        public int Degrees { get; private set; }
        public int Minutes
        {
            get { return minutes; }
            private set
            {
                if (value >= 60)
                    throw new ArgumentOutOfRangeException("Minutes value is greater than 60");
                minutes = value;
            }
        }
        public int Seconds
        {
            get { return seconds; }
            private set
            {
                if (value >= 60)
                    throw new ArgumentOutOfRangeException("Seconds value is greater than 60");
                seconds = value;
            }
        }

        public Angle(){}

        public Angle(int degrees, int minutes, int seconds)
        {
            this.Degrees = degrees;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public double ToDecimal()
        {
            double minutes = ((double)Minutes * 1 / 60);
            double seconds = ((double)Seconds * 1 / 60 * 1 / 60);
            return (double)Degrees + minutes + seconds;
        }

        public static Angle FromDecimalToAngle(double decimalAngle)
        {
            int degrees = (int)decimalAngle;
            int minutes = (int)((decimalAngle - degrees) * 60);
            int seconds = (int)((decimalAngle - degrees - ((double)minutes / 60) + 0.000000001 ) * 3600);
            return new Angle(degrees, minutes, seconds);
        }

        //public static Angle operator +(Angle a1, Angle a2)
        //{
        //    int degrees = a1.Degrees + a2.Degrees;
        //    int minutes = a1.Minutes + a2.Minutes;
        //    int seconds = a1.Seconds + a2.Seconds;
        //    if (minutes > 60)
        //    {
        //        minutes -= 60;
        //        degrees++;
        //    }

        //    if (seconds > 60)
        //    {
        //        seconds -= 60;
        //        minutes++;
        //    }
        //    var sumOfAngles = new Angle(degrees, minutes, seconds);
        //    return sumOfAngles;
        //}

        public static Angle operator +(Angle a1, Angle a2)
        {
            return FromDecimalToAngle(a1.ToDecimal() + a2.ToDecimal());
        }

        public static Angle operator -(Angle a1, Angle a2)
        { 
            return FromDecimalToAngle(a1.ToDecimal() - a2.ToDecimal());
        }

        public static bool operator ==(Angle a1, Angle a2)
        {
            return a1.Degrees == a2.Degrees &&
                   a1.Minutes == a2.Minutes &&
                   a1.Seconds == a2.Seconds;
        }

        public static bool operator !=(Angle a1, Angle a2)
        {
            return !(a1 == a2);
        }

        public int this[string name]
        {
            get
            {
                switch (name)
                {
                    case "degrees":
                        return Degrees;
                    case "minutes":
                        return Minutes;
                    case "seconds":
                        return Seconds;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }

            set
            {
                switch (name)
                {
                    case "degrees":
                        Degrees = value;
                        break;
                    case "minutes":
                        Minutes = value;
                        break;
                    case "seconds":
                        Seconds = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return Degrees;
                    case 1:
                        return Minutes;
                    case 2:
                        return Seconds;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }

            set
            {
                switch (i)
                {
                    case 0:
                        Degrees = value;
                        break;
                    case 1:
                        Minutes = value;
                        break;
                    case 2:
                        Seconds = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return String.Format(@"{0}° {1}' {2}""", Degrees, Minutes, Seconds);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 3; i++)
                yield return this[i];
            //yield return this[0];
            //yield return this[1];
            //yield return this[2];
            //return new AngleEnumerator(this);
        }

        public override bool Equals(object obj)
        {
            var angle = obj as Angle;
            return angle != null &&
                   Degrees == angle.Degrees &&
                   Minutes == angle.Minutes &&
                   Seconds == angle.Seconds;
        }

        public override int GetHashCode()
        {
            var hashCode = -926758218;
            hashCode = hashCode * -1521134295 + Degrees.GetHashCode();
            hashCode = hashCode * -1521134295 + Minutes.GetHashCode();
            hashCode = hashCode * -1521134295 + Seconds.GetHashCode();
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            Angle angle = (Angle)obj;
            if (ToDecimal() > angle.ToDecimal())
                return 1;
            if (ToDecimal() < angle.ToDecimal())
                return -1;
            return 0;  
        }

        public static class Comparer
        {
            public static IComparer CompareByMinutes()
            {
                return new AngleMinutesComparer();
            }

            public static IComparer CompareBySeconds()
            {
                return new AngleSecondsComparer();
            }
        }

        class AngleMinutesComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Angle a1 = (Angle)x;
                Angle a2 = (Angle)y;

                if (a1.Minutes > a2.Minutes)
                    return 1;
                if (a1.Minutes < a2.Minutes)
                    return -1;
                if (a1.Minutes == a2.Minutes)
                    return 0;
                return 1;
            }
        }

        class AngleSecondsComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Angle a1 = (Angle)x;
                Angle a2 = (Angle)y;

                if (a1.Seconds > a2.Seconds)
                    return 1;
                if (a1.Seconds < a2.Seconds)
                    return -1;
                if (a1.Seconds == a2.Seconds)
                    return 0;
                return 1;
            }
        }

        class AngleEnumerator : IEnumerator
        {
            private int currentIndex = -1;
            private Angle _angle;
            public AngleEnumerator(Angle angle)
            {
                this._angle = angle;
            }

            public object Current
            {
                get { return _angle[currentIndex]; }
            }

            public bool MoveNext()
            {
                if (currentIndex == 2)
                {
                    Reset();
                    return false;
                }
                currentIndex++;
                return true;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
