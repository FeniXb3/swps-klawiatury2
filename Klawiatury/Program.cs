Console.CursorVisible = false;

Dictionary<ConsoleKey, string> keyActionMap = new Dictionary<ConsoleKey, string>();
keyActionMap.Add(ConsoleKey.A, "moveLeft");
keyActionMap.Add(ConsoleKey.D, "moveRight");
keyActionMap.Add(ConsoleKey.W, "moveUp");
keyActionMap.Add(ConsoleKey.S, "moveDown");
keyActionMap.Add(ConsoleKey.C, "clone");
keyActionMap.Add(ConsoleKey.Escape, "quitGame");

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

List<Character> characters = new List<Character>();

Point startingPosition = new Point(4, 0);
Player hero = new Player("Snake", "@", startingPosition, keyActionMap);
List<Player> clones = new List<Player>();
clones.Add(hero);
characters.Add(hero);

List<NonPlayerCharacter> npcs = new List<NonPlayerCharacter>();

for (int i = 0; i < 10; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L", new Point(20-i, 8));
    npcs.Add(npc);
    characters.Add(npc);
}

string[] level =
[
    "####.###################################",
    "#......................................#",
    "#...#.............................######",
    "#...............#...................#",
    "#.................................###",
    "#.................................#",
    "#...#.............................#",
    "#.................................#",
    "#.................................#",
    "#.................................#",
    "#.................................#",
    "###################################",
];

foreach (string row in level)
{
    Console.WriteLine(row);
}

bool isPlaying = true;

while (isPlaying)
{
    foreach (Character element in characters)
    {
        element.Display();
    }

    // string chosenAction = hero.ChooseAction();

    // foreach (Player element in clones)
    // {
    //     RedrawCell(element.position);
    // }

    // if (directionsMap.ContainsKey(chosenAction))
    // {
    //     Point direction = directionsMap[chosenAction];

    //     foreach (Player element in clones)
    //     {
    //         element.Move(direction, level);
    //     }
    // }
    // else
    // {
    //     switch (chosenAction)
    //     {
    //         case "clone":
    //             Player clone = new Player(hero.name, "C", startingPosition, keyActionMap);
    //             clones.Add(clone);
    //             characters.Add(clone);
    //             break;
    //         case "quitGame":
    //             isPlaying = false;
    //             break;
    //     }
    // }
    
    foreach(Character element in characters)
    {
        string chosenAction = element.ChooseAction();
        RedrawCell(element.position);
        Point direction = directionsMap[chosenAction];
        element.Move(direction, level);
    }
}

Console.SetCursorPosition(0, level.Length);
Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo consoleKeyInfo;

do
{
    consoleKeyInfo = Console.ReadKey(true);
} while (consoleKeyInfo.Key != ConsoleKey.Spacebar);

void RedrawCell(Point position)
{
    Console.SetCursorPosition(position.x, position.y);
    string row = level[position.y];
    char cellData = row[position.x];
    Console.Write(cellData);
}

/*
Player - klasa
 - hp - liczba
 - maxhp (domyslnie 100)
 - stamina
 - maxstamina
 - name - tekst
 - speed


Konrad - obiket typu gracz
 - hp - 100
 - maxhp - 100
 - stamina - 20
 -max stamina - 20
 - name - Konrad

 
Gremlin - obiket typu gracz
 - hp - 20
 - maxhp - 50
 - stamina - 120
 -max stamina - 120
 - name - Gremlin
*/