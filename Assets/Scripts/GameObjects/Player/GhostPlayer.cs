using UnityEngine;
using System.Collections;

public class GhostPlayer : MonoBehaviour {

    public static GhostPlayer instance;

    private Animator animator;
    private bool facingRight = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            animator = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Grounded(bool grounded)
    {
        instance.animator.SetBool("Ground", grounded);
    }

    public static void Move(float speed)
    {
        instance.animator.SetFloat("Speed", speed);
    }

    public static void VSpeed(float velocityY)
    {
        instance.animator.SetFloat("vSpeed", velocityY);
    }
}
