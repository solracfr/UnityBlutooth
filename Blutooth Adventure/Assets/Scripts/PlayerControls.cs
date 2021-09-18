using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;

    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 2f;
    [SerializeField] float positionPitchFactor = -20f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = -20f; // not used
    [SerializeField] float controlYawFactor = 20f; // how much character "turns" as you push the control stick
    [SerializeField] float positionRollFactor = -20f;
    [SerializeField] float controlRollFactor = -10f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() 
    {
        movement.Enable();
    }

    void OnDisable() 
    {
        movement.Disable();   
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

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

    private void ProcessTranslation()
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
}
