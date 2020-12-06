using System;
using MongoDB.Bson;

namespace DotnetMongoTest.Infra.Models
{
    public record Student
    {
        public ObjectId Id { get; private set; }
        public string Name { get; init; }
        public DateTime Birth { get; init; }
        public int Semester { get; init; }

        public Student() { }

        public Student(string id)
        {
            Id = ObjectId.Parse(id);
        }

        public override string ToString()
        {
            var birth = Birth.ToString("dd/MM/yyyy");
            return $"{Id}, {Name}, {birth}, {Semester}";
        }
    }
}