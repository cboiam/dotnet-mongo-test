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

        public void Delete(string id)
        {
            collection.DeleteOne(s => s.Id == ObjectId.Parse(id));
        }

        public Student Detail(string id)
        {
            return collection.Find(s => s.Id == ObjectId.Parse(id))
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