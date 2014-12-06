using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    public int durability;
    private Animator anim;

    void Awake()
    {

        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            // for dynamic? objects
            // ...
            //Debug.Log("Collide!");

            // for physics objects

            coll.gameObject.rigidbody2D.velocity = gameObject.transform.up * 2.0f;
            //Vector3 normalForce = gameObject.transform.up * -200;
            //coll.gameObject.rigidbody2D.AddForce(normalForce);
            durability--;
            anim.SetBool("isDamaged", true);


            anim.SetInteger("currentCondition", durability);

            if (durability <= 0)
            {
                Destroy(gameObject);
            }

        }

        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.rigidbody2D.velocity = gameObject.transform.up * 2.0f;
        }

    }

    void DamagedAnimationEnd()
    {
        anim.SetBool("isDamaged", false);
    }
}
