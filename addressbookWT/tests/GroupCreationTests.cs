using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("kasin");
            group.Header = "T1";
            group.Footer = "T2";

            app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs строка №19
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);  // Обращение на прямую к GroupHelper.cs строка №19
        }
    }
}
