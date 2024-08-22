using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;

namespace _2212377_Lab01_Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            // Duyệt qua từng adapter
            foreach (NetworkInterface adapter in adapters)
            {
                // Kiểm tra xem adapter có đang hoạt động không
                if (adapter.OperationalStatus == OperationalStatus.Up)
                {
                    // Lấy các địa chỉ IP của adapter
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    UnicastIPAddressInformationCollection addresses = properties.UnicastAddresses;

                    // Hiển thị thông tin về adapter
                    richTextBox1.AppendText($"Adapter: {adapter.Name}\n");

                    // Duyệt qua từng địa chỉ IP
                    foreach (UnicastIPAddressInformation address in addresses)
                    {
                        richTextBox1.AppendText($"  - Địa chỉ IP: {address.Address}\n");
                        richTextBox1.AppendText($"  - Subnet mask: {address.IPv4Mask}\n");

                        // Tìm default gateway
                        GatewayIPAddressInformationCollection gateways = properties.GatewayAddresses;
                        if (gateways.Count > 0)
                        {
                            richTextBox1.AppendText($"  - Default gateway: {gateways[0].Address}\n");
                        }
                    }

                    richTextBox1.AppendText("\n");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
