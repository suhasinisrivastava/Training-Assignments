using bankingwithdatabase.Models;
namespace banking{
    class mainprog{
        public static void Main(){
            iBankRepository repo=new BankRepository();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Create new Account ");
            Console.WriteLine("2) View Account details ");
            Console.WriteLine("3) deposit money ");
            Console.WriteLine("4) Withdraw money ");
            Console.WriteLine("5) Get transaction details ");
            Console.WriteLine("6) Get all Account details ");
            Console.WriteLine("7) Exit ");

            bool exit=false;
            while(exit!=true){
                Console.WriteLine("Choose an option:");
                int key=Convert.ToInt32(Console.ReadLine());
                if(key==1){
                    Console.WriteLine("enter account number, customer name, customer address, current amount in the same order");
                    SuhasiniSbaccount s= new SuhasiniSbaccount();
                    s.AccountNumber=Convert.ToInt32(Console.ReadLine());
                    s.CustomerName=Console.ReadLine();
                    s.CustomerAddress=Console.ReadLine();
                    s.CurrentBalance=Convert.ToInt32(Console.ReadLine());
                    repo.NewAccount(s);
                    Console.WriteLine("Account added successfully");
                }
                else if(key==2){
                    Console.WriteLine("enter account number");
                    int acc=Convert.ToInt32(Console.ReadLine());
                    try{
                    SuhasiniSbaccount sb= repo.GetAccountDetails(acc);
                    if(sb==null){
                        continue;
                    }
                    Console.WriteLine("Account No"+sb.AccountNumber);
                    Console.WriteLine("Customer Name"+sb.CustomerName);
                    Console.WriteLine("Customer Address"+sb.CustomerAddress);
                    Console.WriteLine("Current Balance"+sb.CurrentBalance);
                    }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                }
                else if(key==3){
                    
                    Console.WriteLine("enter account number");
                    
                    int acc=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter amount");
                    int amt=Convert.ToInt32(Console.ReadLine());
                    try{
                    repo.DepositAmount(acc,amt);
                    }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                }
                else if(key==4){
                    Console.WriteLine("enter account number");
                    int acc=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter amount");
                    int amt=Convert.ToInt32(Console.ReadLine());
                    try{
                    repo.WithdrawAmount(acc,amt);
                    }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                }
                else if(key==5){
                    List<SuhasiniSbtransaction> temp=new List<SuhasiniSbtransaction>();
                    Console.WriteLine("enter account number");
                    int acc=Convert.ToInt32(Console.ReadLine());
                    temp=repo.GetTransactions(acc);
                    if(temp.Count==0){
                        Console.WriteLine("no records found");
                        continue;
                    }
                    foreach(var item in temp){
                        Console.WriteLine(item.TransactionId+" "+item.TransactionDate+" "+item.AccountNumber+" "+item.Amount+" "+item.TransactionType);
                    }
                }
               else if(key==6){
                    List<SuhasiniSbaccount> temp=new List<SuhasiniSbaccount>();
                    temp=repo.GetAllAccounts();
                     if(temp.Count==0){
                        Console.WriteLine("no records found");
                         continue;
                    }
                    foreach(var item in temp){
                        Console.WriteLine(item.AccountNumber+" "+item.CustomerName+" "+item.CustomerAddress+" "+item.CurrentBalance);
                    }
                }
                else if(key==7){
                    exit=true;
                }
            }
    }
}
}