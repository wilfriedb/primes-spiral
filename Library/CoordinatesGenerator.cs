using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CoordinatesGenerator
    {
        public CoordinatesGenerator(int number)
        {
            NumberOfRotations = number;
        }

        public int NumberOfRotations { get; }

        public IEnumerable<Tuple<int, int, int>> GetCoordinates()
        {
            int ordinal = 0;
            int x = 0;
            int y = 0;
            int n = 1;
            yield return Tuple.Create(ordinal++, x, y);

            for (int i = 1; i < NumberOfRotations; i++)
            {
                n++;
                for (int xi = x + 1; xi < n; xi++)
                {
                    x = xi;
                    yield return Tuple.Create(ordinal++, x, y);
                }

                for (int yn = y - 1; yn > -n; yn--)
                {
                    y = yn;
                    yield return Tuple.Create(ordinal++, x, y);
                }
                for (int xn = x - 1; xn > -n; xn--)
                {
                    x = xn;
                    yield return Tuple.Create(ordinal++, x, y);
                }
                for (int yn = y + 1; yn < n; yn++)
                {
                    y = yn;
                    yield return Tuple.Create(ordinal++, x, y);
                }
            }
        }
    }
}
