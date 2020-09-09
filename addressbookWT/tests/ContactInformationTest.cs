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

            string fromDetails = app.Contact.GetContactInformationFromDetailsPage(0);
            ContactGroup fromEditPage = app.Contact.ListofContactsEditPagee(0);

            string FLName;
            string WAddress;
            string WHome;
            string WEmail;
            //string WMobile;
            //string WWork;
            //string WEmail2;
            //string WEmail3;



            // Firstname? FirstName? Lastname & LastName?
            if (fromEditPage.FirstName != "" && fromEditPage.LastName != "")
            {
                FLName = Convert.ToString(fromEditPage.FirstName + " " + fromEditPage.LastName).Trim();
            }
            else
            {
                FLName = "";
            }

            if (fromEditPage.FirstName != "" && fromEditPage.LastName == "")
            {

                FLName = Convert.ToString(fromEditPage.FirstName).Trim();
            }
            if (fromEditPage.FirstName == "" && fromEditPage.LastName != "")
            {

                FLName = Convert.ToString(fromEditPage.LastName).Trim();
            }



            if (fromEditPage.Address != "")
            {
                WAddress = Convert.ToString("\r\n" + fromEditPage.Address);

            }
            else
            {
                WAddress = "";
            }


            if (fromEditPage.Home != "" && fromEditPage.Mobile != "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString("H: " + fromEditPage.Home + "\r\n" + "M: " + fromEditPage.Mobile + "\r\n" + "W: " + fromEditPage.Work + "\r\n" + "\r\n").Trim();

            }
            else
            {
                WHome = ""; ;
            }
            if (fromEditPage.Home == "" && fromEditPage.Mobile != "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString("M: " + fromEditPage.Mobile + "\r\n" + "W: " + fromEditPage.Work + "\r\n" + "\r\n").Trim();

            }
            if (fromEditPage.Home != "" && fromEditPage.Mobile == "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString("\r\n" + "H: " + fromEditPage.Home + "\r\n" + "W: " + fromEditPage.Work + "\r\n" + "\r\n").Trim();

            }
            if (fromEditPage.Home != "" && fromEditPage.Mobile != "" && fromEditPage.Work == "")
            {
                WHome = Convert.ToString("\r\n" + "H: " + fromEditPage.Home + "\r\n" + "M: " + fromEditPage.Mobile + "\r\n" + "\r\n").Trim();

            }

            if (fromEditPage.Home != "" && fromEditPage.Mobile == "" && fromEditPage.Work == "")
            {
                WHome = Convert.ToString("\r\n" + "H: " + fromEditPage.Home + "\r\n" + "\r\n").Trim();

            }

            if (fromEditPage.Home == "" && fromEditPage.Mobile != "" && fromEditPage.Work == "")
            {
                WHome = Convert.ToString("\r\n" + "M: " + fromEditPage.Mobile + "\r\n" + "\r\n").Trim();

            }
            if (fromEditPage.Home == "" && fromEditPage.Mobile == "" && fromEditPage.Work != "")
            {
                WHome = Convert.ToString("\r\n" + "W: " + fromEditPage.Work + "\r\n" + "\r\n").Trim();

            }


            if (fromEditPage.Email != "" && fromEditPage.Email2 != "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString(fromEditPage.Email + "\r\n" + fromEditPage.Email2 + "\r\n" + fromEditPage.Email3).Trim();

            }
            else
            {
                WEmail = null;
            }


            if (fromEditPage.Email == "" && fromEditPage.Email2 != "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString(fromEditPage.Email2 + "\r\n" + fromEditPage.Email3).Trim();

            }

            if (fromEditPage.Email != "" && fromEditPage.Email2 == "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString(fromEditPage.Email + "\r\n" + fromEditPage.Email3).Trim();

            }
            if (fromEditPage.Email != "" && fromEditPage.Email2 != "" && fromEditPage.Email3 == "")
            {
                WEmail = Convert.ToString(fromEditPage.Email + "\r\n" + fromEditPage.Email2).Trim();

            }
            if (fromEditPage.Email != "" && fromEditPage.Email2 == "" && fromEditPage.Email3 == "")
            {
                WEmail = Convert.ToString(fromEditPage.Email).Trim();

            }
            if (fromEditPage.Email == "" && fromEditPage.Email2 != "" && fromEditPage.Email3 == "")
            {
                WEmail = Convert.ToString(fromEditPage.Email2).Trim();

            }
            if (fromEditPage.Email == "" && fromEditPage.Email2 == "" && fromEditPage.Email3 != "")
            {
                WEmail = Convert.ToString(fromEditPage.Email3).Trim();

            }

            string EditList = (FLName + WAddress + "\r\n" + "\r\n" + WHome + "\r\n" + "\r\n" + WEmail).Trim();


            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromDetails, EditList);
        }
    }
}
