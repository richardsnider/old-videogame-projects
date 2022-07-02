using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utilities
{
    public static class NameGenerator
    {
        public static List<string> CreateNames(int numOfNames = 1, bool fixedLength = false, int minLength = 2, int length = 8, int maxLength = 10, bool hyphensAllowed = true, bool apostropheAllowed = true)
        {
            List<string> names = new List<string>();
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
            List<char> consonants = new List<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
            Random rand = new Random();

            if (numOfNames < 1) numOfNames = 1;
            if (hyphensAllowed) vowels.Add('-');
            if (apostropheAllowed) vowels.Add('\'');
            if (minLength < 2) minLength = 2;
            if (length < 2) length = 2;
            if (maxLength < minLength) maxLength = minLength;

            for(; numOfNames > 0; numOfNames--)
            {
                string name = "";
                int nameLength;

                if (fixedLength) nameLength = length;
                else nameLength = rand.Next(minLength, maxLength);

                for(int index = 0; index < nameLength; index++) {
                    char nextChar;
                
                    if (rand.Next(2) == 0) nextChar = vowels[rand.Next(vowels.Count)];
                    else nextChar = consonants[rand.Next(consonants.Count)];
                
                    if(index >= 2)
                    {
                        char lastCharacter = name[index - 1];
                        char secondLastCharacter = name[index - 2];
                        
                        if (vowels.Contains(lastCharacter) && vowels.Contains(secondLastCharacter))
                            nextChar = consonants[rand.Next(consonants.Count)];
                        else if (consonants.Contains(lastCharacter) && consonants.Contains(secondLastCharacter))
                            nextChar = vowels[rand.Next(vowels.Count)];
                    }

                    name += nextChar;
                }

                names.Add(name);
            }

            return names;
        }
    }
}
