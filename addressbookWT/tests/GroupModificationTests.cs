using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    [TestFixture]

    public class GroupModificationTests : TestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("kasin_edit");
            newData.Header = "T1_edit";
            newData.Footer = "T2_edit";

            app.Groups.Modify(1, newData);
        }
    }
}
