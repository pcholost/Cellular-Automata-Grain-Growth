using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using CA.src;

namespace CA.src
{
    class Neighbor
    {
        private Data data;
        private Execute execute;
        public Neighbor(Data data, Execute execute)
        {
            this.data = data;
            this.execute = execute;
        }

        public void OwnNeighborClick(Point coords, Display display)
        {
            int x = coords.X / data.CellSize;
            int y = coords.Y / data.CellSize;
            int value;

            if (data.Colors == null)
                return;
            try
            {
                value = data.GridValues[y, x];
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            if (value == 0)
            {
                data.GridValues[y, x] = ++data.CurrentIndex;
                data.AddNewColor();
            }

            display.PrintCells();
          
        }

        public void OwnNeighbor()
        {
            if (data.CurrentIndex > 0)
            {
                execute.Calculate();
            }
        }

        public void RandomNeighbor(Display display)
        {
            if (!data.RestartGenerate)
            {
                data.Initialize();
            }

            Random random = new Random();

            for (int i = 0; i < data.GrainsAmount; i++)
            {
                data.AddNewColor();
                data.GridValues[random.Next(0, data.SizeY), random.Next(0, data.SizeX)] = ++data.CurrentIndex;
            }

            display.PrintCells();
            data.RestartGenerate = false;
        }

        public void RandomInclusionsBefore(Display display)
        {
            data.Initialize();
            Random random = new Random();

            for (int i = 0; i < data.InclusionsAmount; i++)
            {
                data.AddBlackColor();
                data.GridValues[random.Next(0, data.SizeY), random.Next(0, data.SizeX)] = 1;
                data.CurrentIndex++;
            }

            display.PrintCells();
            data.IsInclusionBefore = true;
            data.RestartGenerate = true;

            for (int i = 0; i < data.InclusionSize - 1; i++)
            {
                execute.CalculateInclusion();
            }
        }

        public void RandomInclusionsAfter(Display display)
        {
            data.CurrentIndex = 0;

            Random random = new Random();

            execute.GenerateBoundaryValues();

            data.AddBlackColor();
            data.CurrentIndex++;


            for (int i = 0; i < data.InclusionsAmount; i++)
            {
                int a = random.Next(data.SizeY);
                int b = random.Next(data.SizeX);
                if (data.BoundaryValues[a, b] == 101)
                {
                    data.GridValues[a, b] = data.GrainsAmount +1;
                }
                else
                {
                    i--;
                }
            }
           
            /**
            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {  
                    if (data.BoundaryValues[i, j] == 101 || data.BoundaryValues[i, j] == 0)
                    {
                        data.BoundaryValues[i, j] = 0;
                    }
                    if (data.GridValues[i, j] == data.GrainsAmount + 1 )
                        data.HelpBoundaryValues[i, j] = 1;
                }
            }

            if (data.InclusionSize > 1)
            {
                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        for (int k = data.InclusionSize - 1; k >= 0; k--)
                        {
                            for (int l = data.InclusionSize -1; l >=0; l--)
                            {
                                if (data.HelpBoundaryValues[i, j] == 1)
                                    data.BoundaryValues[i + k, j + l] = data.GrainsAmount + 1;
                            }
                        }
                    }
                }
            }
            */
            
            display.PrintCells();
            
        }
    }
}
