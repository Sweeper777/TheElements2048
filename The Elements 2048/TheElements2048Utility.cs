using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Elements_2048.Properties;

namespace The_Elements_2048 {
    public static class TheElements2048Utility {
        public static Dictionary<Element, Image> GetElementImageDictionary () {
            Dictionary<Element, Image> dic = new Dictionary<Element, Image> ();
            dic.Add (Element.Aluminium, Resources.Al);
            dic.Add (Element.Berylium, Resources.Be);
            dic.Add (Element.Boron, Resources.B);
            dic.Add (Element.Carbon, Resources.C);
            dic.Add (Element.Chlorine, Resources.Cl);
            dic.Add (Element.Fluorine, Resources.F);
            dic.Add (Element.Helium, Resources.He);
            dic.Add (Element.Hydrogen, Resources.H);
            dic.Add (Element.Lithium, Resources.Li);
            dic.Add (Element.Magnesium, Resources.Mg);
            dic.Add (Element.Neon, Resources.Ne);
            dic.Add (Element.Nitrogen, Resources.N);
            dic.Add (Element.Oxygen, Resources.O);
            dic.Add (Element.Phosphorus, Resources.P);
            dic.Add (Element.Silicon, Resources.Si);
            dic.Add (Element.Sodium, Resources.Na);
            dic.Add (Element.Sulphur, Resources.S);
            return dic;
        }

        public static Dictionary<Element, int> GetElementScoreDictionary () {
            Dictionary<Element, int> returnVal = new Dictionary<Element,int> ();
            Element keyIterator = Element.Hydrogen;
            int valueIterator = 2;
            while (keyIterator < (Element)18) {
                returnVal.Add (keyIterator, valueIterator);
                valueIterator *= 2;
                keyIterator = (Element)( ( (int)keyIterator ) + 1 );
            }
            return returnVal;
        }
    }
}
