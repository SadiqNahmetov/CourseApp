using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApplication.Controllers
{
    public class GroupController
    {
        readonly GroupService groupService = new GroupService();
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group name: ");
            string groupName = Console.ReadLine();

            Helper.WriteConsole(ConsoleColor.Blue, "Add teacher name: ");

             TeachName: string groupTeacherName = Console.ReadLine();

            for (int i = 0; i <= 9; i++)
            {
                if (groupTeacherName.Contains(i.ToString()))
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Please correct teacher name: ");
                    goto TeachName;
                }

            }
        

            Helper.WriteConsole(ConsoleColor.Blue, "Add room name: ");
            string roomName = Console.ReadLine();

            Group group = new Group
            {
                Name = groupName,
                Teacher = groupTeacherName,
                Room = roomName
            };


            var result = groupService.Create(group);
            Helper.WriteConsole(ConsoleColor.Green, $"Group id : {result.Id}, Group name : {result.Name}, Teacher name : {result.Teacher}, Room name : {result.Room}");
        }

        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");
           GroupId: string groupId = Console.ReadLine();
            int id;

            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                Group group1 = groupService.GetById(id);
                if (group1 != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {group1.Id}, Group name : {group1.Name}, Teacher name : {group1.Teacher}, Room name : {group1.Room}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found : ");
                    goto GroupId;
                }

            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                goto GroupId;
            }
        }

        public void GetAll()
        {
            List<Group> groups = groupService.GetAll();


            if (groups.Count > 0)
            {
                foreach (var item in groups)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group not found:");
               
            }
                
            
          
           
           

        }

        public void SearchByTeacherName()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Search group by teacher's name: ");
        TeacName: string searchTeacherName = Console.ReadLine();

            List<Group> resultTeachers = groupService.GetAllByTeacherName(searchTeacherName);
            if (resultTeachers.Count != 0)
            {
                foreach (var item in resultTeachers)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Teacher name not found : ");
                goto TeacName;
            }
        }

        public void GetAllByRoom()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Search group by room's name : ");
           string searcRoomName = Console.ReadLine();

            List<Group> resultRooms = groupService.GetAllByRoom(searcRoomName);
            if (resultRooms.Count != 0)
            {

                foreach (var item in resultRooms)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Room name not found : ");
                
            }
        }

        public void SearchByName()
        {
            Helper.WriteConsole(ConsoleColor.Blue, " Search group by name : ");
        SearchByName: string groupsByName = Console.ReadLine();

            List<Group> resultsearch = groupService.SearchGroupByNames(groupsByName);
            if (resultsearch.Count != 0)
            {

                foreach (var item in resultsearch)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {item.Id}, Group name : {item.Name}, Teacher name : {item.Teacher}, Room name : {item.Room}");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Group name not found : ");
                goto SearchByName;
            }

        }
        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id : ");
           GroupId: string groupId = Console.ReadLine();

            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                groupService.Delete(id);

            }

            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type: ");
                goto GroupId;
            }
        
           
        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add group id: ");
           Groupid: string updateGroupId = Console.ReadLine();

            int groupId;

            bool isGroupId = int.TryParse(updateGroupId, out groupId);

            if (isGroupId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add group  new name: ");
                string groupNewName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add group new teacher name: ");
                 NewTeacName : string groupNewTeacherName = Console.ReadLine();
                    for (int i = 0; i <= 9; i++)
                    {
                      if (groupNewTeacherName.Contains(i.ToString()))
                      {
                        Helper.WriteConsole(ConsoleColor.Red, "Teacher name is not correct: ");
                        goto NewTeacName;
                      }

                  }
                Helper.WriteConsole(ConsoleColor.Blue, "Add group new room name: ");
                string groupNewRoomName = Console.ReadLine();

                Group group = new Group()
                {
                    Name = groupNewName,
                    Teacher = groupNewTeacherName,
                    Room = groupNewRoomName 
                };

               var resultGroup = groupService.Update(groupId, group);

                if (resultGroup == null)
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Group not found, please try again:");
                    goto Groupid;
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Group id : {resultGroup.Id}, Group name : {resultGroup.Name}, Teacher name : {resultGroup.Teacher}, Room name : {resultGroup.Room}");
                }
            }
          
        }
    }
}

