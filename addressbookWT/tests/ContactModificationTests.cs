using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            if (!IsElementPresent(By.Name("entry")))
            {

                ContactGroup contact = new ContactGroup("Aleksey_3.0", "Kasin_3.0");
                contact.Mobile = "+7(800)97531";
                contact.Email = "new_mail@mail.ru";
                contact.Address = "new_Moscow";

                app.Contact.Create(contact);

                ContactGroup NewData = new ContactGroup("Aleksey_edit3", "Kasin_edit3");
                NewData.Mobile = "+7(800)13";
                NewData.Email = "mail3@mail.ru";
                NewData.Address = "Moscow3";

                app.Contact.Modify(1, NewData);
            }
            else
            {
                app.Navigator.GoToHomePage();

                ContactGroup NewData = new ContactGroup("Aleksey_edit3", "Kasin_edit3");
                NewData.Mobile = "+7(800)13";
                NewData.Email = "mail3@mail.ru";
                NewData.Address = "Moscow3";

                app.Contact.Modify(1, NewData);
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                app.Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}