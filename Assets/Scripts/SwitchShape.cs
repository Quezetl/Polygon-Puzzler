using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SwitchShape : MonoBehaviour
{
    private int state;
    PhotonView view;
    SpriteRenderer sRender;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        view = GetComponent<PhotonView>();
        sRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine)
            return;


        if (Input.GetKeyDown(KeyCode.V))
        {
            if (state < 2)
                state++;
            else
                state = 0;

            view.RPC("switchState", RpcTarget.AllBuffered, state);
        }
    }

    [PunRPC]
    void switchState(int state)
    {
        sRender.sprite = sprites[state];
        switch (state)
        {
            case 0:
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<PolygonCollider2D>().enabled = false;
                break;
            case 1:
                GetComponent<PolygonCollider2D>().enabled = true;
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                break;
            case 2:
                GetComponent<CircleCollider2D>().enabled = true;
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                break;
        }
    }
}
