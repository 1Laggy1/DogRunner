using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRight : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if ((collision.gameObject.tag != "JumpObject") && (collision.gameObject.tag != "MovingNavigator") && (collision.gameObject.tag != "Eda"))
        if (collision.gameObject.tag == "pol")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isRight = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if ((collision.gameObject.tag != "JumpObject") && (collision.gameObject.tag != "MovingNavigator") && (collision.gameObject.tag != "Eda"))
        if (collision.gameObject.tag == "pol")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isRight = true;
        }

    }
}
