using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{

    public class DeleteContactGroup : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroup()
        {
            app.Navigator.GoToHomePage();

            if (!app.Contact.IsElementPresent(app.Contact.IsContactPresent))
            {
                ContactGroup contact = new ContactGroup("KasinRU", "Kasin_3.0");

                contact.LastName = "Kasin_3.0";
                contact.NickName = "KasinRU";
                contact.Address = "addressRU";

                app.Contact.Create(contact);
            }
            app.Navigator.GoToHomePage();
            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent))
            {
                GroupData group = new GroupData("Kasin_test");
                group.Header = "Kasin_test";
                group.Footer = "Kasin_test";

                app.Groups.Create(group);
            }

            app.Navigator.GoToHomePage();
            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent) && !app.Contact.IsElementPresent(app.Contact.IsContactPresent))
            {
                ContactGroup contact = new ContactGroup("KasinRU", "Kasin_3.0");
                contact.LastName = "Kasin_3.0";
                contact.Address = "addressRU";

                app.Contact.Create(contact);


                GroupData group = new GroupData("Kasin_test");
                group.Header = "Kasin_test";
                group.Footer = "Kasin_test";

                app.Groups.Create(group);
            }

            foreach (ContactGroup contact in ContactGroup.GetAll())
            {
                GroupData group = GroupData.GetAll()[0];
                List<GroupData> groupn = contact.GetGroups();
                List<ContactGroup> oldList = group.GetContacts();

                if (groupn.Count == 0)
                {
                    app.Contact.AddContactToGroup(contact, group);
                    oldList = group.GetContacts();
                    app.Contact.RemoveContactFromGroup(contact, group);
                }
                else
                {
                    app.Contact.RemoveContactFromGroup(contact, group);
                }

                oldList.RemoveAt(0);

                List<ContactGroup> newList = group.GetContacts();
                Assert.AreEqual(oldList, newList);

                foreach (ContactGroup contacts in ContactGroup.GetAll())
                {
                    Assert.AreNotEqual(group.Id, contact.Id);
                }
            }
        }
    }
}
