using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;

namespace n_queen
{
    public partial class Form1 : Form
    {
        private NQueen nq;
        private int[,,] board;
        private System.Windows.Forms.Timer timer;
        private DateTime timerStart;

        public Form1()
        {
            InitializeComponent();
            this.nq = new NQueen();
            board = null;
            pictureBox1.Image = ChessBoard.draw(int.Parse(textBox1.Text), board);
            timer = new System.Windows.Forms.Timer();
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Calculating solution...";
            richTextBox1.Text = "";
            label2.Text = "";
            pictureBox1.Image = ChessBoard.draw(int.Parse(textBox1.Text), null);
            timerStart = DateTime.Now;
            timer.Enabled = true;
            timer.Start();
            var trd = new Thread(() => this.board = this.nq.solve(int.Parse(textBox1.Text)));
            trd.IsBackground = true;
            trd.Start();
            trd.Join();
            timer.Stop();
            timer.Enabled = false;
            labelStatus.Text = board[0,0,1] + " queens found!";
            richTextBox1.Text = this.nq.boardString(board);
            label2.Text = ((TimeSpan)(DateTime.Now - timerStart)).TotalMilliseconds.ToString();
            pictureBox1.Image = ChessBoard.draw(int.Parse(textBox1.Text), board);
        }
    }
}
