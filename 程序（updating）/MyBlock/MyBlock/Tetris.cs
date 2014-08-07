using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyBlock
{
    public partial class Tetris : Form
    {
        public Tetris()
        {
            InitializeComponent();
        }
        private Keys downKey;
        private Keys dropKey;
        private Keys moveLeftKey;
        private Keys moveRightKey;
        private Keys deasilRotateKey;
 //       private Keys contraRotateKey;

        private BlockGame p;
        private void btStart_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
            p = new BlockGame(15, 25, 20, Color.Black, pbRun.CreateGraphics(), lblReady.CreateGraphics());
            p.GpScore = lblScore.CreateGraphics();
            p.BpLevel = lblLevel.CreateGraphics();
            p.Start();

        }

        private void Tetris_Load(object sender, EventArgs e)
        {
            downKey =Keys.Down;
            dropKey =Keys.Space;
            moveLeftKey = Keys.Left;
            moveRightKey = Keys.Right;
            deasilRotateKey = Keys.Up;
       //     contraRotateKey = Keys.S;
        }

        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            // I have overrided the ProcessDialogKey method to do key event.
            // So I handled all keyDown event and keep from any control.
            if (p != null)
                e.Handled = true;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            /* The ProcessDialogKey method in the System.Windows.Forms.Control 
             * class is called automatically when a key or a combination of keys 
             * on the keyboard is pressed. Unlike the KeyPress event, ProcessDialogKey 
             * can capture any key. When overriding the ProcessDialogKey method, you 
             * should return true when the key was handled and false otherwise.
             */
            if (p != null)
            {
                if (keyData == moveLeftKey)
                    p.MoveLeft();
                if (keyData == moveRightKey)
                    p.MoveRight();
                if (keyData == dropKey)
                    p.Drop();
                if (keyData == deasilRotateKey)
                    p.DeasilRotate();
      //          if (keyData == contraRotateKey)
        //            p.ContraRotate();
                if (keyData == downKey)
                    p.Down();
                return false;
            }
            else return base.ProcessDialogKey(keyData);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (p == null)
            {
                return;
            }
            if (btnPause.Text == "暂停")
            {
                p.Pause();
                btnPause.Text = "继续";
            }
            else
            {
                p.EndPause();
                btnPause.Text = "暂停";
            }
        }

        private void Tetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
        }

        private void lblScore_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.ShowScore(e.Graphics);
            }
        }




        private void pbRun_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintPalette(e.Graphics);
            }
        }

        private void lblReady_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintReady(e.Graphics);
            }
        }














        
    }
}