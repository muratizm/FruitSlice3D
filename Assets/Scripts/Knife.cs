using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float jumpforce = 7f;
    public float torque = 5f;
    public float maxAngular = 4f;
    private int comboCount = 0;
    public TrailRenderer trailRenderer1;
    public Rigidbody rb;
    public GameObject comboTextPosition;
    public GameObject comboText;



    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(-3f, jumpforce, 0f);
            rb.maxAngularVelocity = maxAngular;
            rb.AddTorque(0f, 0f, torque, ForceMode.Impulse);
        }

    }

    public int getCount(){
        return comboCount;
    }

    public void setCount(int value){
        comboCount = value;
        
        if(comboCount<2){
           trailRenderer1.material.color = Color.grey;
           Instantiate(comboText, comboTextPosition.transform, false);
        }
        else if(comboCount<5){
            trailRenderer1.material.color = Color.blue;
        }
        else if(comboCount<10){
            trailRenderer1.material.color = Color.red;
        }
    }

  

}