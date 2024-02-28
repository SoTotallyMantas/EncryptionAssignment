using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAssignment.Util
{
    internal class FileOperations
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public FileOperations()
        {
        }

        public string Selectedpath { get; set; }

        public string openfiledialog()
        {
            
            path += "\\EncryptionAssingment";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            OpenFileDialog Filedialog = new OpenFileDialog()
            {
                
                InitialDirectory = path,
                DefaultExt = "txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Select File",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if(Filedialog.ShowDialog() == DialogResult.OK)
            {
                 Selectedpath = Filedialog.FileName;
                string filetext = readfile(Selectedpath);
                return filetext;
            }
            else
            {
                return null;
            }
        }
        public string savetofile(string text)
        {
            SaveFileDialog Filedialog = new SaveFileDialog()
            {
                InitialDirectory = path,
                DefaultExt = "txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                CheckFileExists = false,
                CheckPathExists = true,
                Title = "Save File",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (Filedialog.ShowDialog() == DialogResult.OK)
            {
                Selectedpath = Filedialog.FileName;
                writefile(Selectedpath, text);
                return Selectedpath;
            }
            else
            {
                return null;
            }
        }
        public void writefile(string path, string text)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(text);
                }
            }
        }
        public string readfile(string path)
        {
           using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    
    
    }
}
