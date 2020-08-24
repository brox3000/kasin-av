using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            //if (!IsElementPresent(By.Name("entry")))
            if (!app.Contact.IsElementPresent(app.Contact.IsContactPresent))
            {

                ContactGroup contact = new ContactGroup("Aleksey_3.0", "Kasin_3.0");
                contact.Mobile = "+7(800)97531";
                contact.Email = "new_mail@mail.ru";
                contact.Address = "new_Moscow";

                app.Contact.Create(contact);
                app.Contact.Remove(1);
            }
            else
            {
                app.Contact.Remove(1);
            }
        }
    }
}


