using System;

namespace DesignPatterns
{

    class AccountProxy : IAccount
    {
        readonly bool isDebug = true;
        IAccount account;

        public AccountProxy()
        {
            if (isDebug)
            {
                account = new Account();
            }
            else
            {
                account = (IAccount)Activator.CreateInstance(typeof(IAccount));
            }
        }

        public void Register()
        {
            Console.WriteLine("Please wait...");
            account.Register();
        }
    }

    interface IAccount
    {
        void Register();
    }

    class Account : IAccount
    {
        public void Register()
        {
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("Done");  
        }
    }
}
