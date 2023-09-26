using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;

namespace Lab_1.Logic
{
    internal class CompareService<T> where T: class, new()
    {
        private bool ValidateInput(
            T[] oneDimensionArr,
            T[,] twoDimensionArr,
            T[][] stairsArr)
        {
            if (!(oneDimensionArr.Length == twoDimensionArr.Length &&
                  twoDimensionArr.Length == this.Count(stairsArr)))
            {
                return false;
            }

            return true;
        }

        private int Count(T[][] arr)
        {
            int result = 0;

            foreach (T[] row in arr)
            {
                foreach (T el in row)
                {
                    result ++;
                }
            }

            return result;
        }

        private long GetTime(T[] arr)
        {
            Stopwatch sw = Stopwatch.StartNew();

            foreach (T el in arr)
            {
                el.ToString();
            }

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        private long GetTime(T[,] arr)
        {
            Stopwatch sw = Stopwatch.StartNew();

            foreach (T el in arr)
            {
                el.ToString();
            }

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        private long GetTime(T[][] arr)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (T[] row in arr)
            {
                foreach (T el in row)
                {
                    el.ToString();
                }
            }

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public CompareServiceResult CompareTime (
            T[] oneDimensionArr,
            T[,] twoDimensionArr,
            T[][] stairsArr)
        {
            if (!ValidateInput(oneDimensionArr, twoDimensionArr, stairsArr))
            {
                throw new ArgumentException("Invalid arrays shape");
            }

            long oneDimensionTime = this.GetTime(oneDimensionArr);
            long twoDimensionTime = this.GetTime(twoDimensionArr);
            long stairsTime = this.GetTime(stairsArr);

            return new CompareServiceResult()
            {
                OneDimensionTime = oneDimensionTime,
                TwoDimensionTime = twoDimensionTime,
                StairsTime = stairsTime
            };
        }
    }
}
