using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Slumber_Ware
{
    public class Save
    {
        public static void _save(int id)
        {
            StructurePerso p = new StructurePerso
            {
                Id = id,
                LastName = "Dupond",
                FirstName = "Jean",
                Address = new Address
                {
                    Street = "1, rue du petit pont",
                    ZipCode = "75005",
                    City = "Paris",
                    Country = "France"
                }
            };

            XmlSerializer xs = new XmlSerializer(typeof(StructurePerso));
            using (StreamWriter wr = new StreamWriter("DataPlayer.xml"))
            {
                xs.Serialize(wr, p);
            }
        }

        public static StructurePerso _createObject()
        {
            XmlSerializer xs = new XmlSerializer(typeof(StructurePerso));
            using (StreamReader rd = new StreamReader("DataPlayer.xml"))
            {
                StructurePerso p = xs.Deserialize(rd) as StructurePerso;
                return p;
            }
        }


    }
}
