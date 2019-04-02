using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime data = e.Start;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                
                string val = comboBox1.Text;
                string srk = comboBox4.Text;
                string stav = comboBox3.Text;
                string komis = comboBox2.Text;
                string vid = comboBox5.Text;
                string data = dateTimePicker1.Text;






                double srok = 0;
                double sum = Convert.ToDouble(numericUpDown1.Text);
                double komiss = 0;

                if (srk == "месяц")
                {
                    srok = Convert.ToDouble(numericUpDown4.Text);
                }
                else if (srk == "год")
                {
                    srok = Convert.ToDouble(numericUpDown4.Text) * 12;
                }

                if (komis == "не учитывается")
                {
                    komiss = 0;
                }
                else { komiss = (Convert.ToDouble(numericUpDown2.Text) / 100); }

                double stavka = Convert.ToDouble(numericUpDown3.Text);

                double pay = 0;
                double paymonth = 0;
                double fullpay = 0;
                double pr = (stavka / (12 * 100));
                double ostatok = sum;
                double ss = 0;
                double fullpaysum = 0;
                double obsum = 0;
                double obproz = 0;
                double itog = 0;

                int day = dateTimePicker1.Value.Day;
                int month = dateTimePicker1.Value.Month;
                int year = dateTimePicker1.Value.Year;








                dataGridView1.RowCount = Convert.ToInt32(srok);

                for (int i = 0; i < srok; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;

                    dataGridView1.Rows[i].Cells[1].Value = day + "." + month + "." + year;
                    month++;
                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }

                    if (vid == "дифференцированный")
                    {
                        ss = ss + fullpay;
                        if ((i + 1) == 1) { paymonth = (sum * pr); }
                        else { paymonth = ((sum - ss) * pr); }
                        fullpay = (sum / srok);
                        pay = (paymonth + fullpay);
                        ostatok = (ostatok - fullpay);
                        obsum += pay;
                        obproz += paymonth;
                        itog = obsum * komiss + obproz;

                    }
                    else if (vid == "аннуитетный")
                    {
                        ss = +pay;
                        /*

                        if ((i + 1) == 1) { paymonth = (sum * pr); }
                        else { paymonth = ((sum - ss) * pr); }
                        pay = (((pr * Math.Pow((1 + pr), srok)) / (Math.Pow((1 + pr), srok) - 1)) * sum); 

                        */
                        paymonth = ostatok * pr;
                        pay = sum * (pr + pr / (Math.Pow((1 + pr), srok) - 1));
                        fullpay = (pay - paymonth);
                        fullpaysum = +fullpay;
                        ostatok = (ostatok - fullpay);
                        obsum = +pay;
                        obproz = +paymonth;
                        itog = obsum * komiss + obproz;

                    }
                    label6.AutoSize = true;
                    label2.AutoSize = true;
                    label3.AutoSize = true;
                    label6.Text = "Общая сумма платежей:";
                    label2.Text = "Переплата по процентам за кредит:";
                    label3.Text = "Итоговая переплата с учетом комиссии: ";
                    label7.Text = Convert.ToString(Math.Round(obsum, 2)) + " " + val;
                    label4.Text = Convert.ToString(Math.Round(obproz, 2)) + " " + val;
                    label5.Text = Convert.ToString(Math.Round(itog, 2)) + " " + val;

                    dataGridView1.Rows[i].Cells[2].Value = Math.Round(pay, 2) + " " + val;
                    dataGridView1.Rows[i].Cells[3].Value = Math.Round(fullpay, 2) + " " + val;
                    dataGridView1.Rows[i].Cells[4].Value = Math.Round(paymonth, 2) + " " + val;
                    dataGridView1.Rows[i].Cells[5].Value = Math.Round(ostatok, 2) + " " + val;

                    button3.Visible = true;
                    button2.Visible = true;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    numericUpDown1.Visible = false;
                    numericUpDown2.Visible = false;
                    numericUpDown3.Visible = false;
                    numericUpDown4.Visible = false;
                    dateTimePicker1.Visible = false;

                    dataGridView1.Visible = true;
                    label14.Visible = true;
                    label14.Text = vid;
                    label1.Text = "Вид платежа: ";
                }

                
            }
            catch
            {
                MessageBox.Show("Возникла ошибка.Проверьте введенные вами данные");

                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Visible = true;
                dateTimePicker1.Visible = true;
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false; 

                label14.Visible = false;
                dataGridView1.Visible = false;
                label1.Text = "Параметры кредита";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|CSV-файл (*.csv)|*.csv|Bin-файл (*.bin)|*.bin|Bitmap files (*.bmp)|*.bmp|Image files (*.jpg)|*.jpg";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWritet = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount-1 ; i++)
                        {
                            var first = true;
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                if (!first) myWritet.Write(";");
                                myWritet.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                                first = false;

                            }
                            myWritet.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        MessageBox.Show("Таблица успешно сохранена");
                        myWritet.Close();
                    }
                    myStream.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown2.Visible = true;
            numericUpDown3.Visible = true;
            numericUpDown4.Visible = true;
            dateTimePicker1.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            label6.Text = "Вид платежа:";
            label2.Text = "Сумма кредита:";
            label3.Text = "Срок кредита:";
            label7.Text = "Начало выплат:";
            label4.Text = "Процентная ставка: ";
            label5.Text = "Единовременная комиссия:";

            label14.Visible = false;
            dataGridView1.Visible = false;
            label1.Text = "Параметры кредита";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть калькулятор?", Application.ProductName, MessageBoxButtons.YesNo) != DialogResult.No)
                Application.Exit();
        }
    }
}
