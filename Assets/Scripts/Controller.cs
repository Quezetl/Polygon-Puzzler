using UnityEngine;
using Photon.Pun;

public class Controller : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed;

    float horizontalMove = 0f;
    bool jump = false;
    PhotonView view;
    
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
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
        if (view.IsMine)
        {
            controller.Move(horizontalMove, false, jump);
            jump = false;
        }
    }
}
