using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

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

                        value = Moore(y, x, data.GridValues); 

                        if (value > 1 && data.IsInclusionBefore == true)
                        {
                            continue;
                        }

                        if (value < data.GrainsAmount+1 && data.FlagToGrain == true)
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

        public void ShapeControlCalculate()
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

                        bool flag = false;

                        value = MooreShapeControl(y, x);

                        

                        if (data.ShapeCounter >= 5 && flag == false)
                        {
                            flag = true;
                        }
                        
                        if (data.ShapeCounter >= 3 && data.ShapeCounter < 5 && flag == false)
                        {
                            value = NearestMooreShapeControl(y, x);
                            if (data.ShapeCounter >= 3 && data.ShapeCounter < 5)
                            {
                                flag = true;
                            }
                            else
                            {
                                value = FurtherMooreShapeControl(y, x);
                                if (data.ShapeCounter >= 3 && data.ShapeCounter < 5)
                                {
                                    flag = true;
                                }
                            }
                        }
                                
                        if (data.MaxCounterToProbability > 0 && data.MaxCounterToProbability <= 4 && flag == false)
                        {
                            Thread.Sleep(1);
                            value = ProbabilityShapeControl(y, x);
                            flag = true;
                        }

                        if (flag == false)
                        {
                            value = 0;
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

        public void CalculateSelection(int[,] array)
        {
            for (int i = 0; i < data.Speed; i++)
            {
                int[,] nextStepGrid = new int[data.SizeY, data.SizeX];

                for (int y = 0; y < data.SizeY; y++)
                {
                    for (int x = 0; x < data.SizeX; x++)
                    {
                        int actualCell = array[y, x];
                        nextStepGrid[y, x] = actualCell;

                        if (actualCell != 0)
                        {
                            continue;
                        }

                        int value = 0;

                        value = Moore(y, x, array);

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

                if (data.SelectionType == true)
                {
                    data.GrainsSelectionArray = nextStepGrid;
                    MergeArraySelection();
                }
                else
                {
                    data.GeneratedGrains = nextStepGrid;
                    MergeArraySelectionSubstructure();
                } 

                display.PrintCells();
            }

        }

        public void MergeArraySelectionSubstructure()
        {
            for (int k = 0; k < data.SizeY; k++)
            {
                for (int l = 0; l < data.SizeX; l++)
                {
                    if(data.LocalSubstructure[k,l] == 0)
                    {
                        data.GridValues[k, l] = data.GeneratedGrains[k, l];
                    }
                    else
                    {
                        data.GridValues[k, l] = data.LocalSubstructure[k, l];
                    }
                }
            }
        }

        public void MergeArraySelection()
        {
            for (int k = 0; k < data.SizeY; k++)
            {
                for (int l = 0; l < data.SizeX; l++)
                {
                    data.GridValues[k, l] = data.GrainsSelectionArray[k, l];
                }
            }

            if (data.SelectionType == false)
            {
                for (int k = 0; k < data.SizeY; k++)
                {
                    for (int l = 0; l < data.SizeX; l++)
                    {
                        if (data.SubstructureArray[k, l] != 0)
                        {
                            data.GridValues[k, l] = data.SubstructureArray[k, l];
                        }
                    }
                }
            }
            else
            {
                for (int k = 0; k < data.SizeY; k++)
                {
                    for (int l = 0; l < data.SizeX; l++)
                    {
                        if (data.DualPhaseArray[k, l] != 0)
                        {
                            data.GridValues[k, l] = data.DualPhaseArray[k, l];
                        }
                    }
                }
            }
        }

        public void CalculateSquareInclusion()
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

                    value = Moore(y, x, data.GridValues);

                    if (value != 0)
                    {
                        nextStepGrid[y, x] = value;
                        data.Cells[value]++;
                    }
                }
            }

            data.GridValues = nextStepGrid;
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
        private int Moore(int i, int j, int[,] array)
        {
            int[] tabNeighbours = new int[8];

            if (i > 0)
            {
                tabNeighbours[0] = array[i - 1, j];
            }
            if (i < data.GridValues.GetLength(0) - 1)
            {
                tabNeighbours[1] = array[i + 1, j];
            }
            if (j > 0)
            {
                tabNeighbours[2] = array[i, j - 1];
            }
            if (j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[3] = array[i, j + 1];
            }
            if (i > 0 && j > 0)
            {
                tabNeighbours[4] = array[i - 1, j - 1];
            }
            if (i < data.GridValues.GetLength(0) - 1 && j > 0)
            {
                tabNeighbours[5] = array[i + 1, j - 1];
            }
            if (i > 0 && j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[6] = array[i - 1, j + 1];
            }
            if (i < data.GridValues.GetLength(0) - 1 && j < data.GridValues.GetLength(1) - 1)
            {
                tabNeighbours[7] = array[i + 1, j + 1];
            }

            if (data.IsPeriodic)
            {
                if (i == 0)
                {
                    tabNeighbours[0] = array[data.GridValues.GetLength(0) - 1, j];
                }

                if (i == data.GridValues.GetLength(0) - 1)
                {
                    tabNeighbours[1] = array[0, j];
                }

                if (j == 0)
                {
                    tabNeighbours[2] = array[i, data.GridValues.GetLength(1) - 1];
                }

                if (j == data.GridValues.GetLength(1) - 1)
                {
                    tabNeighbours[3] = array[i, 0];
                }

                if (i == 0 && j == 0)
                {
                    tabNeighbours[4] = array[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                }
                if (i == data.GridValues.GetLength(0) - 1 && j == 0)
                {
                    tabNeighbours[5] = array[0, data.GridValues.GetLength(1) - 1];
                }
                if (i == 0 && j == data.GridValues.GetLength(1) - 1)
                {
                    tabNeighbours[6] = array[data.GridValues.GetLength(0) - 1, 0];
                }
                if (i == data.GridValues.GetLength(0) - 1 && j == data.GridValues.GetLength(1) - 1)
                {
                    tabNeighbours[7] = array[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                }
            }

            return selectNeighbour(tabNeighbours);
        }


        private int MooreShapeControl(int i, int j)
        {
            int[] tabNeighbours = new int[8];
            for (int l = 0; l < tabNeighbours.Length; l++)
            {
                tabNeighbours[l] = 0;
            }
            int returnedValue = 0;
            data.ShapeCounter = 0;

            //c1
            if (i < data.GridValues.GetLength(0) - 1 && j < data.GridValues.GetLength(1) - 1)
            {
                if (data.GridValues[i + 1, j + 1] != 0)
                {
                    tabNeighbours[0] = data.GridValues[i + 1, j + 1];
                    data.ShapeCounter++;
                }
            }
            //c2
            if (i < data.GridValues.GetLength(0) - 1)
            {
                if (data.GridValues[i + 1, j] != 0)
                {
                    tabNeighbours[1] = data.GridValues[i + 1, j];
                    data.ShapeCounter++;
                }
            }
            //c3
            if (i < data.GridValues.GetLength(0) - 1 && j > 0)
            {
                if (data.GridValues[i + 1, j - 1] != 0)
                {
                    tabNeighbours[2] = data.GridValues[i + 1, j - 1];
                    data.ShapeCounter++;
                }
            }
            //c4
            if (j < data.GridValues.GetLength(1) - 1)
            {
                if (data.GridValues[i, j + 1] != 0)
                {
                    tabNeighbours[3] = data.GridValues[i, j + 1];
                    data.ShapeCounter++;
                }    
            }
            //c6 
            if (j > 0)
            {
                if (data.GridValues[i, j - 1] != 0)
                {
                    tabNeighbours[4] = data.GridValues[i, j - 1];
                    data.ShapeCounter++;
                }
            }
            //c7
            if (i > 0 && j < data.GridValues.GetLength(1) - 1)
            {
                if (data.GridValues[i - 1, j + 1] != 0)
                {
                    tabNeighbours[5] = data.GridValues[i - 1, j + 1];
                    data.ShapeCounter++;
                }
            }
            //c8
            if (i > 0)
            {
                if (data.GridValues[i - 1, j] != 0)
                {
                    tabNeighbours[6] = data.GridValues[i - 1, j];
                    data.ShapeCounter++;
                }              
            }
            //c9
            if (i > 0 && j > 0)
            {
                if (data.GridValues[i - 1, j - 1] != 0)
                {
                    tabNeighbours[7] = data.GridValues[i - 1, j - 1];
                    data.ShapeCounter++;
                }       
            } 

            if (data.IsPeriodic)
            {
                //c1
                if (i == data.GridValues.GetLength(0) - 1 && j == data.GridValues.GetLength(1) - 1)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[0] = data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }   
                }
                //c2
                if (i == data.GridValues.GetLength(0) - 1)
                {
                    if (data.GridValues[0, j] != 0)
                    {
                        tabNeighbours[1] = data.GridValues[0, j];
                        data.ShapeCounter++;
                    }   
                }
                //c3
                if (i == data.GridValues.GetLength(0) - 1 && j == 0)
                {
                    if (data.GridValues[0, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[2] = data.GridValues[0, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }    
                }
                //c4
                if (j == data.GridValues.GetLength(1) - 1)
                {
                    if (data.GridValues[i, 0] != 0)
                    {
                        tabNeighbours[3] = data.GridValues[i, 0];
                        data.ShapeCounter++;
                    }  
                }
                //c6
                if (j == 0)
                {
                    if (data.GridValues[i, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[4] = data.GridValues[i, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }    
                }
                //c7
                if (i == 0 && j == data.GridValues.GetLength(1) - 1)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, 0] != 0)
                    {
                        tabNeighbours[5] = data.GridValues[data.GridValues.GetLength(0) - 1, 0];
                        data.ShapeCounter++;
                    } 
                }
                //c8
                if (i == 0)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, j] != 0)
                    {
                        tabNeighbours[6] = data.GridValues[data.GridValues.GetLength(0) - 1, j];
                        data.ShapeCounter++;
                    }    
                }
                //c9
                if (i == 0 && j == 0)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[7] = data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }  
                }
            }

            if (data.ShapeCounter >= 5 && data.ShapeCounter < 9)
            {
                data.MaxValueToProbability = 0;
                data.MaxCounterToProbability = 0;
                int counter = 0;
                int wartosc = 0;
                for (int q = 0; q < tabNeighbours.Length; q++)
                {
                    wartosc = tabNeighbours[q];
                    for (int k = 0; k < tabNeighbours.Length; k++)
                    {
                        if (wartosc == tabNeighbours[k] && tabNeighbours[k] != 0)
                        {
                            counter++;
                        }
                    }
                    if (counter > data.MaxCounterToProbability)
                    {
                        data.MaxCounterToProbability = counter;
                        data.MaxValueToProbability = wartosc;
                    }
                    counter = 0;
                }
                if (data.MaxCounterToProbability >= 5)
                {
                    returnedValue = data.MaxValueToProbability;
                }
            }
            else
            {   
                data.MaxValueToProbability = 0;
                data.MaxCounterToProbability = 0;
                int counter = 0;
                int wartosc = 0;
                for (int q = 0; q < tabNeighbours.Length; q++)
                {
                    wartosc = tabNeighbours[q];
                    for (int k = 0; k < tabNeighbours.Length; k++)
                    {
                        if (wartosc == tabNeighbours[k] && tabNeighbours[k] != 0)
                        {
                            counter++;
                        }
                    }
                    if (counter > data.MaxCounterToProbability)
                    {
                        data.MaxCounterToProbability = counter;
                        data.MaxValueToProbability = wartosc;
                    }
                    counter = 0;
                }
            }

            data.ShapeCounter = data.MaxCounterToProbability;

            return returnedValue;
        }

        private int FurtherMooreShapeControl(int i, int j)
        {
            int[] tabNeighbours = { 0, 0, 0, 0 };
            int returnedValue = 0;
            data.ShapeCounter = 0;

            if (i > 0 && j > 0)
            {
                if (data.GridValues[i - 1, j - 1] != 0)
                {
                    tabNeighbours[0] = data.GridValues[i - 1, j - 1];
                    data.ShapeCounter++;
                }            
            }
            if (i < data.GridValues.GetLength(0) - 1 && j > 0)
            {
                if (data.GridValues[i + 1, j - 1] != 0)
                {
                    tabNeighbours[1] = data.GridValues[i + 1, j - 1];
                    data.ShapeCounter++;
                }    
            }
            if (i > 0 && j < data.GridValues.GetLength(1) - 1)
            {
                if (data.GridValues[i - 1, j + 1] != 0)
                {
                    tabNeighbours[2] = data.GridValues[i - 1, j + 1];
                    data.ShapeCounter++;
                }
            }
            if (i < data.GridValues.GetLength(0) - 1 && j < data.GridValues.GetLength(1) - 1)
            {
                if (data.GridValues[i + 1, j + 1] != 0)
                {
                    tabNeighbours[3] = data.GridValues[i + 1, j + 1];
                    data.ShapeCounter++;
                }
            }

            if (data.IsPeriodic)
            {
                if (i == 0 && j == 0)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[0] = data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }     
                }
                if (i == data.GridValues.GetLength(0) - 1 && j == 0)
                {
                    if (data.GridValues[0, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[1] = data.GridValues[0, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }     
                }
                if (i == 0 && j == data.GridValues.GetLength(1) - 1)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, 0] != 0)
                    {
                        tabNeighbours[2] = data.GridValues[data.GridValues.GetLength(0) - 1, 0];
                        data.ShapeCounter++;
                    }       
                }
                if (i == data.GridValues.GetLength(0) - 1 && j == data.GridValues.GetLength(1) - 1)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[3] = data.GridValues[data.GridValues.GetLength(0) - 1, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }                 
                }
            }

            if (data.ShapeCounter >= 3 && data.ShapeCounter < 5)
            {
                int counter = 0;
                int value = 0;
                int maxValue = 0;
                int maxCounter = 0;
                for (int q = 0; q < tabNeighbours.Length; q++)
                {
                    value = tabNeighbours[q];
                    for (int k = 0; k < tabNeighbours.Length; k++)
                    {
                        if (value == tabNeighbours[k] && tabNeighbours[k] != 0)
                        {
                            counter++;
                        }
                    }
                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        maxValue = value;
                    }
                    counter = 0;
                }
                data.ShapeCounter = maxCounter;
                if (maxCounter >= 3 && maxCounter < 5)
                {
                    returnedValue = maxValue;
                }
            }


            return returnedValue;
        }

        private int NearestMooreShapeControl(int i, int j)
        {
            int[] tabNeighbours = { 0, 0, 0, 0 };
            int returnedValue = 0;
            data.ShapeCounter = 0;

            if (i > 0)
            {
                if (data.GridValues[i - 1, j] != 0)
                {
                    tabNeighbours[0] = data.GridValues[i - 1, j];
                    data.ShapeCounter++;
                }   
            }
            if (i < data.GridValues.GetLength(0) - 1)
            {
                if (data.GridValues[i + 1, j] != 0)
                {
                    tabNeighbours[1] = data.GridValues[i + 1, j];
                    data.ShapeCounter++;
                }       
            }
            if (j > 0)
            {
                if (data.GridValues[i, j - 1] != 0)
                {
                    tabNeighbours[2] = data.GridValues[i, j - 1];
                    data.ShapeCounter++;
                }   
            }
            if (j < data.GridValues.GetLength(1) - 1)
            {
                if (data.GridValues[i, j + 1] != 0)
                {
                    tabNeighbours[3] = data.GridValues[i, j + 1];
                    data.ShapeCounter++;
                }     
            }

            if (data.IsPeriodic)
            {
                if (i == 0)
                {
                    if (data.GridValues[data.GridValues.GetLength(0) - 1, j] != 0)
                    {
                        tabNeighbours[0] = data.GridValues[data.GridValues.GetLength(0) - 1, j];
                        data.ShapeCounter++;
                    }             
                }
                if (i == data.GridValues.GetLength(0) - 1)
                {
                    if (data.GridValues[0, j] != 0)
                    {
                        tabNeighbours[1] = data.GridValues[0, j];
                        data.ShapeCounter++;
                    }          
                }
                if (j == 0)
                {
                    if (data.GridValues[i, data.GridValues.GetLength(1) - 1] != 0)
                    {
                        tabNeighbours[2] = data.GridValues[i, data.GridValues.GetLength(1) - 1];
                        data.ShapeCounter++;
                    }       
                }
                if (j == data.GridValues.GetLength(1) - 1)
                {
                    if (data.GridValues[i, 0] != 0)
                    {
                        tabNeighbours[3] = data.GridValues[i, 0];
                        data.ShapeCounter++;
                    }         
                }
            }

            if (data.ShapeCounter >= 3 && data.ShapeCounter < 5)
            {
                int counter = 0;
                int value = 0;
                int maxValue = 0;
                int maxCounter = 0;
                for (int q = 0; q < tabNeighbours.Length; q++)
                {
                    value = tabNeighbours[q];
                    for (int k = 0; k < tabNeighbours.Length; k++)
                    {
                        if (value == tabNeighbours[k] && tabNeighbours[k] != 0)
                        {
                            counter++;
                        }
                    }
                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        maxValue = value;
                    }
                    counter = 0;
                }
                data.ShapeCounter = maxCounter;
                if (maxCounter >= 3 && maxCounter < 5)
                {
                    returnedValue = maxValue;
                }
            }
            return returnedValue;
        }

        private int ProbabilityShapeControl(int i, int j)
        { 
            int returnedValue = 0;
            Random random = new Random();
            int a = random.Next(1, 100);
           
            if (a < data.Probability)
            { 
                returnedValue = data.MaxValueToProbability;
            }
            return returnedValue;
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
