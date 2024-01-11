namespace banking{
    class SBTransaction{
        public int TransactionId{
            get;set;
        }
        public DateTime TransactionDate{
            get;set;
        }
         public int AccountNumber{
            get;set;
        }
         public decimal Amount{
            get;set;
        }
        public string TransactionType{
            get;set;
        }

        public SBTransaction(){}

        public SBTransaction(int tid, DateTime tdate, int acc, decimal amt, string tt){
            TransactionId=tid;
            TransactionDate=tdate;
            TransactionType=tt;
            Amount=amt;
            AccountNumber=acc;

        }
    }
}