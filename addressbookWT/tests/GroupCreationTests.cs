using System;
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

            // S4.0

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
            // F4.0 
        }

        [Test]

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            // 4.0
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //
        }

        [Test]

        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("kasin_group");
            group.Header = "";
            group.Footer = "";

            // 4.0
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs


            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //
        }
    }
}
