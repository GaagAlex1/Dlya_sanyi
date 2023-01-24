using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_1
{
    public partial class PointArray : IEnumerator
    {
        private int position = -1;

        public PointArray GetEnumerator()
        {
            return new PointArray(points);
        }

        public bool MoveNext()
        {
            position++;
            return (position < points.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Point Current
        {
            get
            {
                try
                {
                    return points[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
