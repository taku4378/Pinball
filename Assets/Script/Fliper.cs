using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fliper : MonoBehaviour
{
    float timer;
    public float actiontime;
    float actiontime2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.D)&&timer>actiontime)
        {
            FlipAction();
        }
    }

    public void FlipAction()
    {
        transform.DORotate(new Vector3(0,0, -50), actiontime / 2, RotateMode.LocalAxisAdd);
        transform.DORotate(new Vector3(0,0, 50), actiontime / 2, RotateMode.LocalAxisAdd);
        timer = 0;
    }
}
