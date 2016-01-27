using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin_menu
{
    class Program
    {
        static void Main(string[] args)
        {
            case 8: //admin menu\
                        int counter = 0;
            while (true)
            {
                counter = 0;

                Console.WriteLine("Please enter the administrator password: ");
                string passwordInput = Console.ReadLine();

                if (counter == 3)
                {
                    Console.WriteLine("You have entered the password wrong too many times. Restarting...");
                    doubleContinue = true;
                    break;
                }
                if (!passwordInput.Equals(password))
                {
                    Console.WriteLine("INVALID PASSWORD!!!");
                    doubleContinue = true;
                    counter++;
                    continue;
                }
                else
                {
                    Console.WriteLine("Administrator Menu\n");
                    Console.WriteLine("Please choose an option: \n");

                    Console.WriteLine("A - Add a student");
                    Console.WriteLine("B - Add a resource");
                    Console.WriteLine("C - Delete a student");
                    Console.WriteLine("D - Delete a resource");
                    Console.WriteLine("E - Exit admin menu");
                    Console.WriteLine("F - Exit program");
                    Console.WriteLine("G - Restart program");

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

                    switch(menuChoice)
                    {
                        case "A": //add a student
                            while(true)
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

                                LCStudents.Add(newStudent);

                                Console.WriteLine("Would you like to enter another student? Enter \"yes\" or \"no\".");
                                string addInput = Console.ReadLine().ToLower();

                                if (addInput == "yes")
                                {
                                    continue;
                                }

                                if (addInput == "no")
                                {
                                    doubleContinue = true;
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

                                if (!LCResources.Contains(newResource))
                                {
                                    LCResources.Add(newResource);
                                    Console.WriteLine(newResource + "has been added to the list.\n");
                                }
                                else
                                {
                                    Console.WriteLine("That resource is already in the list.");
                                    continue;
                                }

                                Console.WriteLine("Would you like to enter another resource? Type \"yes\" or \"no\".");

                                string addInput = Console.ReadLine().ToLower();


                                if (addInput == "yes")
                                {
                                    continue;
                                }

                                if (addInput == "no")
                                {
                                    doubleContinue = true;
                                    break;
                                }
                            }
                            break;

                        case "C": //delete a student 
                            while (true)
                            {
                                Console.WriteLine("Delete a Student\n");

                                Console.WriteLine("Enter the name of the student you wish to delete: ");
                                string nameInput = Console.ReadLine().ToLower();

                                if (nameInput == "quit")
                                {
                                    doubleBreak = true;
                                    break;
                                }

                                if (nameInput == "restart")
                                {
                                    doubleContinue = true;
                                    continue;
                                }

                                if (LCStudents.Contains(nameInput))
                                {
                                    LCStudents.Remove(nameInput);
                                    Console.WriteLine(nameInput + " has been removed.\n");
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: Request Unavailable. That student does not exist.");
                                    continue;
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
                        case "D": //delete a resource

                            Console.WriteLine("Delete a Resource\n");

                            while (true)
                            {
                                Console.WriteLine("Enter the name of the resource you wish to delete: ");
                                string resourceInput = Console.ReadLine().ToLower();

                                if (resourceInput == "quit")
                                {
                                    doubleBreak = true;
                                    break;
                                }

                                if (resourceInput == "restart")
                                {
                                    doubleContinue = true;
                                    continue;
                                }

                                if (LCResources.Contains(resourceInput))
                                {
                                    LCResources.Remove(resourceInput);
                                    Console.WriteLine(resourceInput + " has been removed.\n");
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: Request Unavailable. That student does not exist.");
                                    continue;
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

                            Console.WriteLine("Exiting admin menu...");
                            doubleContinue = true;
                            break;

                        case "F": //exit program

                            Console.WriteLine("Exiting program...");
                            doublebreak = true;
                            break;

                        case "G": //restart program
                            Console.WriteLine("Restarting program...");
                            doubleContinue = true;
                            break;
                        default: //restart admin menu

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

            }


            if (doubleContinue == true)
            {
                continue;
            }

            break;
        }
    }
}

