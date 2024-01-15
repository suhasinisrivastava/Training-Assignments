using bankingwithdatabase.Models;
namespace banking{
    interface iBankRepository{
        void NewAccount(SuhasiniSbaccount acc);
        List<SuhasiniSbaccount> GetAllAccounts();
        SuhasiniSbaccount GetAccountDetails(int accno);
        void DepositAmount(int accno, decimal amt);
        void WithdrawAmount(int accno, decimal amt);
        List<SuhasiniSbtransaction> GetTransactions(int accno);
    }
}