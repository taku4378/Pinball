using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fliper_left : MonoBehaviour
{
    public float timer;
    public float actiontime;
    bool ActionSwitch;
    bool UpSwitch;
    bool DownSwitch;
    bool PowerSwitch;
    public GameObject Ball;
    Rigidbody BallRb;
    public Vector3 AddPower;
    void Start()
    {
        ActionSwitch = false;
        UpSwitch = false;
        DownSwitch = false;
        PowerSwitch = false;

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && timer > actiontime)
        {
            Ball = GameObject.FindGameObjectWithTag("Ball");
            ActionSwitch = true;
            UpSwitch = true;
            PowerSwitch = true;
        }

        if (ActionSwitch == true)
        {
            BallRb = Ball.GetComponent<Rigidbody>();
            FlipAction(BallRb);
        }


    }

    public void FlipAction(Rigidbody BallRb)
    {
        if (UpSwitch == true)
        {
            timer = 0;
            FlipUp();

        }

        if (timer >= actiontime / 2)
        {
            DownSwitch = true;
        }

        if (DownSwitch == true)
        {
            PowerSwitch = false;
            FlipDown();
        }


    }

    void FlipUp()
    {
        transform.DORotate(new Vector3(0, 0, 50), actiontime / 2, RotateMode.LocalAxisAdd);
        UpSwitch = false;
        Debug.Log(ActionSwitch);
    }

    void FlipDown()
    {
        transform.DORotate(new Vector3(0, 0, -50), actiontime / 2, RotateMode.LocalAxisAdd);
        ActionSwitch = false;
        DownSwitch = false;
        timer = 0;
        Debug.Log(ActionSwitch);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PowerSwitch)
            BallRb.AddForce(AddPower);
    }
}
