using Connectly.Application.Interfaces.ServiceInterfaces;

namespace Connectly.Infrastructure.ExternalServices;

public class PasswordGeneratorService : IPasswordGeneratorService
{

    


    private readonly string[] Words =
    [
        "fagus",
        "1",
        "bok",
        "2",
        "ek",
        "ask",
        "3",
        "al",
        "gran",
        "4",
        "tall",
        "plommon",
        "apelsin",
        "?",
        "citron",
        "lime",
        "jordgubbe",
        "hallon",
        "!",
        "lingon",
        "kantarell",
        "tratt",
        "svamp",
        "fisk",
        "5",
        "hund",
        "katt",
        "orm",
        "spindel",
        "skorpion",
        "varg",
        "lejon",
        "6",
        "tiger",
        "elefant",
        "7",
        "krokodil",
        "pingvin",
        "zebra",
        "giraff",
        "vinter",
        "sommar",
        "blomma",
        "geting",
        "bi",
        "humla",
        "myra",
        "syrsa",
        "skata",
        "korp",
        "duva",
        "sparv",
        "svala",
        "kaja",
        "falk",
        "8",
        "uggla",
        "kattuggla",
        "domkraft",
        "skruvmejsel",
        "spik",
        "skiftnyckel",
        "tumstock",
        "vattenpass",
        "hammare",
        "borr",
        "vanilj",
        "choklad",
        "honung",
        "eld",
        "M90",
        "9",
        "@",
        "regemente",
        "bataljon",
        "kompani",
        "pluton",
        "grupp",
        "gripen",
        "paj",
        "många",
        "kung",
        "drottning",
        "prins",
        "prinsessa",
    ];


    public string Generate()
    {
      
            const int minCharLength = 16;
            const int amountOfIterations = 4;
            var password = string.Empty;
            var random = new Random();

            for (var i = 0; i < amountOfIterations; i++)
            {
                var word = Words[random.Next(0, Words.Length)];

                if (password.ToLower().Contains(word.ToLower()))
                {
                    i--;
                    continue;
                }

                if (random.Next(0, 2) == 1)
                {
                    word = word.ToUpper();
                }

                if (i > 0 && i < amountOfIterations)
                {
                    password += "-";
                }

                password += word;

                if (i == amountOfIterations - 1 && password.Length < minCharLength)
                {
                    i--;
                }
            }

            if (!password.Any(char.IsDigit))
            {
                password += $"-{random.Next(0, 10)}";
            }

            
            return password;
        
      

       
    }
}