using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Elements_2048.Properties;

namespace The_Elements_2048
{
    public static class TheElements2048Utility
    {
        public static IReadOnlyDictionary<Element, Image> ElementImageDictionary { get; }

        public static IReadOnlyDictionary<Element, int> ElementScoreDictionary { get; }

        static TheElements2048Utility()
        {
            var mutableElementImageDictionary = new Dictionary<Element, Image>();
            mutableElementImageDictionary.Add(Element.Aluminium, Resources.Al);
            mutableElementImageDictionary.Add(Element.Berylium, Resources.Be);
            mutableElementImageDictionary.Add(Element.Boron, Resources.B);
            mutableElementImageDictionary.Add(Element.Carbon, Resources.C);
            mutableElementImageDictionary.Add(Element.Chlorine, Resources.Cl);
            mutableElementImageDictionary.Add(Element.Fluorine, Resources.F);
            mutableElementImageDictionary.Add(Element.Helium, Resources.He);
            mutableElementImageDictionary.Add(Element.Hydrogen, Resources.H);
            mutableElementImageDictionary.Add(Element.Lithium, Resources.Li);
            mutableElementImageDictionary.Add(Element.Magnesium, Resources.Mg);
            mutableElementImageDictionary.Add(Element.Neon, Resources.Ne);
            mutableElementImageDictionary.Add(Element.Nitrogen, Resources.N);
            mutableElementImageDictionary.Add(Element.Oxygen, Resources.O);
            mutableElementImageDictionary.Add(Element.Phosphorus, Resources.P);
            mutableElementImageDictionary.Add(Element.Silicon, Resources.Si);
            mutableElementImageDictionary.Add(Element.Sodium, Resources.Na);
            mutableElementImageDictionary.Add(Element.Sulphur, Resources.S);
            ElementImageDictionary = mutableElementImageDictionary;

            var mutableScoreDict = new Dictionary<Element, int>();
            Element keyIterator = Element.Hydrogen;
            int valueIterator = 2;
            while (keyIterator < (Element)18)
            {
                mutableScoreDict.Add(keyIterator, valueIterator);
                valueIterator *= 2;
                keyIterator = (Element)(((int)keyIterator) + 1);
            }
            ElementScoreDictionary = mutableScoreDict;
        }
    }
}
