using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
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

            ContactGroup NewData = new ContactGroup("Aleksey_edit3", "Kasin_edit3");
            NewData.Mobile = "+7(800)13";
            NewData.Email = "mail3@mail.ru";
            NewData.Address = "Moscow3";

            List<ContactGroup> oldContact = app.Contact.GetContactList();

            app.Contact.ModifyContact(1, NewData);



            List<ContactGroup> newContact = app.Contact.GetContactList();

            ContactGroup oldData = oldContact[0];



            oldContact[0].FirstName = NewData.FirstName;
            oldContact[0].LastName = NewData.LastName;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

            foreach (ContactGroup contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(NewData.FirstName, contact.FirstName);
                    Assert.AreEqual(NewData.LastName, contact.LastName);
                }
            }
        }
    }
}