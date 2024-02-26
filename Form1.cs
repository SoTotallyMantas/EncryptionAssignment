using EncryptionAssignment.Util;
using EncryptionAssignment.VigenereEncryptionDecryption;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionAssignment
{
    public partial class Form1 : Form
    {
        public string Selectedfile;
        public string Text;
        VigenereEncryptionDecryptionClass vigenere = new VigenereEncryptionDecryptionClass();
        public Form1()
        {


            InitializeComponent();
           
            comboBox2.SelectedIndex = 0;
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            FileOperations fileOperations = new FileOperations();
           
            if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "Vigenere")
            {

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Output.Text = vigenere.EncryptVigenereDictionary(Input.Text, Key.Text);
                        break;
                    case 1:
                        Output.Text = vigenere.EncryptVigenereASCII(Input.Text, Key.Text);
                        break;
                    case 2:
                        Output.Text = vigenere.EncryptVigenereArray(Input.Text, Key.Text);
                        break;
                }
            }
            DESEncryptionDecryptionClass DES = new DESEncryptionDecryptionClass();
            
            if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "DES")
            {
                if(Selectedfile==null)
                {
                    CallFileOperations();
                    return; 
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                         DES.EncryptDES(Input.Text,Selectedfile, Key.Text, CipherMode.ECB);
                        Output.Text = fileOperations.readfile(Selectedfile);
                        break;
                    case 1:
                        DES.EncryptDES(Input.Text, Selectedfile, Key.Text, CipherMode.CBC);
                        Output.Text = fileOperations.readfile(Selectedfile);
                        break;
                    case 2:
                        DES.EncryptDES(Input.Text, Selectedfile, Key.Text, CipherMode.CFB);
                        Output.Text = fileOperations.readfile(Selectedfile);
                        break;
                }
            }



        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "Vigenere Dictionary")
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Output.Text = vigenere.DecryptVigenereDictionary(Input.Text, Key.Text);
                        break;
                    case 1:
                        Output.Text = vigenere.DecryptVigenereASCII(Input.Text, Key.Text);
                        break;
                    case 2:
                        Output.Text = vigenere.DecryptVigenereArray(Input.Text, Key.Text);
                        break;

                }
            }
            //if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "DES")
            //{
            //    switch(comboBox1.SelectedIndex)
            //    {
            //        case 0:
            //            Output.Text = DES.Dencrypt(Input.Text, Key.Text, DESMode.ECB);
            //            break;
            //        case 1:
            //            Output.Text = DES.Dencrypt(Input.Text, Key.Text, DESMode.CBC);
            //            break;
            //        case 2:
            //            Output.Text = DES.Dencrypt(Input.Text, Key.Text, DESMode.CFB);
            //            break;
            //    }
            //}


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxCollections collections = new ComboboxCollections();

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(collections.VigenereMethods);
                    break;
                case 1:

                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(collections.DESMethods);
                    break;

            }
        }
        private void CallFileOperations()
        {
            FileOperations fileOperations = new FileOperations();
           
            Text = fileOperations.openfiledialog();
            Selectedfile = fileOperations.Selectedpath;
        }

        private void selectFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallFileOperations();
        }
    }
}