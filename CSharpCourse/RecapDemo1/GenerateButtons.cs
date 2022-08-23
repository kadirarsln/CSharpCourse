using System;
using System.Drawing;
using System.Windows.Forms;

namespace RecapDemo1
{
    public partial class GenerateButtons : Form
    {
        public GenerateButtons()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateButons();
        }

        private void GenerateButons()
        {
            Button[,] buttons = new Button[8, 8]; //buton ekleriz class şeklinde fazla ekleyebilmek ve düzen için Array kullanırız.

            int top = 0;
            int left = 0;
            for (int i = 0; i <= buttons.GetUpperBound(0); i++) //GetUpp yaparak 1. ve 2. indisleri seçerek max şekilde seçeriz.
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button(); //tekrar buttons olarak tanımlarız.
                    buttons[i, j].Width = 75; //Butonlarımıza style veririz.(css)
                    buttons[i, j].Height = 75;

                    buttons[i, j].Top = top;
                    buttons[i, j].Left = left; //Butonun soldan başlangıç değerini seçer ve ona atarız. Sıfırdan başlar.
                    left += 75; //Butonu her seferinde 75 kaydıracak şekilde 75 150 olarak arttırırz ki yan yana eklensin.

                    if ((i + j) % 2 == 1) // Koşul ile mod alarak tek ve çifte göre renk verdik. 
                    {
                        buttons[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;
                    }

                    this.Controls.Add(buttons[i, j]); //Eklenen butonu ekrana eklemek için kullanırız.
                }

                top += 75; //Aynı işlemi aşağı sıralamak iin de yaparız
                left = 0; //Burada ise ikinci satıra geçerken left=0 yaparız bu 7sayede 8 adet eklenir   
            }
        }
    }
}
