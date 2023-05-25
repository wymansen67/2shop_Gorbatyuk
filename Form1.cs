using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Shop pyaterochka = new Shop();
        Product cola = new Product("Кола", 85);
        Product juice = new Product("Сок \"Добрый\"", 100);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(cola.GetInfo());
            listBox1.Items.Add(juice.GetInfo());
            pyaterochka.AddProduct(cola, 9000);
            pyaterochka.AddProduct(juice, 128312);
            pyaterochka.WriteAllProducts(listBox1);
            checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                pyaterochka.Sell("Кола", 5);
                label2.Text = $"{int.Parse(label2.Text) + (cola.Price * 5)}";
                pyaterochka.WriteAllProducts(listBox1);
            }
            else if (!checkBox1.Checked && checkBox2.Checked)
            {
                pyaterochka.Sell("Сок \"Добрый\"", 5);
                label2.Text = $"{int.Parse(label2.Text) + (juice.Price * 5)}";
                pyaterochka.WriteAllProducts(listBox1);
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {

                pyaterochka.Sell("Кола", 5);
                pyaterochka.Sell("Сок \"Добрый\"", 5);
                label2.Text = $"{int.Parse(label2.Text) + (cola.Price * 5 + juice.Price * 5)}";
                pyaterochka.WriteAllProducts(listBox1);

            }
        }
    }
}
