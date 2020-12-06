using System;
using MongoDB.Bson;

namespace DotnetMongoTest.Infra.Models
{
    public class Student
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public int Semester { get; set; }

        public override string ToString()
        {
            var birth = Birth.ToString("dd/MM/yyyy");
            return $"{Id}, {Name}, {birth}, {Semester}";
        }
    }
}