using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vieyra18022490_Task2
{
    public partial class Form1 : Form
    {
        GameEngine engine;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblRound.Text = "Round: " + engine.Round.ToString();
            engine.Update();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, txtInfo, grpMap,5,timer1,lblResources);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Save();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Read();
            gameEngine.DisplayAfterRead(grpMap);
        }
    }
}
