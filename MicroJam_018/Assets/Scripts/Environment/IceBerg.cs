using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBerg : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SplitIceBerg();
        }
    }

    public void SplitIceBerg()
    {
        _animator.CrossFade("SplitIceberg", 0.15f);
    }
}
