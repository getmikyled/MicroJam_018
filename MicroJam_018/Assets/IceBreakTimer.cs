using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreakTimer : MonoBehaviour
{

    //Get Iceberg Object
    public IceBerg iceberg;

    //Get the menu object
    [SerializeField] private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        //Approve Object Exists
        if (iceberg == null){
             Debug.LogError("Iceberg not found");
        }

        //Start Timer (5 seconds)
        StartCoroutine(RunFunctionAfterDelay(3.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator RunFunctionAfterDelay(float delay)
    {
        //Wait for the specified delay
        yield return new WaitForSeconds(delay);

        //Run the function after the delay
        iceberg.SplitIceBerg();

        //Set menu active
        menu.SetActive(true);
    }
}
