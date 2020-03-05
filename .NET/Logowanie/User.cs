using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    public class User
    {
        private string _pass;
        private bool _isAdmin;
        private readonly string s1 = "123233";
        private readonly string s2 = "Ajfkl;sjfklsjadfklasjdf";

        public string username { get; set; }
        private string password {
            
            set
            {
                _pass = s1+value+s2;
            }

        }
        public User(string username, string pass, bool isAdmin)
        {
            this.username = username;
            this.password = pass;
            this._isAdmin = isAdmin;
        }
        public bool isAdmin
        {
            get
            {
                return _isAdmin;
            }
        }

        
        public bool passiscorrect(string pass)
        {
            if (s1 + pass + s2 == _pass)
                return true;
            return false;
        }
        

        
    }
}
