using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Transform Player;
    public Animator anim;
    private Vector3 Direction;
    private Vector2 MouseIput;
    private Rigidbody RB;
    public float MouseSensitivity = 1.0f;
    public Camera ViewCam;
    public GameObject bulletInpact;
    public int CurrentArmmo;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Movementation();
        Fire();
    }

    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + Direction * 10 * Time.fixedDeltaTime);
    }

    void Movementation()
    {
        Direction = Player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized);
        MouseIput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * MouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + MouseIput.x, transform.rotation.eulerAngles.z);
    }
    void Fire()
    {
        if(Input.GetMouseButtonDown(0)){
            if (CurrentArmmo > 0)
            {
                Ray ray = ViewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletInpact, hit.point, transform.rotation);
                    if(hit.transform.tag == "Enemy")
                    {
                        hit.transform.GetComponent<EnemmyController>().TakeDamage();
                    }
                }
              
                CurrentArmmo--;
                anim.SetBool("Fire",true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Fire", false);
        }
    }

}
