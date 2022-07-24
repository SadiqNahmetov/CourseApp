using Domain.Models;
using Repository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public Group Create(Group group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;
        }

        public void Delete(int id)
        {
            Group group = GetById(id);
            if (group == null) Console.WriteLine("Group nof found"); 
            _groupRepository.Delete(group);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(group.Name +" -- "+ "Deleted group");

        }
               
        public Group GetById(int id)
        {
            var group = _groupRepository.Get(m => m.Id == id);
            if (group is null) return null;
            return group;
        }

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group Update(int id, Group group)
        {
            Group dbGroup = GetById(id);
            if (dbGroup is null) return null;
            group.Id = dbGroup.Id;
           
            _groupRepository.Update(group);
            return dbGroup;
        }

        public List<Group> GetAllByTeacherName(string name)
        {
           return  _groupRepository.GetAll(m => m.Teacher.Trim().ToLower() == name.Trim().ToLower());
        }

        public List<Group> GetAllByRoom(string roomName)
        {
            return _groupRepository.GetAll(m => m.Room.Trim().ToLower() == roomName.Trim().ToLower());
        }

        public List<Group> SearchGroupByNames(string search)
        {
            return _groupRepository.GetAll(m => m.Name.Trim().ToLower() == search.Trim().ToLower());
        }

       
    }
}
