using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]
    private Sprite spriteArmmo;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private string ArmmoType;
    private int ArmoQTD;
    [SerializeField]
    private int Min_ArmoQTD;
    [SerializeField]
    private int Max_ArmoQTD;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = spriteArmmo;
        ArmoQTD = Random.Range(Min_ArmoQTD, Max_ArmoQTD);
        Debug.Log("colidiu");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position - Vector3.forward);
    }
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerMovement>().CurrentArmmo += ArmoQTD;
        Destroy(this.gameObject);
    }
}
