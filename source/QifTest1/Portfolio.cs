using System;
using System.Collections.Generic;

namespace Reconcile
{
    public class Portfolio
    {
        public Portfolio()
        {
            Accounts = new List<Account>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastLogon { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
