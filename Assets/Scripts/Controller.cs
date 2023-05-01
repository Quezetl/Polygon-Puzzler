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

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

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
}
