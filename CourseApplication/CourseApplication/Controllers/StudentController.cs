using Domain.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Service.Helpers;

namespace CourseApplication.Controllers
{
    public class StudentController
    {
        StudentService studentService = new StudentService();
        GroupService groupService = new GroupService();
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id: ");
        GroupId: string groupId = Console.ReadLine();
            int selectedGroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            var datas = groupService.GetById(selectedGroupId);
            if (datas != null)
            {
                if (isSelectedId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student name: ");

                Crname: string studentName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please correct name: ");
                            goto Crname;
                        }
                        else if (string.IsNullOrWhiteSpace(studentName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Name cant be empty: ");
                            goto Crname;
                        }

                    }



                    Helper.WriteConsole(ConsoleColor.Blue, "Add student surname: ");

                Creatsneme: string studentSurName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentSurName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please correct  surname: ");
                            goto Creatsneme;
                        }
                        else if (string.IsNullOrWhiteSpace(studentSurName))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Surname cant be empty: ");
                            goto Creatsneme;
                        }

                    }
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student age: ");

                    Age: string studentAge = Console.ReadLine();

                     if (string.IsNullOrWhiteSpace(studentAge))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student age cant be empty: ");
                        goto Age;
                    }

                    int age;
                    bool isAge = int.TryParse(studentAge, out age);

                    if (isAge)
                    {
                        Student student = new Student()
                        {
                            Name = studentName,
                            Surname = studentSurName,
                            Age = age
                        };
                        var result = studentService.Create(selectedGroupId, student);
                        if (result != null)
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $" Student id : {result.Id}, Student name : {result.Name},Student surname : {result.Surname}, Student age : {result.Age}, Student group : {result.Group.Name}");
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Add correct student age: ");
                            goto Age;
                        }
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Add correct student age type: ");
                        goto Age;
                    }

                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct group id type: ");
                    goto GroupId;
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id: ");
                goto GroupId;
            }


        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id: ");
             StudentId: string updateStudentId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(updateStudentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id cant be empty: ");
                goto StudentId;
            }

            int studentId;

            bool isStudentId = int.TryParse(updateStudentId, out studentId);

            if (isStudentId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add student new name: ");
                NewStudentName: string studentNewName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(studentNewName))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student name cant be empty: ");
                    goto NewStudentName;
                }

                Helper.WriteConsole(ConsoleColor.Blue, "Add student new surname: ");
              NewStudentSurname: string studentNewsurname = Console.ReadLine();
                for (int i = 0; i <= 9; i++)
                {
                    if (studentNewName.Contains(i.ToString()))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student name is not correct: ");
                        goto NewStudentName;
                    }
                   else if (string.IsNullOrWhiteSpace(studentNewsurname))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student surname cant be empty: ");
                        goto NewStudentSurname;
                    }



                }
                     for (int i = 0; i <= 9; i++)
                {
                    if (studentNewsurname.Contains(i.ToString()))
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Student surname is not correct: ");
                        goto NewStudentSurname;
                    }

                }
                   Helper.WriteConsole(ConsoleColor.Blue, "Add student new age: ");
                   StNewAge: string studentNewAge = Console.ReadLine();

                int age;
                bool isAge = int.TryParse(studentNewAge, out age);

                Student student = new Student()
                {
                    Name = studentNewName,
                    Surname = studentNewsurname,
                    Age = age
                };

                var resultStudent = studentService.Update(studentId, student);

                if (resultStudent == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Age have to number:");
                    goto StNewAge;

                }
                else if (string.IsNullOrWhiteSpace(studentNewAge))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student age cant be empty: ");
                    goto StNewAge;
                }
                else
                {

                    Helper.WriteConsole(ConsoleColor.Green, $"Studen id : {resultStudent.Id}, Student name : {resultStudent.Name},  Surname : {resultStudent.Surname},  Student age : {resultStudent.Age}");
                }

                

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, " Student not found, please try again:");
                goto StudentId;
            }

        }


        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");
            StudentId: string studentId = Console.ReadLine();

             if (string.IsNullOrWhiteSpace(studentId))
              {
                Helper.WriteConsole(ConsoleColor.Red, "Student id cant be empty: ");
                goto StudentId;
              }
            int id;

            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                Student student = studentService.GetById(id);
                if (student != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student id : { student.Id}, Student name : { student.Name}, Student surname : { student.Surname}, Student age : { student.Age}");
                }
                
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Student not found : ");
                    goto StudentId;
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                goto StudentId;
            }


        }


        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");
            StudentId: string studentId = Console.ReadLine();

            int id;
            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                studentService.Delete(id);

            }
            else if (string.IsNullOrWhiteSpace(studentId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student id cant be empty: ");
                goto StudentId;
            }

            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                goto StudentId;
            }


        }

        public void GetStudentsByAge()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Search student age : ");
            StudentAge: string stAge = Console.ReadLine();

           

            int age;
            bool isAge = int.TryParse(stAge, out age);

            List<Student> resultstudent = studentService.GetStudentsByAge(age);
            if (resultstudent.Count != 0)
            {
                foreach (var item in resultstudent)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student id : {item.Id}, Student name : {item.Name}, Student surname : {item.Surname},Student group : {item.Group.Name}, Student age : {item.Age} ");
                }
            }
          else if (string.IsNullOrWhiteSpace(stAge))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Search age cant be empty: ");
                goto StudentAge;
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Not found, please correct age : ");
                goto StudentAge;
            }


        }


        public void Search()
        {

            Helper.WriteConsole(ConsoleColor.Blue, "Add student search text : ");

            Searchtxt: string search = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(search))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Search text cant be empty: ");
                goto Searchtxt;
            }

            List<Student> resultStudent = studentService.Search(search);

            if (resultStudent.Count != 0)
            {
                foreach (var item in resultStudent)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Student id : {item.Id}, Student name : {item.Name}, Student surname : {item.Surname}, Student age : {item.Age}");
                }

            }
          
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Student name or surname not found: ");

            }
        }

        public void GetAll()
        {
            List<Student> students = studentService.GetAll();

            foreach (var item in students)
            {
                Helper.WriteConsole(ConsoleColor.Green, $"Studen id : {item.Id}, Student name : {item.Name},  Surname : {item.Surname},  Student age : {item.Age}");
            }
        }

        public void GetAllStudentByGrupId()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id :");
            GrupId: string groupId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.WriteConsole(ConsoleColor.Red, "Id cant be empty: ");
                goto GrupId;
            }
           

            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                List<Student> students = studentService.GetAllStudentByGrupId(id);

                if (students.Count != 0)
                {
                    foreach (var item in students)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Studen id : {item.Id}, Student name : {item.Name},  Surname : {item.Surname},  Student age : {item.Age}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found :");
                    goto GrupId;
                }

                

            }
           

             else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct group id :");
                goto GrupId;
            }


                    
        }

    }

}
