using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -5f;
    float xThrow, yThrow;


    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlRollFactor = -5f;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor; //We are adding a scale to the position thats clamped and then getting that value an using that for the rotation
        float pitchDueToControlThrow = yThrow * controlPitchFactor; //Since yThrow will be from -1 to 1 we want to add a pitch factor which over time will shoot back the ship to look straight ahead

        float pitch = pitchDueToPosition + pitchDueToControlThrow; //Note our yThrow goes to 0 so it will bounce back

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //-1 to 1
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffSet = xThrow * xSpeed * Time.deltaTime;
        float yOffSet = yThrow * xSpeed * Time.deltaTime;

        float rawXpos = transform.localPosition.x + xOffSet; //Grabbing our value and adding it to our local pos x
        float clampedXPos = Mathf.Clamp(rawXpos, -xRange, xRange);

        float rawYpos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYpos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); //Then we add our changed value to our ship
    }
}
