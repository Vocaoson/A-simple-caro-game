using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace ProjectFinalAlgorithms
{
    public partial class FormMain : Form
    {
        ManageChess manager;
    

        public FormMain()
        {
            InitializeComponent();
         
            manager = new ManageChess(PanelChessBoard);
            manager.Player += Manager_Player;
            manager.EndGame += Manager_EndGame;
        }
     

        private void Manager_EndGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void Manager_Player(object sender, EventArgs e)
        {
            LabelTime.Text = Constant.TIME_THINK.ToString();
            pbarLeft.Value = 0;
            pBarRight.Value = 0;
            timer1.Start();        
           
        }
        public void NewGame()
        {
            manager.DrawChessBoard();
            LabelTime.Text = Constant.TIME_THINK.ToString();
            pBarRight.Visible = true;
            pbarLeft.Visible = true;
            pbarLeft.Value = 0;
            pBarRight.Value = 0;
            timer1.Stop();
        }
        public void EndGame()
        {
            timer1.Stop();
            pBarRight.Visible = false;
            pbarLeft.Visible = false;
            LabelTime.Text = "";
            if (manager.CurrentPlayer == 0)
            {
                MessageBox.Show(manager.ListPlayer[1].Name + " win,chúc mừng !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(manager.ListPlayer[0].Name + " win,chúc mừng !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            PanelChessBoard.Enabled = false;
            manager.StackPlayerInfor.Clear();
        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            SetNewGame game = new SetNewGame();
            game.SetName += Game_SetName;   
            game.ShowDialog();
        }
        private void Game_SetName(object sender, EventArgs e)
        {
            lbPlayerone.Text = ((MyEventArgs)e).NamePlayer1;
            lbPlayerTwo.Text = ((MyEventArgs)e).NamePlayer2;
            manager.NamePlayerOne = ((MyEventArgs)e).NamePlayer1;
            manager.NamePlayerTwo = ((MyEventArgs)e).NamePlayer2;
            NewGame();
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            Out();
        }
        public void Out()
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // khi form dang thoát
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát ?", "Thông báo ", MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;// k cho thoát
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (Int32.Parse(LabelTime.Text) <= 0)
            {
                EndGame();
                return;
            }
            LabelTime.Text = (Int32.Parse(LabelTime.Text) - 1).ToString();
            pbarLeft.PerformStep();
            pBarRight.PerformStep();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            manager.Undo();
        }
    }
}

