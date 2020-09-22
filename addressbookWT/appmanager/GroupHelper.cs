using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public By IsGroupPresent = By.ClassName("group");
        public GroupHelper(ApplicationManager manager)
           : base(manager)

        {
        }

        public GroupHelper Create(GroupData group)  // Метод называется с Большой Буквы
        {
            manager.Navigator.GoToGroupsPage();

            InitGroupCreation();
            FillGroupFrom(group); // Заполняем форму
            SubmitGroupCreation();
            ReturnToGroupsPage(); // Возвращание на список групп
            return this;
        }

        public GroupHelper ModifyGroup(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(p);
            InitGroupModification(); // Egit Group
            FillGroupFrom(newData); // Заполняем форму
            SubmitGroupModification(); // Update Group
            ReturnToGroupsPage(); // Возвращание на список групп
            return this;
        }

        //7.4
        public GroupHelper AddChanges(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupFrom(newData); // Заполняем форму
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }
        //

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        //7.1
        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        //

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupFrom(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        //7.2
        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }
        //

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        // 4.0
        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();
                    }
                }
            }

            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
