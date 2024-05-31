using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mayin_Tarlasi03
{
    public partial class Mayin_Tarlasi03 : Form
    {
        byte[,] Positions = new byte[15, 15];
        Button[,] ButtonList = new Button[15, 15];
        public Mayin_Tarlasi03()
        {
            InitializeComponent();
            GenerateBombs();
            GeneratePositionValue();
            GenerateButtons();
        }

        Random rnd = new Random();
        private void GenerateBombs()
        {
            int bombs = 0;
            while( bombs < 30)
            {
                int x = rnd.Next(0, 14);
                int y = rnd.Next(0, 14);

                if (Positions[x, y] == 0)
                {
                    Positions[x, y] = 10;
                    bombs++;
                }
            }
        }

        private void GeneratePositionValue()
        {
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    if (Positions[x, y] == 10)
                        continue;
                    byte bombCounts = 0;
                    for (int counterX = -1; counterX < 2; counterX++)
                    {
                        int checkerX = x + counterX;

                        for (int counterY = -1; counterY < 2; counterY++)
                        {
                            int checkerY = y + counterY;
                            if (checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
                                continue;
                            if (checkerY == y && checkerX == x)
                                continue;
                            if (Positions[checkerX, checkerY] == 10)
                                bombCounts++;

                        }
                    }

                    if (bombCounts == 0)
                        Positions[x, y] = 20;
                    else
                        Positions[x, y] = bombCounts;

                }
            }
        }
        private void GenerateButtons()
        {
            int xLoc = 3;
            int yLoc = 3;
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    Button btn = new Button();
                    btn.Parent = pnlPanel;
                    btn.Location = new Point(xLoc, yLoc);
                    btn.Size = new Size(25, 22);
                    btn.Tag = $"{x},{y}";
                    btn.Click += BtnClick;
                    btn.MouseUp += BtnMouseUp;
                    xLoc += 25;
                    ButtonList[x,y] = btn;  
                }
                yLoc += 22;
                xLoc = 3;
            }
        }
        private void BtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));
            byte value = Positions[x, y];

            if (value == 10)
            {
                btn.Image = Properties.Resources.mayin_foto01;

                MessageBox.Show("Oyun bitti");
                pnlPanel.Enabled = false;
            }
            else if (value == 20)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
                btn.FlatAppearance.BorderSize = 1;
                btn.Enabled = false;
                OpenAdjacentEmptyTile(btn);
                points++;

            }
            else
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
                btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
                btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                btn.Text = Positions[x, y].ToString();
                points++;
            }

            btn.Click -= BtnClick;
            txtSkor.Text = points.ToString();
        }
        private void OpenAdjacentEmptyTile(Button btn)
        {
            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));

            List<Button> empytButtons = new List<Button>();

            for (int counterX = -1; counterX < 2; counterX++)
            {
                int checkerX = x + counterX;

                for (int counterY = -1; counterY < 2; counterY++)
                {
                    int checkerY = y + counterY;
                    if (checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
                        continue;
                    if (checkerY == y && checkerX == x)
                        continue;
                    Button btnAdjacent = ButtonList[checkerX, checkerY];

                    int xAdjacent = Convert.ToInt32(btnAdjacent.Tag.ToString().Split(',').GetValue(0));
                    int yAdjacent = Convert.ToInt32(btnAdjacent.Tag.ToString().Split(',').GetValue(1));

                    byte value = Positions[xAdjacent, yAdjacent];
                    if (value == 20)
                    {
                        if (btnAdjacent.FlatStyle != FlatStyle.Flat)
                        {
                            btnAdjacent.FlatStyle = FlatStyle.Flat;
                            btnAdjacent.FlatAppearance.BorderSize = 1;
                            btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
                            btnAdjacent.Enabled = false;
                            empytButtons.Add(btnAdjacent);
                            points++;
                        }

                    }else if (value != 10) 
                    {
                        btnAdjacent.PerformClick();
                    }

                }
            }
                
            foreach(var btnEmpty in empytButtons)
            {
                OpenAdjacentEmptyTile(btnEmpty);
            }

            txtSkor.Text = points.ToString();
        }


        int mayin_tarlasi_bayrak = 30;

        int points = 0;
        private void BtnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                if(btn.Image == null)
                {
                    btn.Image = Properties.Resources.mayin_tarlasi_bayrak;
                    btn.Click -= BtnClick;
                    mayin_tarlasi_bayrak--;
                }
                else
                {
                    btn.Image = null;
                    btn.Click += BtnClick;
                    mayin_tarlasi_bayrak++;
                }
                flag.Text = mayin_tarlasi_bayrak.ToString();
            }
        }

        private void btnOyna_Click(object sender, EventArgs e)
        {
            points = 0;
            mayin_tarlasi_bayrak = 30;

            for(int x = 0; x<15;  x++)
            {
                for(int y = 0; y<15; y++)
                {
                    ButtonList[x,y].Dispose();
                }
            }
            pnlPanel.Controls.Clear();
            ButtonList = new Button[15,15];

            Positions =  new byte[15,15];
            pnlPanel.Enabled = true;

            GenerateBombs();
            GeneratePositionValue();
            GenerateButtons();
        }

    }
}
