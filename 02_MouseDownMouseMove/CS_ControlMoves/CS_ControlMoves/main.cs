using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS_ControlMoves
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1_Click");
        }

        private void main_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Name != "pictureBox1")//底圖不綁選擇事件
                {
                    ctrl.MouseDown += ctrl_MouseDown;
                }
            }
            pictureBox1.MouseMove += ctrl_MouseMove;

            
            blnselect = false;
            ctrlbuf = null;
        }

        bool blnselect;
        Control ctrlbuf;
        public void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl.Capture==true && e.Button == MouseButtons.Left)//選擇物件
            {
                ctrlbuf = ctrl;
                blnselect = true;
            }
            
            if (e.Button == MouseButtons.Right)//放開物件
            {
                blnselect = false;
                ctrlbuf = null;
            }
            
        }
        public void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            if ((blnselect == true) && (ctrlbuf != null))
            {
                ctrlbuf.Top = e.Y;
                ctrlbuf.Left = e.X;
            }
        }

        /*
        public void ctrl_MouseUp(object sender, MouseEventArgs e)
        {

            blnselect = false;
            ctrlbuf = null;
        }
        */ 
    }
}
