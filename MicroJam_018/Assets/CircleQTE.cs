using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleQTE : MonoBehaviour
{
    public float shrinkSpeed = 0.1f; // Speed at which the image shrinks
    public float minScale = 0.1f; // Minimum scale for all axes

    private RectTransform largeCircle;
    private bool isShrinking = true;

    // Start is called before the first frame update
    void Start()
    {
        Transform largeCircleTransform = transform.Find("LargeCircle");

        if (largeCircleTransform == null)
        {
            Debug.LogError("LargeCircle object not found!");
            return;
        }

        largeCircle = largeCircleTransform.GetComponent<RectTransform>();

        // If the large circle is missing, throw error
        if (largeCircle == null)
        {
            Debug.LogError("RectTransform component not found on LargeCircle object!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Stop Shrinking
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShrinking = false;
            float localScale = largeCircle.localScale;

            //If the scale is between 0.65 and 0.5, the circle is perfect.
            
        }

        // If it's shrinking, shrink the scale by using the shrink speed
        if (isShrinking && largeCircle != null)
        {
            Vector3 newScale = largeCircle.localScale - Vector3.one * shrinkSpeed * Time.deltaTime;

            // Prevents shrinking past minimum scale
            newScale.x = Mathf.Max(newScale.x, minScale);
            newScale.y = Mathf.Max(newScale.y, minScale);
            newScale.z = Mathf.Max(newScale.z, minScale);

            largeCircle.localScale = newScale;
        }

        // Example: Get and print the scale of the large circle
        Debug.Log("Scale of LargeCircle: " + largeCircle.localScale);
    }
}