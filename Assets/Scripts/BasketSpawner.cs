using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
    [SerializeField] private BasketPool basketPool;
    [SerializeField] private GameObject spawnPoint;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        Debug.Log(".............................");
        GameObject basket = basketPool.GetPooledObject();

        if(basket != null)
        { 
            basket.transform.position = spawnPoint.transform.position;
            basket.transform.rotation = spawnPoint.transform.rotation;
            basket.SetActive(true);
            spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x,spawnPoint.transform.position.y + 4,spawnPoint.transform.position.z);
        }
        
    }
}
