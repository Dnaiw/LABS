
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Lab2.Interfaces;

namespace Lab2.Models
{
    internal class Person: IDateAndCopy
    {
        protected string firstName;
        protected string lastName;
        protected DateTime birthsday;

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
            firstName = "Denis";
            lastName = "Kudryavcev";
            birthsday = new DateTime(2004, 5, 16);
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime Birthsday
        {
            get { return birthsday; }
            set { birthsday = value; }
        }
        public DateTime Date { get; set; }

        public int BirthsdayYear
        {
            get { return birthsday.Year; }
            set
            {
                birthsday = new DateTime(
                value,
                birthsday.Month,
                birthsday.Day);
            }
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} {Birthsday}";
        }

        public object DeepCopy()
        {
            return new Person(this.firstName, this.lastName, this.birthsday);
        }

        public virtual string ToShortString()
        {
            return $"{firstName} {lastName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Person person = obj as Person;


            return (this.firstName.Equals(person.FirstName) &&
                    this.lastName.Equals(person.LastName) &&
                    this.birthsday.Equals(person.Birthsday));
        }

        public static bool operator ==(Person left, Person right)
        {
            return left.Equals(right); 
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left.Equals(right));
        }

        public override int GetHashCode()
        {
            return this.firstName.GetHashCode() +
                   this.lastName.GetHashCode() +
                   this.birthsday.GetHashCode();
        }
    }
}
