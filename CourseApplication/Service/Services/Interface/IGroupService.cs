using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Service.Services.Interface
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id, Group group);
        void Delete(int id);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> GetAllByTeacherName(string name);
        List<Group> GetAllByRoom(string roomName);
        List<Group> SearchGroupByNames(string search);
    }
}
