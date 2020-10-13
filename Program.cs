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
        // define paths for each XML and Sound File 
        private static string SolutionPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));
        private static string SC1Path = Path.Combine(SolutionPath, @"SCENE01.xml");
        private static string SC1BGM = Path.Combine(SolutionPath, @"spooky1.wav");
        static void Main(string[] args)
        {
  
            //CreateXML();
            Text scene1 = LoadXML(SC1Path);
            //SoundPlayer sound = new SoundPlayer(SC1BGM);
            //sound.PlayLooping();
            RunText(scene1);
        }

        public static void RunText(Text txt)
        {
            int nodeID = 0; // start at root node

            // a nodeID of -1 indicates game over , if the next node has a nodeID of -1 or does not exist, end the game
            while (nodeID != -1 && nodeID < txt.Nodes.Count)
            {
                TextNode current_node = txt.Nodes[nodeID];
                int next_nodeID = -1;

                //Console.WriteLine(current_node.Text);
                Print(current_node);

                // if there are options for this text node, list them to the player
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
                    
                    // get chosen option from the player and assign the corresponding destination node
                    int choice = Int16.Parse(Console.ReadLine());
                    next_nodeID = current_node.Options[choice-1].DestID;
                }

                // if there are no options for this text node, go to the next node on keypress
                else if (current_node.Options.Count == 0)
                {
                    bool pressedEnter = false; 
                    while (!pressedEnter)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                            pressedEnter = true;
                    }
                    next_nodeID = nodeID + 1;
                }

                // assign the next nodeID and clear the console
                nodeID = next_nodeID;
                Console.Clear();
            }

            Environment.Exit(0);
        }

        // A test method that allows us to serialize code into an XML
        public static void CreateXML()
        {
            Text txt = new Text();

            // test
            TextNode node1 = new TextNode("Are you kidding me?","Bennet");
            TextNode node2 = new TextNode("Of all fucking times to get caught out in a snowstorm...","Bennet");
            TextNode node3 = new TextNode("Damn it, I can't see shit...","Bennet");
            TextNode node4 = new TextNode("I'd better take the next exit.","Bennet");
            TextNode node5 = new TextNode("You can barely make out a building in the distance. Seems like a diner. The sign reads 'Gigi's - All natural American Beef'");
            TextNode node6 = new TextNode("You catch a glimpse of the headlights of a 16 wheeler just before it loses control and pulverizes your car. You are Dead...");
            TextNode node7 = new TextNode("You walk into the diner.");
            TextNode node8 = new TextNode("Welcome to Gigi's hun. Take a seat wherever you'd like.","Anna");
            TextNode node9 = new TextNode("You grab a seat by the window and check your phone.");
            TextNode node10 = new TextNode("No reception. Come on! I'm supposed to report in right now. Shit...","Bennet");
            TextNode node11 = new TextNode("You stand up and walk to the counter.");
            TextNode node12 = new TextNode("Need something hun? I was just about to come over.", "Anna");
            TextNode node13 = new TextNode("Sorry, Anna was it? Do you happen to have a phone I could use?", "Bennet");
            TextNode node14 = new TextNode("We had a phone... then it grew hands and started climbing up the wall.", "Anna");
            TextNode node15 = new TextNode("What? Listen... I don't have time for games Anna. I need to place a call.", "Bennet");
            TextNode node16 = new TextNode("Well, good luck with that. Now are you going to order something or not?", "Anna");
            TextNode node17 = new TextNode("Forget it. I'm going.", "Bennet");
            TextNode node18 = new TextNode("You head to the door and try to open. It won't budge.");
            TextNode node19 = new TextNode("Hey! What gives? I can't open the door!", "Bennet");
            TextNode node20 = new TextNode("The blizzard must have burried the door in snow.","Anna");
            TextNode node21 = new TextNode("I've been here a whole 5 minutes... You've got to be kidding me.", "Bennet");
            TextNode node22 = new TextNode("I take it you're not from around these parts.", "Anna");
            TextNode node23 = new TextNode("The firemen should clear the mound in the morning. Why don't you order something?", "Anna");
            TextNode node24 = new TextNode("I'm sorry, we're all out of burgers... Any else catch your eye?", "Anna");
            TextNode node25 = new TextNode("I'm sorry, we're all out milk... Would you care for anything else?", "Anna");
            TextNode node26 = new TextNode("I'm sorry, we have a special way of serving our coffee, is that ok?", "Anna");
            TextNode node27 = new TextNode("Fine... whatever.", "Bennet");
            TextNode node28 = new TextNode("Why don't you go back to your seat? I'll go make that coffee for you.", "Anna");
            TextNode node29 = new TextNode("You walk back to your seat.");
            TextNode node30 = new TextNode("A few moments pass and Anna arrives with a generously sized white mug in her hands.");
            TextNode node31 = new TextNode("Our special house blend. Always served with 3 Laits et 1 Sucre.", "Anna");
            TextNode node32 = new TextNode("I'm sorry... What?", "Bennet");
            TextNode node33 = new TextNode("It's French for 3 Milks and 1 Sugar.", "Anna");
            TextNode node34 = new TextNode("Anna places the coffee on a tray in front of you.");
            TextNode node35 = new TextNode("Near your cup are the empty containers of milk and sugar, labeled L and S respectively.");


            txt.AddNode(node1);
            txt.AddNode(node2);
            txt.AddNode(node3);
            txt.AddNode(node4);
            txt.AddNode(node5);
            txt.AddNode(node6);
            txt.AddNode(node7);
            txt.AddNode(node8);
            txt.AddNode(node9);
            txt.AddNode(node10);
            txt.AddNode(node11);
            txt.AddNode(node12);
            txt.AddNode(node13);
            txt.AddNode(node14);
            txt.AddNode(node15);
            txt.AddNode(node16);
            txt.AddNode(node17);
            txt.AddNode(node18);
            txt.AddNode(node19);
            txt.AddNode(node20);
            txt.AddNode(node21);
            txt.AddNode(node22);
            txt.AddNode(node23);
            txt.AddNode(node24);
            txt.AddNode(node25);
            txt.AddNode(node26);
            txt.AddNode(node27);
            txt.AddNode(node28);
            txt.AddNode(node29);
            txt.AddNode(node30);
            txt.AddNode(node31);
            txt.AddNode(node32);
            txt.AddNode(node33);
            txt.AddNode(node34);
            txt.AddNode(node35);


            txt.AddOption("Stay in the car", node5, node6);
            txt.AddOption("Go inside", node5, node7);
            txt.AddOption("Continue", node6, node1);
            txt.AddOption("Exit Game", node6, null);
            txt.AddOption("Gigi Burger", node23, node24);
            txt.AddOption("Vanilla Shake", node23, node25);
            txt.AddOption("Black Coffee", node23, node26);
            txt.AddOption("Vanilla Shake", node24, node25);
            txt.AddOption("Black Coffee", node24, node26);
            txt.AddOption("Gigi Burger", node25, node24);
            txt.AddOption("Black Coffee", node25, node26);



            XmlSerializer makeSerial = new XmlSerializer(typeof(Text));
            StreamWriter writer = new StreamWriter(SC1Path);

            makeSerial.Serialize(writer, txt);
        }

        // a method to create objects by deserializing an existing XML
        public static Text LoadXML(string path)
        {
            XmlSerializer makeSerial = new XmlSerializer(typeof(Text));
            StreamReader reader = new StreamReader(path);

            Text txt = (Text)makeSerial.Deserialize(reader);

            return txt;
        }

        // A print method that writes to the console as if someone were typing the message
        public static void Print(TextNode node)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (node.Actor != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(node.Actor + ": ");
            }
            foreach (char c in node.Text)
            {
                Console.Write(c);
                Thread.Sleep(50); // sleep 50ms between each character printed
            }
        }
    }
}
