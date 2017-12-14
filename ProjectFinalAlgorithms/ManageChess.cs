using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProjectFinalAlgorithms
{

    public class ManageChess
    {
        #region Propety
        private Panel panelChessBoard;
        //Luu ban co bang 2 list long nhau = > tuong duong moi ma tran
        private List<List<Button>> listChess;
        private List<Player> listPlayer;
        private event EventHandler endGame;
        private event EventHandler player;
        private StackCustom<PlayInfor> stackPlayerInfor;
        public event EventHandler EndGame
        {
            add
            {
                endGame += value;
            }
            remove
            {
                endGame -= value;
            }
        }
        public event EventHandler Player
        {
            add
            {
                player += value;
            }
            remove
            {
                player -= value;
            }
        }
        private string namePlayerOne;
        private string namePlayerTwo;
        private int currentPlayer;
        //mang giá trị 0,1 : biểu thị cho người chơi hiejn tại
        public Panel PanelChessBoard
        {
            get
            {
                return panelChessBoard;
            }

            set
            {
                panelChessBoard = value;
            }
        }

        public List<List<Button>> ListChess
        {
            get
            {
                return listChess;
            }

            set
            {
                listChess = value;
            }
        }

        public List<Player> ListPlayer
        {
            get
            {
                return listPlayer;
            }

            set
            {
                listPlayer = value;
            }
        }

        public int CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }

            set
            {
                currentPlayer = value;
            }
        }

        public StackCustom<PlayInfor> StackPlayerInfor
        {
            get
            {
                return stackPlayerInfor;
            }

            set
            {
                stackPlayerInfor = value;
            }
        }

        public string NamePlayerOne
        {
            get
            {
                return namePlayerOne;
            }

            set
            {
                namePlayerOne = value;
                if (listPlayer.Count > 0) listPlayer.Clear();
                listPlayer.Add(new Player(NamePlayerOne,Properties.Resources.player1));
            }
        }

        public string NamePlayerTwo
        {
            get
            {
                return namePlayerTwo;
            }

            set
            {
                namePlayerTwo = value;
                if (listPlayer.Count > 1) listPlayer.Clear();
                listPlayer.Add(new Player(namePlayerTwo, Properties.Resources.player2));
            }
        }
        #region Init
        public ManageChess(Panel panelChessBoard)
        {
            this.panelChessBoard = panelChessBoard;
            this.listPlayer = new List<Player>();
            this.CurrentPlayer = 0;// đầu tiên là ng chơi 1
            StackPlayerInfor = new StackCustom<PlayInfor>();
        }
        #endregion
        #endregion
        #region Method
        /*Method chiu trach nhiem ve ban co*/
        public void DrawChessBoard()
        {
            SetNewGame();
            int hozizontal = Constant.HOZIZONTAL;
            int vartical = Constant.VARTICAL;
            listChess = new List<List<Button>>();
            for (int i = 0; i < Constant.HEIGHT_BOARD; i++)
            {
                List<Button> aList = new List<Button>();
                for (int j = 0; j < Constant.WIDTH_BOARD; j++)
                {
                    Button buttonChess = new Button()
                    {

                        Width = Constant.WIDTH_BUTTON,
                        Height = Constant.HEIGHT_BUTTON,
                        Location = new Point(hozizontal, vartical)

                    };
                    buttonChess.Tag = i.ToString();
                    buttonChess.BackgroundImageLayout = ImageLayout.Stretch;
                    buttonChess.Click += ButtonChess_Click;
                    aList.Add(buttonChess);
                    PanelChessBoard.Controls.Add(buttonChess);
                    hozizontal += buttonChess.Width;
                }
                hozizontal = Constant.HOZIZONTAL;
                vartical += Constant.HEIGHT_BUTTON;
                listChess.Add(aList);
            }
        }
        public bool isEndGame(Button customBtn)
        {
            if (CheckWinHozizontal(customBtn)) return true;
            else if (CheckWinVartical(customBtn)) return true;
            else if (CheckWinCheoChinh(customBtn)) return true;
            else if (CheckWinCheoPhu(customBtn)) return true;
            return false;
        }
        public bool CheckWinHozizontal(Button customBtn)
        {

            int vartical = Int32.Parse(customBtn.Tag.ToString());
            int hozizontal = listChess[vartical].IndexOf(customBtn);
            int checkRight = 0;
            int checkLeft = 0;
            int i = hozizontal;
            for (; i < Constant.WIDTH_BOARD; i++)
            {
                if (customBtn.BackgroundImage == listChess[vartical][i].BackgroundImage)
                {
                    checkRight++;
                }
                else break;
            }
            i = hozizontal - 1;
            for (; i >= 0; i--)
            {
                if (customBtn.BackgroundImage == listChess[vartical][i].BackgroundImage)
                {
                    checkLeft++;
                }
                else break;
            }
            return checkLeft + checkRight >= 5;
        }
        public bool CheckWinVartical(Button customBtn)
        {
            int vartical = Int32.Parse(customBtn.Tag.ToString());
            int hozizontal = listChess[vartical].IndexOf(customBtn);
            int CheckTop = 0;
            int CheckButton = 0;
            int i = vartical;
            for (; i < Constant.HEIGHT_BOARD; i++)
            {
                if (customBtn.BackgroundImage == listChess[i][hozizontal].BackgroundImage)
                {
                    CheckTop++;
                }
                else break;
            }
            i = vartical - 1;
            for (; i >= 0; i--)
            {
                if (customBtn.BackgroundImage == listChess[i][hozizontal].BackgroundImage)
                {
                    CheckButton++;
                }
                else break;
            }
            return CheckTop + CheckButton >= 5;
        }
        public bool CheckWinCheoChinh(Button customBtn)
        {
            int vartical = Int32.Parse(customBtn.Tag.ToString());
            int hozizontal = listChess[vartical].IndexOf(customBtn);
            int i = vartical;
            int j = hozizontal;
            int checkTop = 0;
            int checkBottom = 0;
            for (; i >= 0 && j >= 0; i--, j--)
            {
                if (listChess[i][j].BackgroundImage == customBtn.BackgroundImage) checkTop++;
                else break;
            }
            i = vartical++;
            j = hozizontal++;
            for (; i < Constant.HEIGHT_BOARD && j < Constant.WIDTH_BOARD; i++, j++)
            {
                if (listChess[i][j].BackgroundImage == customBtn.BackgroundImage) checkBottom++;
                else break;
            }
            return checkTop + checkBottom >= 6;
        }
        public bool CheckWinCheoPhu(Button customBtn)
        {
            int vartical = Int32.Parse(customBtn.Tag.ToString());
            int hozizontal = listChess[vartical].IndexOf(customBtn);
            int i = vartical;
            int j = hozizontal;
            int checkTop = 0;
            int checkBottom = 0;
            for (; i >= 0 && j < Constant.WIDTH_BOARD; i--, j++)
            {
                if (listChess[i][j].BackgroundImage == customBtn.BackgroundImage) checkTop++;
                else break;
            }
            i = vartical++;
            j = hozizontal++;
            for (; i < Constant.HEIGHT_BOARD && j >= 0; i++, j--)
            {
                if (listChess[i][j].BackgroundImage == customBtn.BackgroundImage) checkBottom++;
                else break;
            }
            return checkTop + checkBottom >= 6;
        }
        private void ButtonChess_Click(object sender, EventArgs e)// object sender chinh la button dang nhấn
        {
            Button btn = sender as Button;// ép sender về button
            if (btn.BackgroundImage == null)
            {
                Play(btn);
            }
        }
        public void Play(Button btn)
        {
            btn.BackgroundImage = listPlayer[CurrentPlayer].Avatar;
            Point point = GetPointButton(btn);
            StackPlayerInfor.Push(new PlayInfor() { Point = point, Current = CurrentPlayer });
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;           
            if (player != null)
            {
                player(this, new EventArgs());
            }
            if (isEndGame(btn))
            {
                SetEndGame();
            }
        }
        public Point GetPointButton(Button customButton)
        {
            int vartical = Convert.ToInt32(customButton.Tag);
            int hozizontal = listChess[vartical].IndexOf(customButton);
            return new Point() { X = hozizontal, Y = vartical };
        }
    
        public bool Undo()
        {
            if (stackPlayerInfor.isEmpty()) return false;

            PlayInfor playerInfor = stackPlayerInfor.Pop();
            CurrentPlayer= playerInfor.Current;
            if (player != null)//event đếm số lại
            {
                player(this, new EventArgs());
            }
            Point p = playerInfor.Point;
            listChess[p.Y][p.X].BackgroundImage = null;
            return true;
        }
        public void SetNewGame()
        {
            panelChessBoard.Enabled = true;
            PanelChessBoard.Controls.Clear();
            CurrentPlayer = 0;
        }
        public void SetEndGame()
        {
            stackPlayerInfor.Clear();
            if (endGame != null)
            {
                endGame(this, new EventArgs());
            }
        }
        #endregion
    }
}
