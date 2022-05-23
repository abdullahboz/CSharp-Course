using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 64 adet buton ile DAMA tahtası oluşturmak.
        private void Form1_Load(object sender, EventArgs e)
        {
          
            
        }
        private void GenerateButtons()
        {
            // button nesnesi oluşturuyoruz.
            Button[,] buttons = new Button[8, 8];
            int top = 0;
            int left = 0;
            // her biri için 8 li döngü yapacağız matris gibi.
            for (int i = 0; i < buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j < buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button(); // ilk buttton yeni bir buttondur. // her buttonu yeniden oluşturmak gerekir.
                    buttons[i, j].Width = 50; // classların özellikleri
                    buttons[i, j].Height = 50;
                    buttons[i, j].Left = left;
                    buttons[i, j].Top = top;
                    left += 50; // ilk döngüde sola doğru button oluştur.
                    if ((i + j) % 2 == 0) // i+j'nin modundan kalan 0 ise
                    {
                        buttons[i, j].BackColor = Color.Black;  // siyah olacak
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;  // değilse beyaz.
                    }

                    this.Controls.Add(buttons[i, j]); // buttonları ekle.
                }
                top += 50; // yukarıdan asağı için top'ı ekliyoruz.
                left = 0; // lefti sıfırlamamız gerekiyor.
                // ilk 8 için top 50 ikinci için top 50
            }
        }
    }
}
