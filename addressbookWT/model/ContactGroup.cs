using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactGroup
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

        public ContactGroup(string amonth, string bmonth, string aday, string bday, string ayear, string byear, string notes, string phone2, string address2, string homepage, string email, string email2, string email3, string fax, string firstname, string middlename, string lastname, string nickname, string company, string title, string address,string home, string mobile, string work)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
            this.middlename = middlename;
            this.title = title;
            this.company = company;
            this.address = address;
            this.home = home;
            this.mobile = mobile;
            this.work = work;
            this.fax = fax;
            this.email = email;
            this.email2 = email2;
            this.email3 = email3;
            this.homepage = homepage;
            this.byear = byear;
            this.address2 = address2;
            this.phone2 = phone2;
            this.notes = notes;
            this.ayear = ayear;
            this.bday = bday;
            this.aday = aday;
            this.bmonth = bmonth;
            this.amonth = amonth;
        }

        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }

        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }

        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }

        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string NickName
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }

        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
    }
}
