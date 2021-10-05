using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemmyController : MonoBehaviour
{
    public int healt = 3;
    public GameObject explosion;
    public float playerRange = 10f;
    public Rigidbody thRB;
    public float moveSpeed;
    public GameObject Player;
    void Start()
    {
        
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < playerRange)
        {
            Vector3 playerDirection = Player.transform.position - transform.position;
            thRB.velocity = playerDirection.normalized * moveSpeed;
        }
        else
        {
            thRB.velocity = Vector3.zero;
        }
        transform.LookAt(Player.transform.position - Vector3.forward);
    }
    public void TakeDamage()
    {
        healt--;
        if(healt <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
