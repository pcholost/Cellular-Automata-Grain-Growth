using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA.src
{
    class Display
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private PictureBox pictureBox;
        private Data data;
        bool bitmapFlag;
        string filePath;

        public Display(PictureBox pictureBox, Data data)
        {
            this.pictureBox = pictureBox;
            this.data = data;

            if (bitmapFlag == true)
            {
                bitmap = new Bitmap(filePath);
                pictureBox.Image = bitmap;
                graphics = Graphics.FromImage(bitmap);
            }
            else
            {
                bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                graphics = Graphics.FromImage(bitmap);
            }

        }

        public void Clear()
        {
            graphics.Clear(Color.White);
            pictureBox.Image = bitmap;
        }

        public void PrintCells()
        {
            if (data.IsSelectionClicked == false)
                Clear();

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    Rectangle rect = new Rectangle(
                        j * data.CellSize,
                        i * data.CellSize,
                        data.CellSize,
                        data.CellSize);
                    graphics.FillRectangle(data.Colors[data.GridValues[i, j]], rect);
                }
            }

            pictureBox.Image = bitmap;
        }

        public void ExportToBitmap(object sender, EventArgs e)
        {
           string path = Directory.GetCurrentDirectory() + "\\bitmaps";

           if (!Directory.Exists(path))
           {
               Directory.CreateDirectory(path);
           }
           
           bitmap.Save(path + "\\exportedBitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

           string bitmapFile = data.SizeX + ";" + data.SizeY + ";" + data.CurrentIndex + ";" + data.GridValues;

           File.WriteAllText(path + "\\exportedFileBitmap.txt", bitmapFile);
        }

        public void ImportFromBitmap(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    bitmap = new Bitmap(filePath);
                    bitmapFlag = true;
                    pictureBox.Image = bitmap;
                    graphics = Graphics.FromImage(bitmap);
                }


            }

        }

        public void ExportToFile(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\files";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            string createText = data.SizeX + " " + data.SizeY + " " + data.CurrentIndex + Environment.NewLine;

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    createText += j + " " + i + " " + data.GridValues[i,j] + Environment.NewLine;
                }
            }
            File.WriteAllText(path + "\\exportedMicrostructure.txt", createText);
        }

        public void ImportFromFile(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
            
                    string token = File.ReadAllText(filePath);
                    string[] lines = token.Split(' ', '\n');

                    data.SizeX = int.Parse(lines[0]);
                    data.SizeY = int.Parse(lines[1]);

                    data.Initialize();

                    data.CurrentIndex = int.Parse(lines[2]);
                    int indexOfGrain = 3;

                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            data.GridValues[i, j] = int.Parse(lines[2 + indexOfGrain]);

                            data.AddNewColor();

                            indexOfGrain += 3;
                        }
                    }

                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            if (data.GridValues[i, j] == 1 || data.IsInclusionBefore == true)
                            {
                                data.AddBlackColor();
                                data.GridValues[i, j] = data.GrainsAmount + 1;
                            }
                        }
                    }

                    PrintCells();

                }
            }

        }

        public void DisplayBoundariesOfGrain()
        {
            if (data.IsSelectionClicked == false)
                Clear();

            for (int i = 0; i < data.SizeY; i++)
            {
                for (int j = 0; j < data.SizeX; j++)
                {
                    Rectangle rect = new Rectangle(
                        j * data.CellSize,
                        i * data.CellSize,
                        data.CellSize,
                        data.CellSize);
                    graphics.FillRectangle(data.Colors[data.BoundariesArray[i, j]], rect);
                }
            }

            pictureBox.Image = bitmap;
        }

        public void ExportDistribution(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\files";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            int counter = 0;
            string createText = "Id: " + "Size: " + "%" + Environment.NewLine;

            for (int k = 1; k <= data.CurrentIndex; k++)
            {
                {
                    counter = 0;
                    for (int i = 0; i < data.SizeY; i++)
                    {
                        for (int j = 0; j < data.SizeX; j++)
                        {
                            if (data.GridValues[i, j] == k)
                            {
                                counter++;
                            }
                        }
                    }
                    if (counter != 0)
                    {
                        double percent = (100.0 * (double)counter / ((double)data.SizeY * (double)data.SizeX));
                        createText += k + " " + counter + " " + Math.Round(percent, 4) + Environment.NewLine;
                    }
                }
            }
            File.WriteAllText(path + "\\exportedDistribution.txt", createText);
        }

    }
}
