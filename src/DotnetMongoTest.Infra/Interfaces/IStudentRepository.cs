using System.Collections.Generic;
using DotnetMongoTest.Infra.Models;
using MongoDB.Bson;

namespace DotnetMongoTest.Infra.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        IEnumerable<Student> List();
        void Update(Student student);
        Student Detail(ObjectId id);
        void Delete(ObjectId id);
    }
}