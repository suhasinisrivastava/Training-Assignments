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
                    int acc=Convert.ToInt32(Console.ReadLine());
                    string name=Console.ReadLine();
                    string add=Console.ReadLine();
                    int amt=Convert.ToInt32(Console.ReadLine());
                    repo.NewAccount(new SBAccount(acc,name,add,amt));
                    Console.WriteLine("Account added successfully");
                }
                else if(key==2){
                    Console.WriteLine("enter account number");
                    int acc=Convert.ToInt32(Console.ReadLine());
                    SBAccount sb= repo.GetAccountDetails(acc);
                    if(sb==null){
                        continue;
                    }
                    Console.WriteLine("Account No"+sb.AccountNumber);
                    Console.WriteLine("Customer Name"+sb.CustomerName);
                    Console.WriteLine("Customer Address"+sb.CustomerAddress);
                    Console.WriteLine("Current Balance"+sb.CurrentBalance);
                }
                else if(key==3){
                    Console.WriteLine("enter account number");
                    
                    int acc=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter amount");
                    int amt=Convert.ToInt32(Console.ReadLine());
                    repo.DepositAmount(acc,amt);
                }
                else if(key==4){
                    Console.WriteLine("enter account number");
                    int acc=Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter amount");
                    int amt=Convert.ToInt32(Console.ReadLine());
                    repo.WithdrawAmount(acc,amt);
                }
                else if(key==5){
                    List<SBTransaction> temp=new List<SBTransaction>();
                    Console.WriteLine("enter account number");
                    int acc=Convert.ToInt32(Console.ReadLine());
                    temp=repo.GetTransactions(acc);
                    if(temp.Count==0){
                        Console.WriteLine("no records found");
                        continue;
                    }
                    foreach(SBTransaction item in temp){
                        Console.WriteLine(item.TransactionId+" "+item.TransactionDate+" "+item.AccountNumber+" "+item.Amount+" "+item.TransactionType);
                    }
                }
                else if(key==6){
                    List<SBAccount> temp=new List<SBAccount>();
                    temp=repo.GetAllAccounts();
                     if(temp.Count==0){
                        Console.WriteLine("no records found");
                         continue;
                    }
                    foreach(SBAccount item in temp){
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