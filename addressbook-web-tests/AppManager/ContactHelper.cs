﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewPage();

            FillContactFormWithoutGroup(contact);
            AddGroupInContact(contact);
            SaveContactForm();
            Thread.Sleep(500);
            manager.Navigator.OpenHomePage();
            Thread.Sleep(500);
            return this;
        }
        public ContactHelper Modify(int v, ContactData newContact)
        {
            manager.Navigator.OpenHomePage();

            ChooseContact(v);
            InitContactModification(v);
            FillContactFormWithoutGroup(newContact);
            SubmitContactModification();
            ReternToHomePage();
            manager.Navigator.OpenHomePage();
            Thread.Sleep(250);
            return this;
        }

        public ContactHelper Remove(int a)
        {
            manager.Navigator.OpenHomePage();

            ChooseContact(a);
            DeleteContact();
            ConfirmContactDeletion();
            ReternToHomePage();
            manager.Navigator.OpenHomePage();
            Thread.Sleep(250);
            return this;
        }

        public ContactHelper ReternToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper FillContactFormWithoutGroup(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            /*
            driver.FindElement(By.Name("photo")).Click();
            driver.FindElement(By.Name("photo")).Clear();
            driver.FindElement(By.Name("photo")).SendKeys("C:\\fakepath\\Cat.jpg");
            */
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);

            Select(By.Name("bday"), contact.Bday);
            Select(By.Name("bmonth"), contact.Bmonth);

            Type(By.Name("byear"), contact.Byear);

            Select(By.Name("aday"), contact.Aday);
            Select(By.Name("amonth"), contact.Amonth);

            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper AddGroupInContact(ContactData contact)
        {
            Select(By.Name("new_group"), contact.New_group);
            return this;
        }
        public ContactHelper SaveContactForm()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }
        /*
        public ContactHelper ReternToAddNewPage()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
        */
        public ContactHelper ChooseContact(int index)
        {
            driver.FindElement(By.XPath("//tr[@name=\"entry\"][" + (index+1) + "]//input[@type='checkbox']")).Click();
            acceptNextAlert = true;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//tr[@name=\"entry\"][" + (index+1) + "]//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ConfirmContactDeletion()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public bool FindContact()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        public void ContactExistenceCheck()
        {
            manager.Navigator.OpenHomePage();

            if (FindContact())
            {
                return;
            }
            CreateFirstContact();
        }

        public void CreateFirstContact()
        {
            manager.Navigator.GoToAddNewPage();

            ContactData contact = new ContactData("First name", "Last name1");

            FillContactFormWithoutGroup(contact);
            AddGroupInContact(contact);
            SaveContactForm();
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    cells.GetEnumerator();
                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }
    }

}

