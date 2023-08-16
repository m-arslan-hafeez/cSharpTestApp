using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace cSharpTestApp
{
    public partial class Form1 : Form
    {

        int user_key;
        string output_path;
        string fileName;
        string selectedFile;

        [DllImport("EncDecLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void encryptFile(string file_name, string address, int key, string output_file_path);
        [DllImport("EncDecLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void decryptFile(string file_path, string address, int key, string output_file_path);

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFile = openFileDialog.FileName;
                    fileName = Path.GetFileName(selectedFile);                     
                    textBoxFile.Text = fileName;
                    textBoxAddress.Text = selectedFile;

                }
            }
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            user_key = int.Parse(textBoxKey.Text);
            output_path = textBoxOutputPath.Text;
            //MessageBox.Show("File : " +fileName + " Address : " + selectedFile + " Key : " + user_key + " Output Path : " + output_path);
            decryptFile(fileName, selectedFile, user_key, output_path);

            MessageBox.Show("OKAY!");
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "All Files|*.*";
            //openFileDialog.Title = "Select File to Encrypt";
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string inputFile = openFileDialog.FileName;
            //    textBoxFile.Text = inputFile;
            //    string address = textBoxAddress.Text;
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.Filter = "Encrypted Files|*.enc";
            //    saveFileDialog.Title = "Save Encrypted File As";
            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string encryptedFile = saveFileDialog.FileName;
            //        int user_key = int.Parse(textBoxKey.Text);
            //        MessageBox.Show("File encrypted and saved successfully!");
            //    }
            //}
        }
    }
}
