using Lab_4.Interfaces;

namespace Lab_4.Models
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
        public DateTime Date { get; set; }

        public int BirthsdayYear
        {
            get { return this.birthsday.Year; }
            set
            {
                this.birthsday = new DateTime(
                value,
                this.birthsday.Month,
                this.birthsday.Day);
            }
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} {this.Birthsday}";
        }

        public object DeepCopy()
        {
            return new Person(this.firstName, this.lastName, this.birthsday);
        }

        public virtual string ToShortString()
        {
            return $"{this.firstName} {this.lastName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            Person person = (Person) obj;

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
