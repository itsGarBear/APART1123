using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Move Tutorial: https://pavcreations.com/platformers-implementation-in-unity-from-scratch/3/#Player-controller-script
    //Ladder Tutorial: https://pavcreations.com/climbing-ladders-mechanic-in-unity-2d-platformer-games/ 
    public float maxMoveSpeed = 50f;
    public float moveSpeed;
    public float jumpForce = 5f;

    //private Rigidbody2D rb;
    //public LayerMask groundLayer;
    [SerializeField] private Collider2D collider;

    //delete me later
    public Toggle creativeToggle;

    [Header("Weapon")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;

    //trying new movement 
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    [SerializeField] private LayerMask groundLayer;
    private float xMove = 0f;
    private float lastJumpY = 0f;
    private bool isFacingRight = false;
    private bool isJumping = false;

    //ladder
    private bool jumpHeld = false;
    private bool crouchHeld = false;
    private bool isUnderPlatform = false;
    private bool isCloseToLadder = false;
    private bool climbHeld = false;
    private bool hasStartedClimb = false;

    private Transform ladder;
    private float yMove = 0f;
    public float climbSpeed = .2f;

    //stairs
    private Stairs stair;
    public bool isNearAStair = false;

    public bool canShoot = true;

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
        circleCollider = GetComponentInChildren<CircleCollider2D>();
    }
    private void Start()
    {
        moveSpeed = maxMoveSpeed;
    }

    private void Update()
    {
        #region Creative Mode
        if (Input.GetKeyDown(KeyCode.C))
        {
            creativeToggle.isOn = !creativeToggle.isOn;
        }

        if(!creativeToggle.isOn)
        {
            Move();

            if (IsGrounded() && Input.GetButtonDown("Jump"))
                isJumping = true;

            if(!IsGrounded())
            {
                if (lastJumpY < transform.position.y)
                    lastJumpY = transform.position.y;
            }
        }
        else
        {
            CreativeMove();
        }
        #endregion

        yMove = Input.GetAxisRaw("Vertical") * climbSpeed;

        //crouchHeld = (IsGrounded() && !isCloseToLadder && Input.GetButton("Crouch")) ? true : false;
        climbHeld = (isCloseToLadder && Input.GetButton("Climb")) ? true : false;
        if(climbHeld)
        {
            if (!hasStartedClimb) hasStartedClimb = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(canShoot)
                TryShoot();
        }
            

        //Enter Stair
        if (isNearAStair && Input.GetButtonDown("Climb"))
        {
            transform.position = stair.EnterStair();
            print(stair.name);
            stair = stair.stairExitsAt;
            print(stair.name);
            isNearAStair = true;
        }
    }

    private void FixedUpdate()
    {
        if(!creativeToggle.isOn)
        {
            float moveFactor = xMove * Time.fixedDeltaTime;

            rb.velocity = new Vector2(moveFactor * 10f, rb.velocity.y);

            //if (moveFactor > 0 && !isFacingRight) flipFacingDirection();
            //else if (moveFactor < 0 && isFacingRight) flipFacingDirection();

            if (isJumping)
            {
                Jump();
            }

            #region Climbing

            if (hasStartedClimb && !climbHeld)
            {
                //if (xMove > 0 || xMove < 0) 
                ResetClimbing();
            }
            else if (hasStartedClimb && climbHeld)
            {
                float height = GetComponent<SpriteRenderer>().size.y;
                float topLadderY = Half(ladder.transform.GetChild(0).transform.localPosition.y + height);
                float bottomLadderY = Half(ladder.transform.GetChild(1).transform.localPosition.y + height);


                float transformY = Half(transform.position.y);
                float transformVY = transformY + yMove;

                if (transformVY > topLadderY || transformVY < bottomLadderY)
                {
                    ResetClimbing();
                }
                else if (transformY <= topLadderY && transformY >= bottomLadderY)
                {
                    rb.bodyType = RigidbodyType2D.Kinematic;
                    if (!transform.position.x.Equals(ladder.transform.position.x))
                        transform.position = new Vector3(ladder.transform.position.x, transform.position.y, transform.position.z);

                    Vector3 fowardDir = new Vector3(0f, transformVY, 0);
                    Vector3 newPos = Vector3.zero;

                    if (yMove > 0)
                        newPos = transform.position + fowardDir * Time.deltaTime * climbSpeed;
                    else if (yMove < 0)
                        newPos = transform.position - fowardDir * Time.deltaTime * climbSpeed;
                    if (newPos != Vector3.zero)
                        rb.MovePosition(newPos);
                }
            }

            #endregion
        }

    }

    private void ResetClimbing()
    {
        //if(hasStartedClimb)
        //{
            hasStartedClimb = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            transform.position = new Vector3(transform.position.x, Half(transform.position.y), transform.position.z);
        //}
    }

    public static float Half(float value)
    {
        //print(Mathf.Floor(value) + 0.5f);
        return Mathf.Floor(value) + 0.5f;
    }
    private void flipFacingDirection()
    {
        isFacingRight = !isFacingRight;

        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        isJumping = false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(circleCollider.bounds.center, circleCollider.radius, Vector2.down, 0.1f, groundLayer);
        if (hit && !lastJumpY.Equals(0))
            lastJumpY = 0;

        return hit.collider != null;
    }
    private void CreativeMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(x,y,0f) * moveSpeed;
    }
    private void TryShoot()
    {
        Quaternion angle = bulletSpawnPos.transform.parent.transform.parent.rotation;
        angle.eulerAngles = new Vector3(angle.eulerAngles.x, angle.eulerAngles.y, angle.eulerAngles.z + 180f);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, angle);
        Bullet b = bullet.GetComponent<Bullet>();

        b.rb.velocity = bulletSpawnPos.right * b.fireForce;
    }

    private void Move()
    {
        xMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        Vector2 dir = (transform.right * xMove);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stairs"))
        {
            isNearAStair = true;
            stair = collision.gameObject.GetComponent<Stairs>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ladder"))
        {
            isCloseToLadder = true;
            this.ladder = collision.transform;
        }

        if(collision.gameObject.CompareTag("Stairs"))
        {

        }
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ladder"))
        {
            isCloseToLadder = false;
            this.ladder = null;
        }

        if (collision.gameObject.CompareTag("Stairs"))
        {
            isNearAStair = false;
            stair = null;
        }
    }

    
}
