using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Models
{
    internal class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthsday;

        public Person(
            string firstName,
            string lastName,
            DateTime birthsday)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthsday = birthsday;
        }

        public Person()
        {
            this.firstName = "Denis";
            this.lastName = "Kudryavcev";
            this.birthsday = new DateTime(2004, 5, 16);
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public DateTime Birthsday
        {
            get { return this.birthsday; } 
            set { this.birthsday = value; }
        }

        public int BirthsdayYear
        {
            get { return this.birthsday.Year; }
            set { this.birthsday = new DateTime(
                value, 
                this.birthsday.Month, 
                this.birthsday.Day); }
        }

        public override string ToString()
        {
            return $"Name: {this.firstName} Last name: {this.lastName} Birthsday: {this.Birthsday}";
        }

        public virtual string ToShortString()
        {
            return $"{this.firstName} {this.lastName}";
        }
    }
}
