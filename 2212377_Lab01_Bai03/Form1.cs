using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace _2212
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hostname = textBox1.Text;


            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                richTextBox1.Clear();

                richTextBox1.AppendText($"Tên miền: {hostname}\n");
                richTextBox1.AppendText("Địa chỉ IP:\n");

                foreach (IPAddress ip in hostEntry.AddressList)
                {
                    richTextBox1.AppendText($"{ip}\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText($"Lỗi: {ex.Message}");
            }
        }
    }
}
