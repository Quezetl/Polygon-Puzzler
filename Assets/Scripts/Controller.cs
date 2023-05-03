using UnityEngine;
using Photon.Pun;

public class Controller : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed;

    float horizontalMove = 0f;
    bool jump = false;
    PhotonView view;

    private Joystick joystick;
    
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        // joystick = FindObjectOfType<GameSession>().joystick;
        joystick = FindObjectOfType<Joystick>();
        if (joystick == null) {
            Debug.LogError("Joystick not found!");
        }
    }

    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        horizontalMove = joystick.Horizontal * speed;

        // if (Input.GetButtonDown("Jump"))
        // {
        //     jump = true;
        // }

        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
        //     // This code will be executed when the user touches the screen
        //     jump = true;
        // }

        // if (player presses jump button){ jump = true; call jumpButton function}
        // if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
        //     Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        //     Raycast hit;

        //     if(Physics.Raycast(ray, out hit)){
        //         if(hit.GameObject.name == "JumpButton"){
        //             Debug.Log("Jump button pressed!");
        //         }
        //     }
        // }

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            controller.Move(horizontalMove, false, jump);
            jump = false;
        }
    }

    // void toggleJumpBoolean(){
    //     jump = true;
    // }
}
