using System;
using System.Windows.Forms;

namespace ImgChinelao
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
            if (loginValue == "operador")
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }

            if (loginValue == "diretor")
            {
                button5.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
