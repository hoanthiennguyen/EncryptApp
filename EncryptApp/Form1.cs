using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EncryptApp
{
    public partial class Form1 : Form
    {
        EncryptUtil util = new EncryptUtil();
        string regex = "^[!-z]+$";
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
        private bool checkValidPassword(string password)
        {
            Match match = Regex.Match(password, regex);
            return match.Success;
        }
        private bool validateAllFields()
        {
            error.Visible = true;
            if (txtPath.Text == "")
            {
                error.Text = "File is required!";
                return false;
            }
            else if (txtPwd.Text == "")
            {
                error.Text = "Password is required!";
                return false;
            }
            else if (!checkValidPassword(txtPwd.Text))
            {
                error.Text = "Password can't have unicode characters!";
                return false;
            }
            else if (txtConfirmPassword.Text != txtPwd.Text)
            {
                error.Text = "Two password fields don't match!";
                return false;
            }
            else
            {
                error.Visible = false;
                util.filePath = txtPath.Text;
                util.password = txtPwd.Text;
                return true;
            }

        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (validateAllFields())
            {
                util.Encrypt();
                MessageBox.Show("Encrypted!");
            }
        }
        
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if(validateAllFields())
            {
                util.Decrypt();
                MessageBox.Show("Decrypted!");
            }
        }
    }
}
