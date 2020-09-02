using System.Collections.Generic;
using NUnit.Framework;


//4.0
namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage(); //

            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent))
            {

                GroupData group = new GroupData("kasin_test1");
                group.Header = "kasin_test2";
                group.Footer = "kasin_test3";
                app.Groups.Create(group);

            }

            GroupData newData = new GroupData("kasin_modif1");
            newData.Header = "kasin_modif2";
            newData.Footer = "kasin_modif3";
            List<GroupData> OldGroups = app.Groups.GetGroupList();

            app.Groups.ModifyGroup(1, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            OldGroups[0].Name = newData.Name;

            OldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(OldGroups, newGroups);

        }
    }
}