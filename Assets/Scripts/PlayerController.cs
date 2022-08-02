using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed;
    public Transform dative;

    private float timeToShoot;
    public float reloadTime;
    public bool canShoot;

    public GameObject target, rocket;
    public Transform barrel;

    public float offset;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseFollow();

        timeToShoot -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Mouse0) && timeToShoot <= 0 && canShoot)
        {
            Shooting();
        }
    }

    void MouseFollow()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        /*
        Vector2 direction = (dative.position - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        */
    }

    void Shooting()
    {
        timeToShoot = reloadTime;
        Instantiate(target, dative.transform.position, this.transform.rotation);
        Instantiate(rocket, barrel.position, this.transform.rotation);
    }
}
