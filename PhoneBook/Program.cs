namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();
            string phoneBookPath = "D:\\Phone_Book.txt";

            try
            {
                using (StreamReader sr = new StreamReader(phoneBookPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] tokens = line.Split(" ");
                        phoneBook.Add(tokens[0], tokens[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string phonesPath = "D:\\Phones.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(phonesPath))
                {
                    foreach (string phoneNumber in phoneBook.Values)
                    {
                        sw.WriteLine(phoneNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Enter name");

            string name = Console.ReadLine();

            if (phoneBook.ContainsKey(name))
            {
                Console.WriteLine(phoneBook[name]);
            }

            string newPhonesPath = "D:\\New.txt";

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(newPhonesPath))
                {
                    foreach (var kvp in phoneBook)
                    {
                        string newNumber = kvp.Value;

                        if (newNumber.StartsWith("80"))
                        {
                            newNumber = "+3" + newNumber;
                        }
                        streamWriter.WriteLine($"{kvp.Key} {newNumber}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}