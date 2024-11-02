using System;
using System.Collections;
using System.Collections.Generic;

namespace Xennan.Math;

public class Primes : IEnumerable<int>
{
    readonly int maxNumber;
    readonly bool[] list;
    bool isGenerated;

    /// <summary>
    /// Calculates primes in the range 2 .. max.
    /// </summary>
    /// <param name="max">Maximum of the range. Higher will be slower.</param>
    public Primes(int max)
    {
        CheckValue(max);
        maxNumber = max;
        list = new bool[max + 1];
        isGenerated = false;
    }

    private static void CheckValue(int max)
    {
        if (max > 1000000000) throw new ArgumentOutOfRangeException("Argument may not be bigger than 1000000000.");
        if (max < 2) throw new ArgumentOutOfRangeException("Argument may not be smaller than 2.");
    }

    public void Generate()
    {
        list[0] = false;
        list[1] = false;
        for (int i = 2; i < list.Length; i++)
        {
            list[i] = true;
        }
        var n = 2;
        while (n * n <= maxNumber)
        {
            if (list[n])
            {
                for (int i = n * n; i <= maxNumber; i += n)
                {
                    list[i] = false;
                }
            }
            n++;
        }
        isGenerated = true;
    }

    public bool IsPrime(int n)
    {
        CheckValue(n);
        if (!isGenerated) Generate();
        return list[n];
    }

    public int GetPrime(int primenumber)
    {
        if (!isGenerated) Generate();
        int n = 1;
        int counter = 0;
        while (n <= primenumber)
        {
            counter++;
            if (list[counter])
            {
                n++;
            }
        }
        return counter;
    }


    #region IEnumerable<int> Members

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        return new PrimeEnumerator(this);
    }

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new PrimeEnumerator(this);
    }

    #endregion

    private class PrimeEnumerator : IEnumerator<int>
    {
        Primes p;
        int index;
        public PrimeEnumerator(Primes primes)
        {
            p = primes;
            index = 1; // Is 1 ipv 2 want bij foreach wordt éérst een MoveNext() gedaan voor de Current.
        }
        #region IEnumerator<int> Members

        public int Current
        {
            get { return index; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // niets te disposen
        }

        #endregion

        #region IEnumerator Members

        object IEnumerator.Current
        {
            get { return index; }
        }

        public bool MoveNext()
        {
            if (++index > p.maxNumber)
            {
                return false;
            }
            while (!p.list[index])
            {
                index++;
                if (index > p.maxNumber)
                {
                    return false;
                }
            }
            return true;
        }

        public void Reset()
        {
            index = 1;
        }

        #endregion
    }
}
