using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{

    class Authorizator
    {
        protected bool isActive = false;

        public bool IsActive()
        {
            return isActive;
        }

        public void Authorize(string email, string password)
        {
            if (email.Equals("beysenbek@gmail.com") && password.Equals("11112"))
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
    }

    class Authorizator2: Authorizator
    {
        public void Authorize(string email, string password, string pin)
        {
            if (email.Equals("beysenbek@gmail.com") && password.Equals("11112") && pin.Equals("123"))
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Authorizator2 a = new Authorizator2();
            a.Authorize("beysenbek@gmail.com", "11112","123");
            Console.WriteLine(a.IsActive());
        }
    }
}
