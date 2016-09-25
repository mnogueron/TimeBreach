using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float maxSpeed = 10f;
    public Transform groundCheck;
    public Transform bodyCheck;
    public float jumpForce = 700f;
    public int numberOfKey = 0;

    public bool doubleJumpEnabled = false;

    private bool facingRight = true;
    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    private bool grounded = false;
    private float groundRadius = 0.2f;
    private bool doubleJump = false;
    

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.instance.currentWorld.CompareTo(GameManager.World.PRESENT) == 0)
        {
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, GameManager.PresentWorldLayer ());
        }
        else
        {
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, GameManager.FutureWorldLayer ());
        }
        animator.SetBool("Ground", grounded);

        animator.SetFloat("vSpeed", rigidbody2D.velocity.y);

        if (grounded)
        {
            doubleJump = false;
        }

        float move = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if((move > 0 && !facingRight) || (move < 0 && facingRight))
        {
            Flip();
        }
    }

    void Update()
    {
        if((grounded || (!doubleJump && doubleJumpEnabled)) && Input.GetButtonDown("Jump") )
        {
            animator.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));

            if(!doubleJump && !grounded)
            {
                doubleJump = true;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SwitchWorld()
    {
        if (GameManager.IsWorldFuture())
        {
            // switch to the PRESENT
            transform.position = new Vector3(transform.position.x, transform.position.y, 60f);
        }
        else
        {
            // switch to the FUTURE
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
    }

    public bool CanSwitchWorld()
    {
        LayerMask toCheck = (GameManager.IsWorldFuture()) ? GameManager.PresentWorldLayer() : GameManager.FutureWorldLayer();
        return !Physics2D.OverlapCircle(bodyCheck.position, groundRadius, toCheck);
    }
}
