﻿
using System;

namespace banking
{
    class BankRepository : iBankRepository
    {
        List<SBAccount> l1=new List<SBAccount>();
        List<SBTransaction> l2=new List<SBTransaction>();
        public void DepositAmount(int accno, decimal amt)
        {
             foreach(SBAccount item in l1){
                if(item.AccountNumber==accno){
                    item.CurrentBalance+=amt;
                    Random rnd = new Random();
                    int num = rnd.Next();   
                    DateTime currentDateTime = DateTime.Now;
                    l2.Add(new SBTransaction(num,currentDateTime,accno,item.CurrentBalance,"Deposit"));
                    Console.WriteLine("amount deposited succesfully");
                    return;
                }
            }
            Console.WriteLine("No account found");
        }

        public SBAccount GetAccountDetails(int accno)
        {
            foreach(SBAccount item in l1){
                if(item.AccountNumber==accno){
                    return item;
                }
            }
            Console.WriteLine("No account found");
            return null;
        }

        public List<SBAccount> GetAllAccounts()
        {
            return l1;
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            List<SBTransaction> temp=new List<SBTransaction>();

            foreach(SBTransaction item in l2){
                if(item.AccountNumber==accno){
                    temp.Add(new SBTransaction(item.TransactionId,item.TransactionDate,item.AccountNumber,item.Amount, item.TransactionType));
                }
            }
            return temp;
        }

        public void NewAccount(SBAccount acc)
        {
            l1.Add(acc);
        }

        public void WithdrawAmount(int accno, decimal amt)
        {
             foreach(SBAccount item in l1){
                if(item.AccountNumber==accno){
                    if(item.CurrentBalance<amt){
                        Console.WriteLine("Not sufficient balance");
                        return;
                    }
                    else{

                    
                    item.CurrentBalance-=amt;
                    Random rnd = new Random();
                    int num = rnd.Next();   
                    DateTime currentDateTime = DateTime.Now;
                    l2.Add(new SBTransaction(num,currentDateTime,accno,item.CurrentBalance,"Withdraw"));
                    Console.WriteLine("amount withdrawn succesfully");
                    return;
                    }
                }
            }
            Console.WriteLine("No account found");
        }
    }

    
}