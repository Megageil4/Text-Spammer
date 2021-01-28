using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput.Native;
using WindowsInput;
using System.Timers;
using System.Threading;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        // <Initialize Component>
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Text");
            comboBox1.Items.Add("Random");
            comboBox1.Items.Add("nHentai");
            comboBox2.Items.Add("Sekunden");
            comboBox2.Items.Add("Mal");
            textInvisible();
            randomInvisible();
            nHentaiInvisible();
        }
        // </Initialize Component>

        // <Vorgegebenen Text Spammer>
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled)
            {
                System.Threading.Thread.Sleep(Convert.ToInt32(textBox3.Text) * 1000);
                InputSimulator Simulator = new InputSimulator();
                string textData = textBox1.Text;
                Clipboard.SetData(DataFormats.Text, (Object)textData);
                progressBar1.Maximum = Convert.ToInt32(textBox2.Text);
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                {

                Simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, new[] {
                VirtualKeyCode.VK_V
                 });
                Simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                progressBar1.PerformStep();
                }

            }
        }
        // </Vorgegebenen Text Spammer>

        // <Wechsel zwischen Menüs>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Text")
            {
                textVisible();
                randomInvisible();
                nHentaiInvisible();
            }
            else if (comboBox1.Text == "Random")
            {
                textInvisible();
                randomVisible();
                nHentaiInvisible();
            }
            else if (comboBox1.Text == "nHentai")
            {
                textInvisible();
                randomInvisible();
                nHentaiVisible();
            }
            else
            {
                textInvisible();
                randomInvisible();
            }
        }
        // </Wechsel zwischen Menüs>

        // <Mehr Menü wechsel>
        public void textInvisible()
        {
            bool a = false;
            textBox1.Visible = a;
            textBox2.Visible = a;
            textBox3.Visible = a;
            label1.Visible = a;
            label2.Visible = a;
            button1.Visible = a;
            progressBar1.Visible = a;
        }
        public void textVisible()
        {
            bool a = true;
            textBox1.Visible = a;
            textBox2.Visible = a;
            textBox3.Visible = a;
            label1.Visible = a;
            label2.Visible = a;
            button1.Visible = a;
            progressBar1.Visible = a;
        }

        public void randomInvisible()
        {
            bool a = false;
            textBox4.Visible = a;
            button2.Visible = a;
            label4.Visible = a;
            textBox5.Visible = a;
            progressBar2.Visible = a;
            comboBox2.Visible = a;
        }
        public void randomVisible()
        {
            bool a = true;
            textBox4.Visible = a;
            label4.Visible = a;
            textBox5.Visible = a;
            button2.Visible = a;
            progressBar2.Visible = a;
            comboBox2.Visible = a;
        }
        public void nHentaiVisible()
        {
            bool a = true;
            textBox6.Visible = a;
            textBox7.Visible = a;
            label5.Visible = a;
            label6.Visible = a;
            button3.Visible = a;
            progressBar3.Visible = a;
        }
        public void nHentaiInvisible()
        {
            bool a = false;
            textBox6.Visible = a;
            textBox7.Visible = a;
            label5.Visible = a;
            label6.Visible = a;
            button3.Visible = a;
            progressBar3.Visible = a;
        }
        // </Mehr Menü wechsel>

        // <Random Text Spammer>
        private void button2_Click(object sender, EventArgs e)
        {
            //<Sekunden>
            if (comboBox2.Text == "Sekunden")
            {

                System.Threading.Thread.Sleep(Convert.ToInt32(textBox5.Text) * 1000);
                DateTime dtEnd = DateTime.Now.AddSeconds(Convert.ToInt32(textBox4.Text) / 2);
                progressBar2.Maximum = Convert.ToInt32(textBox4.Text) * 63;
                progressBar2.Step = 1;
                progressBar2.Value = 0;
                while (DateTime.Now < dtEnd)
                {
                    int RandomKey = RandomNumber(1, 28);
                    pressRandomKey(RandomKey);
                    progressBar2.PerformStep();
                }
                while (progressBar2.Value != progressBar2.Maximum)
                {
                    progressBar2.PerformStep();
                }
            }
            //</Sekunden>

            //<Anzahl>
            if (comboBox2.Text == "Mal")
            {
                System.Threading.Thread.Sleep(Convert.ToInt32(textBox5.Text) * 1000);
                progressBar2.Maximum = Convert.ToInt32(textBox4.Text);
                progressBar2.Step = 1;
                progressBar2.Value = 0;
                for (int i = 0; i < Convert.ToInt32(textBox4.Text); i++)
                {
                    int RandomKey = RandomNumber(1,28);
                    pressRandomKey(RandomKey);
                    progressBar2.PerformStep();
                }
            }
            //</Anzahl>
        }
        // </Random Text Spammer>
         
        // <Random nHentai Seite>
        private void button3_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(textBox7.Text) * 1000);
            InputSimulator Simulator = new InputSimulator();
            Clipboard.SetData(DataFormats.Text, (Object)"https://nhentai.net/g/");
            progressBar3.Maximum = Convert.ToInt32(textBox6.Text);
            progressBar3.Step = 1;
            progressBar3.Value = 0;
            for (int i = 0; i < Convert.ToInt32(textBox6.Text); i++)
            {
                Simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, new[] {
                VirtualKeyCode.VK_V
                 });
                Simulator.Keyboard.TextEntry(Convert.ToString(RandomNumber(1,50000)));
                Simulator.Keyboard.KeyPress(VirtualKeyCode.DIVIDE);
                Simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                progressBar3.PerformStep();
            }

        }
        // </Random nHentai Seite>

        // <"Random" Number Generator>
        private readonly Random _random = new Random();
     
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        // </"Random" Number Generator>

        //<Random Key codes>
        public void pressRandomKey(int RandomKey)
        {
            InputSimulator Simulator = new InputSimulator();
            switch (RandomKey)
            {
                case 1:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                    break;
                case 2:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_B);
                    break;
                case 3:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_C);
                    break;
                case 4:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_D);
                    break;
                case 5:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_E);
                    break;
                case 6:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_F);
                    break;
                case 7:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_G);
                    break;
                case 8:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_H);
                    break;
                case 9:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_I);
                    break;
                case 10:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_J);
                    break;
                case 11:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_K);
                    break;
                case 12:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_L);
                    break;
                case 13:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_M);
                    break;
                case 14:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_N);
                    break;
                case 15:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_O);
                    break;
                case 16:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_P);
                    break;
                case 17:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_Q);
                    break;
                case 18:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_R);
                    break;
                case 19:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_S);
                    break;
                case 20:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_T);
                    break;
                case 21:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_U);
                    break;
                case 22:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_V);
                    break;
                case 23:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_W);
                    break;
                case 24:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_X);
                    break;
                case 25:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_Y);
                    break;
                case 26:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_Z);
                    break;
                case 27:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                    break;
                case 28:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.SPACE);
                    break;
                default:
                    break;
            }
        }
        public void pressRandomNumber(int RndNummber)
        {
            InputSimulator Simulator = new InputSimulator();
            switch (RndNummber)
            {
                case 0:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_0);
                    break;
                case 1:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_1);
                    break;
                case 2:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_2);
                    break;
                case 3:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_3);
                    break;
                case 4:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_4);
                    break;
                case 5:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_5);
                    break;
                case 6:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_6);
                    break;
                case 7:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_7);
                    break;
                case 8:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_8);
                    break;
                case 9:
                    Simulator.Keyboard.KeyPress(VirtualKeyCode.VK_9);
                    break;
                default:
                    break;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        //</Random Key codes>
    }
}
