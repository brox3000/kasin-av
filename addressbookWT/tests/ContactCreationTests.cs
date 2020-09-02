using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactGroup contact = new ContactGroup("Aleksey444", "Kasin444");
            contact.MiddleName = "";
            contact.NickName = "";
            contact.Company = "";
            contact.Title = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            contact.Email2 = "";
            contact.Email3 = "";
            contact.Homepage = "";
            //contact.Byear = "1990";
            //contact.Ayear = "2020";
            //contact.Bday = "2";
            //contact.Aday = "7";
            //contact.Bmonth = "March";
            //contact.Amonth = "May";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";


            // S4.0
            List<ContactGroup> oldContact = app.Contact.GetContactList();

            app.Contact.Create(contact); // Обращение на прямую к ContactHelper.cs

            List<ContactGroup> newContact = app.Contact.GetContactList();

            oldContact.Add(contact);
            newContact.Sort();
            oldContact.Sort();

            Assert.AreEqual(oldContact, newContact);

            // F4.0
        }
            
    }
}