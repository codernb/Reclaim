using Assets.Scripts.Models.Map;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class MenuController : MonoBehaviour
    {

        private static MenuController self;

        public CameraController cameraController;
        public BuildingMenuController buildingMenuController;
        public HumanMenuController humanMenuController;
        public ZombieMenuController zombieMenuController;

        void Start()
        {
            self = this;
        }

        public void enableCameraMovement(bool enable)
        {
            cameraController.movingEnabled = enable;
        }

        public void openBuildingMenu(Tile tile)
        {
            buildingMenuController.showBuilding(tile);
        }

        public void openHumansMenu(Tile tile)
        {
            humanMenuController.showHumans(tile);
        }

        public void openZombiesMenu(Tile tile)
        {
            zombieMenuController.showHumans(tile);
        }

        public static void enableCameraMovementS(bool enable)
        {
            self.enableCameraMovement(enable);
        }

        public static void openBuildingMenuS(Tile tile)
        {
            self.openBuildingMenu(tile);
        }

        public static void openHumansMenuS(Tile tile)
        {
            self.openHumansMenu(tile);
        }

        public static void openZombiesMenuS(Tile tile)
        {
            self.openZombiesMenu(tile);
        }

    }
}
