using System;
using System.Collections.Generic;

namespace Project_Wek
{
    class Program
    {
        public static bool Restart(int userInput)
        {
            if (userInput == 7)
            {
                return true;
            }

            return false;
        }

        public static bool Quit(int userInput)
        {
            if (userInput == 6)
            {
                return true;
            }

            return false;
        }

        public static bool AdminQuit(string userInput)
        {
            if (userInput == "F")
            {
                return true;
            }

            return false;
        }

        public static bool AdminRestart(string userInput)
        {
            if (userInput == "G")
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            const string password = "admin123"; //admin menu password, const makes it so it can't be changed

            int maxCheckedOutResources = 3;

            List<string> students = new List<string> { "Krista Scholdberg", "Ashley Stewart", "Cadale Thomas", "Lawrence Hudson", "Jennifer Evans", "Kimberly Vargas", "Jacob Lockyer", "Richard Raponi", "Imari Childress", "Mary Winkelman", "Cameron Robinson", "Margaret Landefield", "Quinn Bennett" };
            List<string> resources = new List<string> { "Visual C#", "C# Player's Guide", "Javascript for Kids", "HTML & CSS", "SQL Databases", "Git for Beginners", "Java for Dummies", "C# for Dummies", "Ruby on Rails", "Visual Studio for Beginners" };
            List<List<string>> checkedOutResources = new List<List<string>> (); //first index will be the index as a string of the person's name in students. This list stores the user's checked out resources. contained list indices match the user's index in students
            List<string> LCStudents = new List<string> ();
            List<string> LCResources = new List<string> ();

            for (int i = 0; i < students.Count; i++) //converts each member in the list to all lowercase and saves it in a new list
            {
                LCStudents.Add(students[i].ToLower());
            }

            for (int i = 0; i < resources.Count; i++)
            {
                LCResources.Add(resources[i].ToLower());
            }

            for (int i = 0; i < students.Count; i++) //populates the checkedoutresources list with empty lists of strings
            {
                checkedOutResources.Add(new List <string> ());
            }

            students.Sort();
            resources.Sort();
            LCResources.Sort();
            LCStudents.Sort();

            string[] mainMenu = { "1 - View Students", "2 - View Available Resources", "3 - View Student Accounts", "4 - Checkout Item", "5 - Return Item", "6 - Exit", "7 - Start Over", "8 - Admin Menu\n" };
            string[] adminMenu = { "\nAdministrator Menu\n", "Please choose an option: \n", "A - Add a student", "B - Add a resource", "C - Delete a student", "D - Delete a resource", "E - Exit admin menu", "F - Exit program" };

            while (true)
            { 
                bool doubleContinue = false;
                bool doubleBreak = false;
                bool result = false;
                int choice = 0;

                while (result == false)
                {
                    Console.WriteLine("\n\nWelcome to Bootcamp Resources Checkout System! \n\n");

                    Console.WriteLine("Enter a number to select a menu option: \n");
                    Console.WriteLine(mainMenu[0]);
                    Console.WriteLine(mainMenu[1]);
                    Console.WriteLine(mainMenu[2]);
                    Console.WriteLine(mainMenu[3]);
                    Console.WriteLine(mainMenu[4]);
                    Console.WriteLine(mainMenu[5]);
                    Console.WriteLine(mainMenu[6]);
                    Console.WriteLine(mainMenu[7]);

                    string menuChoice = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    result = int.TryParse(menuChoice, out choice); //makes sure the entry is a number, and if not makes the user enter it again
                   
                    if (Quit(choice))
                    {
                        Console.WriteLine("Quitting...\n");
                        doubleBreak = true;
                        break;
                    }

                    if (Restart(choice))
                    {
                        Console.WriteLine("Restarting...\n");
                        doubleContinue = true;
                        continue;
                    }

                    if (result == true)
                    {
                        break;
                    }
                }

                if (doubleBreak == true) //exits the program
                {
                    break;
                }

                if (doubleContinue == true) //restarts the program
                {
                    continue; 
                }

                //Main Menu
                switch (choice)
                {
                    case 1:
                        string resourceInput; //defined these here so I could reuse them in the switch case
                        int resourcePosition;
                        string nameInput;
                        int namePosition;

                        Console.WriteLine("View the List of Current Students\n\n"); 
                        for (int i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine(students[i]);
                        }

                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("Available Resources\n"); 

                        if (LCResources.Count == 0)
                        {
                            Console.WriteLine("All resources are checked out.");
                            break;
                        }

                        for (int i = 0; i < resources.Count; i++) //this loop prints out the resources in proper title case from resources by checking to see if each index in resources is in LCResources and only printing if they are
                        {
                            string check = resources[i];
                            if (LCResources.Contains(check.ToLower()))
                            {
                                Console.WriteLine(check);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("View Student Accounts\n");
                        while (true)
                        {
                            Console.WriteLine("Enter a Name: \n");
                            nameInput = Console.ReadLine().ToLower();
                            Console.WriteLine();

                            if (!LCStudents.Contains(nameInput)) //checks to see if the user exists
                            {
                                Console.WriteLine("\aERROR: request unavailable");
                                continue;
                            }

                            namePosition = LCStudents.IndexOf(nameInput); //this variable is used to get the index of the name in students so it can be used later to find the appropriate list in checkedoutresources

                            if (checkedOutResources[namePosition].Count == 0) //checks to see if the user has anything checked out
                            {
                                Console.WriteLine("Nothing is checked out...\n");
                                break;
                            }
                            else
                            {
                                checkedOutResources[namePosition].Sort(); //makes sure the list is sorted when printed

                                for (int i = 0; i < checkedOutResources[namePosition].Count; i++) //this loop prints out the checked out items in the user's list
                                {
                                    Console.WriteLine(checkedOutResources[namePosition][i]);
                                }

                                Console.WriteLine();
                                break;
                            }
                        }
                        break;

                    case 4:  //Item checkout
                        while (true)
                        {
                            Console.WriteLine("Checkout an Item\n");
                            Console.WriteLine("Enter a Name: \n");
                            nameInput = Console.ReadLine().ToLower();
                            namePosition = LCStudents.IndexOf(nameInput);

                            if (nameInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (nameInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (LCStudents.Contains(nameInput)) //checks to make sure the name is in the list, and if not, prints error and the loop runs again. if it is in the list, it breaks this while loop and goes to resources
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\aError: Request Unavailable");
                            }
                        }

                        if (doubleContinue == true)
                        {
                            continue;
                        }

                        if (doubleBreak == true)
                        {
                            break;
                        }

                        while (true)
                        {
                            LCResources.Sort();

                            Console.WriteLine("Enter the name of the resource you want to checkout:\n");
                            resourceInput = Console.ReadLine().ToLower();
                            resourcePosition = LCResources.IndexOf(resourceInput);

                            if (resourceInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (resourceInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (!LCResources.Contains(resourceInput)) //makes sure the resource entered exists
                            {
                                Console.WriteLine("\aThat resource does not exist. Please try again. ");
                                continue;
                            }

                            if (checkedOutResources[namePosition].Count == maxCheckedOutResources) //checks to make sure the user doesnt have more than 3 resources checked out
                            {
                                Console.WriteLine(nameInput + " has checked out the maximum number of resources.");
                                doubleContinue = true;
                                break;
                            }

                            if (!LCResources.Contains(resourceInput)) //checks to make sure the resource is available
                            {
                                Console.WriteLine("\aError: Request Unavailable.\n");
                                continue;
                            }

                            if (LCResources.Contains(resourceInput)) //checks to make sure the resource is in resources List and then removes it from resources list to check it out
                            {
                                Console.WriteLine( nameInput + " has checked out " + resourceInput + ".");
                                LCResources.Remove(LCResources[resourcePosition]);
                                LCResources.Sort();
                            }

                            checkedOutResources[namePosition].Add(resourceInput); //adds the resource to the checked out resources

                            Console.WriteLine("\nWould you like to checkout another resource? Enter \"yes\" or \"no\".");

                            string moreCheckout = Console.ReadLine().ToLower();

                            if (moreCheckout == "no")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (moreCheckout == "yes")
                            {
                                continue;
                            }
                        }

                        if (doubleContinue == true)
                        {
                            continue;
                        }

                        break;

                    case 5:
                        Console.WriteLine("Return an Item\n");

                        while (true)
                        {
                            LCResources.Sort();

                            Console.WriteLine("Enter a name:");
                            nameInput = Console.ReadLine().ToLower();
                            namePosition = LCStudents.IndexOf(nameInput);
                            
                            if (nameInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (nameInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (!LCStudents.Contains(nameInput))
                            {
                                Console.WriteLine("That name does not exist. Please try again.");
                                continue;
                            }

                            Console.WriteLine("Enter the name of the resource you want to return: ");
                            resourceInput = Console.ReadLine().ToLower();

                            if (resourceInput == "quit")
                            {
                                doubleBreak = true;
                                break;
                            }

                            if (resourceInput == "restart")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (!checkedOutResources[namePosition].Contains(resourceInput)) //checks to see if the resource is actually in the user's checked out list 
                            {
                                Console.WriteLine("\aError: Request Unavailable");
                            }

                            if (checkedOutResources[namePosition].Count == 0) //checks to see if there is anything to return
                            {
                                Console.WriteLine("You don't have any resources to return.");
                                doubleContinue = true;
                                break;
                            }
                            
                            if (!LCResources.Contains(resourceInput) && checkedOutResources[namePosition].Contains(resourceInput)) //this is a redundant check to make sure that the resource has been checked out by being deleted from LCResources and added to the user's list, both should be true if the user checked it out
                            {
                                LCResources.Add(resourceInput); //adds the resource back to the available resources
                                checkedOutResources[namePosition].Remove(resourceInput); //removes the resource from the user's list
                                Console.WriteLine(resourceInput + " has been returned.");
                                LCResources.Sort(); //resorts the list once the resource has been readded
                            }

                            Console.WriteLine("\nWould you like to return another resource? Enter \"yes\" or \"no\".");

                            string moreReturn = Console.ReadLine().ToLower();

                            if (moreReturn == "no")
                            {
                                doubleContinue = true;
                                break;
                            }

                            if (moreReturn == "yes")
                            {
                                continue;
                            }
                        }
                        
                        if (doubleBreak == true)
                        {
                            break;
                        }

                        if (doubleContinue == true)
                        {
                            continue;
                        }

                        break;

                    case 6: //quit
                        Console.WriteLine("You want to quit");
                        doubleBreak = true;
                        break;

                    case 7: //restart
                        Console.WriteLine("You want to start over");
                        doubleContinue = true;
                        break;
                    
                    case 8: //admin menu
                        int counter = 0;
                        bool passwordEntered = false; 

                        while (true)
                        {
                            if (!passwordEntered) //makes you enter the password only once when entering the admin menu. needs to be entered each time you start the admin menu
                            {
                                Console.WriteLine("Please enter the administrator password: ");
                                string passwordInput = Console.ReadLine();

                                if (counter == 2) //restarts the program if the password is entered incorrectly too many times
                                {
                                    Console.WriteLine("\nYou have entered the password wrong too many times. Restarting...");
                                    doubleContinue = true;
                                    break;
                                }

                                if (!passwordInput.Equals(password)) //checks to make sure the password is correct. this part is case sensitive
                                {
                                    Console.WriteLine("\a\a\aINVALID PASSWORD!!!");
                                    counter++; //increments the password counter to count the number of invalid attempts
                                    continue;
                                }
                                else
                                {
                                    passwordEntered = true; //if the password gets entered correctly, this bool variable breaks the loop that will keep asking for the password up to three attempts.
                                }
                            }
                            else
                            {
                                foreach (string item in adminMenu) // prints the admin menu
                                {
                                    Console.WriteLine(item);
                                }

                                string menuChoice = Console.ReadLine().ToUpper();
                                Console.WriteLine();

                                if (AdminQuit(menuChoice))
                                {
                                    Console.WriteLine("Quitting...\n");
                                    doubleBreak = true;
                                    break;
                                }

                                if (AdminRestart(menuChoice))
                                {
                                    Console.WriteLine("Restarting...\n");
                                    doubleContinue = true;
                                    continue;
                                }

                                switch (menuChoice)
                                {
                                    case "A": //add a student
                                        while (true)
                                        {
                                            Console.WriteLine("Add a student \n");
                                            Console.WriteLine("Enter the name of the student you wish to enter.");
                                            string newStudent = Console.ReadLine().ToLower();

                                            if (newStudent == "quit")
                                            {
                                                break;
                                            }

                                            if (newStudent == "restart")
                                            {
                                                continue;
                                            }

                                            if (students.Contains(newStudent))
                                            {
                                                Console.WriteLine("\aThat student already exists!");
                                                continue;
                                            }

                                            LCStudents.Add(newStudent);
                                            LCStudents.Sort(); //resorts the list once the new student is added

                                            Console.WriteLine("\nWould you like to enter another student? Enter \"yes\" or \"no\".");
                                            string addInput = Console.ReadLine().ToLower();

                                            if (addInput == "yes")
                                            {
                                                continue;
                                            }

                                            if (addInput == "no")
                                            {
                                                break;
                                            }
                                        }
                                        break;

                                    case "B": //add a resource
                                        Console.WriteLine("Add a resource\n");

                                        while (true)
                                        {
                                            Console.WriteLine("Enter the title you wish to enter: ");

                                            string newResource = Console.ReadLine().ToLower();

                                            if (newResource == "quit")
                                            {
                                                break;
                                            }

                                            if (newResource == "restart")
                                            {
                                                continue;
                                            }
                                            // TODO: Methodize whole if statement below
                                            if (!LCResources.Contains(newResource)) //makes sure the resource isn't already in there
                                            {
                                                LCResources.Add(newResource);
                                                resources.Add(newResource);
                                                Console.WriteLine(newResource + " has been added to the list.\n");
                                                LCResources.Sort(); //resorts with the new addition 
                                                resources.Sort();
                                            }

                                            else
                                            {
                                                Console.WriteLine("That resource is already in the list.");
                                                continue;
                                            }

                                            Console.WriteLine("\nWould you like to enter another resource? Type \"yes\" or \"no\".");

                                            string addInput = Console.ReadLine().ToLower();

                                            if (addInput == "yes")
                                            {
                                                continue;
                                            }

                                            if (addInput == "no")
                                            {
                                                break;
                                            }
                                        }

                                        break;

                                    case "C": //delete a student 
                                        while (true)
                                        {
                                            Console.WriteLine("Delete a Student\n");

                                            Console.WriteLine("Enter the name of the student you wish to delete: ");
                                            string deleteStudent = Console.ReadLine().ToLower();

                                            if (deleteStudent == "quit")
                                            {
                                                doubleBreak = true;
                                                break;
                                            }

                                            if (deleteStudent == "restart")
                                            {
                                                doubleContinue = true;
                                                continue;
                                            }

                                            if (LCStudents.Contains(deleteStudent)) //will only delete if the student is actually in there, otherwise you get an error
                                            {
                                                LCStudents.Remove(deleteStudent);
                                                Console.WriteLine(deleteStudent + " has been removed.\n");
                                                LCStudents.Sort();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\aERROR: Request Unavailable. That student does not exist.");
                                                continue;
                                            }

                                            Console.WriteLine("\nWould you like to delete another student? Enter \"yes\" or \"no\".");
                                            string addInput = Console.ReadLine().ToLower();

                                            if (addInput == "yes")
                                            {
                                                continue;
                                            }

                                            if (addInput == "no")
                                            {
                                                break;
                                            }
                                        }

                                        if (doubleContinue == true)
                                        {
                                            continue;
                                        }

                                        if (doubleBreak == true)
                                        {
                                            break;
                                        }

                                        break;

                                    case "D": //delete a resource

                                        Console.WriteLine("Delete a Resource\n");

                                        while (true)
                                        {
                                            Console.WriteLine("Enter the name of the resource you wish to delete: ");
                                            string deleteResource = Console.ReadLine().ToLower();

                                            if (deleteResource == "quit")
                                            {
                                                doubleBreak = true;
                                                break;
                                            }

                                            if (deleteResource == "restart")
                                            {
                                                doubleContinue = true;
                                                continue;
                                            }

                                            if (LCResources.Contains(deleteResource)) //makes sure the resource exists before it's deleted
                                            {
                                                LCResources.Remove(deleteResource);
                                                Console.WriteLine(deleteResource + " has been removed.\n");
                                                LCResources.Sort();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\aERROR: Request Unavailable. That resource does not exist.");
                                                continue;
                                            }

                                            Console.WriteLine("\nWould you like to delete another resource? Enter \"yes\" or \"no\".");
                                            string addInput = Console.ReadLine().ToLower();

                                            if (addInput == "yes")
                                            {
                                                continue;
                                            }

                                            if (addInput == "no")
                                            {
                                                break;
                                            }
                                        }

                                        if (doubleContinue == true)
                                        {
                                            continue;
                                        }

                                        if (doubleBreak == true)
                                        {
                                            break;
                                        }

                                        break;

                                    case "E": // exit admin menu

                                        Console.WriteLine("Exiting admin menu...\n");
                                        doubleContinue = true;
                                        break;

                                    case "F": //exit program 

                                        Console.WriteLine("Exiting program...\n");
                                        doubleBreak = true;
                                        break;

                                    default: //restart admin menu
                                        Console.WriteLine("Restarting admin menu...\n");
                                        break;
                                }
                            }

                            if (doubleBreak == true)
                            {
                                break;
                            }

                            if (doubleContinue == true) 
                            {
                                break;
                            }
                        }
                        
                        if (doubleContinue == true)
                        {
                            continue;
                        }

                        break;

                    default: //default restarts since it wasn't a valid choice
                        Console.WriteLine("You didn't enter a valid menu choice. Restarting...");
                        doubleContinue = true;
                        break;
                }

                if (doubleBreak == true) //exits the program
                {
                    break;
                }
                if (doubleContinue == true) //restarts the program
                {
                    continue;
                }
            }
        }
    }
}

