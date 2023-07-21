using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip mySoundDie;
    [SerializeField] float speed = 1f;
    Rigidbody2D myRigidbody;
    BoxCollider2D myFace;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFace = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        myRigidbody.velocity = new Vector2(speed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(mySoundDie, Camera.main.transform.position);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        speed = -speed;
        FlipEnemyFace();
    }
    void FlipEnemyFace()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
