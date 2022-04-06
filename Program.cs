// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//A list of objects with the class contact, used to more easily create more and view various contacts.
List<Contact> contacts = new List<Contact>();
contacts.Add(new Contact("Speedwagon","Stormwind Harbor",2482914));
contacts.Add(new Contact("Darron Dawnshine", "Eversong Forest", 3124141));
while(true)
{
    //The users input, used to call various functions
    string input = Console.ReadLine();
    if(input.ToLower() == "create")
    {
        CreateNewContact();
    }
    if (input.ToLower() == "read" || input.ToLower() == "display" )
    {
        ReadContact();
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
        contacts.RemoveAt(int.Parse(input));
        contacts.Insert(int.Parse(input),new Contact(name,adresse,telefonnummer));
    }
}

//A function for creating new contacts and adding them to the list.
void CreateNewContact()
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

    contacts.Add(new Contact(name, adresse, telefonnummer));
    Console.WriteLine("Er dette korrekt?");
    Console.WriteLine(contacts.Last());
}
void UpdateContact()
{

}
void ReadContact ()
{
    for (int i = 0; i < contacts.Count; i++)
    {
        Console.WriteLine(i);
        Console.WriteLine(contacts[i]);
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