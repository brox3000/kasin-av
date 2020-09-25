using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{

    [Table(Name = "addressbook")]

    public class ContactGroup : IEquatable<ContactGroup>, IComparable<ContactGroup>
    {
        private string allPhones;
        private string allEmails;

        public ContactGroup()
        {
        }

        public ContactGroup(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        // S4.0
        public bool Equals(ContactGroup other)
        {

            if (Object.ReferenceEquals(other.LastName, null) 
                && (Object.ReferenceEquals(other.FirstName, null) 
                && Object.ReferenceEquals(other.Id, null)))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other.LastName) 
                && (Object.ReferenceEquals(this, other.FirstName) 
                && (Object.ReferenceEquals(this, other.Id))))
            {
                return true;
            }

            return LastName == other.LastName && FirstName == other.FirstName && Id == other.Id;

        }
        // F4.0




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


        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address
        {
            get; set;
        }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "photo")]
        public string Photo { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactGroup> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }

        public List<GroupData> GetGroups()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups from gcr in db.GCR.Where(p => p.GroupId == g.Id && p.ContactId == Id
                        && g.Deprecated == "0000-00-00 00:00:00") select g).Distinct().ToList();
            }
        }
    }
}
