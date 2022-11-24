namespace DevShirme.Utils
{
    public class Enums
    {
        public enum DestroyType
        {
            DestroyNewObj,
            DestroyOldObj
        }
        public enum MovementType
        {
            Transform,
            Rigidbody,
        }
        public enum TriggerBehavior : int
        {
            OnTriggerEnter = 1,
            OnTriggerExit = 2,
            Both = 3
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
            Door = 1,
            Fan = 2,
            Count = 3
        }
    }
}
