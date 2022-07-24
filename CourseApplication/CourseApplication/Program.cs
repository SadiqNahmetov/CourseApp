using CourseApplication.Controllers;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace CourseApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GroupController groupController = new GroupController();

            StudentController studentController = new StudentController();

            Helper.WriteConsole(ConsoleColor.Blue, "Select one option: ");

            GetMenues();

            while (true)
            {
            SelectOption : string selectOption = Console.ReadLine();
                int selectTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menues.CreateGroup:

                            groupController.Create();
                            break;

                        case (int)Menues.GetGroupById:

                            groupController.GetById();
                            break;


                        case (int)Menues.UpdateGroup:

                            groupController.Update();
                            break;


                        case (int)Menues.DeleteGroup:

                            groupController.Delete();
                            break;

                        case (int)Menues.GetAllGroups:

                            groupController.GetAll();
                            break;

                        case (int)Menues.SearchForGroupsByTeacherName:
                            
                            groupController.SearchByTeacherName();
                            break;

                        case (int)Menues.GetAllGroupsByRoom:

                             groupController.GetAllByRoom();
                             break;

                        case (int)Menues.SearchMethodForGroupsByName:

                            groupController.SearchByName();
                             break;

                           
                            // Students 

                        case (int)Menues.CreateStudent:

                           studentController.Create();
                            break;

                        case (int)Menues.UpdateStudent:

                            studentController.Update();
                            break;

                        case (int)Menues.GetStudentById:

                            studentController.GetById();
                            break;

                        case (int)Menues.DeleteStudent:

                            studentController.Delete();
                            break;


                        case (int)Menues.GetStudentsByAge:

                            studentController.GetStudentsByAge();
                            break;


                        case (int)Menues.SearchStudentsByNameOrSurname:

                            studentController.Search();
                            break;
                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number: ");
                            break;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option: ");
                    goto SelectOption;
                }
            }
        }
        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.Cyan, "1 - Create group\n2 - Get group by id\n3 - Update group\n4 - Delete group\n5" +
              " - Get all groups\n6 - Search for groups by teacher name\n7 - Get all groups by room\n8" +
              " - Search method for groups by name\n9 - Create student\n10 - Update student\n11 - Get student by Id\n12 - Delete student\n13" +
              " - Get students by age\n14 - Get all students by group id\n15 - Search method for students by name or surname");
        }
    }
}
