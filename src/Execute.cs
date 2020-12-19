using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CA.src
{
    class Execute
    {
        private Display display;
        private Data data;
        private Random random;

        public Execute(Display display, Data data)
        {
            this.display = display;
            this.data = data;
            random = new Random();
        }

        public void Calculate()
        {

            for (int i = 0; i < data.Speed; i++)
            {
                int[,] nextStepGrid = new int[data.SizeY, data.SizeX];

                for (int y = 0; y < data.SizeY; y++)
                {
                    for (int x = 0; x < data.SizeX; x++)
                    {
                        int actualCell = data.GridValues[y, x];
                        nextStepGrid[y, x] = actualCell;

                        if (actualCell != 0)
                        {
                            continue;
                        }

                        int value = 0;

                        value = Moore(y, x); 

                        if (value == 1 && data.IsInclusionBefore == true)
                        {
                            continue;
                        }

                        if (value != 0)
                        {
                            nextStepGrid[y, x] = value;
                            data.Cells[value]++;
                        }
                    }
                }

                data.GridValues = nextStepGrid;

                display.PrintCells();

            }
        }

        public void CalculateInclusion()
        {
            int[,] nextStepGrid = new int[data.SizeY, data.SizeX];

            for (int y = 0; y < data.SizeY; y++)
            {
                for (int x = 0; x < data.SizeX; x++)
                {
                    int actualCell = data.GridValues[y, x];
                    nextStepGrid[y, x] = actualCell;

                    if (actualCell != 0)
                    {
                        continue;
                    }

                    int value = 0;

                    value = Moore(y, x);

                    if (value != 0)
                    {
                        nextStepGrid[y, x] = value;
                        data.Cells[value]++;
                    }
                }
            }

            data.GridValues = nextStepGrid;

            display.PrintCells();
        }

        public void GenerateBoundaryValues()
        {
            for (int y = 0; y < data.SizeY; y++)
            {
                for (int x = 0; x < data.SizeX; x++)
                {
                    data.IsBorder = false;

                    CheckBoundaryConditions(y, x);

                    if (data.IsBorder)
                    {
                        data.BoundaryValues[y, x] = 101;
                    }
                }

            }

        }

        public void CheckBoundaryConditions(int i, int j)
        {
            int[] tabNeighbours = new int[8];

            if (i > 0)
            {
                tabNeighbours[0] = data.GridValues[i - 1, j];
            }
            if (i < data.GridValues.GetLength(0) - 1)
            {
                tabNeighbours[1] = data.GridValues[i + 1, j];
            }
            if (j > 0)
            {
                tabNeighbours[2] = data.GridValues[i, j - 1];
            }
            if (j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[3] = data.GridValues[i, j + 1];
            }
            if (i > 0 && j > 0)
            {
                tabNeighbours[4] = data.GridValues[i - 1, j - 1];
            }
            if (i < data.GridValues.GetLength(0) - 1 && j > 0)
            {
                tabNeighbours[5] = data.GridValues[i + 1, j - 1];
            }
            if (i > 0 && j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[6] = data.GridValues[i - 1, j + 1];
            }
            if (i < data.GridValues.GetLength(0) - 1 && j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[7] = data.GridValues[i + 1, j + 1];
            }

            
            for (int q = 0; q < 8 ; q++)
            {
                if (tabNeighbours[q] != data.GridValues[i,j] && tabNeighbours[q] != 0)
                {
                    data.IsBorder = true;
                }
            }
        }

       
        private int Moore(int i, int j)
        {
            int[] tabNeighbours = new int[8];

            if (i > 0)
            {
                tabNeighbours[0] = data.GridValues[i - 1, j];
            }
            if (i < data.GridValues.GetLength(0) - 1)
            {
                tabNeighbours[1] = data.GridValues[i + 1, j];
            }
            if (j > 0)
            {
                tabNeighbours[2] = data.GridValues[i, j - 1];
            }
            if (j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[3] = data.GridValues[i, j + 1];
            }
            if (i > 0 && j > 0)
            {
                tabNeighbours[4] = data.GridValues[i - 1, j - 1];
            }
            if (i < data.GridValues.GetLength(0) - 1 && j > 0)
            {
                tabNeighbours[5] = data.GridValues[i + 1, j - 1];
            }
            if (i > 0 && j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[6] = data.GridValues[i - 1, j + 1];
            }
            if (i < data.GridValues.GetLength(0) - 1 && j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[7] = data.GridValues[i + 1, j + 1];
            }

            if (data.IsPeriodic)
            {
                if (i == 0)
                {
                    tabNeighbours[0] = data.GridValues[data.GridValues.GetLength(0) - 1, j];
                }

                if (i == data.GridValues.GetLength(0) - 1)
                {
                    tabNeighbours[1] = data.GridValues[0, j];
                }

                if (j == 0)
                {
                    tabNeighbours[2] = data.GridValues[i, data.GridValues.GetLength(1) - 1];
                }

                if (j == data.GridValues.GetLength(1) - 1)
                {
                    tabNeighbours[3] = data.GridValues[i, 0];
                }

                if (i == 0 && j == 0)
                {
                    tabNeighbours[4] = data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                }
                if (i == data.GridValues.GetLength(0) - 1 && j == 0)
                {
                    tabNeighbours[5] = data.GridValues[0, data.GridValues.GetLength(1) - 1];
                }
                if (i == 0 && j == data.GridValues.GetLength(1) - 1)
                {
                    tabNeighbours[6] = data.GridValues[data.GridValues.GetLength(0) - 1, 0];
                }
                if (i == data.GridValues.GetLength(0) - 1 && j == data.GridValues.GetLength(1) - 1)
                {
                    tabNeighbours[7] = data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                }
            }

            return selectNeighbour(tabNeighbours);
        }

        private int selectNeighbour(int[] neighbours)
        {
            int index = 0;
            for (int i = 1; i < neighbours.Length; i++)
            {
                if (data.Cells[neighbours[i]] > data.Cells[neighbours[index]])
                {
                    index = i;
                }
            }
            return neighbours[index];
        }
    }
}
