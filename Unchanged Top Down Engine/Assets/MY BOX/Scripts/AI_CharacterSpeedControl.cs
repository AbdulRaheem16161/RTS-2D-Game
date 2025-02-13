using UnityEngine;
using MoreMountains.TopDownEngine;
using System.Collections;

public class AI_CharacterSpeedControl : CharacterAbility
{
    public SoundCreatorLayerChanger soundcreatorlayerchanger;

    [Header("Actual Speed")]
    [SerializeField] private float normalSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float SlowWalkSpeed;

    [SerializeField] private float maxseconds;
    [SerializeField] private float minseconds;

    private float timePassed;  // For tracking time elapsed for random interval selection
    private float currentInterval;  // The current interval of speed change (in seconds)

    [Header("Current State")]
    public string currentState;  // Display current state (Run, Walk, Slow Walk) in the Inspector

    protected override void Initialization()
    {
        base.Initialization();
        SetRandomInterval();  // Set the initial interval time randomly
    }

    private void Update()
    {
        timePassed += Time.deltaTime;  // Update time passed each frame

        // If the interval time has passed, change the speed randomly
        if (timePassed >= currentInterval)
        {
            timePassed = 0f;
            SetRandomInterval();
            RandomizeSpeed();
        }
    }

    protected override void HandleInput()
    {
        base.HandleInput();

        var characterMovement = _character.FindAbility<CharacterMovement>();

        if (characterMovement == null) return;

        characterMovement.MovementSpeed = normalSpeed;
    }

    // Method to set the random interval time for the speed change
    private void SetRandomInterval()
    {
        currentInterval = Random.Range(minseconds, maxseconds);
    }

    // Method to randomize the character's movement speed
    private void RandomizeSpeed()
    {
        var characterMovement = _character.FindAbility<CharacterMovement>();

        if (characterMovement == null) return;

        int randomChoice = Random.Range(0, 3);  // Random number between 0 and 2

        switch (randomChoice)
        {
            case 0:
                Run(characterMovement);
                break;
            case 1:
                Walk(characterMovement);
                break;
            case 2:
                SlowWalk(characterMovement);
                break;
        }
    }

    // Set the speed to running
    public void Run(CharacterMovement characterMovement)
    {
        characterMovement.MovementSpeed = runSpeed;
        soundcreatorlayerchanger.ChangeToRunningLayer();
        currentState = "Running";  // Update the current state to "Running"
    }

    // Set the speed to slow walking
    public void SlowWalk(CharacterMovement characterMovement)
    {
        characterMovement.MovementSpeed = SlowWalkSpeed;
        soundcreatorlayerchanger.RemoveLayer();
        currentState = "Slow Walking";  // Update the current state to "Slow Walking"
    }

    // Set the speed to walking
    public void Walk(CharacterMovement characterMovement)
    {
        characterMovement.MovementSpeed = normalSpeed;
        soundcreatorlayerchanger.ChangeToWalkingLayer();
        currentState = "Walking";  // Update the current state to "Walking"
    }
}
