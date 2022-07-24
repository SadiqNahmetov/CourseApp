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

                    string studentName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please correct name: ");
                            goto surneme;
                        }

                    }



                    Helper.WriteConsole(ConsoleColor.Blue, "Add student surname: ");

                surneme: string studentSurName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                        if (studentSurName.Contains(i.ToString()))
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Please correct  surname: ");
                            goto surneme;
                        }

                    }
                    Helper.WriteConsole(ConsoleColor.Blue, "Add student age: ");

                    Age: string studentAge = Console.ReadLine();

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
                            Helper.WriteConsole(ConsoleColor.Green, $" Student name : {result.Id}, Student name : {result.Name},Student surname : {result.Surname}, Student age : {result.Age}, Student group : {result.Group.Name}");
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

        }

        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add student id : ");
        StudentId: string studentId = Console.ReadLine();
            int id;

            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
               Student student= studentService.GetById(id);
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

            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                goto StudentId;
            }


        }

        public void GetStudentsByAge()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Search student age : ");
        StudentAge : string stAge = Console.ReadLine();

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
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Not found, please correct age : ");
                goto StudentAge;
            }


        }


        public void Search()
        {

            Helper.WriteConsole(ConsoleColor.Blue, "Add student search text : ");

            string search = Console.ReadLine();

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

    }
    
}
