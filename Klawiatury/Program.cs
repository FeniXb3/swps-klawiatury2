﻿Console.CursorVisible = false;

Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Point startingPosition =  new Point(4, 0);
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

while (true)
{
    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        Console.Write(element.avatar);
    }
    
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        string row = level[element.position.y];
        char cellData = row[element.position.x];
        Console.Write(cellData); 
    }

    if (directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        Point direction = directionsMap[pressedKeyInfo.Key];

        foreach (Player element in clones)
        {
            // 1. Załóżmy, że docelowa pozycja początkowo to moja aktualna pozycja
            // 2. Róbmy krok po kroku w wybranym kierunku
            // 3. Przy każdym kroku sprawdźmy czy nie próbujemy wejść w ścianę
            // 4a. Jeśli tak (planujemy wejść w ścianę), to przerwij
            // 4b. Jeśli nie, to zaktualizuj docelową pozycję

            int targetX = element.position.x;
            int targetY = element.position.y;

            int signY = Math.Sign(direction.y);
            int signX = Math.Sign(direction.x);

            for (int i = 1; i <= Math.Abs(direction.y * element.speed); i++)
            {
                int coordinateToTest = element.position.y + i * signY;
                if (coordinateToTest >= level.Length || coordinateToTest < 0 || level[coordinateToTest][targetX] == '#')
                {
                    break;
                }
                else
                {
                    targetY = coordinateToTest; 
                }
            }
            
            for (int i = 1; i <= Math.Abs(direction.x * element.speed); i++)
            {
                int coordinateToTest = element.position.x + i * signX;
                if (coordinateToTest >= level[targetY].Length || coordinateToTest < 0 || level[targetY][coordinateToTest] == '#')
                {
                    break;
                }
                else
                {
                    targetX = coordinateToTest;
                }
            }


            element.position.x = targetX;
            element.position.y = targetY;

            // HACK: First line limits y, second line limits x
            // because x useses y
            element.position.y = Math.Clamp(element.position.y, 0, level.Length - 1);
            element.position.x = Math.Clamp(element.position.x, 0, level[element.position.y].Length - 1);

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