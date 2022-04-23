using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("New modify group");
            newData.Header = "Logo2";
            newData.Footer = "Comment2";

            app.Groups.Modify(1, newData);
        }
    }
}
