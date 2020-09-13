using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        // S4.0 - 5.0
        public static IEnumerable<ContactGroup> RandomContactDataProvider()
        {
            List<ContactGroup> oldContact = new List<ContactGroup>();
            for (int i = 0; i < 5; i++)
            {
                oldContact.Add(new ContactGroup(GenerateRandomString(20), GenerateRandomString(20))

                {
                    Address = GenerateRandomString(100)
                }
            );
            }
            return oldContact;

        }

        // 6.0 Format
        // CSV
        public static IEnumerable<ContactGroup> ContactDataFromCsvFile()

        {
            List<ContactGroup> contact = new List<ContactGroup>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');

                contact.Add(new ContactGroup(parts[0], parts[1])
                {
                    Address = parts[2]
                });

            }
            return contact;
        }

        // XML
        public static IEnumerable<ContactGroup> ContactDataFromXmlFile()
        {
            List<ContactGroup> contact = new List<ContactGroup>();

            return (List<ContactGroup>)new XmlSerializer(typeof(List<ContactGroup>))
                .Deserialize(new StreamReader("contacts.xml"));
        }

        // JSON
        public static IEnumerable<ContactGroup> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactGroup>>
              (
              File.ReadAllText(@"contacts.json")
              );
        }

        [Test, TestCaseSource("ContactDataFromCsvFile")]
        public void CreateNewContact(ContactGroup contact)
        {

            List<ContactGroup> oldContact = app.Contact.GetContactList();
            app.Contact.Create(contact);
            List<ContactGroup> newContact = app.Contact.GetContactList();

            oldContact.Add(contact);

            newContact.Sort();
            oldContact.Sort();

            Assert.AreEqual(oldContact, newContact);
            // F4.0-5.0
        }
    }
}
