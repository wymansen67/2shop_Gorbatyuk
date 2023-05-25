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
        int amountCola = 9000;
        int amountJuice = 9000;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(cola.GetInfo());
            listBox1.Items.Add(juice.GetInfo());
            pyaterochka.AddProduct(cola, 9000);
            pyaterochka.AddProduct(juice, 9000);
            pyaterochka.WriteAllProducts(listBox1);
            checkBox1.Checked = true;
            textBox1.Text = "5";
            textBox2.Text = "5";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                if (textBox1.Text != "" && int.Parse(textBox1.Text) > 0 && amountCola > int.Parse(textBox1.Text))
                {
                    pyaterochka.Sell("Кола", int.Parse(textBox1.Text));
                    label2.Text = $"{int.Parse(label2.Text) + (cola.Price * int.Parse(textBox1.Text))}";
                    amountCola -= int.Parse(textBox1.Text);
                    pyaterochka.WriteAllProducts(listBox1);
                }
            }
            else if (!checkBox1.Checked && checkBox2.Checked)
            {
                if (textBox2.Text != "" && int.Parse(textBox2.Text) > 0 && amountJuice > int.Parse(textBox2.Text))
                {
                    pyaterochka.Sell("Сок \"Добрый\"", int.Parse(textBox2.Text));
                    label2.Text = $"{int.Parse(label2.Text) + (juice.Price * int.Parse(textBox2.Text))}";
                    amountJuice -= int.Parse(textBox2.Text);
                    pyaterochka.WriteAllProducts(listBox1);
                }
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {

                if (textBox1.Text != "" && int.Parse(textBox1.Text) > 0)
                {
                    if (textBox2.Text != "" && int.Parse(textBox2.Text) > 0 && amountCola > int.Parse(textBox1.Text) && amountJuice > int.Parse(textBox2.Text))
                    pyaterochka.Sell("Кола", int.Parse(textBox1.Text));
                    pyaterochka.Sell("Сок \"Добрый\"", int.Parse(textBox2.Text));
                    label2.Text = $"{int.Parse(label2.Text) + (cola.Price * int.Parse(textBox1.Text) + juice.Price * int.Parse(textBox2.Text))}";
                    amountCola -= int.Parse(textBox1.Text);
                    amountJuice -= int.Parse(textBox2.Text);
                    pyaterochka.WriteAllProducts(listBox1);
                }
            }
        }
    }
}
