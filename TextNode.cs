using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Inhabited
{
    public class TextNode
    {
        public int NodeID = -1; //ID used for navigating the dialogue tree
        public string Text;
        public string Actor;
        public List<TextOption> Options;   

        // empty constructor for serialization
        public TextNode() { }

        // constructor for narrator text nodes
        public TextNode(string text)
        {
            this.Text = text;
            this.Options = new List<TextOption>();
        }

        // constructor for actor text nodes
        public TextNode(string text, string actor)
        {
            this.Text = text;
            this.Actor = actor;
            this.Options = new List<TextOption>(); 
        }
    }
}
