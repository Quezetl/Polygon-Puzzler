using UnityEngine;

public class SquareGrow : MonoBehaviour
{
    public float growthRate = 2f; 
    public Transform top;
    public Transform bottom;
    public LayerMask lMask;
    private SpriteRenderer sprite;
    private Vector2 initialSize; 
    private bool canGrow;
    
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        initialSize = new Vector2(2f, 2f);
    }

    
    void FixedUpdate()
    {
        top.localPosition = new Vector3(0, sprite.size.y / 2 , 0);
        bottom.localPosition = new Vector3(0, -sprite.size.y / 2 , 0);
        
        if (Physics2D.OverlapBox(top.position, new Vector2(.9f, 0.05f), transform.eulerAngles.z, lMask) && Physics2D.OverlapBox(bottom.position, new Vector2(.9f, 0.05f), transform.eulerAngles.z, lMask))
        {
            canGrow  = false;
            Debug.Log(transform.eulerAngles.z);
        }
            

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if(canGrow)
            {
                Vector2 newSize = sprite.size;
                newSize.y += growthRate * Time.deltaTime;
                sprite.size = newSize;
            }
        }
        else
        {
            canGrow = true;
            sprite.size = initialSize;
        }
    }
}