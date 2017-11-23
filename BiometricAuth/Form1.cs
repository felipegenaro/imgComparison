using System;
using System.Drawing;
using System.Windows.Forms;

namespace BiometricAuth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string fnameI, fnameB1, fnameB2, fnameB3;
        Bitmap imgI, imgB1, imgB2, imgB3;
        int count1 = 0, count2 = 0, count3 = 0, countB1 = 0, countB2 = 0, countB3 = 0;
        bool flag1 = true, flag2 = true, flag3 = true;
        DB db;

        public string _login;

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new DB();
            openFileDialog1.FileName = "";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png";

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString() != "")
            {
                fnameI = openFileDialog1.FileName.ToString();
                var imagem1 = Image.FromFile(fnameI);
                pictureBox1.Image = imagem1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName.ToString() != "")
            {
                progressBar1.Visible = true;

                string imgI_ref, imgB1_ref, imgB2_ref, imgB3_ref;

                imgI = new Bitmap(fnameI);
                imgB1 = db.getBitmapFromTable("Images", "name='B1'","img");
                imgB2 = db.getBitmapFromTable("Images", "name='B2'", "img");
                imgB3 = db.getBitmapFromTable("Images", "name='B3'", "img");

                progressBar1.Maximum = 100;
                if (imgI.Width == imgB1.Width && imgI.Height == imgB1.Height)
                {
                    for (int i = 0; i < imgI.Width; i++)
                    {
                        for (int j = 0; j < imgI.Height; j++)
                        {
                            imgI_ref = imgI.GetPixel(i, j).ToString();
                            imgB1_ref = imgB1.GetPixel(i, j).ToString();
                            if (imgI_ref != imgB1_ref)
                            {
                                countB1++;
                                flag1 = false;
                                break;
                            }
                            count1++;
                        }
                        progressBar1.Value = 33;
                    }

                    for (int i = 0; i < imgI.Width; i++)
                    {
                        for (int j = 0; j < imgI.Height; j++)
                        {
                            imgI_ref = imgI.GetPixel(i, j).ToString();
                            imgB2_ref = imgB2.GetPixel(i, j).ToString();
                            if (imgI_ref != imgB2_ref)
                            {
                                countB2++;
                                flag2 = false;
                                break;
                            }
                            count2++;
                        }
                        progressBar1.Value = 66;
                    }

                    for (int i = 0; i < imgI.Width; i++)
                    {
                        for (int j = 0; j < imgI.Height; j++)
                        {
                            imgI_ref = imgI.GetPixel(i, j).ToString();
                            imgB3_ref = imgB3.GetPixel(i, j).ToString();
                            if (imgI_ref != imgB3_ref)
                            {
                                countB3++;
                                flag3 = false;
                                break;
                            }
                            count3++;
                        }
                        progressBar1.Value = 100;
                    }

                    int percentB1 = (imgI.Width * 60) / 100;
                    int percentB2 = (imgI.Width * 70) / 100;
                    int percentB3 = (imgI.Width * 85) / 100;

                    int match1 = imgI.Width - countB1;
                    int match2 = imgI.Width - countB2;
                    int match3 = imgI.Width - countB3;

                    if (match1 >= percentB1 && match1 < percentB2 || countB1 == 0 && flag1)
                    {
                        if (countB1 == 0) match1 = 100;
                        else match1 = (match1 * 100) / imgI.Width;
                        MessageBox.Show("Match " + match1 + "% \nBem vindo Operador !!");
                        _login = "operador";
                        resetCount();
                        open();
                    }

                    else if (match2 >= percentB2 && match2 < percentB3 || countB2 == 0 && flag2)
                    {
                        if (countB2 == 0) match2 = 100;
                        else match2 = (match2 * 100) / imgI.Width;
                        MessageBox.Show("Match " + match2 + "% \nBem vindo Diretor !!");
                        _login = "diretor";
                        resetCount();
                        open();
                    }

                    else if (match3 >= percentB3 || countB3 == 0 && flag3)
                    {
                        if (countB3 == 0) match3 = 100;
                        else match3 = (match3 * 100) / imgI.Width;
                        MessageBox.Show("Match " + match3 + "% \nBem vindo Ministro !!");
                        _login = "ministro";
                        resetCount();
                        open();
                    }

                    else if (flag1 == false && flag2 == false && flag3 == false || match1 <= 0 && match2 <= 0 && match3 <= 0)
                    {
                        MessageBox.Show("Usuario não consta na base de dados.");
                        progressBar1.Value = 0;
                        flags();
                        resetCount();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel comparar estas imagens.");
                    return;
                }

            }
            else{
                MessageBox.Show("Selecione uma Imagem Antes !!");
            }
                
        }

        private void resetCount()
        {
            progressBar1.Value = 0;
            count1 = 0;
            count2 = 0;
            count3 = 0;
            countB1 = 0;
            countB2 = 0;
            countB3 = 0;
        }

        private void flags()
        {
            flag1 = true;
            flag2 = true;
            flag3 = true;
        }

        private void open()
        {
            Form2 settingsForm = new Form2()
            {
                loginValue = this._login
            };
            settingsForm.Show();
            this.Hide();
        }
     
    }
}
