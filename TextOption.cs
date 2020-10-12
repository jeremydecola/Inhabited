using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Inhabited
{
    public class TextOption
    {
        public string Text;
        public int DestID; //Specifies the ID of to navigate to if this option is selected. 

        // empty constructor for serialization
        public TextOption() { }

        public TextOption(string text, int dest)
        {
           this.Text = text;
           this.DestID = dest; 
        }
    }
}
