using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemmyController : MonoBehaviour
{
    [SerializeField]
    private int healt = 3;
    [SerializeField]
    private float playerRange = 20f;
    [SerializeField]
    private float MinDistancePlayer = 4.0f;
    public Rigidbody thRB;
    [SerializeField]
    private float moveSpeed;
    public GameObject Player;
    public Animator StateEnemy;
    private bool dead = false;
    void Start()
    {
        StateEnemy = GetComponent<Animator>();
    }
    void Update()
    {
        if((Vector3.Distance(transform.position, Player.transform.position) < playerRange) && (Vector3.Distance(transform.position, Player.transform.position)  > 4.0f))
        {
            if (!dead)
            {
                Vector3 playerDirection = Player.transform.position - transform.position;
                thRB.velocity = playerDirection.normalized * moveSpeed;
                StateEnemy.SetBool("Idle", false);
            }
            else
            {
                thRB.velocity = Vector3.zero;
            }
        }
        else
        {
            thRB.velocity = Vector3.zero;
            StateEnemy.SetBool("Idle", true);
        }
        transform.LookAt(Player.transform.position - Vector3.forward);
    }
    public void TakeDamage()
    {
        healt--;
        StateEnemy.SetBool("Damage", true);
        if(healt <= 0)
        {
            dead = true;
            StateEnemy.SetBool("Dead", true);

        }
    }
    public void DamageAnimation()
    {
        StateEnemy.SetBool("Damage", false);
    }
}
