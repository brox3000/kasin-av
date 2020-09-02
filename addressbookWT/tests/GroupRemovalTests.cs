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

    // 4.0
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage(); //

            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent))
            {

                GroupData group = new GroupData("kasin_test1");
                group.Header = "kasin_test2";
                group.Footer = "kasin_test3";
                app.Groups.Create(group);

            }

            List<GroupData> OldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData RemovedG = OldGroups[0];
            OldGroups.RemoveAt(0);
            Assert.AreEqual(OldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, RemovedG.Id);
            }
        }
    }
}


/* 4.0		
List<GroupData> oldGroups = app.Groups.GetGroupList();

app.Groups.Remove(0);

Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

List<GroupData> newGroups = app.Groups.GetGroupList();

GroupData toBeRemoved = oldGroups[0];
oldGroups.RemoveAt(0);
Assert.AreEqual(oldGroups, newGroups);

foreach (GroupData group in newGroups)
{
    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
}
*/



