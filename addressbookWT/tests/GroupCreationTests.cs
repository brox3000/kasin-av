﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
           GroupData group = new GroupData("kasin");
           group.Header = "T1";
           group.Footer = "T2";
            
           // 4.0
           //List<GroupData> oldGroups = app.Groups.GetGroupList();

           app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs
           
           //List<GroupData> newGroups = app.Groups.GetGroupList();
           //oldGroups.Add(group);
           //oldGroups.Sort();
           //newGroups.Sort();
           //Assert.AreEqual(oldGroups, newGroups); 
           // 4.0 
        }

        [Test]

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            // 4.0
            //List<GroupData> oldGroups = app.Groups.GetGroupList();

            //app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            //oldGroups.Add(group);
            //oldGroups.Sort();
            //newGroups.Sort();
            //Assert.AreEqual(oldGroups, newGroups);
            //
        }

        [Test]

        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            // 4.0
            //List<GroupData> oldGroups = app.Groups.GetGroupList();

            //app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            //oldGroups.Add(group);
            //oldGroups.Sort();
            //newGroups.Sort();
            //Assert.AreEqual(oldGroups, newGroups);
            //
        }
    }
}
