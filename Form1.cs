using System.Collections.Generic;
using System.Text;

namespace EncryptionAssignment
{
    public partial class Form1 : Form
    {
        public static Dictionary<char, int> abcEncode = new Dictionary<char, int>();
        public int dictionaryLength = 0;
        public Form1()
        {
            abcDictionary();
            dictionaryLength = abcEncode.Count;
            InitializeComponent();
        }
        public static void abcDictionary()
        {

            int i = 0;
            for (char c = 'a'; c <= 'z'; ++c)
            {
                abcEncode.Add(c, i++);
            }
            i = 0;
            for (char c = 'A'; c <= 'Z'; ++c)
            {
                abcEncode.Add(c, i++);
            }
            for (char c = '0'; c <= '9'; ++c)
            {
                abcEncode.Add(c, i++);
            }


        }

        public void EncryptVigenereDictionary(string plaintext, string key)
        {


            string ciphertext = "";
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Key cannot be empty");
                return;
            }
            plaintext.Trim();
            int keycounter = 0;
            int length = plaintext.Length;
            for (int i = 0; i < length; i++)
            {

                char cipherChar = plaintext[i];
                char keyChar = key[keycounter++ % key.Length];
                if (abcEncode.ContainsKey(cipherChar))
                {

                    abcEncode.TryGetValue(cipherChar, out int cipherValue);
                    abcEncode.TryGetValue(keyChar, out int keyValue);
                    int c1 = (cipherValue + keyValue) % 26;

                    char cipherEncoded = abcEncode.FirstOrDefault(x => x.Value == c1).Key;
                    ciphertext += cipherEncoded;
                }
                else
                {
                    keycounter--;
                    ciphertext += cipherChar;
                }
            }
            Output.Text = ciphertext;
        }
        public void EncryptVigenereASCII(string plaintext, string key)
        {

            string ciphertext = "";
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Key cannot be empty");
                return;
            }
            plaintext.Trim();
            int length = plaintext.Length;
            for (int i = 0; i < length; i++)
            {
                char c = plaintext[i];
                char k = key[i % key.Length];

                if ((int)c >= 32 && (int)c <= 127)
                {
                    ciphertext += (char)((c + k - 32) % 95 + 32);
                }
                else
                {
                    ciphertext += c;
                }
            }
            Output.Text = ciphertext;
        }
        public void DecryptVigenereDictionary(string ciphertext, string key)
        {

            string plaintext = "";
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Key cannot be empty");
                return;
            }
            if (ciphertext.Length == 0)
            {
                MessageBox.Show("Ciphertext cannot be empty");
                return;
            }
            ciphertext.Trim();
            int keycounter = 0;
            int length = ciphertext.Length;
            for (int i = 0; i < length; i++)
            {

                char cipherChar = ciphertext[i];
                char keyChar = key[keycounter++ % key.Length];
                if (abcEncode.ContainsKey(cipherChar))
                {
                    abcEncode.TryGetValue(cipherChar, out int cipherValue);
                    abcEncode.TryGetValue(keyChar, out int keyValue);
                    int c1 = (cipherValue - keyValue + 36) % 36;

                    char cipherEncoded = abcEncode.FirstOrDefault(x => x.Value == c1).Key;
                    plaintext += cipherEncoded;
                }
                else
                {
                    keycounter--;
                    plaintext += cipherChar;
                }
            }
            Output.Text = plaintext;
        }
        public void DecryptVigenereASCII(string ciphertext, string key)
        {
            string plaintext = "";
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Key cannot be empty");
                return;
            }
            if (ciphertext.Length == 0)
            {
                MessageBox.Show("Ciphertext cannot be empty");
                return;
            }
            ciphertext.Trim();
            int length = ciphertext.Length;
            for (int i = 0; i < length; i++)
            {
                int ascii = 0;
                char c = ciphertext[i];
                char k = key[i % key.Length];
                if ((int)c >= 32 && (int)c <= 127)
                {

                    int calc1 = (c - k);
                    int calc2 = (calc1 - 32);
                    int calc3 = (calc2 + 95);
                    int calc4 = (calc3 % 95);
                    int calc5 = (calc4 + 32);
                    ascii = calc5;

                    plaintext += (char)ascii;

                }
                else
                {
                    plaintext += c;
                }
            }
            Output.Text = plaintext;
        }
        private void EncryptButton_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    EncryptVigenereDictionary(Input.Text, Key.Text);
                    break;
                case 1:
                    EncryptVigenereASCII(Input.Text, Key.Text);
                    break;
            }

            
            
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    DecryptVigenereDictionary(Input.Text, Key.Text);
                    break;
                case 1:
                    DecryptVigenereASCII(Input.Text, Key.Text);
                    break;
            }
            

        }
    }
}