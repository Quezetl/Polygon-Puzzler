using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed;

    float horizontalMove = 0f;
    bool jump = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove, false, jump);
        jump = false;
    }

}
