using System;

class Contact
{
    public string Name;
    public string Phone;
    public string Email;
}

class ContactManager
{
    private List<Contact> contacts = new List<Contact>();

    private bool IsValidPhone(string phone)
    {
        if (phone.Length < 10 || phone.Length > 15)
            return false;

        for (int i = 0; i < phone.Length; i++)
        {
            if (phone[i] < '0' || phone[i] > '9')
                return false;
        }

        return true;
    }

    private bool IsValidEmail(string email)
    {
        int atIndex = -1;
        int dotIndex = -1;

        for (int i = 0; i < email.Length; i++)
        {
            if (email[i] == '@')
                atIndex = i;

            if (email[i] == '.')
                dotIndex = i;
        }

        if (atIndex <= 0) return false;
        if (dotIndex <= atIndex + 1) return false;
        if (dotIndex == email.Length - 1) return false;

        return true;
    }

    public void AddContact()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        string phone;
        do
        {
            Console.Write("Enter Phone (10-15 digits): ");
            phone = Console.ReadLine();
        } while (!IsValidPhone(phone));

        string email;
        do
        {
            Console.Write("Enter Email: ");
            email = Console.ReadLine();
        } while (!IsValidEmail(email));

        Contact c = new Contact();
        c.Name = name;
        c.Phone = phone;
        c.Email = email;

        contacts.Add(c);

        Console.WriteLine("Contact Added\n");
    }

    public void SearchContact()
    {
        Console.Write("Enter name to search: ");
        string search = Console.ReadLine().ToLower();

        bool found = false;

        for (int i = 0; i < contacts.Count; i++)
        {
            string nameLower = contacts[i].Name.ToLower();

            if (nameLower.Contains(search))
            {
                Console.WriteLine(contacts[i].Name + " | " + contacts[i].Phone + " | " + contacts[i].Email);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No contacts found");

        Console.WriteLine();
    }

    public void GroupContacts()
    {
        Dictionary<char, List<Contact>> groups = new Dictionary<char, List<Contact>>();

        for (int i = 0; i < contacts.Count; i++)
        {
            char key = Char.ToUpper(contacts[i].Name[0]);

            if (!groups.ContainsKey(key))
            {
                groups[key] = new List<Contact>();
            }

            groups[key].Add(contacts[i]);
        }

        foreach (KeyValuePair<char, List<Contact>> pair in groups)
        {
            Console.WriteLine("Group " + pair.Key + ":");

            for (int i = 0; i < pair.Value.Count; i++)
            {
                Contact c = pair.Value[i];
                Console.WriteLine(c.Name + " | " + c.Phone + " | " + c.Email);
            }

            Console.WriteLine();
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Search Contact");
            Console.WriteLine("3. Group Contacts");
            Console.WriteLine("4. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1") AddContact();
            else if (choice == "2") SearchContact();
            else if (choice == "3") GroupContacts();
            else if (choice == "4") break;
            else Console.WriteLine("Invalid choice\n");
        }
    }
}

class Program
{
    static void Main()
    {
        ContactManager manager = new ContactManager();
        manager.Run();
    }
}