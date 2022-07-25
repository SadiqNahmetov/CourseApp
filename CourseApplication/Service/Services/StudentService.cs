using Domain.Models;
using Repository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        private int _count;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }

        public Student Create(int groupId, Student student)
        {
            var group = _groupRepository.Get(m => m.Id == groupId);
            if (group is null) return null;
            student.Id = _count;
            student.Group = group;
            _studentRepository.Create(student);
            _count++;
            return student;
        }

        public Student Update(int id, Student student)
        {
             Student dbStudent = GetById(id);
             if (dbStudent is null) return null;
             student.Id = dbStudent.Id;
             _studentRepository.Update(student);
             return dbStudent;
        }

        public Student GetById(int id)
        {
            var student = _studentRepository.Get(m => m.Id == id);
            if (student is null) return null;
            return student;
        }

        public void Delete(int id)
        {
            Student student = GetById(id);
            if (student== null) Console.WriteLine("Group nof found");
            _studentRepository.Delete(student);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(student.Name + " -- " + "Deleted group");
        }

       
        public List<Student> GetStudentsByAge(int age)
        {
            return _studentRepository.GetAll(m => m.Age == age);
        }

        public List<Student> Search( string search)
        {
            return _studentRepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(search.ToLower().Trim()) || m.Surname.Trim().ToLower().StartsWith(search.ToLower().Trim()));
        }

        public List<Student> GetAllStudentByGrupId(int id)
        {
            var datas = _studentRepository.GetAll(m => m.Group.Id == id);
            return datas;
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
    }
}
