namespace DevShirme.Utils
{
    public class Enums
    {
        public enum DestroyType
        {
            DestroyNewObj,
            DestroyOldObj
        }
        public enum ManagerType: int
        {
            DataManager = 0,
            PoolManager = 1,
            GameManager = 2,
            UIManager = 3
        }
        public enum GameItemType: int
        {
            Collectable = 0,
            Obstacle = 1
        }
        public enum ObstacleType: int
        {
            Axe = 0,
            Fan = 1,
            Gate = 2,
            Count = 3
        }
        public enum Cameras : int
        {
            Follow = 0,
            Success = 1
        }
    }
}
