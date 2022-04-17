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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("New group1");
            /*
            group.Header = "Logo1";
            group.Footer = "Comment1";
            */
            FillGroupForm(group);
            SubmitGroupCreation();
            ReternToGroupsPage();
        }
    }
}
