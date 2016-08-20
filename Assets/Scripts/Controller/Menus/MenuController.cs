using Assets.Scripts.Models.Map;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class MenuController : MonoBehaviour
    {

        private static MenuController self;

        public GameObject mainMenu;
        public CameraController cameraController;
        public BuildingMenuController buildingMenuController;
        public HumanMenuController humanMenuController;
        public ZombieMenuController zombieMenuController;

        private int counter;
        private bool editText;

        void Start()
        {
            self = this;
        }

        public static void enableCameraMovementS(bool enable)
        {
            if (enable)
                self.enableCameraMovement();
            else
                self.disableCameraMovement();
        }

        public void startEditText()
        {
            if (editText)
                return;
            editText = true;
            disableCameraMovement();
        }

        public static void startEditTextS()
        {
            self.startEditText();
        }

        public void endEditText()
        {
            editText = false;
            enableCameraMovement();
        }

        public static void endEditTextS()
        {
            self.endEditText();
        }

        public void openMainMenu()
        {
            disableCameraMovement();
            mainMenu.SetActive(true);
        }

        public void closeMainMenu()
        {
            enableCameraMovement();
            mainMenu.SetActive(false);
        }

        public void openBuildingMenu(Tile tile)
        {
            disableCameraMovement();
            buildingMenuController.showBuilding(tile);
        }

        public void closeBuildingMenu()
        {
            enableCameraMovement();
            buildingMenuController.close();
        }

        public void openHumansMenu(Tile tile)
        {
            disableCameraMovement();
            humanMenuController.showHumans(tile);
        }

        public void closeHumansMenu()
        {
            enableCameraMovement();
            humanMenuController.close();
        }

        public void openZombiesMenu(Tile tile)
        {
            disableCameraMovement();
            zombieMenuController.showZombies(tile);
        }

        public void closeZombiesMenu()
        {
            enableCameraMovement();
            zombieMenuController.close();
        }

        public static void openBuildingMenuS(Tile tile)
        {
            self.openBuildingMenu(tile);
        }

        public static void closeBuildingMenuS()
        {
            self.closeBuildingMenu();
        }

        public static void openHumansMenuS(Tile tile)
        {
            self.openHumansMenu(tile);
        }

        public static void closeHumansMenuS()
        {
            self.closeHumansMenu();
        }

        public static void openZombiesMenuS(Tile tile)
        {
            self.openZombiesMenu(tile);
        }

        public static void closeZombiesMenuS()
        {
            self.closeZombiesMenu();
        }

        public bool isMenuOpen()
        {
            return counter > 0;
        }

        public static bool isMenuOpenS()
        {
            return self.isMenuOpen();
        }

        private void enableCameraMovement()
        {
            if (--counter > 0 || editText)
                return;
            counter = 0;
            cameraController.movingBlocked = false;
        }

        private void disableCameraMovement()
        {
            counter++;
            cameraController.movingBlocked = true;
        }

    }
}
