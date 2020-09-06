using System;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;



namespace WebAddressbookTests
{

    [TestFixture]

    public class ContactInformationTest : AuthTestBase
    {

        [Test]
        public void TestContactInformation()
        {
            ContactGroup fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactGroup fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }

    }
}
