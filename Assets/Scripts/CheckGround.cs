using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pol")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pol")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isGrounded = true;
        }
            
    }
}
