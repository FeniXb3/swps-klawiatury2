
class PlayerClone : Player
{
    Player prototype;

    public PlayerClone(string name, string avatar) : base(name, avatar)
    {
    }

    public PlayerClone(string name, string avatar, Point position, Dictionary<ConsoleKey, string> keyActionMap, Player prototype) : base(name, avatar, position, keyActionMap)
    {
        this.prototype = prototype;
    }

    public override string ChooseAction()
    {
        return prototype.chosenAction;
    }
}
