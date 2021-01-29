
namespace BullsAndCowsGame
{
    public class RuleResponse
    {
        public string Info { get; private set; }

        public bool Cleared { get; set; } = false;

        public RuleResponse(string info)
        {
            Info = info;
        }
    }

}
