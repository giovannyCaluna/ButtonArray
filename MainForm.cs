
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ButtonArray
{
    public partial class MainForm : Form
    {
        int r = 3 ;    // number of rows
        int c = 4 ;    // number of columns
        int xp = 20 ;  // X padding
        int yp = 20 ;  // Y padding

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetParams dlg = new GetParams();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MainForm_RemoveButtons(sender, e);

                r = int.Parse(dlg.textBox1.Text);
                c = int.Parse(dlg.textBox2.Text);
                xp = int.Parse(dlg.textBox3.Text);
                yp = int.Parse(dlg.textBox4.Text);

                MainForm_Resize(sender, e);

            }
        }

        private void MainForm_RemoveButtons(object sender, EventArgs e)
        {
            for (int rr = 0; rr < r; ++rr)
            {
                for (int cc = 0; cc < c; ++cc)
                {
                    string name = "ButtonArray (" + rr.ToString() + ";" + cc.ToString() + ")";
                    this.Controls.RemoveByKey(name);
                }
            }
            this.Refresh();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Size s = new Size((this.ClientRectangle.Width - (c + 1) * xp) / c,
                               (this.ClientRectangle.Height - (r + 1) * yp) / r);

            for (int rr = 0; rr < r; ++rr)
            {
                for (int cc = 0; cc < c; ++cc)
                {
                    Button b = new Button();
                    b.Text = "ButtonArray (" + rr.ToString() + ";" + cc.ToString() + ")";
                    b.Size = s;
                    b.Location = new Point(xp + cc * (s.Width + xp), yp + rr * (s.Height + yp));
                    b.Name = b.Text;
                    b.Click += new EventHandler(ButtonArray_Click);
                    b.ContextMenuStrip = contextMenuStrip1;
                    this.Controls.Add(b);
                }
            }
        }


        private void ButtonArray_Click(object sender, EventArgs e)
        {
            string[] s = sender.ToString().Split(new char [] {'(', ';', ')'}, StringSplitOptions.RemoveEmptyEntries) ;
            int row = int.Parse(s[1]);
            int col = int.Parse(s[2]);

            MessageBox.Show("Sor: " + row.ToString() + " oszlop: " + col.ToString());
        }

        private void setTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuStrip strip = (sender as ToolStripMenuItem).Owner as ContextMenuStrip;
            Control pressed = strip.SourceControl as Control;

            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pressed.ForeColor = dlg.Color;
            }
        }

        private void setBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuStrip strip = (sender as ToolStripMenuItem).Owner as ContextMenuStrip;
            Control pressed = strip.SourceControl as Control;

            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pressed.BackColor = dlg.Color;
            }
        }

    }
}
