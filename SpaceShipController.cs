using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().mass = 5;
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0f, 0f, 0.1f));
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0f, 0f, -0.1f));
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(-0.1f, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0.1f, 0f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }
    }

    void Explode()
    { //https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html
        Debug.Log("BOOM!");

        float radius = 5.0F;
        float power = 10000.0F;

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }


  

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        Destroy(go);

        GetComponent<Transform>().localScale += go.GetComponent<Transform>().localScale ;

        //i = 5;

        //i = i + 2;
        //i += 2;
        //i++;
    }
}
