using ROBaspCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ROBaspCore.Utilities
{
    public static class XML
    {
        //public static XDocument SetCharacterSheet(CharacterSheetModel character)
        //{
          

        //}

        public static XElement SetAbilities(string ability, int bonus, int save, int savemodifier, int saveprof, int score)
        {
            var b = new XElement(nameof(bonus), bonus);            
            var s = new XElement(nameof(save), save);
            var sm = new XElement(nameof(savemodifier), savemodifier);
            var sp = new XElement(nameof(saveprof), saveprof);
            var sc = new XElement(nameof(score), score);

            b.SetAttributeValue("type", "number");
            s.SetAttributeValue("type", "number");
            sm.SetAttributeValue("type", "number");
            sp.SetAttributeValue("type", "number");
            sc.SetAttributeValue("type", "number");

            return new XElement(ability, b, s, sm, sp, sc);
        }

        public static void WriteRaceXML(RaceModel race, string fileName)
        {
            XElement baseModifiers = new XElement("BaseModifiers");
            XElement customModifiers = new XElement("CustomModifiers");

            XDocument doc =
                new XDocument
                (
                    new XElement
                    ("Race",
                        new XElement("Name", race.Name),
                        new XElement("DescriptionBrief", race.DescriptionBrief),
                        new XElement("Description", race.Description),
                        new XElement("Attributes", baseModifiers, customModifiers),
                        new XElement("Walk", race.Walk),
                        new XElement("Tactical", race.Tactical),
                        new XElement("Sprint", race.Sprint),
                        new XElement("Luck", race.Luck),
                        new XElement("Size", race.Size)
                    )
                );
            var test = doc.Element("Race").Element("Description");
            test.SetAttributeValue("Description", "Does not have");
            test.SetValue("NOOOOOO");
            doc.Save(fileName);

            /*  THIS WILL PRODUCE THIS XML FILE WITH THE "GETTESTRACE" INFO
                <?xml version="1.0" encoding="utf-8"?>
                <Race>
                  <Name>Aenwyn</Name>
                  <DescriptionBrief>Wood Elf</DescriptionBrief>
                  <Description Description="Does not have">NOOOOOO</Description>
                  <Attributes>
                    <BaseModifiers>
                      <Accuracy>2</Accuracy>
                      <Dexterity>2</Dexterity>
                    </BaseModifiers>
                    <CustomModifiers>
                      <Accuracy>0</Accuracy>
                      <Dexterity>0</Dexterity>
                    </CustomModifiers>
                  </Attributes>
                  <Walk>13</Walk>
                  <Tactical>1</Tactical>
                  <Sprint>2</Sprint>
                  <Luck>5</Luck>
                  <Size>Large</Size>
                </Race>
             */
        }
    }
}
