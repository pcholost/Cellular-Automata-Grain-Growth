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
        private bool restartGenerate;
        private int speed;
        private int currentIndex;

        private int inclusionSize;
        private int inclusionsAmount;

        private List<Brush> colors;
        private List<int> cells;
        private int[,] gridValues;
        private int[,] boundaryValues;
        private int[,] helpBoundaryValues;

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
        public bool RestartGenerate { get => restartGenerate; set => restartGenerate = value; }
        public List<int> Cells { get => cells; set => cells = value; }
        public List<Brush> Colors { get => colors; set => colors = value; }
        public int[,] GridValues { get => gridValues; set => gridValues = value; }
        public Point[,] GridPoints { get => gridPoints; set => gridPoints = value; }
        public int Speed { get => speed; set => speed = value; }
        public int GrainsAmount { get => grainsAmount; set => grainsAmount = value; }
        public int InclusionSize { get => inclusionSize; set => inclusionSize = value; }
        public int InclusionsAmount { get => inclusionsAmount; set => inclusionsAmount = value; }
        public int[,] BoundaryValues { get => boundaryValues; set => boundaryValues = value; }
        public int[,] HelpBoundaryValues { get => helpBoundaryValues; set => helpBoundaryValues = value; }

        public Data()
        {
            random = new Random();

            isPeriodic = false;
            currentIndex = 0;
            CellSize = 3;
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
            gridValues = new int[sizeY, sizeX];
            boundaryValues = new int[sizeY, sizeX];
            helpBoundaryValues = new int[sizeY, sizeX];
            gridPoints = new Point[sizeY, sizeX];
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    gridPoints[i, j] = new Point(random.Next(i * cellSize, (i + 1) * cellSize), random.Next(j * cellSize, (j + 1) * cellSize));
                    boundaryValues[i, j] = 0;
                    helpBoundaryValues[i, j] = 0;
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
