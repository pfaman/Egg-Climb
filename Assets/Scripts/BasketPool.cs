using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketPool : MonoBehaviour
{
    [SerializeField] private GameObject BasketPrefab;
    [SerializeField] private Transform spawnpoint;
    private List<GameObject> poolBasket = new List<GameObject>();
    private int amountToPool = 100;

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject basket = Instantiate(BasketPrefab, spawnpoint.position, spawnpoint.rotation);
            basket.SetActive(false);
            poolBasket.Add(basket);
            
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolBasket.Count; i++)
        {
            if (!poolBasket[i].activeInHierarchy)
            {
                if(i%3 == 0)
                {
                    poolBasket[i].GetComponent<BasketController>().MoveEnabled = true;
                }
                else
                {
                    poolBasket[i].GetComponent<BasketController>().MoveEnabled = false;
                }
                return poolBasket[i];
            }
        }

        return null;
    }
}
