// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//A list of objects with the class contact, used to more easily create more and view various contacts.
List<Contact> contacts = new List<Contact>();
List<Contact> virksomheder = new List<Contact>();
contacts.Add(new Contact("Speedwagon","Stormwind Harbor",2482914));
contacts.Add(new Contact("Darron Dawnshine", "Eversong Forest", 3124141));
string listChosen = "";
while (true)
{
    
    //First the user is asked what sort of contact list they want to access.
    Console.WriteLine("Hvilken liste vil du tilgå? \n Virksomheder eller personer?");
    bool choiceSuccess = false;
    do
    {
        
        listChosen = Console.ReadLine();
        if (listChosen.ToLower() == "virksomheder" || listChosen.ToLower() == "firmaer" || listChosen.ToLower() == "corporations" || listChosen.ToLower() == "businesses")
        {
            listChosen = "bis";
            choiceSuccess = true;
        }
        if (listChosen.ToLower() == "personer" || listChosen.ToLower() == "individuals" || listChosen.ToLower() == "kunder" || listChosen.ToLower() == "venner" || listChosen.ToLower() == "friends")
        {
            listChosen = "pers";
            choiceSuccess= true;
        }
    } while (choiceSuccess == false);
    
    //The users input, used to call various functions
    string input = Console.ReadLine();
    if(input.ToLower() == "create")
    {
        if (listChosen.ToLower() == "pers")
        {
            CreateNewContact(contacts);
        }
        if (listChosen.ToLower() == "bis")
        {
            CreateNewContact(virksomheder);
        }
    }
    if (input.ToLower() == "read" || input.ToLower() == "display" )
    {
        ReadContact(listChosen);
    }
    if (input.ToLower() == "delete" || input.ToLower() == "remove" || input.ToLower() == "fjern")
    {
        Console.WriteLine("Hvad vil du gerne fjerne?");
        do
        {
            try
            {
                input = Console.ReadLine();
                Console.WriteLine(contacts[int.Parse(input)]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Den findes ikke, prøv igen.");
                input = "fejlkode";
            }
            catch(FormatException)
            {
                Console.WriteLine("Den findes ikke, prøv igen.");
                input = "fejlkode";
            }
        } while (input.ToLower() == "fejlkode");
        
        Console.WriteLine(contacts[int.Parse(input)]);
        DeleteContact(int.Parse(Console.ReadLine()));
    }
    if (input.ToLower() == "update" || input.ToLower() == "opdater" || input.ToLower() == "replace" || input.ToLower() == "udskift")
    {
        Console.WriteLine("Hvad vil du gerne opdatere?");
        do
        {
            try
            {
                input= Console.ReadLine();
                Console.WriteLine(contacts[int.Parse(input)]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Den findes ikke, prøv igen");
                input = "fejlkode";
            }
            catch (FormatException)
            {
                Console.WriteLine("Den findes ikke, prøv igen");
                input = "fejlkode";
            }
        } while (input.ToLower() == "fejlkode");
        Console.WriteLine("Indtast et navn.");
        string name = Console.ReadLine();
        Console.WriteLine("Indtast en adresse");
        string adresse = Console.ReadLine();
        Console.WriteLine("Indtast et telefonnummer");
        //int telefonnummer = int.Parse(Console.ReadLine());
        int telefonnummer = 0;
        //Er ikke særlig vant til error handling... Så det her er nok lidt noget rod.
        do
        {
            try
            {
                telefonnummer = int.Parse(Console.ReadLine());
            }
            catch (OverflowException)
            {
                telefonnummer = 100000000;
            }
            catch (FormatException)
            {
                telefonnummer = 100000000;
            }

            if (telefonnummer.ToString().Length != 8)
            {
                Console.WriteLine("Dette er ikke et korrekt telefonnummer, prøv igen");
            }
        } while (telefonnummer.ToString().Length != 8);

        if (listChosen == "pers")
        {
            contacts.RemoveAt(int.Parse(input));
            contacts.Insert(int.Parse(input), new Contact(name, adresse, telefonnummer));
        }
        if(listChosen == "bis")
        {
            virksomheder.RemoveAt(int.Parse(input));
            virksomheder.Insert(int.Parse(input), new Contact(name,adresse, telefonnummer));
        }
    }
}

//A function for creating new contacts and adding them to the list.
void CreateNewContact(List<Contact> list)
{
    Console.WriteLine("Indtast et navn.");
    string name = Console.ReadLine();
    Console.WriteLine("Indtast en adresse");
    string adresse = Console.ReadLine();
    Console.WriteLine("Indtast et telefonnummer");
    //int telefonnummer = int.Parse(Console.ReadLine());
    int telefonnummer = 0;
    //Er ikke særlig vant til error handling... Så det her er nok lidt noget rod.
    do
    {
        try
        {
            telefonnummer = int.Parse(Console.ReadLine());
        }
        catch (OverflowException)
        {
            telefonnummer = 100000000;
        }
        catch(FormatException)
        {
            telefonnummer = 100000000;
        }
        
        if (telefonnummer.ToString().Length != 8)
        {
            Console.WriteLine("Dette er ikke et korrekt telefonnummer, prøv igen");
        }
    } while (telefonnummer.ToString().Length != 8);

    list.Add(new Contact(name, adresse, telefonnummer));
    Console.WriteLine("Er dette korrekt?");
    Console.WriteLine(list.Last());
}
void UpdateContact()
{

}
void ReadContact (string choice)
{
    if (choice == "bis")
    {
        for (int i = 0; i < virksomheder.Count; i++)
        {
            Console.WriteLine(i);
            Console.WriteLine(virksomheder[i]);
        }
    }
    if (choice == "pers")
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine(i);
            Console.WriteLine(contacts[i]);
        }
    }
    
    //foreach(Contact contact in contacts)
    //{
    //    Console.WriteLine(contact);
    //}
}
//Denne metode fjerner et bestemt index fra contacts listen, den er skrevet med en parameter for at vise at det kan jeg også :)
void DeleteContact(int i)
{
    contacts.RemoveAt(i);
    //contacts.Remove();
}
//A class containing the necessary information for a contact.
public class Contact
{
    //public string Name { get; set; }
    //public string Address { get; set; }
    //public int Phone { get; set; }
    private string name;
    private string address;
    private int phone;
    public Contact(string Name, string Address, int Phone)
    {
        name = Name;
        address = Address;
        phone = Phone;
    }
    public void print()
    {
        Console.WriteLine("Navn: " + name);
        Console.WriteLine("Adresse: " + address);
        Console.WriteLine("Telefonnummer: " + phone);
    }
    public string GetContents ()
    {
        string output = name;
        output +="\n" + address;
        return output;
    }
    public override string ToString()
    {
        string output = "------------------------------------------------";
        output += "\n" + name;
        output += "\n" + address;
        output += "\n" + phone;
        output += "\n" + "------------------------------------------------";
        return output;
    }
}