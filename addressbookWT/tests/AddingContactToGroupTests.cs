using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    //7.4
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactGroup> oldList = group.GetContacts();
            ContactGroup contact = ContactGroup.GetAll().Except(oldList).First();

            // actions

            app.Contact.AddContactToGroup(contact, group);

            List<ContactGroup> newList = group.GetContacts();

            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}