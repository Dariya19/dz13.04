using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz13._04
{
    public partial class Form2 : Form
    {
        string ln;
        string fn;
        static string gr;
        double ex;
        double cw;

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string[] group = { "ПИэ21_21", "ПИэ20_20", "ПИэ19_19", "ПИэ18_18" };


            comboBox1.DataSource = group; // источник данных
            comboBox1.SelectedIndex = 0; // значение по умолчанию
                                         // действие при изменении comboBox1
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            exam.KeyPress += exam_KeyPress;
            coursework.KeyPress += exam_KeyPress;

            exam.TextChanged += mark_TextChanged;
            coursework.TextChanged += mark_TextChanged;


        }
        static void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            // значение переменной gr (группа) равна выбранному значению в comboBox
            gr = comboBox.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png";
            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openPicture.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
        private void exam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ввод в texBox только цифр и ','
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != ',')
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lastname.Text != String.Empty)
            {
                ln = lastname.Text;
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия");
                lastname.Focus();
                return;
            }
            if (firstname.Text != String.Empty)
            {
                fn = firstname.Text;
            }
            else
            {
                firstname.Focus();
                MessageBox.Show("Заполните поле Имя");
                return;
            }
            if (exam.Text != String.Empty)
            {
                ex = Convert.ToDouble(exam.Text.Replace(',', '.'));
            }
            else
            {
                exam.Focus();
                MessageBox.Show("Заполните поле Экзамен");
                return;
            }
            if (coursework.Text != String.Empty)
            {
                cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
            }
            else
            {
                coursework.Focus();
                MessageBox.Show("Заполните поле Курсовая работа");
                return;
            }
            // Создаем объект Student
            Student s = new Student(ln, fn, gr, ex, cw);

            // Выводим информацию
            MessageBox.Show(s.Info());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            double sred_ball = 0;
            // проверяем заполнено поле Экзамен
            if (exam.Text != String.Empty)
            {

                // если да, то берем из TextBox Экзамен значение и конвертируем в число

                ex = Convert.ToDouble(exam.Text.Replace(',', '.'));
            }
            else
            {
                // устанавливаем курсор в поле Экзамен
                exam.Focus();
                MessageBox.Show("Заполните поле Экзамен");
                // прерываем выполнение программы
                return;
            }
            // проверка для поля Курсовая работа аналогична
            if (coursework.Text != String.Empty)
            {

                cw = Convert.ToDouble(coursework.Text.Replace(',', '.'));
            }
            else
            {
                coursework.Focus();
                MessageBox.Show("Заполните поле Курсовая работа");
                return;
            }

            // Считаем средний балл
            sred_ball = (ex + cw) / 2;
            // Выводим в значение в TextBox с именем averageball
            averageball.Text = sred_ball.ToString();
        }
        // При изменении оценок (начинаем вводить новые) средний балл необходимо пересчитать
        private void mark_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            averageball.Text = "";
        }

        
    }
}

