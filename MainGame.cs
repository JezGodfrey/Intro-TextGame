using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

// NOTE: This game is an exercise in showcasing my code knowledge thus far as I learn C#.

// TODO:
// Find a way to block input from players during story moments - inputs end up stacking and play out once sequences that take player input resume.
// ^-- Pressing Enter before such sequences works as a temporary fix but disrupts the flow of the experience at certain points.
// Develop the stats more - strength and defense are unused stats - and subsequently more mini-games to 'train' them.
// Level up system is also unused


namespace FirstProject
{
    class Entity
    {
        public string name;
        public int level;
        public int exp;
        public int[] lvlup;
        public int hp;
        public int stamina;
        public int maxhp;
        public int maxstamina;
        public int str;
        public int def;
        public int speed;
        public string[] attacks;
        public int[] damage;
        public int[] costs;
        public string[] ftext;
        public bool psn;

        public Entity(string _name, int _level, int _exp, int[] _lvlup, int _hp, int _stamina, int _maxhp, int _maxstamina, int _str, int _def, int _speed, string[] _attacks, int[] _damage, int[] _costs, string[] _ftext, bool _psn)
        {
            name = _name;
            level = _level;
            exp = _exp;
            lvlup = _lvlup;
            hp = _hp;
            stamina = _stamina;
            maxhp = _maxhp;
            maxstamina = _maxstamina;
            str = _str;
            def = _def;
            speed = _speed;
            attacks = _attacks;
            damage = _damage;
            costs = _costs;
            ftext = _ftext;
            psn = _psn;

        }

        public static void GameText(string s, int textSpeed = 30, int textStop = 300)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                if (s[i] == '?' || s[i] == '.' || s[i] == '!')
                {
                    Thread.Sleep(textStop);
                }
                else
                {
                    Thread.Sleep(textSpeed);
                }
            }
        }


        public void PlayerStats()
        {

            Console.WriteLine($"\n- {name} Stats -\nHealth: {hp} / {maxhp}\nPower Points: {stamina} / {maxstamina}\n\ntrain\theal\tq - quit\n");
            // Strength: {str}\nDefence: {def}\n

        }


        public bool crit()
        {
            Random rand = new Random();
            int rng = rand.Next(0, 100);
            bool crit = rng % 15 == 0;
            
            return crit;
        }


        public int eChoice()
        {
            int rng;

            do
            {
                Random rand = new Random();
                rng = rand.Next(0, attacks.Length);
            } while (costs[rng] > stamina);

            return rng;

        }

        public void playerStatus(string statusMove)
        {
            Random rand = new Random();
            int rng = rand.Next(0, 100);

            if (statusMove == "Rest")
            {
                if (rng != 55 && rng % 5 == 0)
                {
                    GameText($"Nice!\n{name} healed 8HP and 4BP!\n");
                    hp = hp + 8;
                    stamina = stamina + 4;
                }
                else if (rng % 11 == 0)
                {
                    GameText($"{name} healed 10HP and 6BP!\nPhew!\n");
                    hp = hp + 10;
                    stamina = stamina + 6;
                } else
                {
                    GameText($"{name} healed 5HP and 3BP!\n");
                    hp = hp + 5;
                    stamina = stamina + 3;
                }


            }


            if (hp > maxhp)
            {
                hp = maxhp;
            }

            if (stamina > maxstamina)
            {
                stamina = maxstamina;
            }


        }


        public void Status(string statusMove)
        {
            Random rand = new Random();
            int rng = rand.Next(0, 100);

            if (statusMove == "Rest")
            {
                if (rng != 55 && rng % 5 == 0)
                {
                    //hp = hp + 10;
                    stamina = stamina + 10;
                }
                else if (rng % 11 == 0)
                {
                    //hp = hp + 15;
                    stamina = stamina + 15;
                }
                else
                {
                    //hp = hp + 5;
                    stamina = stamina + 5;
                }

                if (stamina > maxstamina)
                {
                    stamina = maxstamina;
                }

            }

            if (statusMove == "Compose")
            {
                if (rng != 55 && rng % 5 == 0)
                {
                    //hp = hp + 10;
                    stamina = stamina + 10;
                }
                else if (rng % 11 == 0)
                {
                    //hp = hp + 15;
                    stamina = stamina + 20;
                }
                else
                {
                    //hp = hp + 5;
                    stamina = stamina + 5;
                }

                if (stamina > maxstamina)
                {
                    stamina = maxstamina;
                }

            }

            if (statusMove == "Peeler")
            {
                if (speed > 1)
                {
                    speed--;
                }
            }

            if (statusMove == "Buff Up")
            {
                if (hp < maxhp)
                {
                    hp++;
                }
            }

            if (statusMove == "Sour Juice")
            {
                psn = true;
            }
        }


        public void Approaches()
        {

            // Switch would have been better here

            if (name == "Brock")
            {
                GameText("              * *\n           *    *  *\n      *  *    *     *  *\n     *     *    *  *    *\n * *   *    *    *    *   *\n *     *  *    * * .#  *   *\n *   *     * #.  .# *   *\n  *     \"#.  #: #\" * *    *\n *   * * \"#. ##\" ##      *\n   *       \"#######\n             #o#o\n             ##u#\n             ####\n             ####\n             ####\n            ,####.\n           .######.\n", 1, 1);
                GameText($"\nTrainee {name} shows you the ropes!");
            }
            
            
            if (name == "Snek")
            {
                GameText("             ____\n            / o o\\\n            \\  ---<\n             \\  /\n   __________/ /\n-=:___________/\n", 1,1);
                GameText($"\n{name} slithers erratically!\n");
            }

            if (name == "Octosis")
            {
                GameText("      _______\n ,-~~~       ~~~-,\n(      \\   /      )\n       o   o\n         ^\n \\,-, , , , , ,-,/\n  / / / | | \\ \\ \\\n  | | | | | | | |\n / / /  / \\ \\ \\  \\\n",1,1);
                GameText($"\nValiant {name} holds the fort!\n");
            }

            if (name == "Octobro")
            {
                GameText("      _______\n ,-~~~       ~~~-,\n(      u    u     )\n      .o   o.\n         ^\n \\,-, , , , , ,-,/\n  / / / | | \\ \\ \\\n  | | | | | | | |\n / / /  / \\ \\ \\  \\\n",1,1);
                GameText($"\nDepressed {name} takes a stand!\n");
            }


            if (name == "Banana")
            {
                GameText(" _\n//\\\nV  \\\n \\  \\_\n  \\,'.`-.\n   |\\ `. `.\n   ( \\  `. `-.                        _,.-:\\\n    \\ \\   `.  `-._             __..--' ,-';/\n     \\ `.   `-.   `-..___..---'   _.--' ,'/\n      `. `.    `-. o       __..--'    ,' /\n        `. `-_    o   )..''       _.-' ,'\n          `-_ `-.___        __,--'   ,'\n             `-.__  `----\"\"\"    __.- '\n                  `--..____..--'\n",1,1);
                GameText($"\nIt's a {name}! Crazy!\n\n{name} used Planetary Devastation! (The world will end in 20 turns)\n");
            }

            
            if (name == "Strawbs")
            {
                GameText("            _\n        /> //  __\n    ___/ \\// _/ /\n  ,' , \\_/ \\/ _/__\n /    _/ |--\\  `  `~,\n' , ,/  /`\\ / `  `   `,\n|    |  |  \\> `  `  ` |\n|  ,  \\/ ' '    `  `  /\n`,   '  '    ' `  '  /\n  \\ `   o  'o ' ,  ,'\n   \\ ` `  U   ,  ,/\n    `,  `  '  , ,'\n      \\ `  ,   /\n       `~----~'\n",1,1);
                GameText($"\nRecruit {name} wants a fruitful fight!\n");
            }
            
            if (name == "Carl")
            {
                GameText("  \\/_\n _/\n(,;)\n(,.)\n(,/\n|/\n|\n", 1, 1);
                GameText($"\nControlled Gatekeeper {name} guards the door!\n");
            }
            
            if (name == "Spidra")
            {

                GameText("           ____                      ,\n          /---.'.__             ____//\n               '--.\\\\           /.---'\n" +
                    "          _______  \\\\         //\n        /.------.\\  \\|      .'/  ______\n       //  ___  \\ \\ ||/|\\  //  _/_----.\\__\n" +
                    "      |/  /.-.\\  \\ \\:|< >|// _/.'..\\   '--'\n         //   \\'. | \\'.|.'/ /_/ /  \\\\\n        //     \\ \\_\\/\" ' ~\\-'.- '    \\\\\n" +
                    "       //       '-._| :-: |'-.__     \\\\\n      //           (/'==='\\)'-._\\     ||\n      ||                        \\\\    \\|\n" +
                    "      ||                         \\\\    '\n      |/                          \\\\\n                                   ||\n                                   ||\n" +
                    "                                   \\\\\n                                    '\n", 1, 1);
                GameText($"{name} crawls into your personal space!\n");
            }


            if (name == "Pengin")
            {
                
                // Symbols generated from image - Would be cleaner to load in from separate files rather than hard-coded in


                string imgPengin = "                                            ░▒▒▒▒▒▒▒▒▒\n                                     ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n                                 " +
                    "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n                             ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n                           ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒" +
                    "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n                         ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n                      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒" +
                    "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n                     ▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓██▓▓▓▓▒▒▒▒▒▒\n                   ▒▒▒▒▓▓█▒░      ░▒█▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓" +
                    "▓▒░░    ░░▓▓▓▓▒▒▒▒▒\n                  ▒▒▒▓█▓░  ░░░░░░░░░  ▒█▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓█▒  ░░░░░░░░░░  ▓▓▓▒▒▒▒\n                 ▒▒▓▓░    ░░░░░░░░░░░░░ ▒▓▓▒▒▒▒▒▒▒▒▒▒▒" +
                    "▓▓▓░  ░░░░░░░░░░░░░░  ▒▓▒▒▒▒▒\n               ▒▒▓▓░    ▒░░░░░░░░░░░░░░░░ ▒▓▓▒▒▒▒▒▒▒▓▓▓░ ░░░░░░░░░░░░░░      ░▓▓▒▒▒\n              ░▒▓▓   ████░░░░░░░░░░░░░░░░░" +
                    "░ ▒▓▓▒▒▓▓▓▓░ ░░░░░░░░░░░░░░░░████    ▒▓▓▒▒\n             ▒▒▓▒  ███    ░░░░░░░░░░░░░░░░░░░░▓██▓░ ░░░░░░░░░░░░░░░░░░░   ███▒  ░▓▒▒▒\n             ▒▒▓░░█▒   ░░░░" +
                    "░░░░░░░░░░░░░░░░░░░░   ░░░░░░░░░░░░░░░░░░░░░░░    ██░ ░▓▒▒▒\n            ▒▒▓░░░  ░░░░    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░   ░░░▒▓▒▒▒\n        " +
                    "    ▒▓░░░░░░░          ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░       ░░░░░░░░ ▒▒▒▒▒\n          ▒▒▒▒░░░░░░   ███████  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░   ▓███▒   " +
                    "░░░░░░░▒▓▒▒▒\n       ▒▒▒▒▒▓▒░░░░░  ████▒   ▒█░ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  █████████   ░░░░░░▓▒▒▒▒▒▒▒\n      ▒▒▒▒▒▒▓░░░░░░ █████      █  ░░░░░░░░░░░░░░░░" +
                    "░░░░░░░░░░░░░  █░    █████  ░░░░░ ▓▒▒▒▒▒▒▒▒\n    ▒▒▒▒▒▒▒▒▓▒░░░░░ ██         █░ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ██        ███ ░░░░░ ▒▒▒▒▒▒▒▒▒▒▒\n   ░▒▒▒▒▒▒▒▒▓░░░" +
                    "░░░ █████     ██▓ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ██       ░███ ░░░░░ ▓▒▒▒▒▒▒▒▒▒▒▒\n   ▒▒▒▒▒▒▒▒▒▓░░░░▒▓  ████░  ████  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ████   █████" +
                    "░ ░░░░░░▓▒▒▒▒▒▒▒▒▒▒▒▒\n   ▒▒▒▒▒▒▒▒▒▓▒░░░▒█▒  ██████████  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ ▒██████████▓  ██░░░░▓▒▒▒▒▒▒▒▒▒▒▒▒▒\n   ▒▒▒▒▒▒▒▒▒▒▒░░░░█▓▓   ██████░  ░░" +
                    "░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░░░░░░░  ▓████████   ▓█▒░░░▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒\n    ▒▒▒▒▒▒▒▒▒▓░░░░▓▓▓▓▓░        ░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▓░░░░░░░░░░░    ██▒    ▒▓▓▓░░░ ▓▒▒▒▒▒▒▒▒▒" +
                    "▒▒▒▒░\n    ▒▒▒▒▒▒▒▒▒▓▓░░░░▓▓▓▓▓█▓▓▓▒░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░      ▒▓▓▓▓▓░░░░▒▓▒▒▒▒▒▒▒▒▒▒▒▒▒\n    ░▒▒▒▒▒▒▒▒▒▓░░░░░▒▓█▓▓▓▓█▓░░░░░░░░░░░░░░░▒▒▒▒▒▒▒░" +
                    "░░░░░░░░░░░░░░▒▓▓▓▓█▓▓▓▓▓░░░░░▓▒░░░▒▒▒▒▒▒▒▒\n       ▒▒▒▒▒    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▓▓▓█▓░░░░░░░▓░    ▒▒▒▒▒▒\n                 " +
                    "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓░\n                  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n       " +
                    "           ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n                    ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n    " +
                    "                 ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n                     ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n         " +
                    "         ░░░▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n                 ░▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒░░░\n              " +
                    "  ░▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒░░\n                ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒░\n        " +
                    "         ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░                      ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░\n                  ░░▒▒▒▒▒▒▒▒▒▒░░░                           ░░░▒▒▒▒▒▒▒▒▒▒▒▒░░░\n     " +
                    "               ░░░░░░░░░░░                                 ░░░░░░░░░░░░\n";


                // Inverting 'colors' against black background of cmd
                
                imgPengin = imgPengin.Replace("█", "4");
                imgPengin = imgPengin.Replace(" ", "1");
                imgPengin = imgPengin.Replace("▓", "3");
                imgPengin = imgPengin.Replace("░", "2");

                imgPengin = imgPengin.Replace("4", " ");
                imgPengin = imgPengin.Replace("1", "█");
                imgPengin = imgPengin.Replace("3", "░");
                imgPengin = imgPengin.Replace("2", "▓");

                GameText(imgPengin, 1, 1);
                GameText($"\nBrave Warrior {name} tests your strength!\n", 60);
            }

            
        }
        
    }


    class MainGame
    {

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key);


        public static string textWrap(string text)
        {
            string textWrapped = "";
            int textLength = text.Length;
            int lines = textLength / 140;

            for (int i = 0; i < lines; i++)
            {
                string tempLine = text.Substring(0, 140);
                int spacePos = tempLine.LastIndexOf(" ");
                tempLine = tempLine.Remove(spacePos, 1).Substring(0, spacePos);
                textWrapped += $"{tempLine}\n";
                text = text.Remove(0, spacePos + 1);
            }

            textWrapped += text;

            return textWrapped;
        }


        public static void Opening(string name)
        {

            bool start = true;
            Console.WriteLine("\n\n(Press Spacebar to skip)\n");

            int i = 0;
            string s = "Once upon a time, Nature Land was ruled by a peaceful King, allowing all animals and produce to live freely... that was until the King was\ndefeated by an Evil Crow, who took " +
                "the crown and all its powers. The Evil Crow used the crown to take Nature Land for himself, filling the\nworld with evil. Many years passed and a many noble warriors tried to take " +
                "down the Evil Crow to reclaim Nature Land...\n\nBut no one could...\n\n";
            s += textWrap($"Amidst a dark and stormy night, {name} hears a thud at the door. {name} opened the door cautiously but saw " +
                $"no one around, until suddenly hearing a murmur from below. A penguin lay on the doormat, wounded. {name} quickly brought them inside.");
            s += "\n\nThe next morning...\n\nPengin: Thanks for the save there, bud! I'm Pengin the Penguin. Nice to meet you!";
            if (name == "Pengin")
            {
                s += ".. Huh? That's your name too!? :O";
            }    
            s += "\n\nAfter some pleasantries, Pengin explained how he took on the Evil Crow alone but was defeated in battle.\n\nPengin: All of Nature Land is in trouble if we don't overthrow " +
                "the Evil King... But I wasn't strong enough.\n";

            while (i < s.Length && (GetAsyncKeyState(32) & 0x8000) == 0)
            {

                Console.Write(s[i]);

                if (s[i] == '?' || s[i] == '.' || s[i] == '!')
                {
                    Thread.Sleep(300);
                }
                else
                {
                    Thread.Sleep(60);
                }
                i++;
            }

            Console.Write(s.Substring(i));

            Console.WriteLine("\n(Press Enter to continue)\n");

            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    start = false;
                }
            } while (start);

        }

        public static void GameText(string s, int textSpeed = 30, bool noskip = true, int textStop = 300)
        {

            bool start = true;
            bool skip = false;

            int i = 0;
            while (i < s.Length && !skip)
            {
                if (!((GetAsyncKeyState(32) & 0x8000) == 0) && !noskip)
                {
                    skip = true;
                }
                Console.Write(s[i]);
                if (s[i] == '?' || s[i] == '.' || s[i] == '!')
                {
                    Thread.Sleep(textStop);
                }
                else
                {
                    Thread.Sleep(textSpeed);
                }
                i++;
            }
            Console.Write(s.Substring(i));

            if (skip)
            {
                Console.WriteLine("(Press Enter to continue)\n");
                do
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        start = false;
                    }
                } while (start);
            }
        }



        public static int attack(Entity player)
        {

            ConsoleKeyInfo cki;
            int i;
            int a;


            do
            {

                i = 1;
                a = 20;
                GameText("\nPick an action!\n");
                Console.WriteLine($"HP: {player.hp} / {player.maxhp}\tBP: {player.stamina} / {player.maxstamina}");
                foreach (string at in player.attacks)
                {
                    Console.Write($"{i} - {at}\t");
                    i++;
                }
                Console.WriteLine("\n");

                cki = Console.ReadKey();
                switch (cki.Key.ToString())
                {
                    case "D1":
                        a = 0;
                        break;
                    case "D2":
                        a = 1;
                        break;
                    case "D3":
                        a = 2;
                        break;
                    case "D4":
                        a = 3;
                        break;
                    case "D5":
                        a = 4;
                        break;
                    default:
                        a = 20;
                        continue;
                }

                if (player.costs[a] > player.stamina)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    GameText($"{player.name} is too tired to {player.attacks[a]}.\n");
                    a = 20;
                }

            } while (a < 0 || a > 4);

            Console.SetCursorPosition(0, Console.CursorTop);
            GameText($"{player.name} uses {player.attacks[a]}!\n");
            player.stamina = player.stamina - player.costs[a];
            if (player.damage[a] > 0)
            {
                if (player.crit())
                {
                    GameText($"Whoaaaa!!\n", 100);
                    GameText($"It did {Convert.ToInt32(player.damage[a] * 1.5)} damage!\n");
                    return Convert.ToInt32(player.damage[a] * 1.5);
                }
                else
                {
                    GameText($"It did {player.damage[a]} damage!\n");
                    return player.damage[a];
                }
            }
            else
            {
                player.playerStatus(player.attacks[a]);
                return player.damage[a];
            }

        }


        public static int enemyAttack(Entity player, int a)
        {

            GameText($"{player.name} uses {player.attacks[a]}!\n");
            player.stamina = player.stamina - player.costs[a];
            if (player.damage[a] > 0)
            {
                if (player.crit())
                {
                    GameText($"Yiiikes!!\n", 100);
                    GameText($"It did {Convert.ToInt32(player.damage[a] * 1.5)} damage!\n");
                    GameText($"{player.ftext[a]}\n");
                    return Convert.ToInt32(player.damage[a] * 1.5);
                }
                else
                {
                    GameText($"It did {player.damage[a]} damage!\n");
                    GameText($"{player.ftext[a]}\n");
                    return player.damage[a];
                }
            }
            else
            {
                player.Status(player.attacks[a]);
                GameText($"{player.ftext[a]}\n");
                return 0;
            }

        }



        public static string Fight(Entity player, Entity enemy)
        {

            Stopwatch fightTimer = new Stopwatch();

            enemy.Approaches();

            int pattack;
            int eattack;
            int enemyturns = 1;
            int calc;
            int remainder = 0;
            int update;

            do
            {

                fightTimer.Start();

                Random rand = new Random();
                int rng = rand.Next(0, 100);
                int psndmg;

                pattack = attack(player);
                enemy.hp = enemy.hp - pattack;


                // Get the time elapsed in seconds. Divide number of seconds by enemy's speed value and round down. Enemy gets that many turns.
                // Store the remainder as timer gets reset and add it to next calculation.
                update = Convert.ToInt32(fightTimer.ElapsedMilliseconds / 1000) + remainder; //27
                calc = Convert.ToInt32(update / enemy.speed); //2.7
                remainder = update % enemy.speed;

                enemyturns = enemyturns + calc;


                if (enemyturns > 0)
                {
                    fightTimer.Reset();
                    if (enemy.hp <= 0)
                    {
                        GameText($"{enemy.name} isn't done yet!\n", 60);
                    }
                }

                while (enemyturns > 0)
                {
                    eattack = enemyAttack(enemy, enemy.eChoice());
                    player.hp = player.hp - eattack;
                    enemyturns--;
                }

                if (enemy.psn)
                {
                    GameText($"{player.name} felt sick.\n");
                    if (rng <= 50)
                    {
                        psndmg = 1;
                    }
                    else if (rng >= 51 && rng < 90)
                    {
                        psndmg = 2;
                    }
                    else
                    {
                        psndmg = 3;
                    }
                    GameText($"{player.name} lost {psndmg}HP!\n");
                    player.hp = player.hp - psndmg;
                }

                if (player.hp < 0)
                {
                    player.hp = 0;
                    continue;
                }


                if (enemy.hp < 0)
                {
                    enemy.hp = 0;
                    continue;
                }

                // Below code used when testing.
                // Console.WriteLine($"{player.name} has {player.hp} health left.\n{enemy.name} has {enemy.hp} left.\n");



            } while (player.hp > 0 && enemy.hp > 0);

            if (player.hp == 0)
            {
                Console.WriteLine("\n");
                Thread.Sleep(1000);
                GameText($"{player.name} was defeated...\n\n", 100);
                GameText("G A M E   ", 300);
                Thread.Sleep(500);
                GameText("O V E R\n", 300);
                return "q";

            }
            else if (enemy.hp == 0)
            {

                if (enemy.name == "Evil Crow")
                {
                    Thread.Sleep(1000);
                    GameText($"\n{enemy.name} has been defeated!\n\n", 100);
                    return "win";
                }

                if (enemy.name == "Banana")
                {
                    GameText($"\n{enemy.name} has been", 60);
                    GameText($"has been has been has been has beenbeenbeenbeenbeen", 60);
                    Console.WriteLine("\nError (code 0513) - - Expecting ';' at Line 601");
                    Thread.Sleep(200);
                    Console.WriteLine("C:\\Users\\Banana\\source\\repos\\NatureFight\\bin\\Debug\\net5.0\\NatureFight.exe (process 1328) exited with code 0.\nPlease close the window.\n\n");
                    Thread.Sleep(10000);
                    Console.WriteLine(" ");
                    Thread.Sleep(500);
                    Console.WriteLine(" ");
                    Thread.Sleep(500);
                    GameText($"The {enemy.name} tried to break the game in hopes you would leave...\n", 60);
                    Thread.Sleep(500);
                    GameText($"In the midst of confusion, the {enemy.name} escapes to another dimension!\n\n", 60);
                }
                else
                {
                    Thread.Sleep(1000);
                    GameText($"\n{enemy.name} has been defeated!\n\n", 60);
                }
            }

            return "win";

        }


        static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(142, 48);
            }

            while (true)
            {

                Console.WriteLine("~*-*-  Nature Fight!!  -*-*~\n");
                bool choicecheck = false;
                string choice;
                do
                {
                    Console.WriteLine("What is your name? (Up to 24 characters)");
                    choice = Console.ReadLine();
                    if (choice == "" || choice.Replace(" ", "") == "")
                    {
                        // Default Name
                        choice = "Mishy";
                    }
                    choice = char.ToUpper(choice[0]) + choice.Substring(1);
                    if (choice.Length <= 24)
                    {
                        choicecheck = true;
                    }
                    else
                    {
                        Console.WriteLine("Name too long!\n");
                    }
                } while (!choicecheck);

                Opening(choice);

                string uinput;
                bool readycheck = false;
                do
                {
                    GameText($"{choice}! Will you join the resistance and help us? (Y/N)\n");
                    uinput = Console.ReadLine();
                    if (uinput == "y" || uinput == "Y")
                    {
                        Console.WriteLine("\n");
                        GameText(textWrap($"Pengin: That's great, {choice}! I'm sure with your help we can finally take down the Evil Crow! I sent for my friend to deliver some supplies for our travels." +
                            $" He'll be here any minute, so get yourself ready while you can!\n\n"), 60, false);
                        readycheck = true;
                    }
                    else if (uinput == "n" || uinput == "N")
                    {
                        GameText("\nYou decide you are content under the Evil Crow's rule. Pengin is upset, but understands fighting isn't for everyone.\nHe thanks you for your hospitality and leaves.\n", 60);
                        uinput = "q";
                        readycheck = true;
                    }
                    else
                    {
                        GameText("Try typing \"Y\" or \"N\"\n");
                        continue;
                    }
                } while (!readycheck);

                bool win = false;

                string[] training;
                training = new string[] { "  8  ", "  4  ", "  5  ", "  6  ", "LEFT", " UP ", "RIGHT", "DOWN" };
                int[] trainingKeys;
                trainingKeys = new int[] { 104, 100, 101, 102, 37, 38, 39, 40 };

                // Template
                // Entity Pengin = new("Pengin", 1, 0, new int[] { }, 80, 40, 80, 40, 0, 0, 15, new string[] { }, new int[] { }, new int[] { }, new string[] { });

                Entity Player = new(choice, 1, 0, new int[] { 10, 30, 60, 100, 150 }, 10, 15, 20, 15, 30, 26, 50, new string[] { "Punch", "Kick", "Jump Kick", "Rest" }, new int[] { 3, 5, 8, 0 }, new int[] { 1, 2, 4, 0 }, new string[] { "choice used Punch!", "choice used Kick!", "choice used Jump Kick", "choice took a quick rest..." }, true);
                Entity Spidra = new("Spidra", 1, 0, Array.Empty<int>(), 30, 30, 20, 30, 40, 12, 4, new string[] { "Bite", "Kick", "Web" }, new int[] { 4, 3, 0 }, new int[] { 2, 1, 0 }, new string[] { "Ouch!", "Pretty flimsy.", "Spidra started spinning a web." }, false);
                Entity Pengin = new("Pengin", 1, 0, Array.Empty<int>(), 80, 35, 80, 50, 0, 0, 11, new string[] { "Peck", "Tuxedo Slam", "Chilly Stare", "Sword Slash", "Sniffle", "Rest" }, new int[] { 5, 8, 12, 20, 0, 0 }, new int[] { 5, 7, 8, 15, 0, 0 }, new string[] { "Hey, quit peckin'!", "All in the coat!", "It's freeeezing!", "Shwing!", "Pengin doesn't want to hurt you.", "Pengin took a quick rest." }, false);
                Entity Strawbs = new("Strawbs", 1, 0, Array.Empty<int>(), 60, 10, 80, 20, 0, 0, 9, new string[] { "Tackle", "Seed Barrage", "Sour Juice", "Leaf Trim", "Rest" }, new int[] { 5, 10, 0, 0, 0 }, new int[] { 1, 5, 3, 0, 0 }, new string[] { "Oof.", "Like a machine gun!", "Out of date. Bleh!", "Just straightening up the sides.", "Strawbs took a quick rest." }, false);
                Entity Snek = new("Snek", 1, 0, Array.Empty<int>(), 50, 48, 80, 48, 0, 0, 7, new string[] { "Coil Squeeze", "Sharp Fangs", "Tail Whip", "Headbutt" }, new int[] { 3, 5, 7, 9 }, new int[] { 4, 8, 0, 12 }, new string[] { "That's too tight!", "To the point!", "WH-CHSHH!", "Yeeouch!!" }, false);
                Entity Carl = new("Carl", 1, 0, Array.Empty<int>(), 66, 40, 80, 40, 0, 0, 9, new string[] { "Body Slam", "Peeler", "Peeler", "Block", "Rest" }, new int[] { 10, 15, 0, 0, 0 }, new int[] { 5, 9, 3, 2, 0 }, new string[] { "Didn't see that coming!", "Let's see how YOU like it!", "Carl shed his own skin.\nCarl got faster!", "Carl flexed his muscles.", "Carl took a quick rest." }, false);
                Entity Brock = new("Brock", 1, 0, Array.Empty<int>(), 10, 40, 80, 40, 0, 0, 10, new string[] { "Nothing" }, new int[] { 0 }, new int[] { 0 }, new string[] { "He's just broccoli." }, false);
                Entity Octobro = new("Octobro", 1, 0, Array.Empty<int>(), 48, 19, 80, 39, 0, 0, 8, new string[] { "Beg", "Poke", "Torrential Tears", "Compose" }, new int[] { 0, 1, 40, 0 }, new int[] { 0, 1, 20, 0 }, new string[] { "Octobro just wants the fighting to end!", "A pitiful attempt to attack.", "Octobro can't stop crying! Don't drown!", "Octobro tries to keep it together." }, false);
                Entity Octosis = new("Octosis", 1, 0, Array.Empty<int>(), 80, 28, 80, 38, 0, 0, 8, new string[] { "Tentickle", "Leer", "Octo-slap", "Rest" }, new int[] { 10, 8, 16, 0 }, new int[] { 8, 4, 12, 0 }, new string[] { "Too many tickle!", "Even her stare hurts!", "No leg spared!", "Octosis takes a quick rest..." }, false);
                Entity Banana = new("Banana", 1, 0, Array.Empty<int>(), 70, 80, 80, 80, 0, 0, 7, new string[] { "Peel Slip", "Obnoxious Dance", "?????", "Spacial Rift" }, new int[] { 10, 0, 14, 17 }, new int[] { 5, 0, 9, 8 }, new string[] { "The classic.", "It's driving you bananas!", "You can't even comprehend this attack.", "Banana tore a hole in the universe." }, false); ;
                Entity EvilCrow = new("Evil Crow", 1, 0, Array.Empty<int>(), 100, 30, 80, 30, 0, 0, 15, new string[] { "Peck", "Dive Bomb", "Smirk" }, new int[] { 15, 5, 0 }, new int[] { 1, 1, 1 }, new string[] { "Seriously, stop pecking!", "An explosive dive!", "Evil Crow's laughs at you." }, false);
                // Unused enemy - Entity Bee = new("Bee", 1, 0, Array.Empty<int>(), 80, 40, 80, 40, 0, 0, 15, new string[] { "Sting", "Buzz" }, Array.Empty<int>(), Array.Empty<int>(), new string[] { }, false);
                // Entity EvilPlayer - planned doppelganger enemy that matches the player's stats at any given time.

                int endRest;
                int endRest2;
                int rng;
                bool keepTraining;
                int keyCount;
                int trainSpeed = 3000;
                int trainRound;
                int hiScore = 0;
                bool fightTime = false;
                int fightCount = 0;
                int roundTime = 120;

                Stopwatch sw = new();
                Stopwatch healWatch = new();
                sw.Start();
                int secs;

                while (uinput != "q" && !win)
                {
                    sw.Start();

                    if (Convert.ToInt32(sw.ElapsedMilliseconds / 1000) >= roundTime)
                    {
                        fightTime = true;
                        sw.Stop();
                        GameText("A CHALLENGER APPROACHES!\n\n", 100);
                    }

                    if (fightTime)
                    {

                        switch (fightCount)
                        {
                            case 0:
                                GameText($"Pengin: Okay {choice}. This is Brock. He can show you the-\n\nBrock: hi.\n\nPengin: ...Yeah, hi... He can show you the basics of combat.\n\n", 60, false);
                                Fight(Player, Brock);
                                GameText(textWrap($"Pengin: Great job, {choice}! You sure are strong! But your training's not done yet! Let's head to the Resistance Barracks so you can spar with some of the other recruits. It's just over Spid Hill! You know... I've always wondered why it's called that.\n\n"), 60, false);
                                fightCount++;
                                roundTime = 300;
                                Player.maxhp = Player.maxhp + 10;
                                if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                {
                                    Console.WriteLine("\n(Press Enter to continue)\n");

                                    do
                                    {
                                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                        {
                                            break;
                                        }
                                    } while (fightTime);
                                }
                                fightTime = false;
                                break;
                            case 1:
                                GameText($"Pengin suddenly leapt forward, rolling on the ground as he landed.\n\nPengin: Whoa, that was close! What was that? It's fast!\n\nYou hear a breeze whoosh by as you both look around...\n\nPengin: {choice}! Watch out!\n\n", 60, false);
                                uinput = Fight(Player, Spidra);
                                if (uinput == "win")
                                {
                                    GameText($"Pengin: Wow... Impressive!\n\nWith Spidra defeated, {choice} and Pengin make it to the barracks. Pengin does what appears to be a secret handshake with the recruit.\n\nPengin: This is our top recruit right now, Strawbs.\n\nStrawbs: Hello! It's nice to meet you. :)\n\nPengin: Strawbs, this is {choice}. They're here to fight for the Resistance.\n\nStrawbs: Oh I see! Just where do you keep finding these new recruits? Hahaha. Well let's test your mettle shall we? I warn you, I won't\ngo easy on you just cause you're a fellow recruit!\n\nPengin: Hold on, Strawbs. We just got out of a Spidra attack. Give them some time to rest...\n\nPengin sounded sorrowful. Like he was in a distant land. He slowly walked over to some other recruits, looking over a map, planning their\nattack on Crow Castle. An ominous chill filled the room, Strawbs watching Pengin with a concerned look. Pengin abruptly trashed the map,\nkicked over the table and stormed out the room...\n\nStrawbs: Forgive him... His mother was... Killed by a gang of Spidra...\n\n", 60, false);
                                }
                                fightCount++;
                                roundTime = 480;
                                Player.maxhp = Player.maxhp + 10;
                                if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                {
                                    Console.WriteLine("\n(Press Enter to continue)\n");

                                    do
                                    {
                                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                        {
                                            break;
                                        }
                                    } while (fightTime);
                                }
                                fightTime = false;
                                break;
                            case 2:
                                GameText("Strawbs: I'm raring to go! You must be ready by now!\n\n", 60, false);
                                uinput = Fight(Player, Strawbs);
                                if (uinput == "win")
                                {
                                    GameText($"Pengin: I told you they were good.\n\nStrawbs: Yeah, no kidding! x_x\n\nPengin: {choice}'s our best hope now, but we'll still need back up. Do you think you can round up the troops when the time comes?\n\nStrawbs saluted.\n\nStrawbs: Of course, sir!\n\nPengin: Alright {choice}, let's get going! Crow Castle is just past Slippery Woods!\n\n", 60, false);
                                    fightCount++;
                                    roundTime = 660;
                                    Player.maxhp = Player.maxhp + 10;
                                    if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                    {
                                        Console.WriteLine("\n(Press Enter to continue)\n");

                                        do
                                        {
                                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                            {
                                                break;
                                            }
                                        } while (fightTime);
                                    }
                                }
                                fightTime = false;
                                break;
                            case 3:
                                GameText($"{choice} and Pengin start making their way through Slippery Woods.\n\nPengin: Be sure to watch your step, {choice}! Travellers say some of these branches on the ground trip you up on purpose!\n\n{choice} suddenly stepped on a branch that felt squishy. You almost slipped but kept your footing!\n\n", 60, false);
                                uinput = Fight(Player, Snek);
                                if (uinput == "win")
                                {
                                    GameText($"Night fall - {choice} and Pengin set up camp half way through Slippery Woods, dimly lit by a determined campfire.\n\nPengin: So... Why do you want the crown?\n\nPengin asked as he prodded a marshmallow with a stick.\n\nPengin: Hmm, I guess the reason doesn't matter. So long as we put a stop to Evil Crow.\n\nThe silence of the night is somewhat soothing against the crackling embers, broiling the tasty snacks.\nPengin blows on his marshmallow to cool it down.\n\nPengin: I noticed you live alone...\n\nYou eat your marshmallow. Pengin chuckled to himself.\n\nPengin: Must be nice... Me? I have a family... Back home...\n\nPengin sighed...\n\nPengin: They drive me so crazy sometimes. My son, Pengin Jr., he must be... yeah, 4 years old now... Wow... Time sure flies, doesn't it?\nI wonder... If he even remembers me...\n\nThe flames glisten in Pengin's glassy eyes, as he smiled, escaping to a better time.\n\nPengin: Anyway... We should get some sleep. We have a long day ahead of us!\n", 60, false);
                                    fightCount++;
                                    roundTime = 800;
                                    Player.maxhp = Player.maxhp + 10;
                                    if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                    {
                                        Console.WriteLine("\n(Press Enter to continue)\n");

                                        do
                                        {
                                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                            {
                                                break;
                                            }
                                        } while (fightTime);
                                    }
                                }
                                fightTime = false;
                                break;
                            case 4:
                                GameText("Pengin: We'll be at the castle soon. Once we're there, you'll have your work cut out for you. So...\n\n", 60, false);
                                GameText("Pengin unsheathes his sword...", 100);
                                GameText("\n\nPengin: I need to be sure you have what it takes!\n\n", 60, false);
                                Thread.Sleep(2000);
                                uinput = Fight(Player, Pengin);
                                if (uinput == "win")
                                {
                                    Thread.Sleep(2000);
                                    GameText("Pengin: Ack..! Well fought! You actually might have a chance of beating him... Here, take this.\n\n", 60, false);
                                    GameText($"{choice} got Pengin's Sword!\n\n", 100);
                                    GameText("Pengin: It's a powerful weapon crafted from crow feathers. I haven't been able to master it, but perhaps you can put it to good use. Come on, the castle's just up ahead!\n", 60, false);
                                    fightCount++;
                                    Player.attacks = new string[] { "Punch", "Kick", "Jump Kick", "Rest", "Sword" };
                                    Player.damage = new int[] { 2, 3, 5, 0, 10 };
                                    Player.costs = new int[] { 1, 2, 5, 0, 12 };
                                    Player.ftext = new string[] { "Player used Punch!", "Player used Kick!", "Player used Jump Kick", "Player took a quick rest...", "Player uses Crow power to launch an attack!" };
                                    roundTime = 950;
                                    Player.maxhp = Player.maxhp + 10;
                                    if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                    {
                                        Console.WriteLine("\n(Press Enter to continue)\n");

                                        do
                                        {
                                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                            {
                                                break;
                                            }
                                        } while (fightTime);
                                    }
                                }
                                fightTime = false;
                                break;
                            case 5:
                                GameText($"Pengin: Oh no! The castle is swarming with mind-controlled soldiers! Damn that Evil Crow! I'm too weak to go any further.\nStorm the castle, {choice}! And save us all! I'll be routing for you out here!\n", 60, false);
                                GameText("\n{choice} approaches the castle.\n\n", 100);
                                uinput = Fight(Player, Carl);
                                if (uinput == "win")
                                {
                                    GameText("Carl shook his head.\n\nCarl: Huh? What? How did I get here? Sorry, I must have zoned out. Let me get the door for you.\n\nCarl unlocks the castle door. You step inside and head for the throne room at the top of the castle.\n", 60, false);
                                    fightCount++;
                                    roundTime = 1100;
                                    Player.maxhp = Player.maxhp + 10;
                                    if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                    {
                                        Console.WriteLine("\n(Press Enter to continue)\n");

                                        do
                                        {
                                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                            {
                                                break;
                                            }
                                        } while (fightTime);
                                    }
                                }
                                fightTime = false;
                                break;
                            case 6:
                                GameText("You climb up the stairs and reach the second floor. It's a big, open floor, with no one around... It's strangely quiet...\nSuddenly you see a strange figure run across the room! They stop as you make eye contact!\n", 60, false);
                                uinput = Fight(Player, Banana);
                                if (uinput == "win")
                                {
                                    GameText($"Before finding the way to the top floor, {choice} decides to look around the several rooms for any loot. Unfortunately they were all empty aside from some corpses. Wonder what happened here?\n\n", 60, false);
                                    fightCount++;
                                    roundTime = 1250;
                                    Player.maxhp = Player.maxhp + 10;
                                    if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                    {
                                        Console.WriteLine("\n(Press Enter to continue)\n");

                                        do
                                        {
                                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                            {
                                                break;
                                            }
                                        } while (fightTime);
                                    }
                                }
                                fightTime = false;
                                break;
                            case 7:
                                GameText($"{choice} finally makes it to the throne room, but it's being guarded!\n\nOctosis: An intruder! Come on, brother, it's time to fight!\n\n" +
                                    "Octobro: B-b-but I don't want to fight! Fighting isn't nice... T-T\n\nOctosis: Are you serious? Get it together, brother!\n\n" +
                                    "Octobro started to cry.\n\nOctosis: Ugh, guess it's down to me!\n\n", 60, false);
                                uinput = Fight(Player, Octosis);
                                if (uinput == "win")
                                {
                                    GameText("Octobro: H-hey... Hey, sis?.. Wake up! Octosis!?... OKAY! ENOUGH IS ENOUGH!!\n\n", 60, false);
                                    uinput = Fight(Player, Octobro);
                                    if (uinput == "win")
                                    {
                                        GameText($"Octosis: Huh? What happened?\n\n{choice} explained they were under Evil Crow's spell.\n\nOctosis: Oh what!? No way, that damn crow! If I wasn't so worn out from our fight I'd go in there and kill him myself.\n\nOctosis picked up her unconscious brother and headed for the exit.\n\nOctosis: Give 'em hell! And hey... Hope we didn't cause you too much trouble.\n\n", 60, false);
                                        GameText($"{choice} stands at the door to the throne room...", 140);
                                        fightCount++;
                                        roundTime = 1500;
                                        Player.maxhp = Player.maxhp + 10;
                                        if ((GetAsyncKeyState(13) & 0x8000) == 0)
                                        {
                                            Console.WriteLine("\n(Press Enter to continue)\n");

                                            do
                                            {
                                                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                                {
                                                    break;
                                                }
                                            } while (fightTime);
                                        }
                                    }
                                }
                                fightTime = false;
                                break;
                            case 8:
                                GameText("Evil Crow: You think I don't hear you out there?\n\nEvil Crow opens the door and pulls you into the throne room!\n\n", 60, false);
                                uinput = Fight(Player, EvilCrow);
                                if (uinput == "win")
                                {
                                    win = true;
                                }
                                break;
                            default:
                                break;
                        }

                        continue;

                    }


                    GameText("What do you want to do?");

                    Player.PlayerStats();


                    //uinput = "";
                    //bool enter = Console.ReadKey(true).Key == ConsoleKey.Enter;

                    uinput = Console.ReadLine();
                    uinput = uinput.Replace(" ", "");


                    if (uinput == "t")
                    {
                        secs = Convert.ToInt32(sw.ElapsedMilliseconds / 1000);
                        Console.WriteLine(secs);
                    }

                    while (uinput == "train")
                    {
                        keepTraining = true;
                        trainRound = 0;
                        if (hiScore >= 60)
                        {
                            trainSpeed = 2000;
                        }

                        Console.WriteLine("- - - - - !Training! - - - - -\n\nGet your hands in position on the keyboard! (make sure Num Lock is ON!)\n\n\t  ^  \t\t  8  \n\t< v >\t\t4 5 6\n\nPress UP to start or DOWN to leave!\n");
                        if (hiScore > 0)
                        {
                            Console.WriteLine($"(High Score: {hiScore})\n");
                        }

                        if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
                        {

                            while (keepTraining)
                            {

                                trainRound++;
                                Random rand = new Random();
                                rng = rand.Next(0, 8);
                                keyCount = 0;


                                // Check how many keys are being pressed at once here

                                foreach (int k in trainingKeys)
                                {
                                    if ((GetAsyncKeyState(k) & 0x8000) > 0)
                                    {
                                        keyCount++;
                                    }
                                }


                                switch (trainRound)
                                {
                                    case 5:
                                        if (trainSpeed < 3000)
                                        {
                                            trainSpeed = 1600;
                                        }
                                        else
                                        {
                                            trainSpeed = 2000;
                                        }
                                        break;
                                    case 12:
                                        if (trainSpeed < 2000)
                                        {
                                            trainSpeed = 1400;
                                        }
                                        else
                                        {
                                            trainSpeed = 1700;
                                        }
                                        break;
                                    case 18:
                                        if (trainSpeed < 1700)
                                        {
                                            trainSpeed = 1200;
                                        }
                                        else
                                        {
                                            trainSpeed = 1500;
                                        }
                                        break;
                                    case 25:
                                        if (trainSpeed < 1500)
                                        {
                                            trainSpeed = 1100;
                                        }
                                        else
                                        {
                                            trainSpeed = 1250;
                                        }
                                        break;
                                    case 32:
                                        trainSpeed = 1000;
                                        break;
                                    case 40:
                                        trainSpeed = 900;
                                        break;
                                    case 50:
                                        trainSpeed = 800;
                                        break;
                                    case 65:
                                        trainSpeed = 700;
                                        break;
                                    case 80:
                                        trainSpeed = 600;
                                        break;
                                    case 100:
                                        trainSpeed = 500;
                                        break;
                                    default:
                                        break;
                                }


                                Console.WriteLine($"Hold {training[rng]}");
                                Thread.Sleep(trainSpeed);

                                // Check the correct key being pressed, but also how many keys are being pressed.
                                // This is to prevent the player from holding down all the keys at once, but allows a buffer in case the player slips keys on faster rounds.
                                if ((GetAsyncKeyState(trainingKeys[rng]) & 0x8000) > 0 && keyCount < 3)
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"Too Slow! You scored {trainRound}!\n");
                                    if (trainRound > hiScore)
                                    {
                                        GameText("A new high score!\n");
                                        hiScore = trainRound;
                                    }

                                    if (keyCount > 2)
                                    {
                                        GameText("Try to only hold one key at a time!\n");
                                    }

                                    if (trainRound >= 10)
                                    {
                                        GameText("Your stamina has increased!\n");
                                        Player.stamina = Player.stamina + (Convert.ToInt32(trainRound / 10) * 2);
                                        Player.maxstamina = Player.maxstamina + Convert.ToInt32(trainRound / 10);
                                        if (Player.stamina > Player.maxstamina)
                                        {
                                            Player.stamina = Player.maxstamina;
                                        }
                                    }

                                    Console.WriteLine("(Press Enter to continue)\n");


                                    // This is to prevent the next input from being filled with numbers
                                    do
                                    {
                                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                        {
                                            keepTraining = false;
                                            uinput = "";
                                        }
                                    } while (keepTraining);

                                }

                            }
                        }
                        else
                        {
                            uinput = "";
                        }

                    }

                    if (uinput == "f")
                    {
                        uinput = Fight(Player, Banana);
                    }


                    while (uinput == "heal")
                    {
                        //startRest = Convert.ToInt32(sw.ElapsedMilliseconds / 1000);
                        //healWatch.Reset();

                        if (Player.hp == Player.maxhp)
                        {
                            GameText("You're already in tip-top shape!\n");
                            uinput = "";
                            continue;
                        }

                        endRest = 0;
                        Console.WriteLine("Hold space to heal");
                        healWatch.Reset();
                        if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                        {
                            healWatch.Start();
                            GameText("Healing", 50);
                            while ((GetAsyncKeyState(32) & 0x8000) > 0 && !fightTime)
                            {
                                if (Convert.ToInt32(sw.ElapsedMilliseconds / 1000) >= roundTime)
                                {
                                    fightTime = true;
                                    sw.Stop();
                                }
                                GameText(".", 50, true, 1000);
                            }

                        }
                        else
                        {
                            GameText("That's not space...", 100);
                        }
                        healWatch.Stop();
                        endRest = Convert.ToInt32(healWatch.ElapsedMilliseconds / 1000) * 2;
                        endRest2 = Convert.ToInt32(healWatch.ElapsedMilliseconds / 1000) / 2;
                        if (endRest2 > 0)
                        {
                            GameText($"\nYou healed {endRest}HP and {endRest2}PP!\n", 50);
                        }
                        else
                        {
                            GameText($"\nYou healed {endRest}HP!\n", 50);
                        }

                        if (Player.hp < Player.maxhp)
                        {
                            Player.hp = Player.hp + endRest;
                            if (Player.hp > Player.maxhp)
                            {
                                Player.hp = Player.maxhp;
                            }
                        }

                        if (Player.stamina < Player.maxstamina)
                        {
                            Player.stamina = Player.stamina + endRest2;
                            if (Player.stamina > Player.maxstamina)
                            {
                                Player.stamina = Player.maxstamina;
                            }
                        }

                        Console.WriteLine("\n(Press Enter to continue)\n");


                        // This is to prevent the next input from being filled with numbers
                        do
                        {
                            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                            {
                                uinput = "";
                            }
                        } while (uinput == "heal");

                    }


                }

                if (win)
                {
                    GameText($"Evil Crow: What!? This is impossible! I'm the King! How can such a puny being defeat me in battle!?\n\n{choice} shrugs.\n\nEvil Crow: No! I can't accept this... I won't accept this!\n\n", 60);
                    Thread.Sleep(200);
                    GameText("{choice} shrugs.\n\n", 100);
                    Thread.Sleep(300);
                    GameText("Evil Crow: ...GRRRAAAAHHHHH!!\n\n", 100);
                    GameText($"Suddenly, Evil Crow pulls out a gun.\nDamn.\nOh my god-\nHe's got an actual gun, what the hell guys\nI mean\neveryone get down\nthis is crazy\n\nBut then... The throne room doors burst open.\n\nPengin, Strawbs, Octosis, Octobro, Carl... even Brock...\n\nEveryone rushes in to beat up the evil king until he died.\n\nAnd so... {choice} became Ruler of Nature Land\n\nPengin: Three cheers for {choice}! Our new Ruler!\n\n", 60);
                    GameText(textWrap($"Everyone cheered. {choice} had finally won. They now had the power to control everyone in the world. But they didn't. They ruled over Nature Land peacefully, and everyone lived happily ever after....."), 60);
                    GameText("\n\nWell except all that stuff with the Banana, I mean, what was that all about..?\n\n", 60);
                    GameText("  T H E\n   E N D\n\n", 300);

                }

                bool reset = true;

                GameText("\nThanks for playing!\n\n", 100);
                Console.WriteLine("\n(Press Enter to continue)\n");
                do
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        reset = false;
                    }
                } while (reset);

                Console.Clear();
            }
        }
    }
}
