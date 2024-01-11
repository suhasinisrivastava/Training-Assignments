namespace banking{
    class SBAccount{
        public int AccountNumber{
            get;set;
        }
        public string CustomerName{
            get;set;
        }
         public string CustomerAddress{
            get;set;
        }
         public decimal CurrentBalance{
            get;set;
        }
         public SBAccount(){}

        public SBAccount(int acc, string cn, string add, decimal amt){
           CustomerName=cn;
           CustomerAddress=add;
            CurrentBalance=amt;
            AccountNumber=acc;

        }
    }
}