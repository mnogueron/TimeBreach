using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player instance;

    public Transform groundCheck;
    public Transform bodyCheck;

    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    public int numberOfKey = 0;

    public bool doubleJumpEnabled = false;

    private bool facingRight = true;
    private bool grounded = false;
    private float groundRadius = 0.2f;
    private bool doubleJump = false;

    private Animator animator;
    private new Rigidbody2D rigidbody2D;

	private Vector3 initialPosition;
    

    // Use this for initialization
    void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        instance.animator = GetComponent<Animator>();
        instance.rigidbody2D = GetComponent<Rigidbody2D>();
		initialPosition = instance.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.IsPaused())
        {
            if (!WorldManager.IsWorldFuture())
            {
                grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WorldManager.PresentWorldLayer());
            }
            else
            {
                grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WorldManager.FutureWorldLayer());
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

            if ((move > 0 && !facingRight) || (move < 0 && facingRight))
            {
                Flip();
            }
        }
    }

    void Update()
    {
        if (!GameManager.IsPaused())
        {
            if ((grounded || (!doubleJump && doubleJumpEnabled)) && Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Ground", false);
                rigidbody2D.AddForce(new Vector2(0, jumpForce));

                if (!doubleJump && !grounded)
                {
                    doubleJump = true;
                }
            }
			// check is player is falling.
			// if he is falling, make him start from the beginning, at his initial position
			if(instance.transform.position.y < -2.0)
			{
				instance.transform.position = new Vector3(instance.transform.position.x, instance.transform.position.y, 2f);
			}
			if(instance.transform.position.y < -3.5 )
			{
				Debug.Log ("Player is falling !");
                StartCoroutine(SceneController.ResetScene());
				//instance.transform.position = initialPosition;
			}
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 newLocalScale = transform.localScale;
        newLocalScale.x *= -1;
        transform.localScale = newLocalScale;
    }

    public static void SwitchWorld()
    {
        if (WorldManager.IsWorldFuture())
        {
            // switch to the PRESENT
            instance.transform.position = new Vector3(instance.transform.position.x, instance.transform.position.y, 60f);
        }
        else
        {
            // switch to the FUTURE
            instance.transform.position = new Vector3(instance.transform.position.x, instance.transform.position.y, 0f);
        }
    }

    public static bool CanSwitchWorld()
    {
        return !Physics2D.OverlapCircle(instance.bodyCheck.position, instance.groundRadius, WorldManager.GetOppositeLayerMask());
    }

    public static void AddKey()
    {
        instance.numberOfKey++;
    }

    public static void RemoveKey()
    {
        instance.numberOfKey--;
    }

    public static bool HasKey()
    {
        return instance.numberOfKey > 0;
    }
}
