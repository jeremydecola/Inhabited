using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Inhabited
{
    public class Text
    {
        public List<TextNode> Nodes = new List<TextNode>();

        public void AddNode(TextNode node)
        {
            if (node == null) return; // if node is null, it is an exit node - no need to add
            Nodes.Add(node); // add the node to Nodes list
            node.NodeID = Nodes.IndexOf(node); // assign the node with NodeID as the current index in the Nodes list
        }

        public void AddOption(string text, TextNode start, TextNode dest)
        {

            TextOption option; // initialize text option object

            // if the start node doesn't already exist create and add to the Nodes list
            if (!Nodes.Contains(start))
                AddNode(start);

            // if the destination node doesn't already exist create and add to the Nodes list
            if (!Nodes.Contains(dest))
                AddNode(dest);

            // if destination node is an Exit node, set to -1 
            if (dest == null)
                option = new TextOption(text, -1);
            else
                option = new TextOption(text, dest.NodeID);

            start.Options.Add(option);
        }
    }
}
