using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n_queen
{
    class ChessBoard
    {
        public static Bitmap draw(int size, int[,,] board)
        {
            int squareSize = 100;
            int circleSize = 70;

            Bitmap bm = new Bitmap(squareSize * size, squareSize * size);
            using (Graphics g = Graphics.FromImage(bm))
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if(((i + j) % 2) == 0)
                            g.FillRectangle(Brushes.White, j * squareSize, i * squareSize, squareSize, squareSize);
                        else
                            g.FillRectangle(Brushes.Black, j * squareSize, i * squareSize, squareSize, squareSize);
                        if (board != null && board[i, j, 0] == 1)
                        {
                            int x = (j * squareSize) + ((squareSize - circleSize) / 2);
                            int y = (i * squareSize) + ((squareSize - circleSize) / 2);
                            g.FillEllipse(Brushes.Red, x, y, circleSize, circleSize);
                        }
                            
                    }
                }
            }
            return bm;
        }
    }
}
