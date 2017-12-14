using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalAlgorithms
{
    public class Player
    {
        #region Propety
        private string name;
        private Image avatar;
        #endregion
        public Player(string name,Image avatar)
        {
            this.name = name;
            this.avatar = avatar;
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Image Avatar
        {
            get
            {
                return avatar;
            }

            set
            {
                avatar = value;
            }
        }
    }
}
