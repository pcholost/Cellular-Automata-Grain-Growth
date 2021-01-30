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

        public void OwnShapeNeighbor()
        {
            if (data.CurrentIndex > 0)
            {
                execute.ShapeControlCalculate();
            }
        }

        public void OwnSelectionNeighbor()
        {
            if (data.SelectionType == false)
            {
                if (data.CurrentIndex > data.GrainsAmount)
                {
                    execute.CalculateSelection(data.GeneratedGrains);
                }
            }
            else
            {
                if (data.CurrentIndex > data.GrainsAmount)
                {
                    execute.CalculateSelection(data.GrainsSelectionArray);
                }
            }
        }

        public void GenerateBorders(Display display)
        {
            execute.GenerateBoundaryValues();

            data.AddBlackColor();

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    if (data.BoundaryValues[i, j] == 101)
                    {
                        data.BoundariesArray[i, j] = data.GrainsAmount + 1;
                    }
                }
            }

            if (data.GbSize > 1)
            {
                int[,] helpBoundariesArray = new int[data.SizeY, data.SizeX];
                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        helpBoundariesArray[i, j] = 0;
                    }
                }
                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        helpBoundariesArray[i, j] = data.BoundaryValues[i, j];
                    }
                }

                for (int size = 1; size < data.GbSize; size++)
                { 
                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            if (i != 0 && j != 0 && i != data.SizeY - 1 && j != data.SizeX - 1)
                            {
                                bool flag = false;
                                for (int k = -1; k < 2; k++)
                                {
                                    for (int l = -1; l < 2; l++)
                                    {
                                        if (flag == false)
                                        {
                                            if (data.BoundaryValues[i + k, j + l] == 101 && k * l == 0)
                                            {
                                                helpBoundariesArray[i, j] = 101;
                                                flag = true;          
                                            }
                                            else
                                            {
                                                helpBoundariesArray[i, j] = data.BoundaryValues[i, j];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            data.BoundaryValues[i, j] = helpBoundariesArray[i, j];
                        }
                    }
                }
            }

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    if (data.BoundaryValues[i, j] == 101)
                    {
                        data.BoundariesArray[i, j] = data.GrainsAmount + 1;
                    }
                }
            }

            display.DisplayBoundariesOfGrain();
        }

        public void RandomNeighbor(Display display)
        {
            if (!data.RestartGenerate)
            {
                data.Initialize();
            }

            data.IsSelectionClicked = false;

            Random random = new Random();

            for (int i = 0; i < data.GrainsAmount; i++)
            {
                if (data.IsInclusionBefore)
                {
                    data.AddNewColor();
                    int a = random.Next(data.SizeY);
                    int b = random.Next(data.SizeX);
                    if (data.GridValues[a, b] != 1)
                    {
                        data.GridValues[a, b] = ++data.CurrentIndex;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    data.AddNewColor();
                    data.GridValues[random.Next(0, data.SizeY), random.Next(0, data.SizeX)] = ++data.CurrentIndex;
                }
            }

            display.PrintCells();

            data.RestartGenerate = false;
        }

        public void RandomNeighborSelection(Display display)
        {
            data.IsSelectionClicked = false;

            Random random = new Random();

            int localValue = 0;

            bool localFlag = false;

            int[,] localSubstructure = new int[data.SizeY, data.SizeX];

            int[,] generatedGrains = new int[data.SizeY, data.SizeX];

            int[,] helpArray = new int[data.SizeY, data.SizeX];

            for (int i = 0; i < data.GrainsToSelectionAmount; i++)
            {
                if (data.IsInclusionBefore)
                {
                    data.AddNewColor();
                    int a = random.Next(data.SizeY);
                    int b = random.Next(data.SizeX);
                    if (data.GridValues[a, b] != 1)
                    {
                        data.GrainsSelectionArray[a, b] = ++data.CurrentIndex;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    int a = random.Next(data.SizeY);
                    int b = random.Next(data.SizeX);
                  
                    if (data.SelectionType == true)
                    {
                        if (data.DualPhaseArray[a, b] == 0)
                        {
                            data.AddNewColor();
                            data.GrainsSelectionArray[a, b] = ++data.CurrentIndex;
                        }
                        else
                        {
                            i--;
                        }
                    }
                }
            }
       
            if (data.SelectionType == false)
            {

                for (int k = 0; k < data.SizeY; k++)
                {
                    for (int l = 0; l < data.SizeX; l++)
                    {
                        data.HelpArraySubstructure[k, l] = data.GridValues[k, l];
                    }
                }

                for (int k = 0; k < data.SizeY; k++)
                {
                    for (int l = 0; l < data.SizeX; l++)
                    {
                        if (data.HelpArraySubstructure[k, l] == data.SubstructureArray[k, l])
                        {
                            data.HelpArraySubstructure[k, l] = 0;
                        }
                    }
                }
                
                for (int k = 0; k < data.SizeY; k++)
                {
                    for (int l = 0; l < data.SizeX; l++)
                    {
                        if (localFlag == false)
                        {
                            if (data.HelpArraySubstructure[k, l] != localValue)
                            {
                                localValue++;
                                localFlag = true;
                            }
                        }
                    }
                }

                for (int k = 0; k < data.SizeY; k++)
                {
                    for (int l = 0; l < data.SizeX; l++)
                    {
                        if (data.HelpArraySubstructure[k, l] == localValue)
                        {
                            localSubstructure[k, l] = data.HelpArraySubstructure[k, l];
                            helpArray[k, l] = data.HelpArraySubstructure[k, l];
                        }
                        else
                        {
                            localSubstructure[k, l] = 0;
                        }
                    }
                }

                for (int i = 0; i < data.GrainsToSelectionAmount; i++)
                {
                    if (data.IsInclusionBefore)
                    {
                        data.AddNewColor();
                        int a = random.Next(data.SizeY);
                        int b = random.Next(data.SizeX);
                        if (data.GridValues[a, b] != 1)
                        {
                            data.GrainsSelectionArray[a, b] = ++data.CurrentIndex;
                        }
                        else
                        {
                            i--;
                        }
                    }
                    else
                    {
                        int a = random.Next(data.SizeY);
                        int b = random.Next(data.SizeX);

                        if (localSubstructure[a, b] != 0)
                        {
                            data.AddNewColor();
                            localSubstructure[a, b] = ++data.CurrentIndex;
                        }
                        else
                        {
                            i--;
                        }
                    }
                }

                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        data.BlankToFillArray[i, j] = data.GridValues[i, j];
                    }
                }

                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        data.LocalSubstructure[i, j] = data.GridValues[i, j];
                        if (localSubstructure[i, j] != 0)
                        {
                            data.LocalSubstructure[i,j] = 0;
                        }
                        if (data.GeneratedGrains[i,j] != 0)
                        {
                            data.LocalSubstructure[i, j] = data.GeneratedGrains[i, j];
                        }
                    }
                }


                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (localSubstructure[i, j] > data.GrainsAmount)
                        {
                            data.GeneratedGrains[i, j] = localSubstructure[i, j];                     
                        }
                    }
                }

                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (data.BlankToFillArray[i,j] == helpArray[i,j])
                        {
                            data.BlankToFillArray[i,j] = 0;
                        }
                    }
                }

                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (data.BlankToFillArray[i, j] != data.GeneratedGrains[i,j] && data.GeneratedGrains[i,j] != 0)
                        {
                            data.BlankToFillArray[i, j] = data.GeneratedGrains[i, j];
                            data.FlagToGrain = true;
                        }
                    }
                }

            }



            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    data.GridValues[i, j] = data.BlankToFillArray[i, j];
                }
            }

            if (data.SelectionType == true)
            {
                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (data.DualPhaseArray[i, j] != 0)
                        {
                            data.GridValues[i, j] = data.DualPhaseArray[i, j];
                        }
                    }
                }
            }

            display.PrintCells();

            data.RestartGenerate = false;
        }

        public void GrainClick(Point coords, Display display)
        {
            int x = coords.X / data.CellSize;
            int y = coords.Y / data.CellSize;
            int value = data.GridValues[y, x];

            if (data.SelectionType == false)
            {
                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (data.GridValues[i, j] == value)
                        {  
                            data.SubstructureArray[i, j] = value;
                        }
                    }
                }
            }

            else
            {
                if (data.FlagColorDualPhase == false)
                {
                    data.ColorDualPhase = data.GridValues[y, x];
                }
                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (data.GridValues[i, j] == data.GridValues[y, x])
                        {
                            data.DualPhaseArray[i, j] = data.ColorDualPhase;
                        }
                    }
                }
            }

            data.NumberOfLeftGrains--;

            data.FlagColorDualPhase = true;
        }

        public void GrainBorderClick(Point coords, Display display)
        {
            int x = coords.X / data.CellSize;
            int y = coords.Y / data.CellSize;
            int value = data.GridValues[y, x];


            if (data.IsBorderyClicked == true)
            {
                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (data.GridValues[i, j] == value)
                        {
                            data.SelectedBoundariesArray[i, j] = value;
                        }
                    }
                }
            }
        }

        public void ShowSelectedBorders(Display display)
        {
            int[,] singleHelpBoundariesArray = new int[data.SizeY, data.SizeX];
            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    singleHelpBoundariesArray[i, j] = 0;
                }
            }

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    data.GridValues[i, j] = data.SelectedBoundariesArray[i, j];
                }
            }

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    singleHelpBoundariesArray[i, j] = data.BoundaryValues[i, j];
                }
            }

            execute.GenerateBoundaryValues();

            data.AddBlackColor();

            if (data.GbSize > 1)
            {
                for (int size = 1; size < data.GbSize; size++)
                {
                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            if (data.SelectedBoundariesArray[i, j] != 0)
                            {
                                if (i != 0 && j != 0 && i != data.SizeY - 1 && j != data.SizeX - 1)
                                {
                                    bool flag = false;
                                    for (int k = -1; k < 2; k++)
                                    {
                                        for (int l = -1; l < 2; l++)
                                        {
                                            if (flag == false)
                                            {
                                                if (data.BoundaryValues[i + k, j + l] == 101 && k * l == 0)
                                                {
                                                    singleHelpBoundariesArray[i, j] = 101;
                                                    flag = true;
                                                }
                                                else
                                                {
                                                    singleHelpBoundariesArray[i, j] = data.BoundaryValues[i, j];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            if (data.SelectedBoundariesArray[i, j] != 0)
                                data.BoundaryValues[i, j] = singleHelpBoundariesArray[i, j];
                        }
                    }
                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            singleHelpBoundariesArray[i, j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    if (data.BoundaryValues[i, j] == 101)
                    {
                        data.BoundariesArray[i, j] = data.GrainsAmount + 1;
                    }
                    else
                    {
                        data.BoundariesArray[i, j] = 0;
                    }
                }
            }

            display.DisplayBoundariesOfGrain();

            data.RestartGenerate = false;
            data.IsBorderyClicked = false;
        }


        public void RandomInclusionsBefore(Display display)
        {
            data.Initialize();

            data.HelpArray = new int[data.SizeY, data.SizeX];

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    data.HelpArray[i, j] = 0;
                }
            }

            Random random = new Random();

            for (int i = 0; i < data.InclusionsAmount; i++)
            {
                data.AddBlackColor();
                data.GridValues[random.Next(0, data.SizeY), random.Next(0, data.SizeX)] = 1;
                data.CurrentIndex++;
            }

            data.HelpArray = data.GridValues;

            display.PrintCells();
            data.IsInclusionBefore = true;
            data.RestartGenerate = true;

            if (data.InclusionType == false)
            {
                for (int i = 0; i < data.InclusionSize - 1; i++)
                {
                    execute.CalculateSquareInclusion();
                    display.PrintCells();
                }
            }
            else
            {
                for (int i = 0; i < data.InclusionSize - 1; i++)
                {
                    execute.CalculateSquareInclusion();
                }

                if (data.InclusionSize > 1)
                {
                    int size = data.InclusionSize - 1;

                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            if (data.HelpArray[i, j] == 1)
                            {
                                //Realizacja tego przez petle
                                if (data.InclusionSize < 5)
                                {
                                    if (i - size > 0 && j - size > 0)
                                    {
                                        data.GridValues[i - size, j - size] = 0;
                                    }
                                    if (i < data.GridValues.GetLength(0) - size && j - size > 0)
                                    {
                                        data.GridValues[i + size, j - size] = 0;
                                    }
                                    if (i - size > 0 && j < data.GridValues.GetLength(1) - size)
                                    {
                                        data.GridValues[i - size, j + size] = 0;
                                    }
                                    if (i < data.GridValues.GetLength(0) - size && j < data.GridValues.GetLength(1) - size)
                                    {
                                        data.GridValues[i + size, j + size] = 0;
                                    }
                                }
                                if (data.InclusionSize >= 5)
                                {
                                    if (i - size > 0 && j - size > 0)
                                    {
                                        data.GridValues[i - size, j - size] = 0;   
                                        data.GridValues[i - size + 1, j - size] = 0;
                                        data.GridValues[i - size, j - size + 1] = 0;
                                    }
                                    if (i < data.GridValues.GetLength(0) - size && j - size > 0)
                                    {
                                        data.GridValues[i + size, j - size] = 0;
                                        data.GridValues[i + size - 1, j - size] = 0;
                                        data.GridValues[i + size, j - size + 1] = 0;
                                    }
                                    if (i - size > 0 && j < data.GridValues.GetLength(1) - size)
                                    {
                                        data.GridValues[i - size, j + size] = 0;
                                        data.GridValues[i - size + 1, j + size] = 0;
                                        data.GridValues[i - size, j + size - 1] = 0;
                                    }
                                    if (i < data.GridValues.GetLength(0) - size && j < data.GridValues.GetLength(1) - size)
                                    {
                                        data.GridValues[i + size, j + size] = 0;
                                        data.GridValues[i + size - 1, j + size] = 0;
                                        data.GridValues[i + size, j + size - 1] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                
                display.PrintCells();
            }
            data.EndInclusionAfter = false;
        }

        public void RandomInclusionsAfter(Display display)
        {
            data.CurrentIndex = 0;

            data.HelpArray = new int[data.SizeY, data.SizeX];

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    data.HelpArray[i, j] = data.GridValues[i, j];
                }
            }    

            Random random = new Random();

            execute.GenerateBoundaryValues();

            data.AddBlackColor();
            data.CurrentIndex++;

            for (int i = 0; i < data.InclusionsAmount; i++)
            {
                int a = random.Next(data.SizeY);
                int b = random.Next(data.SizeX);
                if (data.BoundaryValues[a, b] == 101 && a + data.InclusionSize < data.SizeY && b + data.InclusionSize < data.SizeX)
                {
                    data.BoundaryValues[a, b] = data.GrainsAmount + 1;
                }
                else
                {
                    i--;
                }
            }

            if (data.InclusionType == false)
            {
                SquareAfter(display);
            }
            else
            {
                SquareAfter(display);
                CircularAfter(display);
            }

            display.PrintCells();
            data.EndInclusionAfter = false;
        }
        public void SquareAfter(Display display)
        {
            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    if (data.BoundaryValues[i, j] == 101 || data.BoundaryValues[i, j] == 0)
                    {
                        data.BoundaryValues[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    if (data.BoundaryValues[i, j] == data.GrainsAmount + 1)
                    {
                        data.HelpBoundaryValues[i, j] = 1;
                    }
                }
            }

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    for (int k = data.InclusionSize - 1; k >= 0; k--)
                    {
                        for (int l = data.InclusionSize - 1; l >= 0; l--)
                        {
                            if (data.HelpBoundaryValues[i, j] == 1)
                            {
                                if (i < data.GridValues.GetLength(0) - data.InclusionSize && j < data.GridValues.GetLength(1) - data.InclusionSize)
                                    data.BoundaryValues[i + k, j + l] = data.GrainsAmount + 1;
                                if (i - data.InclusionSize  > 0 && j - data.InclusionSize > 0)
                                    data.BoundaryValues[i - k, j - l] = data.GrainsAmount + 1;
                                if (i < data.GridValues.GetLength(0) - data.InclusionSize && j - data.InclusionSize > 0)
                                    data.BoundaryValues[i + k, j - l] = data.GrainsAmount + 1;
                                if (i - data.InclusionSize - 1 > 0 && j < data.GridValues.GetLength(1) - data.InclusionSize)
                                    data.BoundaryValues[i - k, j + l] = data.GrainsAmount + 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    if (data.BoundaryValues[i, j] == data.GrainsAmount + 1)
                    {
                        data.GridValues[i, j] = data.GrainsAmount + 1;
                    }
                }
            }
        }

        public void CircularAfter(Display display)
        {

            if (data.InclusionSize > 1)
            {
                int size = data.InclusionSize - 1;

                for (int i = 0; i < data.SizeY; i++)
                {
                    for (int j = 0; j < data.SizeX; j++)
                    {
                        if (data.HelpBoundaryValues[i, j] == 1)
                        {
                            //Realizacja tego przez petle
                            if (data.InclusionSize < 5)
                            {
                                if (i - size > 0 && j - size > 0)
                                {
                                    data.GridValues[i - size, j - size] = data.HelpArray[i - size, j - size];
                                }
                                if (i < data.GridValues.GetLength(0) - size && j - size > 0)
                                {
                                    data.GridValues[i + size, j - size] = data.HelpArray[i + size, j - size];
                                }
                                if (i - size > 0 && j < data.GridValues.GetLength(1) - size)
                                {
                                    data.GridValues[i - size, j + size] = data.HelpArray[i - size, j + size];
                                }
                                if (i < data.GridValues.GetLength(0) - size && j < data.GridValues.GetLength(1) - size)
                                {
                                    data.GridValues[i + size, j + size] = data.HelpArray[i + size, j + size];
                                }
                            }
                            if (data.InclusionSize >= 5)
                            {
                                if (i - size > 0 && j - size > 0)
                                {
                                    data.GridValues[i - size, j - size] = data.HelpArray[i - size, j - size];
                                    data.GridValues[i - size + 1, j - size] = data.HelpArray[i - size + 1, j - size];
                                    data.GridValues[i - size, j - size + 1] = data.HelpArray[i - size, j - size + 1];
                                }
                                if (i < data.GridValues.GetLength(0) - size && j - size > 0)
                                {
                                    data.GridValues[i + size, j - size] = data.HelpArray[i + size, j - size];
                                    data.GridValues[i + size - 1, j - size] = data.HelpArray[i + size - 1, j - size];
                                    data.GridValues[i + size, j - size + 1] = data.HelpArray[i + size, j - size + 1];
                                }
                                if (i - size > 0 && j < data.GridValues.GetLength(1) - size)
                                {
                                    data.GridValues[i - size, j + size] = data.HelpArray[i - size, j + size];
                                    data.GridValues[i - size + 1, j + size] = data.HelpArray[i - size + 1, j + size];
                                    data.GridValues[i - size, j + size - 1] = data.HelpArray[i - size, j + size - 1];
                                }
                                if (i < data.GridValues.GetLength(0) - size && j < data.GridValues.GetLength(1) - size)
                                {
                                    data.GridValues[i + size, j + size] = data.HelpArray[i + size, j + size];
                                    data.GridValues[i + size - 1, j + size] = data.HelpArray[i + size - 1, j + size];
                                    data.GridValues[i + size, j + size - 1] = data.HelpArray[i + size, j + size - 1];
                                }
                            }
                        }
                    }
                }
            }

        }

    }
}
