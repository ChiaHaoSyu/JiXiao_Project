using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;

    public float speed;
    public float checkRaduis;
    public float attackRaduis;
    public float transRaduis;

    public LayerMask playerLayer;

    private SpriteRenderer enemySprite;
    private GameObject playerObj;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInTransRange;
    private bool isInChaseRange;
    private bool isInAttackRange;

    private string currentState;

    const string DOG_TRANS = "Dog_transfrom";
    const string DOG_FOLLOW = "Dog_follow";
    const string DOG_ATTACK = "Dog_attack";
    const string DOG_TRANSIDLE = "Dog_transidle";
    const string DOG_HURT = "Dog_hurt";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        isInTransRange = Physics2D.OverlapCircle(transform.position, transRaduis, playerLayer);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRaduis, playerLayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRaduis, playerLayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();

        SwithchAnim();

        LookAt();

        
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter();
        }

        if(isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }

    }

    private void MoveCharacter()
    {
        rb.MovePosition((Vector3)transform.position + (dir * speed * Time.deltaTime));
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }

    void SwithchAnim()
    {
        if (isInTransRange && !isInChaseRange)
        {
            ChangeAnimationState(DOG_TRANS);
        }
        else if (isInChaseRange && !isInAttackRange )
        {
            ChangeAnimationState(DOG_FOLLOW);
        }
        else if (isInAttackRange)
        {
            StartCoroutine(Attack());
        }
    }

    void LookAt()
    {
        if (rb.position.x < target.position.x)
        {
            player.localScale= new Vector3(-1,1,1);  
        }
        else if (rb.position.x > target.position.x)
        {
            player.localScale = new Vector3(1, 1, 1);
        }
    }

    public IEnumerator Attack()
    {
        ChangeAnimationState(DOG_ATTACK);
        yield return new WaitForSeconds(0.2f);
        
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(player.position,transRaduis);
        Gizmos.DrawWireSphere(player.position,checkRaduis);
        Gizmos.DrawWireSphere(player.position,attackRaduis);
    }


}


