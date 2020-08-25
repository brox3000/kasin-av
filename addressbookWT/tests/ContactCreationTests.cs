﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {          
            ContactGroup group = new ContactGroup("Aleksey", "Kasin");
            group.MiddleName = "";
            group.NickName = "";
            group.Company = "";
            group.Title = "";
            group.Address = "";
            group.Home = "";
            group.Mobile = "";
            group.Work = "";
            group.Fax = "";
            group.Email = "";
            group.Email2 = "";
            group.Email3 = "";
            group.Homepage = "";
            //group.Byear = "1990";
            //group.Ayear = "2020";
            //group.Bday = "2";
            //group.Aday = "7";
            //group.Bmonth = "March";
            //group.Amonth = "May";
            group.Address2 = "";
            group.Phone2 = "";
            group.Notes = "";


            // 4.0
            //List<ContactGroup> oldGroups = app.Groups.GetContactList();

            app.Contact.Create(group); // Обращение на прямую к ContactHelper.cs

            //List<ContactGroup> newGroups = app.Groups.GetContactList();
            //oldGroups.Add(group);
            //oldGroups.Sort();
            //newGroups.Sort();
            //Assert.AreEqual(oldGroups, newGroups);
            //
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactGroup group = new ContactGroup("", "");
            group.MiddleName = "";
            group.NickName = "";
            group.Company = "";
            group.Title = "";
            group.Address = "";
            group.Home = "";
            group.Mobile = "";
            group.Work = "";
            group.Fax = "";
            group.Email = "";
            group.Email2 = "";
            group.Email3 = "";
            group.Homepage = "";
            //group.Byear = "";
            //group.Ayear = "";
            //group.Bday = "";
            //group.Aday = "";
            //group.Bmonth = "";
            //group.Amonth = "";
            group.Address2 = "";
            group.Phone2 = "";
            group.Notes = "";

            // 4.0

            app.Contact.Create(group); // Обращение на прямую к ContactHelper.cs

           //
        }

        [Test]
        public void BadNameContactCreationTest()
        {
            ContactGroup group = new ContactGroup("", "");
            group.MiddleName = "";
            group.NickName = "";
            group.Company = "";
            group.Title = "";
            group.Address = "";
            group.Home = "";
            group.Mobile = "";
            group.Work = "";
            group.Fax = "";
            group.Email = "";
            group.Email2 = "";
            group.Email3 = "";
            group.Homepage = "";
            //group.Byear = "";
            //group.Ayear = "";
            //group.Bday = "";
            //group.Aday = "";
            //group.Bmonth = "";
            //group.Amonth = "";
            group.Address2 = "";
            group.Phone2 = "";
            group.Notes = "";

            // 4.0

            app.Contact.Create(group); // Обращение на прямую к ContactHelper.cs

            //
        }
    }
}
