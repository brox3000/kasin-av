using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactUIDB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactGroup> FromUI = app.Contact.GetContactList();
                List<ContactGroup> FromDB = ContactGroup.GetAll();
                FromUI.Sort();
                FromDB.Sort();
                Assert.AreEqual(FromUI, FromDB);

            }
        }

    }
}