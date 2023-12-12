using System;
using System.Threading;

namespace Knossos_
{
        enum Blickrichtung {Ost, West, Nord, S�d};
    class Labyrinth
    {
        enum Tonh�he { REST = 0, F4 = 349, G4 = 391, Gsharp4 = 415, Asharp4 = 466, C5 = 523, D5 = 587, Dsharp5 = 622, G5 = 783, C6 = 1046, } //Hab ich aus der Hilfe
        enum Dauer { Ganze = 1600, Halbe = Ganze / 2, Viertel = Halbe / 2, Achtel = Viertel / 2, Sechzehntel = Achtel / 2, } //Hab ich aus der Hilfe
        struct Note //Hab ich aus der Hilfe
        {
            Tonh�he toneVal;
            Dauer durVal;

            public Note(Tonh�he frequency, Dauer time)
            {
                toneVal = frequency;
                durVal = time;
            }
            public Tonh�he Notenh�he { get { return toneVal; } }
            public Dauer Notendauer { get { return durVal; } }
        }
        static string[,] Garten;
        static bool weitermachen = true;
        static bool WarBeiSphinx = false;
        static bool WarBeiSeherin = false;
        static bool Nase = true;
        static bool Schl�ssel = false;
        static int[] Standort = new int[2];
        static int[] Blickrichtungsort = new int[2];
        static bool FeldFrei;
        static bool erstes = true;
        static Blickrichtung RichtungVar;
        
        //Hauptprogramm
        static void Main()
        {
          
            Initialisierung();
            Start();
          
        }
        
        //Initialisierung
        static void Initialisierung()
        {
        Garten = new string[,]

            //zuf�llig erstellen
          
        {{"#","#","#","#","#","#","#","#","#","#","#","#"},
        {"#","-","-","-","-","-","-","-","Z","#","D","#"},
        {"#","#","#","-","#","#","#","#","#","#","-","#"},
        {"#","#","#","-","D","-","-","-","-","-","-","#"},
        {"#","-","-","-","#","#","#","#","#","#","-","#"},
        {"#","-","#","#","-","-","-","-","-","-","-","#"},
        {"#","-","-","#","#","-","#","#","#","#","-","#"},
        {"#","#","-","#","#","-","#","-","-","-","-","#"},
        {"#","#","-","#","#","-","#","-","#","#","#","#"},
        {"#","D","-","-","-","-","#","-","-","S","#","#"},
        {"#","#","#","#","#","#","#","#","#","#","#","#"}};

        //Sphinxposition suchen
        while (Garten[Standort[0], Standort[1]] == "D" ^ Garten[Standort[0], Standort[1]] == "S" ^ Garten[Standort[0], Standort[1]] == "#" ^ Garten[Standort[0], Standort[1]] == "Z" ^ Garten[Standort[0], Standort[1]] == "S")
        {
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            int Zufallszahl2 = rnd2.Next(1, 9);
            int Zufallszahl3 = rnd3.Next(1, 9);
            Standort[0] = Zufallszahl2;
            Standort[1] = Zufallszahl3;
        }
        Garten[Standort[0], Standort[1]] = "P";

        //Seherposition suchen
        while (Garten[Standort[0], Standort[1]] == "D" ^ Garten[Standort[0], Standort[1]] == "P" ^ Garten[Standort[0], Standort[1]] == "#" ^ Garten[Standort[0], Standort[1]] == "Z" ^ Garten[Standort[0], Standort[1]] == "S")
        {
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            int Zufallszahl2 = rnd2.Next(1, 9);
            int Zufallszahl3 = rnd3.Next(1, 9);
            Standort[0] = Zufallszahl2;
            Standort[1] = Zufallszahl3;
        }
        Garten[Standort[0], Standort[1]] = "W";
        
            //Startposition suchen
        for (int i = 0; i < Garten.GetLength(0); i++)
        {
            for (int j = 0; j < Garten.GetLength(1); j++)
            {
                if (Garten[i, j] == "S")
                {
                    Standort[0] = j;
                    Standort[1] = i;
                }
            }
        }
        Random rnd = new Random();
        int Zufallszahl = rnd.Next(1, 4);
            switch(Zufallszahl) {
                case (1):
                    RichtungVar = Blickrichtung.Ost;
            break;
                case (2):
                    RichtungVar = Blickrichtung.West;
            break;
                case (3):
                    RichtungVar = Blickrichtung.S�d;
            break;
                case (4):
                    RichtungVar = Blickrichtung.Nord;
            break;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("D�dalos: Es ist eine laaange Geschichte...\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" a) ich habe Zeit\n d) mach hin!\n");
            if (Console.ReadLine() == "a")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Ok, ich, D�dalos, k�niglicher Baumeister und Ahnherr aller...!\n");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\nso viel Zeit habe ich doch nicht, alter Mann!\n");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Alles begann so wie ich es dir erz�hle, Theseus, Sohn des K�nigs Aigeus von\nAthen und der Aithra:\n\nMinos, der Sohn von Zeus, ist Gemahl der Pasipha� und Vater der Ariadne und des Androgeos. Er und seine Br�der wurden von Asterios, dem K�nig von Kreta,\nadoptiert. In der Frage, wer dessen Nachfolge antreten sollte, kam es zum Streitzwischen den Dreien. Der griechische Gott Poseidon schenkte dem Minos einen\nherrlichen, wei�en Stier, so dass damit der Streit entschieden war und Minos\nK�nig von Kreta wurde. Da Minos der Stier so gut gefiel, dass er einen anderen\nStier an seiner statt opferte, z�rnte ihm Zeus und strafte ihn dadurch, dass\nseine Gemahlin Pasipha� diesen Stier begehrte und sich eigens dazu vom k�nig-\nlichen Baumeister und Ahnherrn aller K�nstler, mir, eine hohle, h�lzerne Kuh,\ndie mit Kuhhaut �berzogen war, anfertigen lie�. Ich brachte die h�lzerne Kuh zurHerde, woraufhin die darin versteckte Pasipha� mit dem g�ttlichen Stier den\nStiermenschen Minotauros, ein menschenfressendes Ungeheuer, zeugte und gebar.\nK�nig Minos lie� dieses Ungeheuer mit menschlichem Leib und Stierkopf nicht\nt�ten, sondern beauftragte mich mit dem Bau eines sicheren Verstecks, dem\nsagenhaften Labyrinth. Den Tod an seinem Sohn Androgeos bei einem sportlichen\nWettkampf in Attika nahm K�nig Minos zum Anlass, die Athener zu einem j�hrlichenTribut von 7 J�nglingen und 7 Jungfrauen zu zwingen, die dem Minotauros geopfertwurden. Und du, Prinz Theseus, verf�gst dich freiwillig unter die Geiseln, um\nden Minotauros zu t�ten!? Du bist ein Idiot!\n\n");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Ein Patriot!\n");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Was auch immer! Viel Gl�ck!\n\n Ach, die kleine Ariadne hat noch was f�r dich!\n\n\n");
                Console.ReadLine();
                Console.Write("�brigens, das Wort IDIOT kommt von Idiotos und bezeichnet jemanden, der sich\nnur um seine eigenen Dinge k�mmert, also das Gegenteil von Politikos!\nIst also gar nicht so schlimm ein Idiot zu sein.\n\n\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadLine();
            Console.Write("          _\n         / }\n        /\'.\\\n      _/ ) (`-\n        ( ,)\n         |/\n        /|\n       \'  `\n\n");
            Console.Write("Uhh, da ist Ariadne, die Tochter von Minos!\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Kalli nichta! ");
        nochmal:
            Console.Write("Mein H�bscher, wie gehts dir so?\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n a) gut\n s) naja\n d) Gulp...�h....\n");
            switch (Console.ReadLine())
            {
                case ("a"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nIch komm ein bisschen n�her, gehts dir dann besser?\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal;
                case ("s"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nIch komm noch ein bisschen n�her, gehts dir dann besser?\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal;
                case ("d"):
                    Console.Write("\nGulp...�h.... (ich glaube, ich habe mich verliebt!)\n\n");
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Sei ehrlich, Kleiner!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal;
            }
            Console.Clear();
        nochmal2:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Warum gehst du zum Labyrinth, der Minotauros ist gef�hrlich, Kleiner!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n a) ich will Patriot werden!\n s) ich hau ab!\n d) Gulp...�h....\n");
            switch (Console.ReadLine())
            {
                case ("a"):
                    Console.Write("\noh...�h....ja... ich bin ausgezogen, um ein m�chtiger athenischer Patriot\nzu werden, und Minotauros das Handwerk zu legen.\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case ("s"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nBist du ein kleiner Feigling?\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\n�h, ne, ich hatte nur verstanden, dass du mich heiraten willst!\n\n");
                    Console.ReadLine();
                    goto nochmal2;
                case ("d"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nBitte, ich kann dich nicht verstehen!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal2;
                default:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nSprich mit mir, S��er!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal2;
            }
            Console.Clear();
        nochmal3:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Uhh, ein Patriot?! (Meist gibt es nur patriotische Idioten.)\nIch kann dir helfen, wenn...\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n a) glaub ich nicht!\n s) ich hau ab!\n d) wenn was?\n");
            switch (Console.ReadLine())
            {
                case ("a"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nGlaube mir: <Ich kann dir helfen! Die Macht wird mit dir sein!>\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal3;
                case ("s"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nDu bist doch ein feiger Barbar!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\n�h, ne, war deine Frage nicht sowas wie, ...wenn du mich heiratest?\n\n");
                    Console.ReadLine();
                    goto nochmal3;
                case ("d"):
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nKomm, ich fl�ster dir was ins Ohr!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal3;
            }
            Console.Clear();
        nochmal4:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Wenn du mich HEIRATEST und nach Athen bringst, nachdem du Minotaurus\nerledigt hast!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n a) ich liebe das Jungesellenleben!\n s) verdammt, ich will dich!\n d) wenn was?\n");
            switch (Console.ReadLine())
            {
                case ("a"):
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nwa?!...heiraten....in meinem Alter?!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nOhne meine Hilfe kommst du nie aus dem Labyrinth!\n\n");
                    Console.ReadLine();
                    goto nochmal4;
                case ("s"):
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nOk, ich heirate dich!\n(Ich verspreche, ich versprach, ich habe mich versprochen!)\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("O, Liebster\nHier, ich schenke dir das magische Wollkn�ul des D�dalos, damit du jederzeit ausdem Labyrinth wieder herausfindest. Ich warte auf dich!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\n\nSuper!\n\n");
                    Console.ReadLine();
                    break;
                case ("d"):
                    goto nochmal4;
                default:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nH�re mich, an!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal4;
            }
        }
        Console.Clear();
        Console.Write("Herzlich Willkomen beim Faden der Ariadne.\n\nDu bist der Heros Theseus, der auszog, um den ungeheuerlichen Minotauros,\nder j�hrlich sieben athenische J�nglinge und Jungfrauen als Tribut verlangt,\nzu t�ten und ein paar athenische Verdienstmedallien zu bekommen, die so sch�n\nglitzern und hast dich deshalb freiwillig unter die Geiseln gemischt!");
        Console.ReadLine();
        Console.Clear();
            EndMusik();
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("\n\nAuf dem Schild vor dir steht:\n\n           LABYRINTHUS HIC HABITAT MINOTAURUS!\n      (Du stehst vor dem Labyrinth des Minothaurus.)\n\n\n Deine Blickrichtung ist: " + RichtungVar + "\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //Blickrichtung
        static int[] Blickr�ckgabe(Blickrichtung Richtung, int[] Standort)
        {
            switch (Richtung)
            {
                case Blickrichtung.Ost:
                    Blickrichtungsort[0] = Standort[0];
                    Blickrichtungsort[1] = Standort[1] + 1;
                    break;
                case Blickrichtung.West:
                    Blickrichtungsort[0] = Standort[0];
                    Blickrichtungsort[1] = Standort[1]- 1;
                    break;
                case Blickrichtung.S�d:
                    Blickrichtungsort[0] = Standort[0]+ 1;
                    Blickrichtungsort[1] = Standort[1];
                    break;
                case Blickrichtung.Nord:
                    Blickrichtungsort[0] = Standort[0]- 1;
                    Blickrichtungsort[1] = Standort[1];
                    break;
            }

            if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] != "#")
            {
                FeldFrei = true;
            }
            else
            {
                FeldFrei = false;
            }
            return Blickrichtungsort;
        }


        //Programmstart
        static void Start()
        {
            weitermachen = true;
            do
            {
                Console.Write("Du kannst aus folgenden M�glichkeiten w�hlen:\n w) einen Schritt machen!\n s) umschauen!\n a) linksdrehen!\n d) rechtsdrehen!\n e) reden!\n q) aufgeben!\n");
                //Sagen wo er ist, Karte, sagen, was er f�r M�glichkeiten hat.
                string Aktion = Console.ReadLine();
                switch (Aktion)
                {
                    case "w":
                        Schritt();
                        break;
                    case "s":
                        Umschauen();
                        break;
                    case "a":
                        LinksDrehen();
                        break;
                    case "d":
                        RechtsDrehen();
                        break;
                    case "e":
                        Reden();
                        break;
                    case "q":
                        weitermachen = false;
                        break;
                    default:
                        if (erstes == true)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nBitte mit a, w, s oder so antworten, sonst hol ich den DREIK�PFIGEN AFFEN!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            erstes = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.Write("\n                    .-\"\"-..-\"\"-.-\"-.\n                  _/-=-. /-=-./-=-. \\\n                 (_|o o/ |o o/\\o o /|_\n                  / \"  \\/ \"  \\/ \"  \\,_)\n              _   \\`=\' /\\`=\' /\\,=\' //\n             / \\_ .;--\' .;--\' .;--\'�\n             \\___)//            ,  \\\n              \\ \\/; _____)(_____ \\  \\\n               \\_.|:::::::::::::: | |\n                .-\\ \':::::::::::_/_/\n              .\'  _;.         _(_  \\\n             /  .\'   `\\      /  \\\\_/\n            |_ /       |  |\\\\\n           /  _)       /  /||\n          /  /       _/  / //\n          \\_/       ( `-/ ||\n                    /  /   \\\\ .-.\n                    \\_/     \\\'-\\'\n                             `\"`\n\n");
                            Console.Write("Ah... ich hatte dich gewarnt!!!\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            erstes = true;
                            switch (Console.ReadLine()) {
                                case "w":
                                    Schritt();
                                    break;
                                case "s":
                                    Umschauen();
                                    break;
                                case "a":
                                    LinksDrehen();
                                    break;
                                case "d":
                                    RechtsDrehen();
                                    break;
                                case "e":
                                    Reden();
                                    break;
                                case "q":
                                    weitermachen = false;
                                    break;
                            }
                        }
                        break;
                }

            } while (weitermachen);
        }

            static void Schritt()
            {
                Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
                if (FeldFrei == true)
                {
                  if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "D")
                    {
                        do
                        {
                            Random rnd = new Random();
                            int Zufallszahl = rnd.Next(1, 9);
                            Standort[0] = Zufallszahl;
                        } while (Garten[Standort[0], Standort[1]] == "D" ^ Garten[Standort[0], Standort[1]] == "#" ^ Garten[Standort[0], Standort[1]] == "Z" ^ Garten[Standort[0], Standort[1]] == "W" ^ Garten[Standort[0], Standort[1]] == "S");
                        do
                        {
                            Random rnd = new Random();
                            int Zufallszahl = rnd.Next(1, 10);
                            Standort[1] = Zufallszahl;
                        } while (Garten[Standort[0], Standort[1]] == "D" ^ Garten[Standort[0], Standort[1]] == "#" ^ Garten[Standort[0], Standort[1]] == "Z" ^ Garten[Standort[0], Standort[1]] == "W" ^ Garten[Standort[0], Standort[1]] == "S");
                    Random rnd2 = new Random();
                    int Zufallszahl2 = rnd2.Next(1, 4);
                    switch (Zufallszahl2)
                    {
                        case (1):
                            RichtungVar = Blickrichtung.Ost;
                            break;
                        case (2):
                            RichtungVar = Blickrichtung.West;
                            break;
                        case (3):
                            RichtungVar = Blickrichtung.S�d;
                            break;
                        case (4):
                            RichtungVar = Blickrichtung.Nord;
                            break;
                    }
                    Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nD�dalos hat dich verbeamt!\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nD�dalos: \"Ha hahaha!\"\n\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "W")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nOh, hier ist ein Zettel, darauf steht:\n\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\"Willkommen bei Kassandra, der gro�en Seherin GmbH & Co. KG\nHandlesen, Weinlesen\nKarten legen, Garten pflegen\nund weitere �bernat�rliche Dienstleistungen\n\nSprechstunde: Mo + Fr 23:30 - 1:15\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nVielleicht hilft sie mir weiter, aber ist kaum zu glauben!\n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "P")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nOh, hier ist ein Zettel, darauf steht:\n\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\"Ich bin die Sphinx, Wer mein R�tsel nicht l�sen kann, wird gefressen!\nAch und anders vorbei kommst du eh nicht!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nOh... be�ngstigend!\n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "Z")
                    {
                        if (WarBeiSeherin == false & WarBeiSphinx == false)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nOh, hier ist ein Zettel, darauf steht:\n\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nDu musst noch ZWEI R�tsel l�sen!\nBevor du zum Minotauros kannst!\n\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nAlso los!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (WarBeiSeherin == false & WarBeiSphinx == true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nOh, hier ist ein Zettel, darauf steht:\n\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nDu musst noch ein R�tsel l�sen!\n\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nAlso los!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (WarBeiSeherin == true & WarBeiSphinx == false)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nOh, hier ist ein Zettel, darauf steht:\n\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nDu musst noch ein R�tsel l�sen!\n\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nAlso los!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (WarBeiSeherin == true & WarBeiSphinx == true)
                        {
                        if (Schl�ssel == true)
                        {
                            Schlu�();
                        }
                        else {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nOh, hier ist ein Zettel, darauf steht:\n\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n\"Unbefugten ist der Zugang verboten!\nDieses riesige verschlossene Tor kann nur mit dem riesigen goldenen Schl�ssel\nge�ffnet werden.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nIch muss ihn finden!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        }
                    }
                    else if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "S")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nOh, hier ist ein Zettel an der Mauer, darauf steht:\n\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\"Herz, mein Herz im Kampfget�mmel!\n\nAuf dem Schild oder mit dem Schild.\nDoch ohne Kampf geh ich nicht heim!\"\n\nGezeichnet Archillochos\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nIch sollte mir ein Beispiel nehmen!\n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;                        
                    }
                    else {
                    Standort[0] = Blickrichtungsort[0];
                    Standort[1] = Blickrichtungsort[1];
                    Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n Hep!\n\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nHier ist ein Hindernis\n\n", Standort[0], Standort[1], Blickrichtungsort[0], Blickrichtungsort[1]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

        static void Schlu�()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                                _\n                                                              _( (~\\\n       _ _                        /                          ( \\> > \\\n   -/~/ / ~\\                     :;                \\       _  > /(~\\/\n  || | | /\\ ;\\                   |l      _____     |;     ( \\/ /   /\n  _\\\\)\\)\\)/ ;;;                  `8o __-~     ~\\   d|      \\   \\  //\n ///(())(__/~;;\\                  \"88p;.  -. _\\_;.oP        (_._/ /\n(((__   __ \\\\   \\                  `>,% (\\  (\\./)8\"         ;:\'  i\n)))--`.\'-- (( ;,8 \\               ,;%%%:  ./V^^^V\'          ;.   ;.\n((\\   |   /)) .,88  `: ..,,;;;;,-::::::\'_::\\   ||\\         ;[8:   ;\n )|  ~-~  |(|(888; ..``\'::::8888oooooo.  :\\`^^^/,,~--._    |88::| |\n  \\ -===- /|  \\8;; ``:.      oo.8888888888:`((( o.ooo8888Oo;:;:\'  |\n |_~-___-~_|   `-\\.   `        `o`88888888b` )) 888b88888P\"\"\'     ;\n  ;~~~~;~~         \"`--_`.       b`888888888;(.,\"888b888\"  ..::;-\'\n   ;      ;              ~\"-....  b`8888888:::::.`8888. .:;;;\'\'\n      ;    ;                 `:::. `:::OOO:::::::.`OO\' ;;;\'\'\n :       ;                     `.      \"``::::::\'\'    .\'\n    ;                           `.   \\_              /\n  ;       ;                       +:   ~~--  `:\'  -\';\n                                   `:         : .::/\n      ;                            ;;+_  :::. :..;;;\n\n\n");
            Musik();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Buhahaha, ich bin Minotauros, das menschenfressende Ungeheuer!");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Wer bist du, der es wagt mich zu st�ren? ");
        nochmal:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("und WAS beim Tartarus willst du?\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n a) ich will doch nur spielen\n s) du bist so h��lich, wie meine Gro�mutter\n d) Gulp...�h....\n");
            switch (Console.ReadLine())
            {
                case ("a"):
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("und WAS beim Tartarus willst du spielen?\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\n a) Auto.\n s) Doktorspiele.\n d) Verstecken.\n");
                    switch (Console.ReadLine())
                    {
                        case ("a"):
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nTUT TUT, BRUMM BRUMM, QUIETSCH!\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\ndoofes Spiel!\n\n");
                            Console.ReadLine();
                            goto nochmal;
                        case ("s"):
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nOk, ich bin dein Proktologe!\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\nAhhhh!\n\n");
                            Console.ReadLine();
                            goto nochmal;
                        case ("d"):
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\nOk, ich verstecke dich irgendwo im Labyrinth und\ndu musst mich wiederfinden!\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\nNein!\n\n");
                            Console.ReadLine();
                            do
                            {
                                Random rnd = new Random();
                                int Zufallszahl = rnd.Next(1, 9);
                                Standort[0] = Zufallszahl;
                            } while (Garten[Standort[0], Standort[1]] == "D" ^ Garten[Standort[0], Standort[1]] == "#" ^ Garten[Standort[0], Standort[1]] == "Z" ^ Garten[Standort[0], Standort[1]] == "S");
                            do
                            {
                                Random rnd = new Random();
                                int Zufallszahl = rnd.Next(1, 10);
                                Standort[1] = Zufallszahl;
                            } while (Garten[Standort[0], Standort[1]] == "D" ^ Garten[Standort[0], Standort[1]] == "#" ^ Garten[Standort[0], Standort[1]] == "Z" ^ Garten[Standort[0], Standort[1]] == "S");
                            Random rnd2 = new Random();
                            int Zufallszahl2 = rnd2.Next(1, 4);
                            switch (Zufallszahl2)
                            {
                                case (1):
                                    RichtungVar = Blickrichtung.Ost;
                                    break;
                                case (2):
                                    RichtungVar = Blickrichtung.West;
                                    break;
                                case (3):
                                    RichtungVar = Blickrichtung.S�d;
                                    break;
                                case (4):
                                    RichtungVar = Blickrichtung.Nord;
                                    break;
                            }
                            Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
                            break;
                        default:
                            Console.Write("\nHiergeblieben!\n\n");
                            goto nochmal;
                    }
                    break;
                case ("s"):
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nDu siehst aus wie meine Gro�mutter!\n(Sie hat Schlangen statt Haare auf dem Kopf, aber ich mag sie trotzdem)\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nArrrg, WAS?\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nJa und ihre Augen hast du auch!\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nGrrrr, du meinst?! *SPEUTZ* Wir sind verwandt?\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nJa, aber v�terlicherseits!\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nBuhuhu! *SCHNIEF* Du meinst die alte Iokaste?\nmit der ich seit Jahrzehnten nichts mehr zu tun hatte!?\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nJa, sie hat dich auf ihre Rinderfarm eingeladen!Wo nur gl�ckliche Freilandrinder leben!\nWieso besuchst du sie nicht einmal?\nUnd wenn du Gl�ck hast, erwischst du ab und zu einen Vegitarier!\n");
                    Console.ReadLine();
                    Console.Write("\nWas ist?!\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nTante Io, die alte Kuh. Ich vermisse sie so.\n Du hast Recht, ich verlasse diesen �den Ort und lebe ab sofort auf ihrer Farm.\nTsch��!");
                    Console.ReadLine();
                    Console.Write("\nAch, und wenn du rauswillst: Erst links, dann zweimal rechts...\nAber das findest du schon! Lebe wohl!\n");                   
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nPuh! Das ist gerade nocheimal gut gegangen. �dipus wird mir was erz�hlen, wenn der Typ bei ihm aufkreuzt.\n");
                    Console.ReadLine();
                    Schlu�Ende();
                    break;
                case ("d"):
                    Console.Write("\nGulp...�h...ich muss weg! Tsch�ssi!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nARG! Nicht so schnell!\n\n");
                    Console.ReadLine();
                    goto nochmal;
                default:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\n BUHAHAHAHA! Ick fresse dir! *R�LPS*\n\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    goto nochmal;
            }
        }

        static void Schlu�Ende()
        {
            weitermachen = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Du hast Mino gez�hmt und vertrieben! Da du versprochen hast Ariadne zu heiraten, hast du ja D�dalos Wollkn�ul bekommen, das du klugerweise im Labyrinth ausgelegt hast.\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Garten.GetLength(0); i++)
            {
                Console.Write("\n");
                Console.Write("                    ");
                for (int j = 0; j < Garten.GetLength(1); j++)
                {
                    if (Garten[i, j] == "-" ^ Garten[i, j] == "S")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(" " + Garten[i, j]);
                    Thread.Sleep(50);
                }
            }
            Console.Write("\n\n\n");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Oh, mein Liebster, du bist wieder da!\nNun k�nnen wir das lang erseht und erhoffte vollziehen!\n\nTu es, ja!\n\nHeirate mich!!!\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n a) ich nehme dich wie versprochen mit!\n s) Ich stehe eher auf kleine Knaben!\n d) Gulp...�h...ich hab den Faden verloren.\n");
            switch (Console.ReadLine())
            {
                case ("a"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nJippy, das ging leichter als ich dachte!\n\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadLine();
                    break;
                case ("s"):
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("\nOk, nimmst du mich trotzdem mit? (Ich krieg den schon noch rum!)\n\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nNa gut, komm mit an Bord!\n\n");
                    Console.ReadLine();
                    break;
                case ("d"):
                    Console.Write("\nAh... ich hatte ihn in der Hosentasche!\n\n");
                    Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Ich will dich, jetzt und hier!\n\n");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\nNa gut, komm mit an Bord!\n\n");
                    Console.ReadLine();
                    break;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("D�dalos: Auf der R�ckfahrt nahm er Ariadne wie versprochen als seine Verlobte\nmit, lie� die Schlafende aber auf der Insel Naxos zur�ck.\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nWo bin ich hier?!\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nAuf Naxos und ich bin der scharfe Dionysos, Sch�tzchen! SCHMATZ!\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nTheseus! Warum hast du mich verlassen? Theseus!\n");
            Console.ReadLine();
            Console.Write("\nWir m�ssen doch nicht heiraten, wir k�nnen neue Formen der zwischenmenschlicher Beziehung entdecken!\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ReadLine();
            Console.Write("\nWo bist du, Theseus?!\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n*SCHMATZ*\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nAhhhh!\n");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("D�dalos: Auf Naxos wurde die Verlassene und Klagende von Dionysos erw�hlt und erzeugte mit ihr den Oinopion. Nach dem Tode des Aigeus trat Theseus die Herr-\nschaft �ber Attika an und zeichnete sich durch weise Herrschaft sowie durch\nk�hne Heldentaten aus (Er bekam das attische Verdienstdoppelkreuz am Band!).\nEr stiftete die panathen�ischen und isthmischen Spiele, zog mit Herakles gegen\ndie Amazonen und erhielt als Siegespreis die K�nigin Antiope/Hippolyte, die ihm\nden Hippolytos gebar.\n\nSo lebten alle gl�cklich und zufrieden bis an ihr Lebensende.\n\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n*SCHMATZ*\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.ReadLine();
            Console.Write("\n*KAWUMM!*\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nAuauauaua! *JAMMER*\n");
            Console.ReadLine();
            Console.Write("\n*SCHMATZ*\n");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\n\n\n\n\n\n\n\n                    Programmierpraktikum C# WS06/07\n                         Davud Rostam-Afschar\n");
            Console.ReadLine();
        }
        static void LinksDrehen()
        {
                    switch (RichtungVar)
                    {
                        case (Blickrichtung.Ost):
                            RichtungVar = Blickrichtung.Nord;
                            break;
                        case (Blickrichtung.West):
                            RichtungVar = Blickrichtung.S�d;
                            break;
                        case (Blickrichtung.S�d):
                            RichtungVar = Blickrichtung.Ost;
                            break;
                        case (Blickrichtung.Nord):
                            RichtungVar = Blickrichtung.West;
                            break;
                    }
           
            Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
            //Console.Write("Blickkoordinaten: " + Blickrichtungsort[0] + Blickrichtungsort[1]);         
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n Kompassnadel zeigt gen " + RichtungVar + "\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    
        static void RechtsDrehen()
        {
                switch (RichtungVar)
                    {
                        case (Blickrichtung.Ost):
                            RichtungVar = Blickrichtung.S�d;
                            break;
                        case (Blickrichtung.West):
                            RichtungVar = Blickrichtung.Nord;
                            break;
                        case (Blickrichtung.S�d):
                            RichtungVar = Blickrichtung.West;
                            break;
                        case (Blickrichtung.Nord):
                            RichtungVar = Blickrichtung.Ost;
                            break;
                    }
            Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
            //Console.Write("Blickkoordinaten: " + Blickrichtungsort[0] + Blickrichtungsort[1]);         
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n Kompassnadel zeigt gen " + RichtungVar + "\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Umschauen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Blickr�ckgabe(RichtungVar, Standort);
            Console.Write("Kompassnadel zeigt gen " + RichtungVar + "\n");
            switch (RichtungVar) { 
                case (Blickrichtung.Ost):
                    Console.Write("          ______________\n         /|            |\\             # bedeutet Wand\n        / |            | \\            - bedeutet Weg\n       /  |            |  \\           S bedeutet Startpunkt\n      /   |     {0}      |   \\          Z bedeutet Ziel\n     /    |            |    \\\n    /     |            |     \\\n   /      |            |      \\\n   |      |____________|      |\n   |  {1}  /              \\  {2}  |\n   |    /                \\    |\n   |   /                  \\   |\n   |  /                    \\  |\n   | /                      \\ |\n   |/                        \\|\n   �                          `  \n\n", Garten[Blickrichtungsort[0], Blickrichtungsort[1]], Garten[Standort[0] - 1, Standort[1]], Garten[Standort[0] + 1, Standort[1]]); 
                    break;
                case (Blickrichtung.West):
                    Console.Write("          ______________\n         /|            |\\             # bedeutet Wand\n        / |            | \\            - bedeutet Weg\n       /  |            |  \\           S bedeutet Startpunkt\n      /   |     {0}      |   \\          Z bedeutet Ziel\n     /    |            |    \\\n    /     |            |     \\\n   /      |            |      \\\n   |      |____________|      |\n   |  {1}  /              \\  {2}  |\n   |    /                \\    |\n   |   /                  \\   |\n   |  /                    \\  |\n   | /                      \\ |\n   |/                        \\|\n   �                          `  \n\n", Garten[Blickrichtungsort[0], Blickrichtungsort[1]], Garten[Standort[0] + 1, Standort[1]], Garten[Standort[0] - 1, Standort[1]]); 
                    break;
                case (Blickrichtung.S�d):
                    Console.Write("          ______________\n         /|            |\\             # bedeutet Wand\n        / |            | \\            - bedeutet Weg\n       /  |            |  \\           S bedeutet Startpunkt\n      /   |     {0}      |   \\          Z bedeutet Ziel\n     /    |            |    \\\n    /     |            |     \\\n   /      |            |      \\\n   |      |____________|      |\n   |  {1}  /              \\  {2}  |\n   |    /                \\    |\n   |   /                  \\   |\n   |  /                    \\  |\n   | /                      \\ |\n   |/                        \\|\n   �                          `  \n\n", Garten[Blickrichtungsort[0], Blickrichtungsort[1]], Garten[Standort[0], Standort[1] + 1], Garten[Standort[0], Standort[1] - 1]); 
                    break;
                case (Blickrichtung.Nord):
                    Console.Write("          ______________\n         /|            |\\             # bedeutet Wand\n        / |            | \\            - bedeutet Weg\n       /  |            |  \\           S bedeutet Startpunkt\n      /   |     {0}      |   \\          Z bedeutet Ziel\n     /    |            |    \\\n    /     |            |     \\\n   /      |            |      \\\n   |      |____________|      |\n   |  {1}  /              \\  {2}  |\n   |    /                \\    |\n   |   /                  \\   |\n   |  /                    \\  |\n   | /                      \\ |\n   |/                        \\|\n   �                          `  \n\n", Garten[Blickrichtungsort[0], Blickrichtungsort[1]], Garten[Standort[0], Standort[1] - 1], Garten[Standort[0], Standort[1] + 1]); 
                    break;
                default:
                    Console.Write("          ______________\n         /|            |\\             # bedeutet Wand\n        / |            | \\            - bedeutet Weg\n       /  |            |  \\           S bedeutet Startpunkt\n      /   |      x       |   \\          Z bedeutet Ziel\n     /    |            |    \\\n    /     |            |     \\\n   /      |            |      \\\n   |      |____________|      |\n   |   x   /              \\   x   |\n   |    /                \\    |\n   |   /                  \\   |\n   |  /                    \\  |\n   | /                      \\ |\n   |/                        \\|\n   �                          `  \n\n"); 
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Reden()
        {
            Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
            if (FeldFrei == true)
            {
                    if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "W")
                    {
                        Wahrsager();
                    }
                    else if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "P")
                    {
                        Sphinx();
                    }
                    else if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "D")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\nHallo D�dalos, hast du meinen Schl�ssel gesehen?\nIch muss ihn irgendwo verloren haben!\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n�h... hier habe ich einen, ist das deiner?\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\nOh ja, danke sch�n! (Ein sch�ner goldener Schl�ssel)\n\n");
                        Schl�ssel = true;
                    }
                    else if (Garten[Blickrichtungsort[0], Blickrichtungsort[1]] == "Z")
                    {
                        if (Schl�ssel == true)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nIhh!\n\n");
                            Console.ReadLine();
                            Console.Write("\nAch so ist nur ein h��licher Stiermann, der einen Kopf in der Hand h�lt!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\nWahnsinn, ein riesiges verschlossenes Tor!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nMit drei Meter Feldweg reden ist oberlangweilig!\n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nIch glaube, ich spreche mit einer Wand!?\n\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void Musik() //Hab ich aus der Hilfe
        {
            Note[] Melodie = { new Note(Tonh�he.C5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.Dsharp5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.G5, Dauer.Sechzehntel), new Note(Tonh�he.C5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.Dsharp5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.G5, Dauer.Sechzehntel), new Note(Tonh�he.Gsharp4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.C5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.Dsharp5, Dauer.Sechzehntel), new Note(Tonh�he.Gsharp4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.C5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.Dsharp5, Dauer.Sechzehntel), new Note(Tonh�he.F4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.Gsharp4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.C5, Dauer.Sechzehntel), new Note(Tonh�he.F4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.Gsharp4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.C5, Dauer.Sechzehntel), new Note(Tonh�he.G4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.Asharp4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.D5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.Asharp4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.G4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.Asharp4, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Sechzehntel), new Note(Tonh�he.D5, Dauer.Sechzehntel) };
            Play(Melodie);
        }
        static void EndMusik() //Hab ich aus der Hilfe
        {
            Note[] Schlu�Melodie = { new Note(Tonh�he.C5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.Dsharp5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.G5, Dauer.Sechzehntel), new Note(Tonh�he.REST, Dauer.Achtel), new Note(Tonh�he.C6, Dauer.Sechzehntel) };
            Play(Schlu�Melodie);
        }
        static void Play(Note[] Ton) //Hab ich aus der Hilfe
        {
            foreach (Note n in Ton)
            {
                if (n.Notenh�he == Tonh�he.REST)
                    Thread.Sleep((int)n.Notendauer);
                else
                    Console.Beep((int)n.Notenh�he, (int)n.Notendauer);
            }
        }
        static void Wahrsager()
        {
            //ConsoleKeyInfo a;
            //a = Console.ReadKey();
            //switch (a.KeyChar)
            //    case 'a':
            //        break;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n...Ja, ich kann auch Gedanken lesen!\n\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nHey, gut geraten! Wie machst du das?\n\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\nDas war nicht geraten, das war gewusst!\n\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nJa, klar!\n\n");
            Console.ReadLine();
        nochmal:
            int[,] Zahlen = new int[,] { { 99, 79, 59, 39, 19 }, { 98, 78, 58, 38, 18 }, { 97, 77, 57, 37, 17 }, { 96, 76, 56, 36, 16 }, { 95, 75, 55, 35, 15 }, { 94, 74, 54, 34, 14 }, { 93, 73, 53, 33, 13 }, { 92, 72, 52, 32, 12 }, { 91, 71, 51, 31, 11 }, { 90, 70, 50, 30, 10 }, { 89, 69, 49, 29, 9 }, { 88, 68, 48, 28, 8 }, { 87, 67, 47, 27, 7 }, { 86, 66, 46, 26, 6 }, { 85, 65, 45, 25, 5 }, { 84, 64, 44, 24, 4 }, { 83, 63, 43, 23, 3 }, { 82, 62, 42, 22, 2 }, { 81, 61, 41, 21, 1 }, { 80, 60, 40, 20, 0 } };
            string[,] Symbolposition = new string[,] { { "0", "0", "0", "0", "0" }, { "0", "0", "0", "0", "1" }, { "0", "0", "0", "0", "0" }, { "0", "0", "0", "1", "0" }, { "0", "0", "0", "0", "0" }, { "0", "0", "1", "0", "0" }, { "0", "0", "0", "0", "0" }, { "0", "1", "0", "0", "0" }, { "0", "0", "0", "0", "0" }, { "0", "0", "0", "0", "0" }, { "0", "0", "0", "0", "1" }, { "0", "0", "0", "0", "0" }, { "0", "0", "0", "1", "0" }, { "0", "0", "0", "0", "0" }, { "0", "0", "1", "0", "0" }, { "0", "0", "0", "0", "0" }, { "0", "1", "0", "0", "0" }, { "0", "0", "0", "0", "0" }, { "1", "0", "0", "0", "0" }, { "0", "0", "0", "0", "0" } };
            string[] Symbole = new string[] { "�", "^", "?", "~", "+", "#", "*", "\'", "<", ">", "|", "-", "_", ":", ";", "�", "�", "�", "�", "!", "\"", "�", "$", "%", "&", "@", "�", "`" };
            int Zufallszahl;      
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\nNun gut, dann teste mich eben.\nDenke an eine Zweistellige folgender magischen Zahlen und ermittele die\nQuersumme. Diese als Substrakt von deiner gedachten Zahl ergibt eine Zahl die\ndich zum verhexten Symbol f�hrt, dass du dir merkst.\nBeispiel: deine Nummer: 32 -> 3 + 2 = 5 -> 32 � 5 = 27\n\n");
            Console.ReadLine();
                Random rnd = new Random();
                Zufallszahl = rnd.Next(1, 28);
            for (int i = 0; i < Zahlen.GetLength(0); i++)
            {
                Console.Write("\n");
                Console.Write("                   ");
                for (int j = 0; j < Zahlen.GetLength(1); j++)
                {
                    if (Zahlen[i, j] < 10)
                    {
                        Console.Write("  " + Zahlen[i, j]);
                    }
                    else { Console.ForegroundColor = ConsoleColor.White; Console.Write(" " + Zahlen[i, j]); Console.ForegroundColor = ConsoleColor.Gray; }
                    if (Symbolposition[i, j] == "1")
                    {
                        Symbolposition[i, j] = Symbole[Zufallszahl];
                    }
                    else {
                            Random rnd2 = new Random();
                            int Zufallszahl2 = rnd2.Next(1, 28);
                            Symbolposition[i, j] = Symbole[Zufallszahl2];
                            Thread.Sleep(50);
                    }
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" " + Symbolposition[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }    
            }
            Console.Write("\n\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Hast du dir das Symbol a) gemerkt oder willst du d) das ganze nochmal sehen?\n");
            if (Console.ReadLine() == "a")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Du hast dir das Symbol (" + Symbole[Zufallszahl] + ") gedacht!\n");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(Ich habe das Gef�hl, dass sie mich irgendwie reingelegt hat!)\n");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Ich sp�re Zweifel, willst du mich erneut testen? Dann dr�cke \"a\"!\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (Console.ReadLine() == "a")
                {
                    goto nochmal;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Du hast mich getestet, jetzt stell ich dir ein R�tsel, damit du vorbei kannst!\n");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Ich w�re soweit!\n");
                Console.ReadLine();
            nochmal2:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Es gibt sieben H�user, in jedem Haus wohnen sieben Katzen. Jede Katze frisst sieben M�use, von denen wiederum jede sieben Korn�hren gefressen hat. In jeder �hre sind sieben Samen. Wie viele Objekte sind es?\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n a) Das ist leicht!\n s) Ich will aufh�ren!\n d) Ich habe die Frage nicht verstanden!\n");
                switch (Console.ReadLine())
                {
                    case ("a"):
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\nGut, dann gib dein Ergebnis mal ein!\n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (Console.ReadLine() != "19607")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\nDas war wohl nix!\n\n");
                            goto nochmal2;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\nSehr gut, du darfst passieren!\nAber h�te dich vor D�dalos, er hat ein paar Tricks auf Lager!\n\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\nD�dalos ist doch ein feiner Kerl, ich glaube dir nicht. Leb wohl!\n");
                            Console.ReadLine();
                            Console.Clear();
                            Garten[Blickrichtungsort[0], Blickrichtungsort[1]] = "-";
                            Standort[0] = Blickrichtungsort[0];
                            Standort[1] = Blickrichtungsort[1];
                            Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n Hep!\n\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }
                    case ("s"):
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\nWer nicht so eine Frage beantworten kann, kann auch keinen Minotauros besiegen.\n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case ("d"):
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\nNochmal f�r die Bl#den, �h.. Blinden!\n\n");
                        goto nochmal2;
                    default:
                        goto nochmal2;
                }           
            }
            else { goto nochmal; }
            WarBeiSeherin = true;
        }
        static void Sphinx()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Hallo Frau Sphinx, darf ich an Ihnen vorbei!\n");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nIch habe ein kleines R�tsel f�r dich. Wenn du es nicht l�sen kannst\n, dann fresse ich dich!\n");
            Console.ReadLine();
        nochmal:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Es ist am Morgen vierf��ig, am Mittag zweif��ig, am Abend dreif��ig.\nVon allen Gesch�pfen wechselt es allein in der Zahl seiner F��e;\naber eben, wenn es die meisten F��e bewegt, sind Kraft und Schnelligkeit bei ihm am geringsten.\nWer ist das?\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n a) Das ist leicht!\n s) Friss mich nicht!\n d) Ich habe die Frage nicht verstanden!\n");
            switch (Console.ReadLine())
            {
                case ("a"):
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\nNur nicht so naseweis! Bitte eintippen!\n\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (Console.ReadLine() != "Der Mensch")
                    {
                        if (Nase == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\nSo jetzt wird gefressen!\n\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\nNein! Ich hau dir sonst auf die Nase!\n\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\n*BUMMMMS*\n\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\nAAHHHH!\n\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\n*RUUUTSCH*\n\n");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\n(Etwas n�selnd) Meine Nase! Gib mir meine Nase!\n\n");
                            Nase = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\n(immernoch n�selnd) Falsch! Ich lasse dich am Leben, aber nicht durch!\n\n");
                            Console.ReadLine();
                        }
                        goto nochmal;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\nDu hast mein R�tsel gel�st, du darfst gehen!\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\nJa, jetzt hab ich die Nase vorn!\n");
                        Console.ReadLine();
                        Console.Clear();
                        Garten[Blickrichtungsort[0], Blickrichtungsort[1]] = "-";
                        Standort[0] = Blickrichtungsort[0];
                        Standort[1] = Blickrichtungsort[1];
                        Blickrichtungsort = Blickr�ckgabe(RichtungVar, Standort);
                        Console.ForegroundColor = ConsoleColor.White; 
                        Console.Write("\n Hep!\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    }
                case ("s"):
                    if (Nase == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\nSo jetzt wird gefressen!\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\nNein! Ich hau dir sonst auf die Nase!\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("\n*BUMMMMS*\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\nAAHHHH!\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n*RUUUTSCH*\n\n");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n(Etwas n�selnd) Meine Nase! Gib mir meine Nase!\n\n");
                        Nase = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("\n(immernoch n�selnd) Ich lasse dich am Leben, aber nicht durch!\n\n");
                        Console.ReadLine();
                    }
                    goto nochmal;
                case ("d"):
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\nIch werde noch einmal wiederholen!\n\n");
                    Console.ReadLine();
                    goto nochmal;
                default:
                    goto nochmal;
            }
           WarBeiSphinx = true;
        }
      }
}