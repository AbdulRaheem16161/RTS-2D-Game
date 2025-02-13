using UnityEngine;
using MoreMountains.TopDownEngine;
using System.Collections;

public class CharacterSpeedControl : CharacterAbility
{
    public SoundCreatorLayerChanger soundcreatorlayerchanger;  // Added missing semicolon

    [Header("Actual Speed")]
    [SerializeField] private float normalSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float SlowWalkSpeed;

    protected override void Initialization()
    {
        base.Initialization();
    }

    private void Update()
    {

    }

    protected override void HandleInput()
    {
        base.HandleInput();

        var characterMovement = _character.FindAbility<CharacterMovement>();

        if (characterMovement == null) return;

        characterMovement.MovementSpeed = normalSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterMovement.MovementSpeed = runSpeed;
            soundcreatorlayerchanger.ChangeToRunningLayer();   
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            characterMovement.MovementSpeed = SlowWalkSpeed;
            soundcreatorlayerchanger.RemoveLayer();
        }
        else
        {
            characterMovement.MovementSpeed = normalSpeed;
            soundcreatorlayerchanger.ChangeToWalkingLayer(); 
        }
    }
}
