
namespace Console_Dice_Game
{
    class DiceParser
    {
        public static List<Dice> Parse(string[] args)
        {
            if (args.Length < 3)
                throw new ArgumentException("You must provide at least three dice. Example: 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");

            var diceList = new List<Dice>();

            foreach (var arg in args)
            {
                try
                {
                    var faces = arg.Split(',').Select(int.Parse).ToArray();
                    if (faces.Length != 6)
                        throw new ArgumentException("Each die must have exactly 6 faces. Example: 2,2,4,4,9,9");
                    diceList.Add(new Dice(faces));
                }
                catch
                {
                    throw new ArgumentException("Invalid dice configuration. Please provide 6 comma-separated integers for each dice.");
                }
            }

            return diceList;
        }
    }
}
