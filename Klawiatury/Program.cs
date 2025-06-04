Console.CursorVisible = false;

Dictionary<ConsoleKey, string> keyActionMap = new Dictionary<ConsoleKey, string>();
keyActionMap.Add(ConsoleKey.A, "moveLeft");
keyActionMap.Add(ConsoleKey.D, "moveRight");
keyActionMap.Add(ConsoleKey.W, "moveUp");
keyActionMap.Add(ConsoleKey.S, "moveDown");
keyActionMap.Add(ConsoleKey.C, "clone");
keyActionMap.Add(ConsoleKey.Escape, "quitGame");
keyActionMap.Add(ConsoleKey.Q, "attack");

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

List<Character> characters = new List<Character>();

Point startingPosition = new Point(1, 0);
Player hero = new Player("Snake", "@", startingPosition, keyActionMap);
characters.Add(hero);

for (int i = 0; i < 10; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L", new Point(20 - i, 8));
    characters.Add(npc);
}

Level firstLevel = new Level();
firstLevel.Display();

foreach (Character element in characters)
{
    element.Display();
}
bool isPlaying = true;

while (isPlaying)
{
    // We're saving last characters count before the loop
    // so that the new clone will not perform it's action
    // untill next turn.
    // FIXME: If we add removing clones (or if any character
    // would be removed), it would crash.
    int charactersCount = characters.Count;
    for (int i = 0; i < charactersCount; i++)
    {
        Character element = characters[i];
        if (!element.isAlive)
        {
            firstLevel.RedrawCell(element.position);
            continue;
        }

        string chosenAction = element.ChooseAction();

        if (directionsMap.ContainsKey(chosenAction))
        {
            Point direction = directionsMap[chosenAction];
            element.Move(direction, firstLevel);

            firstLevel.RedrawCell(element.previousPosition);
            element.Display();
        }
        else
        {
            switch (chosenAction)
            {
                case "clone":
                    PlayerClone clone = new PlayerClone(hero.name, "C", startingPosition, keyActionMap, hero);
                    characters.Add(clone);
                    firstLevel.OccupyCell(clone.position, clone);
                    clone.cell = firstLevel.GetCell(clone.position);
                    clone.Display();
                    break;
                case "quitGame":
                    isPlaying = false;
                    break;
                case "attack":
                    // TODO: Experiment with delayed attacks with turn counter

                    // Choosing attack target:
                    // 1. Scan surroundings to get all occupied cells
                    //  a. left/right/top/bottom
                    //  b. a + diagonals
                    // 2. Let character choose target
                    // 3. Attack chosen target 

                    List<Point> attackDirections = new List<Point>
                    {
                        new Point(-1, 0),
                        new Point(1, 0),
                        new Point(0, -1),
                        new Point(0, 1),
                    };

                    foreach (Point direction in attackDirections)
                    {
                        Point coordinatesToCheck = new Point(element.position.x + direction.x, element.position.y + direction.y);
                        try
                        {
                            Cell cellToCheck = firstLevel.GetCell(coordinatesToCheck);
                            if (cellToCheck.IsOccupied())
                            {
                                Character occupant = cellToCheck.GetOccupant();
                                occupant.Kill();
                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.SetCursorPosition(0, firstLevel.GetHeight());
                            Console.WriteLine($"{ex.ParamName} has incorrect value: {ex.ActualValue}");
                        }
                    }

                    break;
            }
        }
    }
}

Console.SetCursorPosition(0, firstLevel.GetHeight());
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