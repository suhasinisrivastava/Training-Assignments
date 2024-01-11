namespace oops{
    class employeeclient{
        public static void Main(){
            iemployee permanentemp=new Permanent();
            iemployee trainee=new Trainee();
            permanentemp.AcceptDetails();
            permanentemp.CalculateSalary();
            permanentemp.DisplayDetails();

            trainee.AcceptDetails();
            trainee.CalculateSalary();
            trainee.DisplayDetails();
        }
    }
}