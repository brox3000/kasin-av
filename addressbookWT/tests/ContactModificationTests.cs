using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactGroup NewData = new ContactGroup("Aleksey_edit2", "Kasin_edit2");
            NewData.Mobile = "+7(800)12";
            NewData.Email = "mail2@mail.ru";
            NewData.Address = "Moscow2";

            app.Contact.Modify(1, NewData);
        }
    }
}
