using System.Collections.Generic;
using DotnetMongoTest.Infra.Interfaces;
using DotnetMongoTest.Infra.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DotnetMongoTest.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> collection;

        public StudentRepository(IMongoContext context)
        {
            collection = context.GetCollection<Student>("students");
        }

        public void Add(Student student)
        {
            collection.InsertOne(student);
        }

        public void Delete(ObjectId id)
        {
            collection.DeleteOne(s => s.Id == id);
        }

        public Student Detail(ObjectId id)
        {
            return collection.Find(s => s.Id == id)
                .SingleOrDefault();
        }

        public IEnumerable<Student> List()
        {
            return collection.Find(s => true)
                .ToList();
        }

        public void Update(Student student)
        {
            if(collection.CountDocuments(s => s.Id == student.Id) > 0)
            {
                collection.ReplaceOne(s => s.Id == student.Id, student);
            }
            // TODO: Tratar erro
        }
    }
}