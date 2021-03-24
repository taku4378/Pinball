using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plunger : MonoBehaviour
{
    GameObject Ball;
    Vector3 pos;
    Vector3 normalpos;
    public float Charge;
    public float ChargePower;
    public float PowerLimit;
    public float ChargeSpeed;
    public float FiringPower;
    public float PA;
    public bool PositionSwicth;
    public bool FiringSwicth;
    // Start is called before the first frame update
    void Start()
    {
        Ball=GameObject.FindGameObjectWithTag("Ball");
        PositionSwicth = false;
        FiringSwicth = false;
        normalpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;
        Rigidbody rb = this.GetComponent<Rigidbody>();
        
        Vector3 F = new Vector3(0, FiringPower, FiringPower);
        Vector3 C = new Vector3(0, -ChargeSpeed,-ChargeSpeed);

        if (Input.GetKey(KeyCode.Space))
            PowerCharge(rb,C);      

        if (Input.GetKeyUp(KeyCode.Space))
            PositionSwicth = true;        
        
        if (PositionSwicth == true)
            PositionAdjustment(rb);

        if (FiringSwicth == true&&PositionSwicth==true)
            Firing(rb, Ball, F);            
    }

    void PowerCharge(Rigidbody rb,Vector3 C)
    {
        if (PowerLimit > ChargePower)
        {
            pos.y -= Charge;
            pos.z -= Charge;
            ChargePower += Charge;
            gameObject.transform.position=pos;
        }
        if(PowerLimit <= ChargePower)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void Firing(Rigidbody rb, GameObject Ball, Vector3 F)
    {
        Rigidbody BallRb = Ball.GetComponent<Rigidbody>();
        BallRb.AddForce(F);
        FiringSwicth = false;
    }

    void PositionAdjustment(Rigidbody rb)
    {
        if (pos.y > normalpos.y)pos.y -= PA;       
        if (pos.y < normalpos.y)pos.y += PA;       
        if (pos.z > normalpos.z)pos.z -= PA;       
        if (pos.z < normalpos.z)pos.z += PA;
        ChargePower -=PA ;
        if (ChargePower <= 0) ChargePower = 0;
        gameObject.transform.position = pos;
        if (pos.y >= normalpos.y&&pos.z>=normalpos.z)PositionSwicth = false;
        //FiringSwicth = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        FiringSwicth = true;
    }
    void OnCollisionExit(Collision coll)
    {
        FiringSwicth = false;
    }
}
