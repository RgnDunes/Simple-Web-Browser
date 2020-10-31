using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Divyansh Singh");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
            //textBox2.Text = "";
            comboBox1.Items.Add(textBox1.Text);
            //Form2 f2 = new Form2();
            //f2.listView1.Items.Add(textBox1.Text);
            //string Url_History = textBox1.Text;
        }

        private void NavigateToPage()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            webBrowser1.Navigate(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
                comboBox1.Items.Add(textBox1.Text);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if(e.CurrentProgress>0 && e.MaximumProgress>0 && e.CurrentProgress<=e.MaximumProgress)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // webBrowser1.Navigate(textBox2.Text);
           // textBox1.Text = "http://" + textBox2.Text;
            comboBox1.Items.Add(textBox1.Text);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = webBrowser1.Url.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(comboBox1.Text);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //string Url_History = textBox1.Text;
            //Form2 f2 = new Form2();
            //f2.Show();
        }
    }
}
