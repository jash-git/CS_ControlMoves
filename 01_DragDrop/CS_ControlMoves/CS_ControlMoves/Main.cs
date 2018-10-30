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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1_Click");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //step01-為每個控制項加事件
            
            foreach (Control ctrl in Controls)
            {
                ctrl.MouseMove += ctrl_MouseMove;
                ctrl.MouseDown += ctrl_MouseDown;
            }
        }

        void ctrl_MouseMove(object sender, MouseEventArgs e)//step02
        {
            Control ctrl = sender as Control;
            if (ctrl.Capture && e.Button == MouseButtons.Left)
            {
                DoDragDrop(ctrl, DragDropEffects.Move);//定義拖曳圖示
            }
        }

        private MouseEventArgs _pos = null;
        void ctrl_MouseDown(object sender, MouseEventArgs e)//step05
        {
            if (e.Button == MouseButtons.Left)
            {
                _pos = e;//按下時記錄位置
            }
        }

        /*
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }
        */
        private void Main_DragDrop(object sender, DragEventArgs e)//step04
        {
            if (_ctrl != null)
            {
                _ctrl.Top = this.PointToClient(new Point(e.X, e.Y)).Y;
                _ctrl.Left = this.PointToClient(new Point(e.X, e.Y)).X;
            }
        }

        Control _ctrl = null;
        //存放被拖曳的控制項
        /*
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
        }
        */
        private void Main_DragEnter(object sender, DragEventArgs e)//step03
        {
            //取出被拖曳的控制項
            _ctrl = e.Data.GetData(e.Data.GetFormats(true)[0]) as Control;
            if (_ctrl != null)
                e.Effect = (_ctrl == null) ? DragDropEffects.None : DragDropEffects.Move;
        }
    }
}
