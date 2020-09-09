using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;



namespace WebAddressbookTests
{

    public class ContactHelper : HelperBase
    {

        public By IsContactPresent = By.Name("entry");
        // Конструктор

        public string GetContactInformationFromDetailsPage(int index)
        {
            manager.Navigator.GoToHomePage();


            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();

            string list = driver.FindElement(By.Id("content")).Text;


            return list;


        }

        // 5.0
        public ContactGroup GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactGroup(firstname, lastname)
            {

                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };

        }

        public ContactGroup GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactGroup(firstName, lastName)
            {
                Address = address,
                Mobile = mobile,
                Home = home,
                Work = work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactGroup ListofContactsEditPagee(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactGroup(firstname, lastname)
            {

                Address = address,
                Mobile = mobile,
                Home = home,
                Work = work,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };

        }


        public ContactHelper(ApplicationManager manager)
           : base(manager)
        {

        }


        // 3.0
        public ContactHelper Create(ContactGroup contact) // Метод называется с Большой Буквы
        {
            AddNewContact();
            NewContact(contact);       // Заполняем форму
            SubmitNewContact();
            ReturnToHomePage();
            return this;
        }


        public ContactHelper ModifyContact(int v, ContactGroup NewData)
        {
            SecectContact(v);
            InitContactModification(0);
            NewContact(NewData);         // Заполняем форму
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            SecectContact(v);
            RemoveContact();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper NewContact(ContactGroup contact)
        {
            // Name
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);


            // Company

            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);

            // Telephone
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);

            // Email
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);

            // Data 
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("ayear"), contact.Ayear);

            // Secondary
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);

            return this;
        }


        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            ContactCach = null;
            return this;
        }

        // Удаление контакта

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }


        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            ContactCach = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }


        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            ContactCach = null;
            return this;
        }

        // 5.0
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
           .FindElements(By.TagName("td"))[7]
           .FindElement(By.TagName("a")).Click();

            //driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();

            return this;
        }
        //

        public ContactHelper SecectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            //acceptNextAlert = true;
            return this;
        }


        // 4.0
        private List<ContactGroup> ContactCach = null;
        //private bool acceptNextAlert;

        internal List<ContactGroup> GetContactList()
        {
            if (ContactCach == null)
            {
                ContactCach = new List<ContactGroup>();
                manager.Navigator.GoToHomePage(); // Переход на Home Страницу

                // Прочитать Список
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    ContactCach.Add(new ContactGroup(cells[2].Text, cells[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")

                    });
                }
            }

            return new List<ContactGroup>(ContactCach);


        }


        // 5.0 &  ? Конфликт
        //public void InitContactModification(int index)
        //{
        //    driver.FindElements(By.Name("entry"))[index]
        //    .FindElements(By.TagName("td"))[7]
        //    .FindElement(By.TagName("a")).Click();
        //}

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }      //
}
