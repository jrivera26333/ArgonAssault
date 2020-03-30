using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }

    private void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffSet = xThrow * xSpeed * Time.deltaTime;
        float yOffSet = yThrow * xSpeed * Time.deltaTime;

        float rawXpos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXpos, -xRange, xRange);

        float rawYpos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYpos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
