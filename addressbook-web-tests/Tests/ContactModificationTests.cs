using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("Second name", "Second name");
            newContact.Middlename = null;
            newContact.Nickname = null;
            newContact.Title = null;
            newContact.Company = null;
            newContact.Address = null;
            newContact.Home = null;
            newContact.Mobile = null;
            newContact.Work = null;
            newContact.Fax = null;
            newContact.Email = null;
            newContact.Email2 = null;
            newContact.Email3 = null;
            newContact.Homepage = null;
            newContact.Byear = null;
            newContact.Bday = "3";
            newContact.Bmonth = "June";
            newContact.Ayear = null;
            newContact.Aday = "3";
            newContact.Amonth = "June";
            newContact.Address2 = null;
            newContact.Phone2 = null;
            newContact.Notes = null;
            newContact.New_group = "[none]";

            app.Contacts.ContactExistenceCheck();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}
