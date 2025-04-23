Console.CursorVisible = false;

Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Point startingPosition = new Point(4, 0);
Player hero = new Player("Snake", "@", startingPosition);
List<Player> clones = new List<Player>();
clones.Add(hero);

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
    foreach (Player element in clones)
    {
        element.Display();
    }

    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    foreach (Player element in clones)
    {
        RedrawCell(element.position);
    }

    if (directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        Point direction = directionsMap[pressedKeyInfo.Key];

        foreach (Player element in clones)
        {
            element.Move(direction, level);
            element.speed += 1;
        }
    }
    else
    {
        switch (pressedKeyInfo.Key)
        {
            case ConsoleKey.C:
                Player clone = new Player(hero.name, "C", startingPosition);
                clones.Add(clone);
                break;
            case ConsoleKey.Escape:
                isPlaying = false;
                break;
        }
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