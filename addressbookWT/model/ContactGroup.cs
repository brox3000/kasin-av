using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



namespace WebAddressbookTests
{
    public class ContactGroup : IEquatable<ContactGroup>, IComparable<ContactGroup>
    {
        private string firstname;
        private string lastname = "";
        private string nickname = "";
        private string middlename = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string byear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
        private string ayear = "";
        private string bday = "";
        private string aday = "";
        private string bmonth = "";
        private string amonth = "";

        public ContactGroup(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
		
		// S4.0
        public bool Equals(ContactGroup other)
        {

            if (Object.ReferenceEquals(other.lastname, null) && (Object.ReferenceEquals(other.firstname, null)))
            {
                return false;
            }

            return lastname == other.lastname && firstname == other.firstname;
 
        }
        public override int GetHashCode()
        {
          return lastname.GetHashCode();
        }

        public override string ToString()
        {
           return lastname;
        }

        public int CompareTo(ContactGroup other)
        {
          if (object.ReferenceEquals(other, null))

           {
                return 1;
           }

        
         if ((lastname.CompareTo(other.lastname)) == 0)

          {
              return firstname.CompareTo(other.firstname);
          }

            return (lastname.CompareTo(other.lastname));

        }
		// F4.0
		
        public string Amonth { get; set; }

        public string Bmonth { get; set; }

        public string Aday { get; set; }

        public string Bday { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string MiddleName { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Byear { get; set; }

        public string Ayear { get; set; }

        public string Id { get; set; }
    }
}
