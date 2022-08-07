using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Animator anm;
    public FixedJoystick fixedJoystick;

    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(fixedJoystick.Horizontal * speed, rb.velocity.y, fixedJoystick.Vertical * speed);
        if(fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anm.SetBool("isRunplayer", true);
        }
        else
        {
            anm.SetBool("isRunplayer", false);
        }
    }
}
