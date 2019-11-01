using Contacts_KT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_KT.Controllers
{
    class ContactController
    {
      
        public static List<ContactModel> GetContacts(String path)
        {

            if (File.Exists(path))
            {
                List<ContactModel> contactsList = new List<ContactModel>();

                CultureInfo culture = CultureInfo.InvariantCulture;
                var listfile = File.ReadAllLines(path);
                foreach (var line in listfile)
                {
                    ContactModel contact = new ContactModel();
                    var rs = line.Split(new char[] { '#' });
                    contact.IdContact = int.Parse(rs[0]);
                    contact.FullName = rs[1];
                    contact.Phone = int.Parse(rs[2]);
                    contact.Email = rs[3];
                    contactsList.Add(contact);
                }

                return contactsList.OrderBy(x =>x.firstWordName).ToList();
            }
            return null;


        }
        public static List<ContactModel> addContact(ContactModel contact,String path)
        {
            contact.IdContact = File.ReadAllLines(path).Count();
            string data = string.Format("{0}#{1}#{2}#{3}", contact.IdContact +1, contact.FullName,contact.Phone,contact.Email);
            File.AppendAllText(path, Environment.NewLine + data);
            var lines1 = File.ReadAllLines(path).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(path, lines1);
            return GetContacts(path);
        }
        public static void deleteContact(ContactModel contact,String path)
        {
            var lines = File.ReadAllLines(path);
            string data = string.Format("{0}#{1}#{2}#{3}", contact.IdContact, contact.FullName, contact.Phone, contact.Email);
            File.WriteAllLines(path, lines.Where(x => !x.Contains(data.ToString())).ToArray());
            var lines1 = File.ReadAllLines(path).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(path, lines1);
        }
        public static void updateContact(ContactModel contact, String path)
        {
            var lines1 = File.ReadAllLines(path).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(path, lines1);
            string[] arrLine = File.ReadAllLines(path);
            string data = string.Format("{0}#{1}#{2}#{3}", contact.IdContact, contact.FullName, contact.Phone, contact.Email);
            arrLine[contact.IdContact - 1] = data;
            File.WriteAllLines(path, arrLine);

        }
        public static List<ContactModel> GetContactBySearch(string originalText, string pathDataFile)
        {
            string text = originalText.ToLower();
            List<ContactModel> newListContact = new List<ContactModel>();
            if (!text.Equals(""))
            {
                List<ContactModel> listContact = GetContacts(pathDataFile);
                

                    foreach (var item in listContact)
                    {


                        if (item.FullName.ToLower().Contains(text) || item.Email.Contains(text))
                        {
                            newListContact.Add(item);
                        }
                    }
                    return newListContact;
               

            }
            else
            {
                return GetContacts(pathDataFile);
            }

        }
        public static List<String> removeDuplicates(String path)
        {
            List<String> t = GetContacts(path).Select(x =>x.firstWordName).Distinct().ToList();
            return t;
        }
        public static List<String> removeDuplicatesSearch(string originalText,String path)
        {
            List<String> t = GetContactBySearch(originalText,path).Select(x => x.firstWordName).Distinct().ToList();
            return t;
        }

    }
}
