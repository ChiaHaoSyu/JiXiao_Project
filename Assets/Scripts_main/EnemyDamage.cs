using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    float health, maxhealth;
    public float destoryTime;

    public GameObject floatPoint;

    private SpriteRenderer enemySprite;
    private Animator anim;
    private string currentState;

    const string DOG_DIED = "Dog_died";

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();

        health = maxhealth;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }

    public void TakeDamage(float damageAmount)
    {
        //float damage
        GameObject gb = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damageAmount.ToString();

        health -= damageAmount;

        if (health <= 0)
        {
            ChangeAnimationState(DOG_DIED);
            this.GetComponent<EnemyAI>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject,destoryTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed()
    {
        enemySprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        enemySprite.color = Color.white;
    }

}
