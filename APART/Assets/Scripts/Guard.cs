using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public int moveSpeed;
    public int attackDmg;
    public int hp;
    public float attackRadius;

    public float followRadius;

    [SerializeField] Transform player;

    public Animator anim;


    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().transform;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(checkIfPlayerInFollowRadius())
        {
            if(player.position.x < transform.position.x)
            {
                if(checkIfPlayerInAttackRadius())
                {
                    anim.SetBool("Attack", true);
                }
                else
                {
                    anim.SetBool("Attack", false);
                    transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
            else if(player.position.x > transform.position.x)
            {
                if (checkIfPlayerInAttackRadius())
                {
                    anim.SetBool("Attack", true);
                }
                else
                {
                    anim.SetBool("Attack", false);
                    transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
        }
        else
        {
            //stop moving
        }
    }

    private bool checkIfPlayerInAttackRadius()
    {
        if (Mathf.Abs(player.position.x - transform.position.x) < attackRadius)
            return true;
        else
            return false;
    }
    private bool checkIfPlayerInFollowRadius()
    {
        if (!PlayerController.myPlayer.isCara)
            return false;
        else if (Mathf.Abs(player.position.x - transform.position.x) < followRadius)
            return true;
        else
            return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void AnimationComplete()
    {
        anim.SetBool("Attack", false);
    }
}
