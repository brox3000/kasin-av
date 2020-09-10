using System;
using System.IO;
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
        // 5.5
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        // 6.0
        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();//создаем список
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]

                });


            }
            return groups;
        }
        //




        // The End 5.5

        [Test, TestCaseSource("GroupDataFromFile")]
        public void GroupCreationTest(GroupData group)
        {
            // S4.0


            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs

            //Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            
            Assert.AreEqual(oldGroups, newGroups);
            // F4.0 
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



            //Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //
        }
    }
}
