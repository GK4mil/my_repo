using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    class FileNames
    {
        private string _path;
        private string _savedText;
        public string path
        {
            get
            {
                return _path;
            }
        }
        public string savedText
        {
            get
            {
                return _savedText;
            }
        }
        public FileNames(string path, string text)
        {
            this._path = path;
            this._savedText = text;
        }
    }
}
