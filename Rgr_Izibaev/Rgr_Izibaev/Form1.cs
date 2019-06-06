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

namespace Rgr_Izibaev
{
    public partial class Form1 : Form
    {
        //Добавляем экземпляр класса Random, он нам понадобиться для получения слуйчаной буквы.
        Random random = new Random();
        Stats stats = new Stats();


        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true; //Делаем таймер активным
            timer.Enabled = true; //Делаем таймер активным
            timer.Tick += new EventHandler(Timer_tick);
            timer1.Start(); //Запускаем таймер 

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count > 10 || stats.TimerCounter < 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Игра окончена! Cчёт: " + stats.Total);

                timer1.Stop();
                timer.Stop();


            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if (timer1.Interval > 400)
                {
                    timer1.Interval -= 10;
                    stats.TimerCounter += 0.1;
                }

                if (timer1.Interval > 200)
                {
                    timer1.Interval -= 5;
                    stats.TimerCounter += 0.2;
                }
                if (timer1.Interval > 100)
                {
                    timer1.Interval -= 2;
                    stats.TimerCounter += 0.5;
                }
                if (difficultyProgressBar.Value < 800)
                {
                    difficultyProgressBar.Value = 800 - timer1.Interval;
                }
                stats.Update(true);
            }
            else
            {
                if (timer1.Interval < 750)
                {
                    timer1.Interval += 15;
                }
                stats.Update(false);
            }

            //correctLabel.Text = "Верно: " + stats.Correct;
            //missedLabel.Text = "Промахов: " + stats.Missed;

            accuracyLabel.Text = "Точность: " + stats.Correct + "/" + stats.Accuracy;
            stats.multiple += 0.5;

        }
        void Timer_tick(object sender, EventArgs e)
        {

            stats.Total += (int)stats.multiple;
            TimerLabel.Text = "Время:" + Math.Round((stats.TimerCounter -= 0.1), 2);
            totalLabel.Text = "Счёт: " + stats.Total;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void correctLabel_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
