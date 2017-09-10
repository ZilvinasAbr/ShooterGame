namespace Shooter.Classes
{
    public sealed class Map
    {
        private static volatile Map instance;
        private static object syncRoot = new object();

        private Map() { }

        public static Map Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Map();
                    }
                }

                return instance;
            }
        }
    }
}
