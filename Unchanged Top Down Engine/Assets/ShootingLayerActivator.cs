using MoreMountains.Tools;
using System.Collections;
using UnityEngine;

namespace CustomNamespace
{
    public class ShootingLayerActivator : AIAction
    {
        public SoundCreatorLayerChanger soundcreatorlayerchanger;

        // Override the required PerformAction() method
        public override void PerformAction()
        {
            if (soundcreatorlayerchanger != null)
            {
                soundcreatorlayerchanger.ChangeToShootingLayer();
            }
        }

        public override void OnExitState()
        {
            soundcreatorlayerchanger.RemoveLayer();
        }

    }
}
