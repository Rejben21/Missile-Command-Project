using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);

        if(transform.position.x >= 9)
        {
            transform.position = new Vector2(-9, 5);
        }
        else if (transform.position.x <= -9)
        {
            transform.position = new Vector2(9, 5);
        }

        if(transform.position.y <= -5f)
        {
            transform.position = new Vector3(Random.Range(-8.5f, 8.5f), 5, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Explosion"))
        {
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("House"))
        {
            GameManager.instance.lifes--;

            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
