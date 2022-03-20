using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float shipSpeed = 5;
    public int shields = 1;
    // Update is called once per frame
    void Update()
    {
      Vector3 shipOffset = Vector3.zero;
      shipOffset.x = Input.GetAxis("Horizontal");
      shipOffset.z = Input.GetAxis("Vertical");
      shipOffset = shipOffset * shipSpeed * Time.deltaTime;
      transform.position = transform.position + shipOffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
      //Check for shields
      if(shields > 0)
      {
        shields = shields - 1;
        Destroy(collision.gameObject);
      }
      else
      {
        print("You Lose!");
        Destroy(this.gameObject);
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      print("You Win!");
      Destroy(this.gameObject);

    }
}
