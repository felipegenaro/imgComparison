using System;
using System.Windows.Forms;

namespace BiometricAuth
{
    public partial class Form2 : Form
    {
        public string loginValue { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            button8.Hide();
            textBox1.Hide();
            if (loginValue == "operador")
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Hide();
                button6.Hide();
            }

            if (loginValue == "diretor")
            {
                button5.Hide();
                button6.Hide();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideThings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideThings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideThings();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideThings();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideThings();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideThings();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Hide();
            textBox1.Hide();

            if (loginValue == "ministro")
            {
                showAll();
            }
            else
            {
                showCouple();
            }
        }

        private void hideThings()
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            textBox1.Show();
            button8.Show();
        }

        private void showAll()
        {
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button6.Show();
        }

        private void showCouple()
        {
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new Form1().Show();
        }
    }
}
