using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public Rigidbody rb;
    public GameObject colectable;
    public GameObject Zidovi;
    public float upwardForce = 600f;

    int ime;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        if (collisionInfo.collider.tag == "Jump")
        {
            rb.AddForce(0, upwardForce * Time.deltaTime, 0, ForceMode.Impulse);
        }
        if (collisionInfo.collider.CompareTag("Zid"))
        {
            Zidovi.SetActive(false);
            Destroy(Zidovi.gameObject);
            Debug.Log("Bol");
        }
        if (collisionInfo.collider.CompareTag("Colect"))
        {
           colectable.SetActive(false);
        }
    }
}