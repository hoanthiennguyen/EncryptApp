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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFile.FileName;
                txtPath.Text = filePath;
                //Read the contents of the file into a stream
                //var fileStream = openFile.OpenFile();

                //using (StreamReader reader = new StreamReader(fileStream))
                //{
                //    string fileContent = reader.ReadToEnd();
                //}

            }
            
        }
        void Decrypt(string filePath, byte[] password)
        {

            byte[] content = File.ReadAllBytes(filePath);

            for (int i = 0; i < content.Length; i++)
            {
                int indexInPwd = i % password.Length;
                int sum = (content[i] - password[indexInPwd]) % 256;
                content[i] = (byte)sum;
            }
            File.WriteAllBytes(filePath, content);
        }
        void Encrypt(string filePath, byte[] password)
        {

            byte[] content = File.ReadAllBytes(filePath);
            for (int i = 0; i < content.Length; i++)
            {
                int indexInPwd = i % password.Length;
                int sum = (content[i] + password[indexInPwd]) % 256;
                content[i] = (byte)sum;
            }
            File.WriteAllBytes(filePath, content);
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string pwdText = txtPwd.Text;
            byte[] password = getBytesFromPassword(pwdText);
            string file = txtPath.Text;
            Encrypt(file, password);
            MessageBox.Show("Encrypted!");
        }
        private byte[] getBytesFromPassword(string password)
        {
            byte[] result = new byte[password.Length];
            for(int i = 0; i < password.Length; i++)
            {
                result[i] = (byte)password[i];
            }
            return result;
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string pwdText = txtPwd.Text;
            byte[] password = getBytesFromPassword(pwdText);
            string file = txtPath.Text;
            Decrypt(file, password);
            MessageBox.Show("Decrypted!");
        }
    }
}
