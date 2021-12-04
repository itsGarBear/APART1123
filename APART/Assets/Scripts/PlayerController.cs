using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public float maxMoveSpeed = 5f;
    public float moveSpeed;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    public LayerMask groundLayer;
    [SerializeField] private Collider2D collider;

    //delete me later
    public Toggle creativeToggle;

    [Header("Weapon")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;

    public void toggleGravity()
    {
        if (!creativeToggle.isOn)
            rb.gravityScale = 1;
        else
            rb.gravityScale = 0;
    }
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }
    private void Start()
    {
        moveSpeed = maxMoveSpeed;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            creativeToggle.isOn = !creativeToggle.isOn;
        }

        if(!creativeToggle.isOn)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
                TryJump();
        }
        else
        {
            CreativeMove();
        }
        
        if (Input.GetMouseButtonDown(0))
            TryShoot();
    }
    private void CreativeMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(x,y,0f) * moveSpeed;
    }
    private void TryShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity);

        Bullet b = bullet.GetComponent<Bullet>();

        b.rb.velocity = bulletSpawnPos.right * b.fireForce;
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 dir = (transform.right * x) * moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }

    private void TryJump()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        //RaycastHit2D hit;
        if (Physics2D.Raycast(transform.position, -Vector2.up, collider.bounds.extents.y + 0.1f, groundLayer.value))
        {
            
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
