using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSceneManager : MonoBehaviour
{

    public CircleQTE circleQTE;
    public int circlesRequired = 3;

    // Start is called before the first frame update
    void Start()
    {
        
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


    void createCircleQTE(){

    }
}
