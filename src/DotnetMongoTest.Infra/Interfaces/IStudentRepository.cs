using System.Collections.Generic;
using DotnetMongoTest.Infra.Models;

namespace DotnetMongoTest.Infra.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        IEnumerable<Student> List();
        void Update(Student student);
        Student Detail(string id);
        void Delete(string id);
    }
}