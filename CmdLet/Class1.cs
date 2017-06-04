using System;
using System.Management.Automation;
using System.Xml.Linq;

namespace CmdLet
{
    [Cmdlet(VerbsCommon.Get, "Help")]
    public class About : Cmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject("======================================================================================");
            WriteObject("=                                                                                    =");
            WriteObject("=               New-File to create new XML file at User directory                    =");
            WriteObject("=               Add-User to add users                                                =");
            WriteObject("=                    Add-User -> Name is mandatory field and could not be empty      =");
            WriteObject("=               Remove-User to Delete user by ID                                     =");
            WriteObject("=               Get-List to get user list                                            =");
            WriteObject("=               Get-Help to get Help                                                 =");
            WriteObject("=               Get-Update to update user address and email by ID                    =");
            WriteObject("=               Get-Check to check address and email field not empty                 =");
            WriteObject("=                                                                                    =");
            WriteObject("======================================================================================");
        }
    }

    [Cmdlet(VerbsCommon.New, "File")]
    public class NewFile : Cmdlet
    {
        protected override void ProcessRecord()
        {
            SaveFile();
            WriteObject("======================================================================================");
            WriteObject("=                                                                                    =");
            WriteObject("=               New file %USERPROFILE%\\test-em.xml was created                      =");
            WriteObject("=                                                                                    =");
            WriteObject("======================================================================================");
        }
        /// <summary>
        /// Create and Save ne file in users directory
        /// </summary>
        private void SaveFile()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XComment("Test assigment file"),
                new XElement("Users"));
            XElement root = new XElement("Index");
            root.Add(new XAttribute("Of", 0));
            xDoc.Element("Users").Add(root);
            // Save to Disk
            xDoc.Save("test-em.xml");
        }
    }

    [Cmdlet(VerbsCommon.Add, "User")]
    public class AddUser : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string name;

        [Parameter(Mandatory = true, Position = 1)]
        [AllowEmptyString]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string address;

        
        [Parameter(Mandatory = true, Position = 2)]
        [AllowEmptyString]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string email;

        /// <summary>
        /// Prints result of adding
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteObject("======================================================================================");
            WriteObject("=                                                                                    =");
            WriteObject("=  User "+Name+" Address: "+Address+" email: "+Email+" Added to list");
            WriteObject("=                                                                                    =");
            WriteObject("=  ID "+AddUserToFile()+" user added");
            WriteObject("======================================================================================");
        }
        /// <summary>
        /// Adding user to file
        /// </summary>
        /// <returns>Number of users</returns>
        private int AddUserToFile()
        {
            XDocument xDoc = XDocument.Load("test-em.xml");
            int users = Int32.Parse(xDoc.Root.Element("Index").Attribute("Of").Value);
            users++;

            XElement root = new XElement("User");
            root.Add(new XElement("name", Name));
            root.Add(new XElement("address", Address));
            root.Add(new XElement("email", Email));
            root.Add(new XElement("ID", users));
            xDoc.Element("Users").Add(root);

            xDoc.Root.Element("Index").Attribute("Of").Value=users.ToString();

            xDoc.Save("test-em.xml");
            return users;
        }
    }
    [Cmdlet(VerbsCommon.Get, "List")]
    public class GetList : Cmdlet
    {
        protected override void ProcessRecord()
        {

            XElement xelement = XElement.Load("test-em.xml");
            foreach (XElement xEle in xelement.Elements("User"))
            {
                WriteObject("======================================================================================");
                WriteObject("ID: " + (string)xEle.Element("ID").Value);
                WriteObject("Name: "+(string)xEle.Element("name").Value);
                WriteObject("Address: " + (string)xEle.Element("address").Value);
                WriteObject("Email: " + (string)xEle.Element("email").Value);
            }
            WriteObject("======================================================================================");
        }
        
    }

    [Cmdlet(VerbsCommon.Get, "Check")]
    public class GetCheck : Cmdlet
    {
        protected override void ProcessRecord()
        {

            XElement xelement = XElement.Load("test-em.xml");

            foreach (XElement xEle in xelement.Elements("User"))
            {
                if ((string) xEle.Element("address").Value == "")
                {
                    WriteObject("User ID = "+ (string)xEle.Element("ID").Value+ " has empty address ");
                }
                if ((string) xEle.Element("email").Value == "")
                {
                    WriteObject("User ID = " + (string)xEle.Element("ID").Value + " has empty email ");
                }
            }
            WriteObject("======================================================================================");
        }
    }

    [Cmdlet(VerbsCommon.Get, "Update")]
    public class GetUpdate : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string id;

        [Parameter(Mandatory = true, Position = 1)]
        [AllowEmptyString]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string address;

        [Parameter(Mandatory = true, Position = 2)]
        [AllowEmptyString]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string email;

        private void UpdateUser()
        {
            XElement xelement = XElement.Load("test-em.xml");

            foreach (XElement xEle in xelement.Elements("User"))
            {
                if ((string)xEle.Element("ID").Value == ID)
                {
                    xEle.Element("address").Value = Address;
                    xEle.Element("email").Value = Email;
                }
            }
            xelement.Save("test-em.xml");
        }

        protected override void ProcessRecord()
        {
            UpdateUser();
            WriteObject("======================================================================================");
        }
    }

    [Cmdlet(VerbsCommon.Remove, "User")]
    public class RemoveUser : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string id;

        protected override void ProcessRecord()
        {
            XElement xelement = XElement.Load("test-em.xml");

            foreach (XElement xEle in xelement.Elements("User"))
            {
                if ((string)xEle.Element("ID").Value == ID)
                {
                    xEle.Remove();
                }
            }
            xelement.Save("test-em.xml");
            WriteObject("======================================================================================");
        }
    }
}
