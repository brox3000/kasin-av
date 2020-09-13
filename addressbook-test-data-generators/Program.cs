using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileType = args[0];

            int count = Convert.ToInt32(args[0]);

            string filename = args[1];
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            List<ContactGroup> contacts = new List<ContactGroup>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            // groups
            if (FileType == "group")
            {

                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);

                    if (format == "csv")
                    {
                        WriteGroupsToCsvFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                }
            }

            // contacts
            if (FileType == "contact")
            {
                for (int i = 1; i < count; i++)
                {
                    contacts.Add((new ContactGroup(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        Address = TestBase.GenerateRandomString(50),

                    }));
                }

                if (format == "excel")
                {
                    WriteContactsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);

                    if (format == "csv")
                    {
                        WriteContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                }
            }
        }

        // Format file Groups
        // CSV
        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer
                   ));
            }
        }

        // XML
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        // JSON
        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        //EXCEL
        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            sheet.Cells[1, 1] = "test";

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), filename));

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        // Format file Contacts
        // CSV
        static void WriteContactsToCsvFile(List<ContactGroup> contacts, StreamWriter writer)
        {
            foreach (ContactGroup contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    contact.FirstName,
                    contact.LastName,
                    contact.Address
                    ));
            }
        }
        // XML
        static void WriteContactsToXmlFile(List<ContactGroup> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactGroup>)).Serialize(writer, contacts);
        }

        // JSON
        static void WriteContactsToJsonFile(List<ContactGroup> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        //EXCEL
        static void WriteContactsToExcelFile(List<ContactGroup> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            sheet.Cells[1, 1] = "test";

            int row = 1;
            foreach (ContactGroup group in contacts)
            {
                sheet.Cells[row, 1] = group.FirstName;
                sheet.Cells[row, 2] = group.LastName;
                sheet.Cells[row, 3] = group.Address;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), filename));

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

    }
}