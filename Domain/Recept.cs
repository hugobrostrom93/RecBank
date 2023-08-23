using System.Text.RegularExpressions;

namespace ReceptBank.Domain;


//domain entitet som beskriver 
//validators osv - går inte att förstöra objektet
//properties är samma, men i dataentitet så är de gjorda i decorators för att kunna skriva i json,
//i domain, upprätthålla integritet eller skit. 
//skapas i "verkligeheten" - definerar vad Recept består av

public class Recept
{
    private string _name = string.Empty;
    private string _ingredients = string.Empty;

    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^[a-zA-Z]+( [a-zA-Z]+)*$"))
            {
                throw new ArgumentException("Name must be letters only and may contain one space character between names.");
            }
            _name = value;
        }
    }

    public string Ingredients
    {
          get => _ingredients;
        private set
        {
            if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^[a-zA-Z]+( [a-zA-Z]+)*$"))
            {
                throw new ArgumentException("Name must be letters only and may contain one space character between names.");
            }
            _ingredients = value;
        }
    }

    public Recept (string name, string ingredients)
    {
        Name = name;
        Ingredients = ingredients;
    }
}

