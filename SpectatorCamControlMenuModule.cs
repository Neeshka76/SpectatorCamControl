using ThunderRoad;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SpectatorCamControl
{
    public class SpectatorCamControlMenuModule : MenuModule
    {
        public SpectatorCamControlController spectatorCamControlController;
        public SpectatorCamControlHook spectatorCamControlHook;
        private Text txtCameraControl;
        private Text txtCameraLogo;
        private Text txtCameraHelp;
        private Button btnRightArrowCameraControl;
        private Button btnLeftArrowCameraControl;
        private Button btnCameraScreenshot;
        private Button btnCameraLogo;
        private Button btnCameraHelp;
        public override void Init(MenuData menuData, Menu menu)
        {
            base.Init(menuData, menu);
            // Grab the value from Unity
            txtCameraControl = menu.GetCustomReference("txt_CameraControl").GetComponent<Text>();
            txtCameraLogo = menu.GetCustomReference("txt_CameraLogo").GetComponent<Text>();
            txtCameraHelp = menu.GetCustomReference("txt_CameraHelp").GetComponent<Text>();
            btnRightArrowCameraControl = menu.GetCustomReference("btn_RightArrowCameraControl").GetComponent<Button>();
            btnLeftArrowCameraControl = menu.GetCustomReference("btn_LeftArrowCameraControl").GetComponent<Button>();
            btnCameraScreenshot = menu.GetCustomReference("btn_CameraScreenshot").GetComponent<Button>();
            btnCameraLogo = menu.GetCustomReference("btn_CameraLogo").GetComponent<Button>();
            btnCameraHelp = menu.GetCustomReference("btn_CameraHelp").GetComponent<Button>();

            // Add an event listener for buttons
            btnRightArrowCameraControl.onClick.AddListener(ClickIncreaseCameraControl);
            btnLeftArrowCameraControl.onClick.AddListener(ClickDecreaseCameraControl);
            btnCameraScreenshot.onClick.AddListener(ClickCameraScreenshot);
            btnCameraLogo.onClick.AddListener(ClickCameraLogo);
            btnCameraHelp.onClick.AddListener(ClickCameraHelp);

            // Initialization of datas
            spectatorCamControlController = GameManager.local.gameObject.AddComponent<SpectatorCamControlController>();
            spectatorCamControlController.data.indexSpectatorCamGetSet = 0;
            spectatorCamControlController.data.nbMaxSpectatorCamGetSet = 2;
            spectatorCamControlController.data.spectatorCamNameGetSet = "HMD";
            spectatorCamControlController.data.cameraLogoOnGetSet = true;
            spectatorCamControlController.data.cameraHelpOnGetSet = true;

            spectatorCamControlHook = menu.gameObject.AddComponent<SpectatorCamControlHook>();
            spectatorCamControlHook.menu = this;
            // Update all the Data for left page (text, visibility of buttons etc...)
            UpdateDataPageLeft1();
            // Update all the Data for right page (text, visibility of buttons etc...)
            //UpdateDataPageRight1();
        }

        // When selector is click change display to Error or Clean if no bodies

        public void ClickIncreaseCameraControl()
        {
            if (spectatorCamControlController.data.indexSpectatorCamGetSet <= 1)
            {
                spectatorCamControlController.data.indexSpectatorCamGetSet++;
                UpdateDataPageLeft1();
            }
        }
        public void ClickDecreaseCameraControl()
        {
            if (spectatorCamControlController.data.indexSpectatorCamGetSet >= 1)
            {
                spectatorCamControlController.data.indexSpectatorCamGetSet--;
                UpdateDataPageLeft1();
            }
        }
        public void ClickCameraScreenshot()
        {
            GameManager.Screenshot(Spectator.local.cam);
            UpdateDataPageLeft1();
        }

        public void ClickCameraLogo()
        {
            spectatorCamControlController.data.cameraLogoOnGetSet ^= true;
            Spectator.local.toggleShowLogo.SetIsOnWithoutNotify(true);
            Spectator.local.ShowLogo(spectatorCamControlController.data.cameraLogoOnGetSet);
            UpdateDataPageLeft1();
        }

        public void ClickCameraHelp()
        {
            spectatorCamControlController.data.cameraHelpOnGetSet ^= true;
            Spectator.local.toggleShowHelp.SetIsOnWithoutNotify(true);
            Spectator.local.ShowHelp(spectatorCamControlController.data.cameraHelpOnGetSet);
            UpdateDataPageLeft1();
        }

        public void UpdateDataPageLeft1()
        {
            if (spectatorCamControlController.data.indexSpectatorCamGetSet == 0)
            {
                if (btnLeftArrowCameraControl.IsActive())
                    btnLeftArrowCameraControl.enabled = false;
            }
            else
            {
                btnLeftArrowCameraControl.enabled = true;
            }
            if (spectatorCamControlController.data.indexSpectatorCamGetSet == spectatorCamControlController.data.nbMaxSpectatorCamGetSet)
            {
                if (btnRightArrowCameraControl.IsActive())
                    btnRightArrowCameraControl.enabled = false;
            }
            else
            {
                btnRightArrowCameraControl.enabled = true;
            }
            txtCameraHelp.text = spectatorCamControlController.data.cameraHelpOnGetSet ? "Enabled" : "Disabled";
            txtCameraLogo.text = spectatorCamControlController.data.cameraLogoOnGetSet ? "Enabled" : "Disabled";
            txtCameraControl.text = spectatorCamControlController.data.spectatorCamNameGetSet.ToString();
        }

        public void UpdateDataPageRight1()
        {
            
        }

        // Refresh the menu each frame (need optimization)
        public class SpectatorCamControlHook : MonoBehaviour
        {
            public SpectatorCamControlMenuModule menu;
            void Update()
            {
                menu.UpdateDataPageLeft1();
                //menu.UpdateDataPageRight1();
            }
        }

    }
}
