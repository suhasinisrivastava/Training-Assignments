
using bankingwithdatabase.Models;

namespace banking

{
    class Lessbalanceexception:ApplicationException{
        public Lessbalanceexception(string message):base(message){}
    }
    class Noaccountfound:ApplicationException{
        public Noaccountfound(string message):base(message){}
    }
    class BankRepository : iBankRepository
    {
        private static Ace52024Context db=new Ace52024Context();
        // List<SBAccount> l1=new List<SBAccount>();
        // List<SBTransaction> l2=new List<SBTransaction>();
         public void DepositAmount(int accno, decimal amt)
        {
            SuhasiniSbaccount item=db.SuhasiniSbaccounts.Find(accno);
            if(item!=null){
                    item.CurrentBalance+=amt;
                    db.SuhasiniSbaccounts.Update(item);
                    Random rnd = new Random();
                    int num = rnd.Next();   
                    DateTime currentDateTime = DateTime.Now;
                    SuhasiniSbtransaction s=new SuhasiniSbtransaction();
                    s.TransactionId=num;
                    s.TransactionDate=currentDateTime;
                    s.AccountNumber=accno;
                    s.Amount=amt;
                    s.TransactionType="Deposit";
                    db.SuhasiniSbtransactions.Add(s);
                    db.SaveChanges();
                    Console.WriteLine("amount deposited succesfully");
                    return;
            }
            else{
                throw new Noaccountfound("no account found");
            }
             
            
            
        }

        public SuhasiniSbaccount GetAccountDetails(int accno)
        {
            SuhasiniSbaccount s=db.SuhasiniSbaccounts.Find(accno);
            db.SaveChanges();
            if(s!=null){
                return s;
            }
            throw new Noaccountfound("no account found");
        }

        public List<SuhasiniSbaccount> GetAllAccounts()
        {
            List<SuhasiniSbaccount> result=(from i in db.SuhasiniSbaccounts
                        select i).ToList();
            return result;
        }

        public List<SuhasiniSbtransaction> GetTransactions(int accno)
        {
            List<SuhasiniSbtransaction> result=(from i in db.SuhasiniSbtransactions
                        where i.AccountNumber==accno
                        select i).ToList();
           return result;
        }

        public void NewAccount(SuhasiniSbaccount acc)
        {
            

           db.SuhasiniSbaccounts.Add(acc);
            db.SaveChanges();
        }

        public void WithdrawAmount(int accno, decimal amt)
        {
            SuhasiniSbaccount item=db.SuhasiniSbaccounts.Find(accno);
            if(item!=null){
                    if(item.CurrentBalance<amt){
                        throw new Lessbalanceexception("not sufficient balance");
                        
                    }
                    else{
                    item.CurrentBalance-=amt;
                    db.SuhasiniSbaccounts.Update(item);
                    Random rnd = new Random();
                    int num = rnd.Next();   
                    DateTime currentDateTime = DateTime.Now;
                    SuhasiniSbtransaction s=new SuhasiniSbtransaction();
                    s.TransactionId=num;
                    s.TransactionDate=currentDateTime;
                    s.AccountNumber=accno;
                    s.Amount=amt;
                    s.TransactionType="WITHDRAW";
                    db.SuhasiniSbtransactions.Add(s);
                    db.SaveChanges();
                    Console.WriteLine("amount withdrawn succesfully");
                    return;
                    }
            }
            else{
                throw new Noaccountfound("no account found");
            }
             
        
    }

    
}}