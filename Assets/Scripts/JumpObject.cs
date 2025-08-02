using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour
{
    public PlayerMovement pl;
    public Animator anim;
    [SerializeField]
    private float JumpForceWithJumpObjectPrivate;
    [SerializeField]
    private float JumpForceWithJumpObjectPrivateNew;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            JumpForceWithJumpObjectPrivateNew = JumpForceWithJumpObjectPrivate;
            pl.JumpWithJumpObject(JumpForceWithJumpObjectPrivate);
            anim.SetBool("Idle", false);
            anim.SetTrigger("Jump");
            JumpForceWithJumpObjectPrivate = JumpForceWithJumpObjectPrivateNew;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Idle", true);
        }
    }
}
