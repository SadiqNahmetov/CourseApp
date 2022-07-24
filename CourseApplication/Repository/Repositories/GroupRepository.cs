using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found");
                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public void Update(Group data)
        {
            Group group = Get(m => m.Id == data.Id);
            if (!string.IsNullOrEmpty(data.Name))
                group.Name = data.Name;

            if (!string.IsNullOrEmpty(data.Teacher))
                group.Teacher = data.Teacher;

            if (!string.IsNullOrEmpty(data.Room))
                group.Room = data.Room;


        }
    }
}
