using ROB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Utilities
{
    public class GenerateData
    {
        private class RandomizeValues 
        {
            public int StatInt { get; set; }
            public int RandomValue { get; set; }
        }

        public static List<int> GetRandomAttributeValues(List<int> Values)
        {
            Random rand = new Random();
            List<RandomizeValues> test = new List<RandomizeValues>();
            foreach (var value in Values)
            {
                test.Add(new RandomizeValues { StatInt = value, RandomValue = rand.Next() });
            }
            return test.OrderBy(t => t.RandomValue).Select(t => t.StatInt).ToList();
        }

        public static string GetRandomGender()
        {
            return GetRandomFromList(Gender);
        }

        public static List<string> Gender = new List<string>
        {
            "Male",
            "Female",
            "Undefined"
        };

        public static string GetRandomFaith()
        {
            return GetRandomFromList(Faith);
        }

        public static List<string> Faith = new List<string>
        {
            "Libratarian",
            "Female",
            "Undefined"
        };

        public static string GetRandomEyeColor()
        {
            return GetRandomFromList(EyeColor);
        }

        public static List<string> EyeColor = new List<string>
        {
            "Blue",
            "Green",
            "Brown",
            "Yellow",
            "Pink",
            "Grey",
            "Hazel"
        };

        public static string GetRandomHairColor()
        {
            return GetRandomFromList(HairColor);
        }

        public static List<string> HairColor = new List<string>
        {
            "Blue",
            "Green",
            "Brown",
            "Blonde",
            "Pink",
            "Grey"
        };

        public static string GetRandomSkinColor()
        {
            return GetRandomFromList(SkinColor);
        }

        public static List<string> SkinColor = new List<string>
        {
            "Blue",
            "Green",
            "Brown",
            "Blonde",
            "Pink",
            "Grey"
        };

        public static string GetRandomFromList(List<string> list)
        {
            var random = new Random();
            int number = random.Next(list.Count);
            return list[number];
        }
    }
}
