using Assets.Scripts.Models.Humans;

namespace Assets.Scripts.Utils
{
    class HumanStore
    {

        public static Human getDefault()
        {
            return new Common();
        }

    }
}
