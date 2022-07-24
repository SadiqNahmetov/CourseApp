using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public enum Menues
    {
      CreateGroup = 1,
      GetGroupById = 2,
      UpdateGroup = 3,
      DeleteGroup = 4,
      GetAllGroups = 5,
      SearchForGroupsByTeacherName = 6,
      GetAllGroupsByRoom = 7,
      SearchMethodForGroupsByName = 8,
      
        CreateStudent  =  9,
        UpdateStudent  =  10, 
        GetStudentById =  11,
        DeleteStudent  =  12,
        GetStudentsByAge = 13, 
        GetAllStudentsByGroupId = 14, 
        SearchStudentsByNameOrSurname =15, 
    } 

}
