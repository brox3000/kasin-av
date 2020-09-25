using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
        {

            app.Navigator.GoToHomePage();

            if (!app.Contact.IsElementPresent(app.Contact.IsContactPresent))
            {
                ContactGroup contact_kas = new ContactGroup("KasinRU", "Kasin_3.0");

                contact_kas.LastName = "Kasin_3.0";
                contact_kas.NickName = "KasinRU";
                contact_kas.Address = "AddressRU";

                app.Contact.Create(contact_kas);
            }

            app.Navigator.GoToHomePage();

            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent))
            {
                GroupData group_kas = new GroupData("Kasin_test");
                group_kas.Header = "Kasin_test";
                group_kas.Footer = "Kasin_test";

                app.Groups.Create(group_kas);
            }


            GroupData group = GroupData.GetAll()[0];
            List<ContactGroup> oldList = group.GetContacts();
            List<ContactGroup> oldContacts = ContactGroup.GetAll();
            ContactGroup contactToAdd = null;
            

            if (ContactGroup.GetAll().Except(oldList).ToList().Count == 0)
            {
                ContactGroup NewKasContact = new ContactGroup("KasinRU", "Kasin_3.1");

                NewKasContact.LastName = "Kasin_3.1";
                NewKasContact.NickName = "KasinRU_3.1";
                NewKasContact.Address = "AddressRU3.1";

                app.Contact.Create(NewKasContact);

                //
                List<ContactGroup> newContacts = ContactGroup.GetAll();
                List<ContactGroup> ContactsWithoutGroup = newContacts.Except(oldList).ToList();

                contactToAdd = ContactsWithoutGroup[0];
                app.Contact.AddContactToGroup(contactToAdd, group);

                List<ContactGroup> newList = group.GetContacts();

                oldList.Add(contactToAdd);
                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);


            }
            else
            {
                ContactGroup tokas_add = ContactGroup.GetAll().Except(oldList).First();
                app.Contact.AddContactToGroup(tokas_add, group);

                List<ContactGroup> newList = group.GetContacts();

                oldList.Add(tokas_add);

                newList.Sort();
                oldList.Sort();

                Assert.AreEqual(oldList, newList);

            }
        }
    }
}
