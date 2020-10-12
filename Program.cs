using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Media;
using System.Threading;


namespace Inhabited
{
    class Program
    {
        public TextNode node1 = new TextNode();
        private static string SolutionPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));
        private static string SC1Path = Path.Combine(SolutionPath, @"SCENE01.xml");
        private static string SC1BGM = Path.Combine(SolutionPath, @"spooky1.wav");
        static void Main(string[] args)
        {
  
            //CreateText();
            Text scene1 = LoadText(SC1Path);
            //SoundPlayer sound = new SoundPlayer(SC1BGM);
            //sound.PlayLooping();
            RunText(scene1);
        }

        public static void RunText(Text txt)
        {
            int nodeID = 0; // start at root node

            while (nodeID != -1 && nodeID < txt.Nodes.Count)
            {
                TextNode current_node = txt.Nodes[nodeID];
                int next_nodeID = -1;

                Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine(current_node.Text);
                Print(current_node.Text);

                if (current_node.Options.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\n-------------------------------");
                    int i = 0;
                    while (i < current_node.Options.Count)
                    {
                        Console.WriteLine((i+1) + ". " + current_node.Options[i].Text);
                        i = i + 1;
                    }
                    Console.WriteLine("-------------------------------");
                    int choice = Int16.Parse(Console.ReadLine());

                    next_nodeID = current_node.Options[choice-1].DestID;
                }

                else if (current_node.Options.Count == 0)
                {
                    Console.ReadKey();
                    next_nodeID = nodeID + 1;
                }

                nodeID = next_nodeID;
                Console.Clear();
            }

            Environment.Exit(0);
        }

        public static void CreateText()
        {
            Text txt = new Text();

            // test
            TextNode node1 = new TextNode("Are you kidding me?");
            TextNode node2 = new TextNode("Of all fucking times to get caught out in a snowstorm...");
            TextNode node3 = new TextNode("Damn it, I can't see shit...");
            TextNode node4 = new TextNode("I'd better take the next exit.");
            TextNode node5 = new TextNode("You can barely make out a building in the distance. Seems like a diner. The sign reads 'Gigi's - All natural American Beef'");
            TextNode node6 = new TextNode("You catch a glimpse of the headlights of a 16 wheeler just before it loses control and pulverizes your car. You are Dead...");
            TextNode node7 = new TextNode("You walk into the diner.");

            txt.AddNode(node1);
            txt.AddNode(node2);
            txt.AddNode(node3);
            txt.AddNode(node4);
            txt.AddNode(node5);
            txt.AddNode(node6);
            txt.AddNode(node7);

            txt.AddOption("Stay in the car", node5, node6);
            txt.AddOption("Go inside", node5, node7);
            txt.AddOption("Continue", node6, node1);
            txt.AddOption("Exit Game", node6, null);

            XmlSerializer makeSerial = new XmlSerializer(typeof(Text));
            StreamWriter writer = new StreamWriter(SC1Path);

            makeSerial.Serialize(writer, txt);
        }

        public static Text LoadText(string path)
        {
            XmlSerializer makeSerial = new XmlSerializer(typeof(Text));
            StreamReader reader = new StreamReader(path);

            Text txt = (Text)makeSerial.Deserialize(reader);

            return txt;
        }

        public static void Print(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
        }
        
    }
}
