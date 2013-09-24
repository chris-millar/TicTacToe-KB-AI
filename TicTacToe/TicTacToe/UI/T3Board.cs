using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe.UI
{
    public partial class T3Board : UserControl
    {
        public ArrayList BoardButtons;

        public T3Board()
        {
            InitializeComponent();
            BoardButtons = new ArrayList();

            BoardButtons.Add(NW_Button);
            BoardButtons.Add(N_Button);
            BoardButtons.Add(NE_Button);

            BoardButtons.Add(W_Button);
            BoardButtons.Add(M_Button);
            BoardButtons.Add(E_Button);

            BoardButtons.Add(SW_Button);
            BoardButtons.Add(S_Button);
            BoardButtons.Add(SE_Button);
        }

        private void NE_Button_Click(object sender, EventArgs e)
        {

        }

    }
}
