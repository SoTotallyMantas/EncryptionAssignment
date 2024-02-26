using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAssignment.Util
{
    internal class ComboboxCollections
    {
        
        public ComboboxCollections()
        {
            
        }






        private string[] vigenereMethods = new string[] { "Dictionary", "ASCII", "Array" };
        private string[] dESMethods = new string[] { "ECB", "CBC", "CFB" };

        public string[] DESMethods { get => dESMethods; set => dESMethods = value; }
        public string[] VigenereMethods { get => vigenereMethods; set => vigenereMethods = value; }
    }
}
