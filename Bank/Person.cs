using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Person(string name, string surname)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} can't be equal to null or empty!");
            }

            if (string.IsNullOrEmpty(surname))
            {
                throw new ArgumentException($"{nameof(surname)} can't be equal to null or empty!");
            }

            Name = name;
            Surname = surname;
        }
    }
}
