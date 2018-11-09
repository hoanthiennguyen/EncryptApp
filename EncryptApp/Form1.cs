using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptApp
{
    public partial class Form1 : Form
    {
        EncryptUtil util = new EncryptUtil();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                txtPath.Text = filePath;
            }
        }
        
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            util.filePath = txtPath.Text;
            util.password = txtPwd.Text;
            util.Encrypt();
            MessageBox.Show("Encrypted!");
        }
        
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            util.filePath = txtPath.Text;
            util.password = txtPwd.Text;
            util.Decrypt();
            MessageBox.Show("Decrypted!");
        }
    }
}
