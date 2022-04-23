using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToAddNewPage();
            ContactData contact = new ContactData("First name", "Last name");
            /*
            contact.Middlename = "Middle name";
            contact.Nickname = "Nickname";
            contact.Title = "Title";
            contact.Company = "Company";
            contact.Address = "Address";
            contact.Home = "Home";
            contact.Mobile = "Mobile";
            contact.Work = "Work";
            contact.Fax = "Fax";
            contact.Email = "Email";
            contact.Email2 = "Email2";
            contact.Email3 = "Email3";
            contact.Homepage = "Homepage";
            contact.Byear = "2001";
            contact.Ayear = "2001";
            contact.Address2 = "Address2";
            contact.Phone2 = "Phone2";
            contact.Notes = "Notes";
            */
            app.Contacts
                .FillContactForm(contact)
                .SaveContactForm()
                .ReternToAddNewPage();
        }
    }
}
