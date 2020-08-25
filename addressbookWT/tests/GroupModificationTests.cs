using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;




namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();

            if (!app.Groups.IsElementPresent(app.Groups.IsGroupPresent))
            {

                GroupData group = new GroupData("kasin_modif");
                group.Header = "A1_modif";
                group.Footer = "A2_modif";
                app.Groups.Create(group);


            }

            GroupData newData = new GroupData("kasin_modifData");
            newData.Header = "A1_modifData";
            newData.Footer = "A2_modifData";

            app.Groups.Modify(1, newData);
        }
    }
}



// 4.0
//namespace WebAddressbookTests.tests
//{
//    [TestFixture]

//    public class GroupModificationTests : AuthTestBase
//    {
//        [Test]

//        public void GroupModificationTest()
//        {
//            GroupData newData = new GroupData("kasin_edit3");
//            newData.Header = null;
//            newData.Footer = null;

//            List<GroupData> oldGroups = app.Groups.GetGroupList();

//            app.Groups.Modify(0, newData);

//            List<GroupData> newGroups = app.Groups.GetGroupList();
//            oldGroups[0].Name = newData.Name;
//            oldGroups.Sort();
//            newGroups.Sort();
//            Assert.AreEqual(oldGroups, newGroups);
//        }
//    }
//}
