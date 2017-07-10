using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string _filename;
        List<Account> accounts = new List<Account>();

        public FileAccountRepository(string filename)
        {
            _filename = filename;
        }

        public Account LoadAccount(string accountNumber)
        {
            Account rightAccount = new Account();
            rightAccount = null;
           
            
            using (StreamReader sr = new StreamReader(_filename))
            {
               
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    
                    Account account = new Account();
                    string[] fields = line.Split(',');
                    
                    account.AccountNumber = fields[0];
                    account.Name = fields[1];
                    account.Balance = decimal.Parse(fields[2]);
                    account.Type = ConvertToType(fields[3]);
                    accounts.Add(account);
        
                }
              
            }
            foreach (var account in accounts)
            {

                if (account.AccountNumber == accountNumber)
                {
                   rightAccount = account;
                }
                
            }
            return rightAccount;
        }

        public void SaveAccount(Account account)
        {
            using (StreamWriter sw = new StreamWriter(_filename, false))
            {
                
                sw.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var a in accounts)
                {
                    if (a.AccountNumber != account.AccountNumber)
                    {
                        sw.WriteLine(
                            $"{a.AccountNumber},{a.Name},{a.Balance},{ConvertTypeToLetter(a.Type)}");
                    }
                    else
                    {
                        sw.WriteLine($"{account.AccountNumber},{account.Name},{account.Balance},{ConvertTypeToLetter(account.Type)}");

                    }
                }

            }
        }
        public static AccountType ConvertToType(string s)
        {
            switch (s)
            {
                case "F":
                    return AccountType.Free;
                case "B":
                    return AccountType.Basic;
                case "P":
                    return AccountType.Premium;
                default:
                    throw new Exception("No account type found.");
            }
        }

        public static string ConvertTypeToLetter(AccountType type)
        {
            switch (type)
            {
                case AccountType.Basic:
                    return "B";
                case AccountType.Free:
                    return "F";
                case AccountType.Premium:
                    return "P";
                default:
                    throw new Exception("This type cannot convert");
            }
        }
    }
}
