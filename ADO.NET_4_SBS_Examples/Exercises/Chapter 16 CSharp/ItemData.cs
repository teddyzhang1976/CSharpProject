// ----- Microsoft ADO.NET 4.0 Step by Step
//       Sample for Chapter 16 - C# Version
//       by Tim Patrick

using System;

namespace Chapter_16_CSharp
{
    class ItemData
    {
        // ----- Class used to support ListBox and ComboBox items.
        public string ItemText;
        public long ItemValue;

        public ItemData(string newText, long newValue)
        {
            // ----- Required constructor.
            this.ItemText = newText;
            this.ItemValue = newValue;
        }

        public override string ToString()
        {
            // ----- Show the text in ListBox and ComboBox displays.
            return this.ItemText;
        }

        public override bool Equals(Object obj)
        {
            // ----- Allow IndexOf() and Contains() searches by ItemValue.
            if (obj.GetType() == typeof(long))
                return (bool)((long)obj == this.ItemValue);
            else
                return base.Equals(obj);
        }

        public static long GetItemData(Object whichRecord)
        {
            // ----- Given an object, assume it is an ItemData instance.
            //       Convert it and return the numeric value. Return -1 on failure.
            ItemData itemDataVersion;

            if (whichRecord == null) return -1L;
            if (whichRecord.GetType() != typeof(ItemData)) return -1L;

            // ----- Convert and extract.
            itemDataVersion = (ItemData)whichRecord;
            return itemDataVersion.ItemValue;
        }
    }
}
