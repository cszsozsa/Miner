using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    /* VIEW */
    public class Grid
    {
        private int cellSize = 25;
        private Button[,] cells;
        public Grid(int width, int height, Control container)
        {
            CreateGrid(width, height, container);
        }

        private void CreateGrid(int width, int height, Control container)
        {
            cells = new Button[width, height];

            for(int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = new Button();
                    cells[i, j].Location = new Point(i * cellSize, j * cellSize);
                    cells[i, j].Size = new Size(cellSize, cellSize);
                    cells[i, j].Click += CellClick;
                    container.Controls.Add(cells[i, j]);
                }
            }
            container.ClientSize = new Size(width * cellSize, height * cellSize);
        }

        public void OnCellClick(Action<int, int> clickCallback)
        {
            clickCallback;
        }

        public void UpdateCell(int x, int y, int value)
        {
            cells[x, y].Enabled = false;
            cells[x, y].Text = value.ToString();
        }

        private void CellClick(object sender, EventArgs e)
        {
            int x = (sender as Button).Left / cellSize;
            int y = (sender as Button).Right / cellSize;

            clickCallback(x, y);
        }
    }
}