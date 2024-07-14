using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleQTE : MonoBehaviour
{
    public float shrinkSpeed = 0.4f; // Speed at which the image shrinks
    public float minScale = 0.1f; // Minimum scale for all axes

    private RectTransform largeCircle;
    private Image victoryCircle;
    private Image failureCircle;
    private bool isShrinking = false;

    //The Manager
    public CircleSceneManager circleManager;

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

        //Get the victory and failure circles
        victoryCircle = transform.Find("VictoryCircle").GetComponent<Image>();
        failureCircle = transform.Find("FailureCircle").GetComponent<Image>();

        if(victoryCircle == null || failureCircle == null){
            Debug.LogError("Could not find the circles!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Stop Shrinking
        if (isShrinking && Input.GetKeyDown(KeyCode.Space))
        {
            isShrinking = false;
            float localScale = largeCircle.localScale.x;

            //If the scale is between 0.65 and 0.5, the circle is perfect.
            if(localScale <= 0.655 && localScale >= 0.495){
                print("PERFECT!");
                victoryCircle.enabled = true;
                failureCircle.enabled = false;
            }else{
                print("FAILED");
                victoryCircle.enabled = false;
                failureCircle.enabled = true;
            }
            print(localScale);
            
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
        //Debug.Log("Scale of LargeCircle: " + largeCircle.localScale);
    }


    public void createQTE(){

        //Reset the victory/failure
        victoryCircle.enabled = false;
        failureCircle.enabled = false;

        print("Created!");
        //Reset the scaling
        //Pick random number for scaling and speed
        float newScale = Random.Range(1.0f, 1.6f); 
        largeCircle.localScale = new Vector3(newScale, newScale, newScale);


        //Make speed random
        float newSpeed = Random.Range(0.45f, 0.65f); 
        shrinkSpeed = newSpeed;
        isShrinking = true;


    }
}
