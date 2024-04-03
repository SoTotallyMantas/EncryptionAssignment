using EncryptionAssignment.EncryptionDecryption;
using EncryptionAssignment.Util;
using EncryptionAssignment.VigenereEncryptionDecryption;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

namespace EncryptionAssignment
{
    public partial class Form1 : Form
    {
        public string Selectedfile;
        public string Text;
        public BigInteger ModulusRSA;
        public BigInteger PrivateKey;
        VigenereEncryptionDecryptionClass vigenere = new VigenereEncryptionDecryptionClass();
        public Form1()
        {


            InitializeComponent();

            comboBox2.SelectedIndex = 0;
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {


            if (isencryptionpossible() == false)
            {
                return;
            }
            Output.Clear();
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
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a method");
                    return;
                }

                byte[] bitoutput;
                switch (comboBox1.SelectedIndex)
                {

                    case 0:

                        bitoutput = DES.EncryptDES(Input.Text, Key.Text, CipherMode.ECB);
                        OutputFormat(bitoutput);

                        break;
                    case 1:
                        bitoutput = DES.EncryptDES(Input.Text, Key.Text, CipherMode.CBC);
                        OutputFormat(bitoutput);


                        break;
                    case 2:
                        bitoutput = DES.EncryptDES(Input.Text, Key.Text, CipherMode.CFB);
                        OutputFormat(bitoutput);
                        break;
                }
                for (int i = 0; i < DES.ReturnableIV.Length - 1; i++)
                {
                    Output.Text += DES.ReturnableIV[i] + ",";
                }
                Output.Text += DES.ReturnableIV[DES.ReturnableIV.Length - 1];
            }
            if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "RSA")
            {
                RSAEncryptionDecryption RSA = new RSAEncryptionDecryption();

                byte[] data = RSA.EncryptRSA(XNumberInput.Text, YNumberInput.Text, Input.Text);
                PrivateKey = RSA.PrivateKey;
                string hexString = BitConverter.ToString(data).Replace("-", "");
                Output.Text = hexString;
                Output.Text = $"{hexString}.{RSA.Exponent}.{RSA.Modulus}";




            }



        }
        public void OutputFormat(byte[] encryptedbytes)
        {
            for (int i = 0; i < encryptedbytes.Length - 1; i++)
            {
                Output.Text += encryptedbytes[i] + ",";
            }
            Output.Text += encryptedbytes[encryptedbytes.Length - 1] + ".";

        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (isdecryptionpossible() == false)
            {
                return;
            }

            DESEncryptionDecryptionClass DES = new DESEncryptionDecryptionClass();

           
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

            if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "DES")
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a method");
                    return;
                }
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Output.Text = DES.DecryptDES(FormatDESEncryptedText(), Key.Text, FormatDESIV(), CipherMode.ECB);
                        break;
                    case 1:
                        Output.Text = DES.DecryptDES(FormatDESEncryptedText(), Key.Text, FormatDESIV(), CipherMode.CBC);
                        break;
                    case 2:
                        Output.Text = DES.DecryptDES(FormatDESEncryptedText(), Key.Text, FormatDESIV(), CipherMode.CFB);
                        break;
                }
            }
            if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "RSA")
            {
                RSAEncryptionDecryption RSA = new RSAEncryptionDecryption();

                string input = Input.Text;
                string[] encryptedmessage = input.Split('.');

                string hexString = encryptedmessage[0];
                string exponentString = encryptedmessage[1];
                string modulusString = encryptedmessage[2];

                BigInteger exponent = BigInteger.Parse(exponentString);
                BigInteger modulus = BigInteger.Parse(modulusString);
                ModulusRSA = modulus;
                byte[] encryptedData = Enumerable.Range(0, hexString.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                .ToArray();
                //string decryptedData = RSA.DecryptRSA(encryptedData, ModulusRSA, PrivateKey);
                string decryptedData = RSA.DecryptRSA(encryptedData, ModulusRSA, PrivateKey);
                Output.Text = decryptedData;

            }


        }
        public byte[] FormatDESIV()
        {
            try
            {
                byte[] iv = null;
                string[] ivs = Input.Text.Split('.');
                foreach (string s in ivs)
                {

                    iv = s.Split(',').Select(byte.Parse).ToArray();
                }
                return iv;
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public byte[] FormatDESEncryptedText()
        {

            byte[] result = null;
            int Length = 0;
            string Text = Input.Text;
            try
            {
                foreach (char c in Text)
                {
                    Length++;
                    if (c == '.')
                    {
                        Text = Text.Remove(Length - 1);
                        break;
                    }


                }

                result = Text.Split(',').Select(byte.Parse).ToArray();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private bool isencryptionpossible()
        {
            if (comboBox2.SelectedIndex != 2)
            {


                if (Input.Text == "" && Key.Text == "")
                {
                    MessageBox.Show("Please enter a key and a message");
                    return false;
                }
                if (Input.Text == "")
                {
                    MessageBox.Show("Please enter a message");
                    return false;
                }
                if (Key.Text == "")
                {
                    MessageBox.Show("Please enter a key");
                    return false;
                }
                if (Key.Text.Length != 8 && comboBox2.Items[comboBox2.SelectedIndex].ToString() == "DES")
                {
                    MessageBox.Show("Please enter a key of 8 characters");
                    return false;
                }
            }
            else
            {
                if (!RSAEncryptionDecryption.IsPrime(BigInteger.Parse(XNumberInput.Text)) || !RSAEncryptionDecryption.IsPrime(BigInteger.Parse(YNumberInput.Text)))
                {
                    Console.WriteLine("Both p and q must be prime numbers.");
                    return false;
                }
            }
            return true;
        }
        private bool isdecryptionpossible()
        {
            if (comboBox2.SelectedIndex != 2)
            {
                if (isencryptionpossible() == false)
                {
                    return false;
                }
                bool DESFormat = true;
                if (FormatDESEncryptedText() == null)
                {
                    DESFormat = false;
                }
                if (FormatDESIV() == null)
                {

                    DESFormat = false;
                }
                if (DESFormat == false)
                {
                    MessageBox.Show("Please enter a valid encrypted text");
                    return false;
                }
            }




            return true;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxCollections collections = new ComboboxCollections();
            if (comboBox2.SelectedIndex != 2)
            {
                comboBox1.Visible = true;
                keyGroupBox.Visible = true;
                RSAInpuGroupBox.Visible = false;
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
            else
            {

                comboBox1.Items.Clear();
                comboBox1.Visible = false;
                keyGroupBox.Visible = false;
                RSAInpuGroupBox.Visible = true;
            }
        }


        private void selectFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperations fileOperations = new FileOperations();

            Input.Text = fileOperations.readfromfile();
            Selectedfile = fileOperations.Selectedpath;
        }

        private void saveOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperations fileOperations = new FileOperations();
            fileOperations.savetofile(Output.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XNumberInput.Text = GeneratePrimeNumber.GeneratePrimeNumbers(32).ToString();
            YNumberInput.Text = GeneratePrimeNumber.GeneratePrimeNumbers(32).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SmallPrimeFactorization factorization = new SmallPrimeFactorization();
            List<BigInteger> values = factorization.Factorize(ModulusRSA);
            string Display = string.Join(Environment.NewLine, values.ToArray());
            MessageBox.Show("The prime factors of the modulus are: " + Display);
            XNumberInput.Text = $"{values[0]}";
            YNumberInput.Text = $"{values[1]}";

        }

        private void readRSAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperations fileOperations = new FileOperations();

            Input.Text = fileOperations.readfromfile();
            Selectedfile = fileOperations.Selectedpath;
            string input = Input.Text;
            string[] encryptedmessage = input.Split('.');

            string hexString = encryptedmessage[0];
            string exponentString = encryptedmessage[1];
            string modulusString = encryptedmessage[2];
            BigInteger exponent = BigInteger.Parse(exponentString);
            BigInteger modulus = BigInteger.Parse(modulusString);
            ModulusRSA = modulus;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RSAEncryptionDecryption RSA = new RSAEncryptionDecryption();
            RSA.calcprivate(XNumberInput.Text, YNumberInput.Text);
            MessageBox.Show("The private key has been calculated");
            PrivateKey = RSA.PrivateKey;
          
        }
    }
}