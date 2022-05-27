using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderRoad;
using UnityEngine;

namespace SpectatorCamControl
{
    public class SpectatorCamControlLevelModule : LevelModule
    {
        private SpectatorCamControlController spectatorCamControlController;
        private int valueCamControl = 0;
        // When a level is loaded
        public override IEnumerator OnLoadCoroutine()
        {
            spectatorCamControlController = GameManager.local.gameObject.GetComponent<SpectatorCamControlController>();
            return base.OnLoadCoroutine();
        }

        // Update the location of the player
        public override void Update()
        {
            if (spectatorCamControlController == null)
            {
                spectatorCamControlController = GameManager.local.gameObject.GetComponent<SpectatorCamControlController>();
                return;
            }
            else
            {
                if (valueCamControl != spectatorCamControlController.data.indexSpectatorCamGetSet)
                {
                    switch (spectatorCamControlController.data.indexSpectatorCamGetSet)
                    {
                        // HMD
                        case 0:
                            valueCamControl = 0;
                            Spectator.local.toggleViewHMD.SetIsOnWithoutNotify(true);
                            Spectator.local.SetViewHmd();
                            spectatorCamControlController.data.spectatorCamNameGetSet = "HMD";
                            break;
                        // Player
                        case 1:
                            valueCamControl = 1;
                            Spectator.local.toggleViewFpv.SetIsOnWithoutNotify(true);
                            Spectator.local.SetViewFPV();
                            spectatorCamControlController.data.spectatorCamNameGetSet = "Player";
                            break;
                        // Free
                        case 2:
                            valueCamControl = 2;
                            Spectator.local.toggleViewFree.SetIsOnWithoutNotify(true);
                            Spectator.local.SetViewFree();
                            spectatorCamControlController.data.spectatorCamNameGetSet = "Free";
                            break;
                        // Auto
                        /*case 3:
                            valueCamControl = 3;
                            Spectator.local.toggleViewAuto.SetIsOnWithoutNotify(true);
                            Spectator.local.SetViewAuto();
                            spectatorCamControlController.data.spectatorCamNameGetSet = "Auto";
                            break;*/
                        default:
                            valueCamControl = 0;
                            Spectator.local.toggleViewHMD.SetIsOnWithoutNotify(true);
                            Spectator.local.SetViewHmd();
                            spectatorCamControlController.data.spectatorCamNameGetSet = "HMD";
                            break;
                    }
                }
            }
        }
    }
}
