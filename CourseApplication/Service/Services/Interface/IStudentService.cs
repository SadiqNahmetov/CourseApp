using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interface
{
    public interface IStudentService
    {
        Student Create(int groupId, Student student);

        Student Update(int id, Student student);

        Student GetById(int id);
        void Delete(int id);
        List<Student> GetStudentsByAge(int age);

        List<Student> Search(string search);
    }
}
