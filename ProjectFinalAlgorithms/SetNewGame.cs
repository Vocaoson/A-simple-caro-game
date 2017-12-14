using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinalAlgorithms
{
    public partial class SetNewGame : Form
    {
        private event EventHandler setName;
        public event EventHandler SetName
        {
            add
            {
                setName += value;
            }
            remove
            {
                setName -= value;
            }
        }
        public SetNewGame()
        {
            InitializeComponent();
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(txtPlayer1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người chơi một", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlayer1.Focus();
                return;
            }
            if(txtPlayer2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người chơi hai", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlayer2.Focus();
                return;
            }
            if (setName != null)
            {
                setName(this, new MyEventArgs(txtPlayer1.Text,txtPlayer2.Text));
            }
            this.Close();
        }
    }
    public class MyEventArgs : EventArgs
    {
        private string namePlayer1;
        private string namePlayer2;
        public string NamePlayer1
        {
            get
            {
                return namePlayer1;
            }

            set
            {
                namePlayer1 = value;
            }
        }

        public string NamePlayer2
        {
            get
            {
                return namePlayer2;
            }

            set
            {
                namePlayer2 = value;
            }
        }
        public MyEventArgs(string namePlayer1,string namePlayer2)
        {
            this.namePlayer1 = namePlayer1;
            this.namePlayer2 = namePlayer2;
        }
    }

}
