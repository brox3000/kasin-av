using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;



namespace WebAddressbookTests
{
    public class ContactGroup : IEquatable<ContactGroup>, IComparable<ContactGroup>
    {
        private string allPhones;
        private string allEmails;

        public ContactGroup(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        // S4.0
        public bool Equals(ContactGroup other)
        {

            if (Object.ReferenceEquals(other.LastName, null) && (Object.ReferenceEquals(other.FirstName, null)))
            {
                return false;
            }

            return LastName == other.LastName
                && FirstName == other.FirstName;

        }
        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }

        public override string ToString()
        {
            return ("lastname=" + LastName + "\nfirstname=" + FirstName + "\naddress=" + Address);
            //return LastName;
        }

        public int CompareTo(ContactGroup other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if ((LastName.CompareTo(other.LastName)) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return (LastName.CompareTo(other.LastName));
        }
        // F4.0

        public string Amonth { get; set; }
        public string Bmonth { get; set; }
        public string Aday { get; set; }
        public string Bday { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        //

        // Phone 5.0
        public string AllPhones

        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }

            }

            set
            {
                allPhones = value;
            }
        }



        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "([-()])", "") + "\r\n";
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
        // Phones The End



        // Email 5.0
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
                }

            }


            set
            {
                allEmails = value;
            }
        }


        private string CleanUpEmails(string emailup)
        {
            if (emailup == null || emailup == "")
            {
                return "";
            }
            else
            {
                return emailup.Replace(" ", "") + "\r\n";
            }

        }
        // Email The End 5.0
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
