using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;

public class SquareGrow : MonoBehaviour
{
    public float growthRate = 2f; 
    public Transform top;
    public Transform bottom;
    public LayerMask lMask;
    public SpriteRenderer sprite;
    private Vector2 initialSize; 
    private bool canGrow;
    private bool flip;
    PhotonView view;

    void Start()
    {
        initialSize = new Vector2(2f, 2f);
        flip = true;
        view = GetComponent<PhotonView>();
    }



    void Update()
    {

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("flip value: " + flip);
            flip = !flip;
        }
    }

    void FixedUpdate()
    {
        
        top.localPosition = new Vector3(0, sprite.size.y / 2 , 0);
        bottom.localPosition = new Vector3(0, -sprite.size.y / 2 , 0);
        
        if (Physics2D.OverlapBox(top.position, new Vector2(1.9f, 0.1f), transform.eulerAngles.z, lMask) && Physics2D.OverlapBox(bottom.position, new Vector2(1.9f, 0.1f), transform.eulerAngles.z, lMask))
        {
            canGrow  = false;
        }
        else
        {
            canGrow = true;
        }
            

        if (Input.GetKey(KeyCode.LeftControl))
        {
            view.RPC("shapeChange", RpcTarget.All);
        }
    }

    [PunRPC]
    private void shapeChange()
    {
        if (flip)
        {
            if (canGrow)
            {
                Debug.Log("Growing");
                Vector2 newSize = sprite.size;
                newSize.y += growthRate * Time.deltaTime;
                sprite.size = newSize;
            }
        }
        else if (!flip)
        {
            Debug.Log("Shrinking");
            Vector2 newSize = sprite.size;
            if (newSize.y < 2)
                return;
            newSize.y -= growthRate * Time.deltaTime;
            sprite.size = newSize;
        }
    }
}

