using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {

            if (!app.Contact.IsElementPresent(app.Contact.IsContactPresent))
            {

                ContactGroup contact = new ContactGroup("Aleksey_3.0", "Kasin_3.0");
                contact.Mobile = "+7(800)97531";
                contact.Email = "new_mail@mail.ru";
                contact.Address = "new_Moscow";

                app.Contact.Create(contact);

            }

            app.Navigator.GoToHomePage();

            List<ContactGroup> oldContact = app.Contact.GetContactList();

            app.Contact.Remove(1);

            List<ContactGroup> newContact = app.Contact.GetContactList();

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);

        }
    }
}


