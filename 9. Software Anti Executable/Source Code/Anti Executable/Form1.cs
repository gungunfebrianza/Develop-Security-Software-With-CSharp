using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace Anti_Executable
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        // menampilkan tanggal dan jam pada komputer
        DateTime currentDay = DateTime.Now;
        public int seconds; // Seconds.
        public int minutes; // Minutes.
        public int hours;   // Hours.
        public bool p; // State of the timer
        Form2 aboutform = new Form2();


        private void Form1_Load(object sender, EventArgs e)
        {

            //mengubah warna text pada listbox saat runtime
            listBox1.ForeColor = System.Drawing.Color.Red;

            try
            {
                //memuat logs history logs history,
                string[] items = File.ReadAllLines(@"C:\\Windows\System32\drivers\etc\\logs.indo");
                listBox1.Items.Clear(); // if necessary
                listBox1.Items.AddRange(items);
                listBox1.SelectedIndex = 0;
            }

            catch (System.Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                //button start anti exe
                //subkey exe in class root
                string exe = ".exe";
                RegistryKey rKey1 = Registry.ClassesRoot.OpenSubKey(exe, true);

                //mengubah default value menjadi 0
                rKey1.SetValue("", "0");
                rKey1.Close();

                //subkey exefile in class root
                string exefile = "exefile";
                RegistryKey rKey2 = Registry.ClassesRoot.OpenSubKey(exefile, true);

                //mengubah default value menjadi 0
                rKey2.SetValue("", "0");
                rKey2.Close();

                //subkey exefile\\shell\\open in class root
                string exefileopen = "exefile\\shell\\open";
                RegistryKey rKey3 = Registry.ClassesRoot.OpenSubKey(exefileopen, true);

                //mengubah default value menjadi 0
                rKey3.SetValue("", "0");
                rKey3.Close();

                //menambahkan informasi perubahan pada logs history
                listBox1.Items.Add("Executable has been deadactived at ");
               
                //menampilkan tanggal perubahan
                listBox1.Items.Add(currentDay);
                listBox1.Items.Add("");

                //tampilkan kotak pesan
                MessageBox.Show("Success Executable Has Been Deadactived", "Anti Executable", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            }
            catch 
            {
            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                //button stop anti exe
                //subkey exe in class root
                string exe = ".exe";
                RegistryKey rKey1 = Registry.ClassesRoot.OpenSubKey(exe, true);

                //mengembalikan default value menjadi value seperti semula
                rKey1.SetValue("", "exefile");
                rKey1.Close();

                //subkey exefile in class root
                string exefile = "exefile";
                RegistryKey rKey2 = Registry.ClassesRoot.OpenSubKey(exefile, true);

                //mengembalikan default value menjadi value seperti semula
                rKey2.SetValue("", "Application");
                rKey2.Close();

                //subkey exefile\\shell\\open in class root
                string exefileopen = "exefile\\shell\\open";
                RegistryKey rKey3 = Registry.ClassesRoot.OpenSubKey(exefileopen, true);

                //mengembalikan default value menjadi value seperti semula
                rKey3.SetValue("", "");
                rKey3.Close();

                //menambahkan informasi perubahan pada logs history
                listBox1.Items.Add("Executable has been actived at ");
                
                //menampilkan tanggal perubahan
                listBox1.Items.Add(currentDay);
                listBox1.Items.Add("");

                //tampilkan kotak pesan
                MessageBox.Show("Success Executable Has Been Actived", "Anti Executable", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            }
            catch
            {
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //button start anti exe using timer mode
            if (p != true)
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    timer1.Enabled = true;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;

                    try
                    {
                        //konversi string pada textbox 1, 2 dan 3 ke 32 bit integer
                        minutes = System.Convert.ToInt32(textBox2.Text);
                        seconds = System.Convert.ToInt32(textBox3.Text);
                        hours = System.Convert.ToInt32(textBox1.Text);
                    }
                    catch 
                    {
                      
                    }
                }
                else
                {
                    //tampilkan kotak pesan
                    MessageBox.Show("Incomplete settings!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                timer1.Enabled = true;
                p = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if ((minutes == 0) && (hours == 0) && (seconds == 0))
            {

                //jika waktu telah habis
                timer1.Enabled = false;

                //tampilkan kotak pesan dan teks pada textbox 4
                MessageBox.Show(textBox4.Text,"Anti Executable",MessageBoxButtons.OK , MessageBoxIcon.Information);

                try
                {
                    //button start anti exe
                    //subkey exe in class root
                    string exe = ".exe";
                    RegistryKey rKey1 = Registry.ClassesRoot.OpenSubKey(exe, true);

                    //mengubah default value menjadi 0
                    rKey1.SetValue("", "0");
                    rKey1.Close();

                    //subkey exefile in class root
                    string exefile = "exefile";
                    RegistryKey rKey2 = Registry.ClassesRoot.OpenSubKey(exefile, true);

                    //mengubah default value menjadi 0
                    rKey2.SetValue("", "0");
                    rKey2.Close();

                    //subkey exefile\\shell\\open in class root
                    string exefileopen = "exefile\\shell\\open";
                    RegistryKey rKey3 = Registry.ClassesRoot.OpenSubKey(exefileopen, true);

                    //mengubah default value menjadi 0
                    rKey3.SetValue("", "0");
                    rKey3.Close();

                    //menambahkan informasi perubahan pada listbox dikolom logs history
                    listBox1.Items.Add("Executable has been deadactived at ");
                   
                    //menampilkan waktu perubahan informasi
                    listBox1.Items.Add(currentDay);
                    listBox1.Items.Add("");

//jika melakukan blok menggunakan timer mode pesan tidak ditampilkan untuk mengantisipasi user mengetahuinya
                    //MessageBox.Show("Success Executable Has Been Deadactived", "Anti Executable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                }

                //bersihkan
                textBox4.Clear();
                textBox3.Clear();
                textBox2.Clear();

                //mengaktifkan fungsi textbox1 sampai 4
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Enabled = true;

                //text pada label6,8 dan 10
                label6.Text = "00";
                label8.Text = "00";
                label10.Text = "00";
            }
            else
            {
                // teruskan menghitung
                if (seconds < 1)
                {
                    seconds = 59;
                    if (minutes == 0)
                    {
                        minutes = 59;
                        if (hours != 0)
                            hours -= 1;

                    }
                    else
                    {
                        minutes -= 1;
                    }
                }
                else
                    seconds -= 1;
             
                // menampilkan value dari hours,minute dan string.
                label6.Text = hours.ToString();
                label8.Text = minutes.ToString();
                label10.Text = seconds.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //menyimpan informasi logs history 
                System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\\Windows\System32\drivers\etc\\logs.indo");
                foreach (object item in listBox1.Items)
                    sw.WriteLine(item.ToString());
                sw.Close();
            }

            catch (System.Exception)
            {

            }


        }

        private void setTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //enable to set time
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //keluar dari aplikasi
            Application.Exit();

        }

        private void startAntiExeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button start anti exe
            button1.PerformClick();

        }

        private void stopAntiExeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button stop anti exe
            button2.PerformClick();

        }

        private void startAntiExeTimerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //mengeksekusi button start anti exe timer mode
            button3.PerformClick();

        }

        private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //membersihkan listbox pada logs history
            listBox1.Items.Clear();

        }

        private void hideInTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //menyembunyikan form1 dittray icon
            this.Visible = false;

            //judl pada notif
            notifyIcon1.BalloonTipTitle = "Anti Executable";

            //pesan pada notif
            notifyIcon1.BalloonTipText = "Anti Executable Hide In Tray Icon";
            
            //menampilkan notif dalam waktu 2 detik
            notifyIcon1.ShowBalloonTip(2);

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //menampilkan form1 
            this.Visible = true;

        }


        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //keluar dari aplikasi
            Application.Exit();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //menampilkan aboutform
            aboutform.ShowDialog();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //menampilkan form1 
            this.Visible = true;

        }


    }
}
