using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{
/// ********IF YOU CAN'T SEE THE DOCUMENTATION WHEN YOU HOVER OVER METHODS OR SHIT LIKE THAT IT'S LIKELY BECAUSE YOU HAVEN'T SELECTED THE PROJECT WITH THE .SLN FILE ******\\\\\
    [Header("General Setup Settings")]
    [Tooltip("Moves character in 2d space based on player input")][SerializeField] InputAction movement;
    [Tooltip("Activate and deactivate lasers based on player input")][SerializeField] InputAction fire;
    [Tooltip("Array for lasers; one on each hand")][SerializeField] GameObject[] lasers;

    [Tooltip("How fast the player moves")][SerializeField] float controlSpeed = 10f;
    [Tooltip("Available amt of moveable horizontal distance")][SerializeField] float xRange = 5f;
    [Tooltip("Available amt of moveable vertical distance")][SerializeField] float yRange = 2f;
    [Tooltip("Degree of character tilt on x-axis due to position")][SerializeField] float positionPitchFactor = -20f;
    [Tooltip("Degree of character tilt on x-axis due to stick tilt")][SerializeField] float controlPitchFactor = -10f;
    [Tooltip("Degree of character tilt on y-axis due to position")][SerializeField] float positionYawFactor = -20f; // not used
    [Tooltip("Degree of character tilt on y-axis due to stick tilt")][SerializeField] float controlYawFactor = 20f; // how much character "turns" as you push the control stick
    [Tooltip("Degree of character tilt on z-axis due to position")][SerializeField] float positionRollFactor = -20f;
    [Tooltip("Degree of character tilt on z-axis due to stick tilt")][SerializeField] float controlRollFactor = -10f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() 
    {
        movement.Enable();
        fire.Enable();
    }

    void OnDisable() 
    {
        movement.Disable(); 
        fire.Disable();  
    }


    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToControlThrow; // position will not affect how much character "turns"

        float roll = 0f; // not needed for this game
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        float isFiring = fire.ReadValue<float>();

        if (isFiring > 0.5) //if the player pulls down the trigger enough.
            SetLasersActive(true);
        else 
            SetLasersActive(false);
    }

    void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
           var emissionModule = laser.GetComponent<ParticleSystem>().emission; // my first use of var!!! use when you're not sure what type you're working with.
           emissionModule.enabled = isActive;
        }
    }

}
