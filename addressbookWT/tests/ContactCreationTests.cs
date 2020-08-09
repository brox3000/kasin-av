using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
            ContactGroup group = new ContactGroup("Aleksey", "Kasin");
            group.MiddleName = "";
            group.NickName = "";
            group.Company = "";
            group.Title = "";
            group.Address = "";
            group.Home = "";
            group.Mobile = "";
            group.Work = "";
            group.Fax = "";
            group.Email = "";
            group.Email2 = "";
            group.Email3 = "";
            group.Homepage = "";
            group.Byear = "1990";
            group.Ayear = "2020";
            group.Bday = "2";
            group.Aday = "7";
            group.Bmonth = "March";
            group.Amonth = "May";
            group.Address2 = "";
            group.Phone2 = "";
            group.Notes = "";

            NewContact(group);
            CreateNewContact();
            ReturnToHomePage();
        }
    }
}
