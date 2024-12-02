using System;
using Avalonia.Controls;
using System.Linq;

namespace CalculatorQuest
{
    public class Calculs 
    {
        private string[] _signs = { "+", "-", "x", "/", "%" };

        public Calculs() {}

        public string Operator(string Input)
        {
            string[] parts = Input.Split(_signs, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                return "Opérateur invalide";
            }

            double chiffre1, chiffre2;
            if (!double.TryParse(parts[0], out chiffre1) || !double.TryParse(parts[1], out chiffre2))
            {
                return "Numéro invalide";
            }

            if (Input.Contains("+"))
            {
                return (chiffre1 + chiffre2).ToString();
            }
            else if (Input.Contains("-"))
            {
                return (chiffre1 - chiffre2).ToString();
            }
            else if (Input.Contains("x"))
            {
                return (chiffre1 * chiffre2).ToString();
            }
            else if (Input.Contains("/"))
            {
                if (chiffre1 == 0 || chiffre2 == 0)
                {
                    return "Tu ne peux pas faire ça c'est illégal et répréhensible par la loi des maths";
                }
                return (chiffre1 / chiffre2).ToString();
            }
            else if (Input.Contains("%"))
            {
                return (chiffre1 % chiffre2).ToString();
            }

            return "Opération impossible";
        }
    }
    
}