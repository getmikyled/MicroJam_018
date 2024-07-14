using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSceneManager : MonoBehaviour
{

    public CircleQTE circleQTE;
    public int circlesRequired = 3;
    private int circlesDone = 0;
    private bool QTEactive = false;
    private int totalPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Set timer for QTE
        StartCoroutine(CreateQTE(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Circle
            circleQTE.createQTE();
        }
    }


    private IEnumerator CreateQTE(float delay)
    {
        //Wait for the specified delay
        yield return new WaitForSeconds(delay);

        circleQTE.createQTE();
    }

    public void QTEDone(int points){
        circlesDone+= 1;
        //If the circles done is less than required than create the next one
        if(circlesDone < circlesRequired){
            StartCoroutine(CreateQTE(1.0f));
        }else{
            //Take to Victory
            print("VICTORY!");
        }
    }
}
