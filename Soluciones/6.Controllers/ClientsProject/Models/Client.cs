using System;

namespace ClientsProject.Models
{
    public class Client
    {
        public Client() { }

        public Client(int id, string name, string surname, int age, string email, Gender gender)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Gender = gender;
            LastUpdate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public void Update(string name, string surname, int age, string email, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Gender = gender;
            LastUpdate = DateTime.Now;
        }
    }
}
