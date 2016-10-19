using UnityEngine;
using System.Collections;

public class GhostPlayer : MonoBehaviour {

    public static GhostPlayer instance;

    private Animator animator;
    private SpriteRenderer spriteRender;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            animator = GetComponent<Animator>();
            spriteRender = GetComponent<SpriteRenderer>();
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

    public static void SetVisible()
    {
        instance.spriteRender.color = new Color(1f, 1f, 1f, 1f);
    }

    public static void SetTranparent()
    {
        instance.spriteRender.color = new Color(1f, 1f, 1f, 0.55f);

    }
}