using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            // for dynamic? objects
            // ...
            Debug.Log("Collide!");

            // for physics objects

            coll.gameObject.rigidbody2D.velocity = gameObject.transform.up * 2.0f;
            //Vector3 normalForce = gameObject.transform.up * -200;
            //coll.gameObject.rigidbody2D.AddForce(normalForce);
        }
    }
}
