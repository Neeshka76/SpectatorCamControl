using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderRoad;
using UnityEngine;

namespace SpectatorCamControl
{
    public class SpectatorCamControlData
    {
        public int indexSpectatorCamGetSet { get; set; }

        public int nbMaxSpectatorCamGetSet { get; set; }

        public string spectatorCamNameGetSet { get; set; }

        public bool cameraLogoOnGetSet { get; set; }
        public bool cameraHelpOnGetSet { get; set; }

    }

    public class SpectatorCamControlController : MonoBehaviour
    {
        public SpectatorCamControlData data = new SpectatorCamControlData();
    }
}
