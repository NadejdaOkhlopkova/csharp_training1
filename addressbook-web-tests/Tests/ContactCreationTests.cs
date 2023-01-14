using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("First name", "Last name1");
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
            contact.Bday = "3";
            contact.Bmonth = "June";
            contact.Ayear = "2001";
            contact.Aday = "3";
            contact.Amonth = "June";
            contact.Address2 = "Address2";
            contact.Phone2 = "Phone2";
            contact.Notes = "Notes";
            contact.New_group = "[none]";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Byear = "";
            contact.Bday = "0";
            contact.Bmonth = "-";
            contact.Ayear = "";
            contact.Aday = "0";
            contact.Amonth = "-";
            contact.New_group = "[none]";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
