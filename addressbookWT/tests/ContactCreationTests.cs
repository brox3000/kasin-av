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
        // S4.0 - 5.0
        public static IEnumerable<ContactGroup> RandomContactDataProvider()
        {
            List<ContactGroup> oldContact = new List<ContactGroup>();
            for (int i = 0; i < 5; i++)
            {
                oldContact.Add(new ContactGroup(GenerateRandomString(20), GenerateRandomString(20))
                {
                    Address = GenerateRandomString(100)
                }
            );
            }
            return oldContact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateNewContact(ContactGroup contact)
        {

            List<ContactGroup> oldContact = app.Contact.GetContactList();
            app.Contact.Create(contact);
            List<ContactGroup> newContact = app.Contact.GetContactList();

            oldContact.Add(contact);
            newContact.Sort();
            oldContact.Sort();

            Assert.AreEqual(oldContact, newContact);
         // F4.0-5.0
        }
    }
}
