using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BackgroundCollector : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Background")
        {
            Transform tf = collision.GetComponent<Transform>();
            tf.position = new Vector2(0, tf.position.y - 0.16f);
        }
    }
}
