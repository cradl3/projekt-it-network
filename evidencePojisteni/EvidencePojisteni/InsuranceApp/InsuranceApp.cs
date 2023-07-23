using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp
{
    // třída pro hlavní logiku aplikace
    public class InsuranceApp
    {
        // seznam pro uchování pojištěných osob
        private List<InsuredPerson> insuredPersons;

        // kontruktor pro hlavní logiku aplikace
        public InsuranceApp()
        {
            insuredPersons = new List<InsuredPerson>();
        }

        // metoda pro spuštění aplikace
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                // výpis hlavního menu aplikace
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Evidence pojištěných");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 - Přidat nového pojištěného");
                Console.WriteLine("2 - Zobrazit všechny pojištěné");
                Console.WriteLine("3 - Vyhledat pojištěného");
                Console.WriteLine("4 - Konec");
                Console.Write("Zadejte volbu: ");

                // čtení volby od uživatele
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (input)
                {
                    case '1':
                        AddInsuredPerson();
                        break;
                    case '2':
                        ShowInsuredPersons();
                        break;
                    case '3':
                        SearchInsuredPerson();
                        break;
                    case '4':
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nNeplatná volba.");
                        Console.WriteLine("\nPokračujte libovolnou klávesou...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        // metoda pro přidání nového pojištěného
        private void AddInsuredPerson()
        {
            string firstName;
            string lastName;
            string phoneNumber;
            int age;

            // ověření, že uživatel nezadal prázdné jméno
            while (true)
            {
                Console.Write("\nZadejte jméno pojištěného: ");
                firstName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("Jméno nesmí být prázdné. Zkuste to znovu.");
                }
                else
                {
                    break;
                }
            }

            // ověření, že uživatel nezadal prázdné příjmení
            while (true)
            {
                Console.Write("\nZadejte příjmení: ");
                lastName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Příjmení nesmí být prázdné. Zkuste to znovu.");
                }
                else
                {
                    break;
                }
            }

            // ověření, že uživatel nezadal prázdný telefon
            while (true)
            {
                Console.Write("\nZadejte telefonní číslo: ");
                phoneNumber = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(phoneNumber))
                {
                    Console.WriteLine("Telefonní číslo nesmí být prázdné. Zkuste to znovu.");
                }
                else
                {
                    break;
                }
            }

            // ověření, že uživatel zadal správně věk
            while (true)
            {
                Console.Write("Zadejte věk: ");
                if (!int.TryParse(Console.ReadLine(), out age) || age <= 0 || age > 110)
                {
                    Console.WriteLine("\nZadal jste špatně. Zkuste to znovu: ");
                }
                else
                {
                    break;
                }
            }

            // vytvoření nového pojištěncey a přidání do seznamu
            InsuredPerson person = new InsuredPerson(firstName, lastName, age, phoneNumber);
            insuredPersons.Add(person);

            // potvrzení úspěšného přidání a návrat na hlavní menu
            Console.WriteLine("Data byla uložena. Pokračujte libovolnou klávesou...");
            Console.ReadKey();
            Console.Clear();
        }

        // metoda pro zobrazení všech pojištěných osob
        private void ShowInsuredPersons()
        {
            // výpis seznamu pojištěných osob, pokud není prázdný
            Console.WriteLine("\nSeznam pojištěných:");

            if (insuredPersons.Count > 0)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", "Jméno", "Příjmení", "Telefon", "Věk");

                foreach (InsuredPerson person in insuredPersons)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", person.FirstName, person.LastName, person.PhoneNumber, person.Age);
                }
            }
            else
            {
                Console.WriteLine("Seznam je prázdný.");
            }

            Console.WriteLine("\nPokračujte libovolnou klávesou...");
            Console.ReadKey();
            Console.Clear();
        }

        // metoda pro vyhledání pojištěného
        private void SearchInsuredPerson()
        {
            // natení vstupu od uživatele (jméno nebo příjmení)
            Console.Write("\nZadejte jméno nebo příjmení: ");
            string input = Console.ReadLine();

            // vyhledání pojištěných osob obsahujících zadaný vstup
            List<InsuredPerson> results = insuredPersons.FindAll(p => p.FirstName.Contains(input) || p.LastName.Contains(input));

            // výpis výsledků vyhledávání
            if (results.Count > 0)
            {
                Console.WriteLine("\nVýsledky vyhledávání:");
                Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-15}", "Jméno", "Příjmení", "Telefon", "Věk");
                foreach (InsuredPerson person in results)
                {
                    Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-15}", person.FirstName, person.LastName, person.PhoneNumber, person.Age);
                }
            }
            else
            {
                Console.WriteLine("\nNebyly nalezeny žádné výsledky.\n\nPokračujte libovolnou klávesou...");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
