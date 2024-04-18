using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoSingleton<EggController>
{
    private Rigidbody2D rb;
    private float upForce = 820f;
    public bool rotate;
    public bool UpdateLocation;
    public Vector3 spawnEggPos;
    public BasketController basketController;

    private void OnEnable()
    {
        EggShoot.Instance.EggTossed += EggToss;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Basket")
        {
            basketController = collision.gameObject.GetComponent<BasketController>();
            spawnEggPos = basketController.eggPosition.position;
            UpdateLocation = true;
        }
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         
        spawnEggPos = basketController.eggPosition.position;    
        if(rotate)
        {
            transform.Rotate(0,0,6);
        }
    }

    public void SpawnEgg()
    {
        if(EggLife.Instance.eggRemains)
        {
            gameObject.transform.position = spawnEggPos;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.SetActive(true);
        } 
    }

    private void EggToss()
    {
        Debug.Log("Toss");
        rb.AddForce(new Vector2(rb.velocity.x, upForce));
        rotate = true;
        transform.SetParent(null);
    }
    private void OnDisable()
    {
        EggShoot.Instance.EggTossed -= EggToss;
    }
}
