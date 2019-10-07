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
        {   //Starts the round timer in order for the game to prorgress
            timer1.Enabled = true;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {   //Pauses the round timer
            timer1.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {   //The updating of the round timer
            lblRound.Text = "Round: " + engine.Round.ToString();
            engine.Update();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {   //THe instantiation of the game.            
            
            engine = new GameEngine(20, txtInfo, grpMap,5,timer1,lblResources,700,700);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {   //The calling of the save method to save the game
            GameEngine gameEngine = new GameEngine();
            gameEngine.Save();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {   //The calling of the read method to load a previous game
            GameEngine gameEngine = new GameEngine();
            gameEngine.Read();
            gameEngine.DisplayAfterRead(grpMap);
        }

        private void BtnChangeSize_Click(object sender, EventArgs e)
        {
            GameEngine game = new GameEngine(trbWidth.Value,trbHeight.Value,grpMap);
        }

        private void TrbWidth_Scroll(object sender, EventArgs e)
        {
            lblWidth.Text = "Width: " + trbWidth.Value;
        }

        private void TrbHeight_Scroll(object sender, EventArgs e)
        {
            lblHeight.Text = "Height: " + trbHeight.Value;
        }
    }
}
