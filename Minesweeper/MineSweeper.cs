using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public class MineSweeper
    {
        private Map map;
        private Grid grid;
        public MineSweeper(int width, int height, int mines, Control container)
        {
            //Create Map
            map = new Map(width, height, mines);

            //Create Grid
            grid = new Grid(width, height, container);
            grid.OnCellClick(Interaction);
        }
        
        private void Interaction(int x, int y)
        {
            grid.UpdateCell(x, y, 6);
            //MessageBox.Show($"interaction :{x}, {y}");
        }
    }
}
