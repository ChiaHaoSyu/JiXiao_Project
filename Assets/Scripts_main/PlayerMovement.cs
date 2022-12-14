using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer playerSprite;

    [SerializeField]
    public float moveSpeed = 5f;

    public int coins;

    public Transform weaponTrans,wpTrans;
    public Transform pointRight, pointLeft;

    public GameObject weapon,weaponInFloor;
    public GameObject myWeapon;

    public Camera cam;

    [SerializeField]
    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos -(Vector2) weaponTrans.position;
        lookDir = lookDir.normalized;
        weaponTrans.right = lookDir;

        LookAt();

        SwitchAnim();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void LookAt()
    {
        if (rb.position.x > mousePos.x)
        {
            playerSprite.flipX = true;
            if (weaponTrans != null)
            {
                SpriteRenderer sprite;
                if(sprite = weaponTrans.GetComponentInChildren<SpriteRenderer>())
                {
                    sprite.flipY = true;
                }
                weaponTrans.position = pointLeft.position;
            }
            
        }
        else if (rb.position.x < mousePos.x) 
        {
            playerSprite.flipX = false;
            if(weaponTrans != null)
            {
                SpriteRenderer sprite;
                if(sprite = weaponTrans.GetComponentInChildren<SpriteRenderer>())
                {
                    sprite.flipY = false;
                    
                }
                weaponTrans.position = pointRight.position;
            }
            
        }
    }

    public void UpdateLookAt(Vector2 mousePos)
    {
        wpTrans.right = (mousePos - (Vector2) wpTrans.position).normalized;
        if (wpTrans.position.x > mousePos.x)
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (wpTrans.position.x < mousePos.x)
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void SwitchAnim()
    {
        if (movement == new Vector2(0, 0))
        {
            anim.SetBool("walk", false);
        }
        else
        {
            anim.SetBool("walk", true);
        }
    }

    void WeaponCheck()
    {
        weaponInFloor = null;

        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, 1);

        if(colls.Length<0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                if(colls[i].CompareTag("Weapon"))
                {
                    weaponInFloor = colls[i].gameObject;
                }
            }
        }
    }


}
