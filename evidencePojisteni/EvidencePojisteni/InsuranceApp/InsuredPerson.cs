using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp
{
    // třída pojištěná osoba
    public class InsuredPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        // konstuktor pojištěné osoby
        public InsuredPerson(string firstName, string lastName, int age, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        // přepsaná metoda ToString() pro výpis pojištěné osoby
        public override string ToString()
        {
            return $"{FirstName} {LastName}, věk: {Age}, telefon: {PhoneNumber}";
        }
    }
}
