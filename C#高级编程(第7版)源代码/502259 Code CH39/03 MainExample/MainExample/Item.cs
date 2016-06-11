using System;

namespace MainExample
{
    /// <summary>
    /// Used in some examples
    /// </summary>
    public class Item
    {
        public Item(string text)
        {
            m_text = text;
        }

        public string Text
        {
            get { return m_text; }
        }

        private string m_text;
    }
}
