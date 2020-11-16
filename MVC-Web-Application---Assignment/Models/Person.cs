using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Web_Application___Assignment.Model
{
    public class Person
    {
        private string name;
        private int age;
        private string street;
        private int postnum;
        private string city;
        private int telnum;
        private string email;

        public string Name { get { return name; } }
        public int Age { get { return age; } }
        public string Street { get { return street; } }
        public int PostNum { get { return postnum; } }
        public string City { get { return city; } }
        public string Email { get { return email; } }
        public int TelNum { get { return telnum; } }

        public Person (string personName, int personAge, string personStreet, int personPostnum, string personCity, int personTel, string personEmail)
        {
            name = personName;
            age = personAge;
            street = personStreet;
            postnum = personPostnum;
            city = personCity;
            telnum = personTel;
            email = personEmail;
        }


    }
}
