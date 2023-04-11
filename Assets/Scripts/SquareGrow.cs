using UnityEngine;
using Photon.Pun;


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
    
    void Awake()
    {
    }

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
        if (!view.IsMine)
        {
            return;
        }
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
            if (flip)
            {
                if (canGrow)
                {
                    Debug.Log("Growing");
                    this.transform.localScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y+growthRate * Time.deltaTime);
                    //Vector2 newSize = sprite.size;
                    //newSize.y += growthRate * Time.deltaTime;
                    //sprite.size = newSize;
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
}