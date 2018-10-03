using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
    public class Indexer
    {
        public Indexer(double[] array, int start, int length)
        {
            if (start < 0 || length < 0 || array.Length - start - length < 0)
                throw new ArgumentException();

            this.array = array;
            this.Length = length;
            this.Start = start;
        }

        public readonly int Start;
        public readonly int Length;

        private double[] array;

        public double this[int index]
        {
            get
            {
                IsIndexValid(index);
                index += Start;
                return array[index];
            }
            set
            {
                IsIndexValid(index);
                index += Start;
                array[index] = value;
            }  
        }

        private bool IsIndexValid(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();
            return true;
        }
    }
}
