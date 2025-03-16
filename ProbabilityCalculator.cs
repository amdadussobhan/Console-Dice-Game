
namespace Console_Dice_Game
{
    public class ProbabilityCalculator
    {
        public static double CalculateProbability(Dice dice1, Dice dice2)
        {
            int wins = dice1.Faces.SelectMany(face1 => dice2.Faces, (face1, face2) => new { face1, face2 })
                                  .Count(pair => pair.face1 > pair.face2);

            int total = dice1.Faces.Length * dice2.Faces.Length;

            return (double)wins / total;
        }
    }
}
