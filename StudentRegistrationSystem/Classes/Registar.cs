using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Classes
{
    class Registar
    {
        private string Username;
        private string Password;

        public Registar()
        {

        }
        public Registar(string Uname, string Pass)
        {
            Username = Uname;
            Password = Pass;
        }
        public string getUsername()
        {
            return Username;
        }
        public void setUsername(string Uname)
        {
            Username = Uname;
        }
        public string getPassword()
        {
            return Password;
        }
        public void setPassword(string Pass)
        {
            Password = Pass;
        }
    }
}
