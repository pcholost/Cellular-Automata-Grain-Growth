using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace CA.src
{
    class Data
    {
        private int sizeX;
        private int sizeY;
        private int cellSize;
        private bool isPeriodic;
        private bool isInclusionBefore;
        private bool isBorder;
        private bool endInclusionAfter;
        private bool restartGenerate;
        private int speed;
        private int currentIndex;
        private bool inclusionType;
        private bool selectionType;
        private int shapeCounter;
        private int probability;
        private int maxValueToProbability;
        private int maxCounterToProbability;

        private int inclusionSize;
        private int inclusionsAmount;
        private int grainsToSelectionAmount;
        private bool flagColorDualPhase;
        private int colorDualPhase;
        private int gbSize;
        private bool isBorderyClicked;

        private bool isSelectionClicked;

        private List<Brush> colors;
        private List<int> cells;
        private int[,] gridValues;
        private int[,] boundaryValues;
        private int[,] helpBoundaryValues;
        private int[,] helpArray;

        private int[,] substructureArray;
        private int[,] dualPhaseArray;
        private int[,] grainsSelectionArray;
        private int[,] boundariesArray;
        private int[,] selectedBoundaryArray;

        private Point[,] gridPoints;

        private int grainsAmount;

        private Random random;


        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
        public int CurrentIndex { get => currentIndex; set => currentIndex = value; }
        public int CellSize { get => cellSize; set => cellSize = value; }
        public bool IsPeriodic { get => isPeriodic; set => isPeriodic = value; }
        public bool IsInclusionBefore { get => isInclusionBefore; set => isInclusionBefore = value; }
        public bool IsBorder { get => isBorder; set => isBorder = value; }
        public bool IsSelectionClicked { get => isSelectionClicked; set => isSelectionClicked = value; }
        public bool EndInclusionAfter { get => endInclusionAfter; set => endInclusionAfter = value; }
        public bool RestartGenerate { get => restartGenerate; set => restartGenerate = value; }
        public bool InclusionType { get => inclusionType; set => inclusionType = value; }
        public bool SelectionType { get => selectionType; set => selectionType = value; }
        public bool IsBorderyClicked { get => isBorderyClicked; set => isBorderyClicked = value; }
        public List<int> Cells { get => cells; set => cells = value; }
        public List<Brush> Colors { get => colors; set => colors = value; }
        public int[,] GridValues { get => gridValues; set => gridValues = value; }
        public Point[,] GridPoints { get => gridPoints; set => gridPoints = value; }
        public int Speed { get => speed; set => speed = value; }
        public int ColorDualPhase { get => colorDualPhase; set => colorDualPhase = value; }
        public bool FlagColorDualPhase { get => flagColorDualPhase; set => flagColorDualPhase = value; }
        public int MaxValueToProbability { get => maxValueToProbability; set => maxValueToProbability = value; }
        public int MaxCounterToProbability { get => maxCounterToProbability; set => maxCounterToProbability = value; }
        public int Probability { get => probability; set => probability = value; }
        public int GrainsToSelectionAmount { get => grainsToSelectionAmount; set => grainsToSelectionAmount = value; }
        public int ShapeCounter { get => shapeCounter; set => shapeCounter = value; }
        public int GrainsAmount { get => grainsAmount; set => grainsAmount = value; }
        public int InclusionSize { get => inclusionSize; set => inclusionSize = value; }
        public int InclusionsAmount { get => inclusionsAmount; set => inclusionsAmount = value; }
        public int GbSize { get => gbSize; set => gbSize = value; }
        public int[,] BoundaryValues { get => boundaryValues; set => boundaryValues = value; }
        public int[,] HelpBoundaryValues { get => helpBoundaryValues; set => helpBoundaryValues = value; }
        public int[,] HelpArray { get => helpArray; set => helpArray = value; }
        public int[,] SubstructureArray { get => substructureArray; set => substructureArray = value; }
        public int[,] DualPhaseArray { get => dualPhaseArray; set => dualPhaseArray = value; }
        public int[,] GrainsSelectionArray { get => grainsSelectionArray; set => grainsSelectionArray = value; }
        public int[,] BoundariesArray { get => boundariesArray; set => boundariesArray = value; }
        public int[,] SelectedBoundariesArray { get => boundariesArray; set => boundariesArray = value; }

        public Data()
        {
            random = new Random();

            isPeriodic = false;
            inclusionType = false;
            selectionType = false;
            currentIndex = 0;
            CellSize = 10;
            inclusionSize = 1;
        }

        public void Initialize()
        {
            Colors = new List<Brush>
            {
                new SolidBrush(Color.FromArgb(255, 255, 255))
            };

            cells = new List<int>
            {
                new int()
            };

            currentIndex = 0;
            IsInclusionBefore = false;
            EndInclusionAfter = true;
            flagColorDualPhase = false;
            gridValues = new int[sizeY, sizeX];
            boundaryValues = new int[sizeY, sizeX];
            helpBoundaryValues = new int[sizeY, sizeX];
            gridPoints = new Point[sizeY, sizeX];
            dualPhaseArray = new int[sizeY, sizeX];
            substructureArray = new int[sizeY, sizeX];
            grainsSelectionArray = new int[sizeY, sizeX];
            boundariesArray = new int[sizeY, sizeX];
            selectedBoundaryArray = new int[sizeY, sizeX];
            
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    gridPoints[i, j] = new Point(random.Next(i * cellSize, (i + 1) * cellSize), random.Next(j * cellSize, (j + 1) * cellSize));
                    boundaryValues[i, j] = 0;
                    helpBoundaryValues[i, j] = 0;
                    dualPhaseArray[i, j] = 0;
                    substructureArray[i, j] = 0;
                    grainsSelectionArray[i, j] = 0;
                    boundariesArray[i, j] = 0;
                    selectedBoundaryArray[i, j] = 0;
                }
            }
        }

        public void AddNewColor()
        {
            cells.Add(1);
            colors.Add(new SolidBrush(Color.FromArgb(10 + random.Next(246), 10 + random.Next(246), 10 + random.Next(246))));
        }

        public void AddBlackColor()
        {
            cells.Add(1);
            colors.Add(new SolidBrush(Color.FromArgb(0, 0, 0)));
        }

    }
}
