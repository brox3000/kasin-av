using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]

    public class ContactModificationTests : TestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactGroup NewData = new ContactGroup("Aleksey_edit5", "Kasin_edit5");
            NewData.Mobile = "+7(800)10";
            NewData.Email = "mail@mail.ru";
            NewData.Address = "Moscow";

            app.Contact.Modify(1, NewData);
        }
    }
}
