using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Schema;
using System.Net;

//PRG 281X1 PROJECT MEMBERS :Mphela Napo (578379), Mosifane Mosifane(577306) , Gianni Snyders(577932) , Phumlani Ntuli(577529)

namespace Project_trial_2
{
   
    internal class Program
    {
        enum Menu
            {
               Loan =1,
               Display,
               Exit
        
            }
       
        static void Main(string[] args)
        {
          
            ArrayList loans = new ArrayList(); // Store the collection of loans captured

            bool appOn = true; //Used for the Main menu 
            bool appLoanOn = true; // Used for the loans menu

            while (appOn) 
            {

                Console.Clear();
                Console.WriteLine("Welcome to BC Banking Solutions Select an Option\n1.Apply for loan\n2.Display Loans\n3.Exit Application");
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {

                    case (int)Menu.Loan:

                        while (appLoanOn)
                        {

                            {

                                Console.Clear();
                                double rate = 0;
                                if (!(rate > 0))
                                {
                                    Console.WriteLine("What is the current Prime Interest Rate?\n");
                                    rate = Convert.ToDouble(Console.ReadLine());
                                }

                                

                                Console.Clear() ;
                                Console.WriteLine("What loan type would you like to choose\n1.Business loan \n2.Person Loan");
                                int loanType = Convert.ToInt32(Console.ReadLine());
                                if (loanType == 1 || loanType == 2)
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        switch (loanType)
                                        {
                                            case 1:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("What is your first Name");
                                                    string Name = Console.ReadLine();

                                                    Console.WriteLine("What is your last Name");
                                                    string SurName = Console.ReadLine();

                                                    Console.WriteLine("How much would you like to loan ?");
                                                    double loanAmount = Convert.ToDouble(Console.ReadLine());


                                                    Console.WriteLine("What term would you like? (1 year ,3 year , 5 year");
                                                    int loanTerm = Convert.ToInt32(Console.ReadLine());

                                                    BusinessLoan business = new BusinessLoan(i + 1, Name, SurName, loanAmount, loanTerm, rate);
                                                    business.LoanConditions(loanTerm);
                                                    loans.Add(business);

                                                


                                                    break;
                                                }

                                            case 2:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("What is your first Name");
                                                    string Name = Console.ReadLine();

                                                    Console.WriteLine("What is your last Name");
                                                    string SurName = Console.ReadLine();

                                                    Console.WriteLine("How much would you like to loan ?");
                                                    double loanAmount = Convert.ToDouble(Console.ReadLine());


                                                    Console.WriteLine("What term would you like? ");
                                                    int loanTerm = Convert.ToInt32(Console.ReadLine());

                                                    PersonalLoan personal = new PersonalLoan(i + 1, Name, SurName, loanAmount, loanTerm, rate);
                                                    personal.LoanConditions(loanTerm);
                                                    loans.Add(personal);
                                                    break;
                                                }        

                                        }

                                        Console.Clear();
                                        Console.WriteLine("Would you like to make another loan\n1.Yes\n2.No");
                                        int choice1 = Convert.ToInt32(Console.ReadLine());
                                        if (choice1 == 1)
                                        {
                                            Console.WriteLine("Ok cool");


                                        }
                                        else if (choice1 == 2)
                                        {
                                            break;
                                        }


                                    }



                                }

                                else
                                {
                                    Console.WriteLine("Invalid option");
                                }


                                break;
                            }

                        }
                        break;
                       

                    case (int)Menu.Display:
                        {
                            while (appLoanOn) 
                            {
                                Console.Clear();
                                Console.WriteLine("Loan Details");
                                Console.WriteLine("-------------");
                                
                                for(int i = 0; i < loans.Count; i++)
                                {

                                    Console.WriteLine(loans[i].ToString());
                                    
                                    Console.WriteLine("-------------------------------------------------------------------------------");


                                }

                                Console.WriteLine("\n\n\nPress 1 return to Menu");
                                int choice = Convert.ToInt32(Console.ReadLine());
                                if (choice == 1)
                                {

                                    break;
                                   
                                    

                                }

                                else 
                                {
                                    Console.WriteLine("Invalide option");
                                }
                            }
                        


                            break;
                        }

                    case (int)Menu.Exit:
                        {
                            Console.Clear();
                            Console.WriteLine("Thank you for using our services");
                            appOn = false;



                            break;
                        }




                }

             

            }
           
        }
    }
    public abstract class Loan : LoanConstants1 //Main loan abstract class 
    {
        public int loanNumber;
        public string lastName;
        public string firstName;
        public double loanAmount;
        public int term;
        public double interestRate;
        double totalRepayment;
        

    

        public Loan(int loanNum, string LastName, string first, double loanAmount, int term , double interestRate) : base()
        {
            loanNumber = loanNum;
            this.lastName = LastName;
            firstName = first;
            this.loanAmount = loanAmount;
            this.term = term;
            this.interestRate = interestRate/100;
            
        }

        
       
        
        public void LoanConditions( int trm) // Validates whether the loan amount is above 100000 or not and checks that the user used the right terms
        {
            if (loanAmount > MaxLoanAmount)
            {

                Console.WriteLine("Invalid amount too much money for a loan.");
                loanAmount = 0;
            }


            if (trm != shortTerm() && trm != mediumTerm() && trm != longTerm())
            {
                Console.WriteLine("Invalid loan term. Setting the term to 1 year.");
                term = shortTerm();
            }
            else
            {
                term = trm;
            }




        }

    


        public  override string  ToString() // Displays all the loans information
        {

            totalRepayment = (loanAmount + (loanAmount * interestRate)) * term;

            return $"Loan Number: {loanNumber}\n"+
                   $"FirstName: {firstName}\n" +
                   $"LastName: {lastName}\n" +
                   $"loan Amount:R{loanAmount}\n" +
                   $"Interest rate: {interestRate *100}%\n" +
                   $"Term : {term}\n" +
                   $"Estimated repayment: {totalRepayment}"
               ;
        }




    }

    public class BusinessLoan : Loan // Personal loan class which is inherites from the loan class
    
    {
        
        public BusinessLoan(int loanNum, string LastName, string first, double loanAmount, int term , double PrimeinterestRate) : base(loanNum, LastName, first, loanAmount, term , PrimeinterestRate)
        {
            interestRate =( PrimeinterestRate/100 )+ 0.01;
        }

    }



    public class PersonalLoan : Loan // Personal loan class which is inherites from the loan class
    {

        public PersonalLoan(int loanNum, string LastName, string first, double loanAmount, int term, double PrimeinterestRate) : base(loanNum, LastName, first, loanAmount, term, PrimeinterestRate)
        {

            interestRate = (PrimeinterestRate / 100 )+ 0.02;
        }

    }

    public interface LoanConstants//Constants for the company and system requirements using getter and setters
    {
        int shortTerm();
        int mediumTerm();
        int longTerm();

        string Companyname { get; }
        double MaxLoanAmount { get; }


    }


    public class LoanConstants1 : LoanConstants //Behaves as a bridge class that is used to link and set the constant values
    {
        public string Companyname => "Unique Building Services Loan Company";
        public double MaxLoanAmount => 100000;

        public int longTerm()
        {
            return 5;
        }

        public int mediumTerm()
        {
            return 3;
        }

        public int shortTerm()
        {
            return 1;
        }

    }
}
