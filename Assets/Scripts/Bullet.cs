using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed = 10;
    public int Damadge = 10;
    public Player shooter;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = gameObject.transform.forward * Speed;
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Livable l = other.gameObject.GetComponent<Livable>();
        if (l)
        {
            l.Hit(Damadge, shooter);
        }
        Destroy(gameObject);
    }
}
