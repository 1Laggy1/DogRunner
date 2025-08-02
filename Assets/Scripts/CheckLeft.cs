using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLeft : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if ((collision.gameObject.tag != "JumpObject") && (collision.gameObject.tag != "MovingNavigator") && (collision.gameObject.tag != "Eda"))
        if (collision.gameObject.tag == "pol")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isLeft = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if ((collision.gameObject.tag != "JumpObject") && (collision.gameObject.tag != "MovingNavigator") && (collision.gameObject.tag != "Eda"))
        if (collision.gameObject.tag == "pol")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isLeft = true;
        }

    }
}
