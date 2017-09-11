namespace Shooter.Classes
{
    public sealed class Map
    {
        private static volatile Map _instance;
        private static readonly object SyncRoot = new object();

        private Map() { }

        public static Map Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new Map();
                    }
                }

                return _instance;
            }
        }
    }
}
