namespace oops{
    class client{
        public static void Main(){
            Permanent permanentemp=new Permanent();
            Trainee trainee=new Trainee();
            permanentemp.GetDetails();
            permanentemp.CalculateSalary();
            permanentemp.ShowDetails();

            trainee.GetTraineeDetails();
            trainee.CalculateSalary();
            trainee.ShowTraineeDetails();
        }
    }
}