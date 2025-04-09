Console.CursorVisible = false;

Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Point startingPosition =  new Point(119, 3);
Player hero = new Player("Snake", "@", startingPosition);
List<Player> clones = new List<Player>();
clones.Add(hero);

while (true)
{
    foreach (Player element in clones)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"({element.position.x}, {element.position.y})     ");

        Console.SetCursorPosition(element.position.x, element.position.y);
        Console.Write(element.avatar);
    }
    
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        Console.Write(" "); 
    }

    if (directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        Point direction = directionsMap[pressedKeyInfo.Key];

        foreach (Player element in clones)
        {
            element.position.x += direction.x * element.speed;
            element.position.y += direction.y * element.speed;

            element.position.x = Math.Clamp(element.position.x, 0, Console.BufferWidth - 1);
            element.position.y = Math.Clamp(element.position.y, 0, Console.BufferHeight - 1);

            element.speed += 1;
        }
    }
    else
    {
        switch (pressedKeyInfo.Key)
        {
            case ConsoleKey.C:
                Player clone = new Player(hero.name,  "C", startingPosition);
                clones.Add(clone);
                break;
        }
    }
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo consoleKeyInfo;

do
{
    consoleKeyInfo = Console.ReadKey(true);
} while (consoleKeyInfo.Key != ConsoleKey.Spacebar);


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