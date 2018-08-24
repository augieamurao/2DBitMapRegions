using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DBitMapRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            const int rows = 4;
            const int cols = 10;
            int[,] bitMap = new int[rows, cols] {{1,1,0,0,1,1,1,0,1,1},
                                                 {1,1,0,0,1,1,1,0,1,1},
                                                 {1,0,0,0,0,1,1,0,0,0},
                                                 {0,0,1,1,0,1,0,0,1,1}};

            int regionCt = 0;
            for (int i=0; i < rows; i++)
            {
                for (int j=0; j<cols; j++)
                {
                    if (bitMap[i,j] > 0)
                    {
                        ++regionCt;
                        RegionUtils.MarkRegion(bitMap, i, j);
                    }
                }
            }
            
            Console.WriteLine("Number of regions: {0}", regionCt);
        }
    }

    class RegionUtils
    {
        // The MarkRegion function recursively identifies all contiguous bits of a region
        static public void MarkRegion(int[,]  bitmap, int row, int col)
        {

            // mark this bit as being visited, 
            //return if row/col is invalid (happens when exploring at the edges of the bitmap) or 
            //return if bit is not set (reached the edge of the region)
            try
            {
                if (bitmap[row, col] == 0)
                {
                    return;
                }
                else
                {
                    bitmap[row, col] = 0;
                }
            }
            catch
            {
                return;
            }


            // recurse upper left
            MarkRegion(bitmap, row - 1, col - 1);

            // recurse upper center
            MarkRegion(bitmap, row - 1, col);

            // recurse upper right
            MarkRegion(bitmap, row - 1, col + 1);

            // recurse left
            MarkRegion(bitmap, row, col - 1);

            // recurse right
            MarkRegion(bitmap, row, col + 1);

            // recurse lower left
            MarkRegion(bitmap, row + 1, col - 1);

            // recurse lower center
            MarkRegion(bitmap, row + 1, col);

            // recurse lower right
            MarkRegion(bitmap, row + 1, col + 1);
        }
    }
}
