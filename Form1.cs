using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptionAssignment
{
    public partial class Form1 : Form
    {
        public static Dictionary<char, int> abcEncode = new Dictionary<char, int>();
        public static char[] abcArray = new char[36];
        public int dictionaryLength = 0;
        public Form1()
        {
            abcDictionary();
            abcArrayCreate();
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
        public static void abcArrayCreate()
        {

            int i = 0;
            for (char c = 'a'; c <= 'z'; ++c)
            {
                abcArray[i++] = c;
            }
            for (char c = '0'; c <= '9'; ++c)
            {
                abcArray[i++] = c;
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
                    int c1 = (cipherValue + keyValue) % 36;

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
        public void EncryptVigenereArray(string plaintext, string key)
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
            plaintext = plaintext.ToLower();
             key = key.ToLower();
            for (int i = 0; i < length; i++)
            {

                int keyIndex = 0;
                int CipherIndex = 0;
                char cipherChar = plaintext[i];
                char keyChar = key[keycounter++ % key.Length];

                if (abcArray.Contains(cipherChar))
                {
                    for (int j = 0; j < 35; j++)
                    {
                        if (keyChar == abcArray[j])
                        {
                            keyIndex = j;
                        }
                    }
                    {

                    }
                    for (int j = 0; j < 35; j++)
                    {
                        if (cipherChar == abcArray[j])
                        {
                            CipherIndex = j;
                        }
                    }

                    int c1 = (CipherIndex + keyIndex) % 36;
                    ciphertext += abcArray[c1];


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
                    k = (char)((int)k - 32);
                    c = (char)((c - 32) + k);
                    ciphertext += (char)((c % 95) + 32);
                    
                }
                else
                {
                    ciphertext += c;
                }
            }
            Output.Text = ciphertext;
        }
        public void DecryptVigenereArray(string cipherText, string key)
        {


            string plainText = "";
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Key cannot be empty");
                return;
            }
            cipherText.Trim();
            int keycounter = 0;
            int length = cipherText.Length;
            plainText = plainText.ToLower();
            key = key.ToLower();
            for (int i = 0; i < length; i++)
            {
                int keyIndex = 0;
                int CipherIndex = 0;
                char cipherChar = cipherText[i];
                char keyChar = key[keycounter++ % key.Length];
                if (abcArray.Contains(cipherChar))
                {
                    for (int j = 0; j < 35; j++)
                    {
                        if (keyChar == abcArray[j])
                        {
                            keyIndex = j;
                        }
                    }
                    {

                    }
                    for (int j = 0; j < 35; j++)
                    {
                        if (cipherChar == abcArray[j])
                        {
                            CipherIndex = j;
                        }
                    }

                    int c1 = (CipherIndex - keyIndex + 36) % 36;
                    plainText += abcArray[c1];


                }
                else
                {
                    keycounter--;
                    plainText += cipherChar;
                }
            }
            Output.Text = plainText;
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
                char c = ciphertext[i];
                char k = key[i % key.Length];
                if ((int)c >= 32 && (int)c <= 127)
                {
                     k = (char)((int)k - 32);
                    c = (char)((c - 32) + (95 - k));
                    plaintext += (char)((c % 95) + 32);

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
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    EncryptVigenereDictionary(Input.Text, Key.Text);
                    break;
                case 1:
                    EncryptVigenereASCII(Input.Text, Key.Text);
                    break;
                case 2:
                    EncryptVigenereArray(Input.Text, Key.Text);
                    break;
            }



        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    DecryptVigenereDictionary(Input.Text, Key.Text);
                    break;
                case 1:
                    DecryptVigenereASCII(Input.Text, Key.Text);
                    break;
                case 2:
                    DecryptVigenereArray(Input.Text, Key.Text);
                    break;

            }


        }
    }
}