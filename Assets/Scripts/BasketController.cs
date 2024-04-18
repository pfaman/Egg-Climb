using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] public Transform eggPosition;
    private Collider2D collider;
    private float dirX1 = -1.7f;
    private float dirX2 = 1.7f;
    [Range(0, 10)] public float moveSpeed = 3f;
    private bool moveRight = true;
    public bool MoveEnabled;
    public bool primaryBasket;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Egg")
        {
            primaryBasket = true;
            EggController eggController = collision.gameObject.GetComponent<EggController>();
            eggController.rotate = false;
            eggController.gameObject.transform.rotation = Quaternion.identity;
            eggController.gameObject.transform.position = eggPosition.position;
            eggController.gameObject.transform.parent = gameObject.transform;
            ScoreController.Instance.IncreaseScore(10);
            ScoreController.Instance.scoreIT = true;
        }
        // else if (collision.gameObject.tag == "GameOverBar")
        // {
        //     Debug.Log("Collision...........................");
        //     gameObject.SetActive(false);
        //     collider.enabled = true;
        // }
    }

    private void OnEnable()
    {
        if(collider != null)
        {
            collider.enabled = true;
        }
    }

    private void Start()
    {
        EggShoot.Instance.EggTossed += OntossCalled;
        EggLife.Instance.EggCrack += OntossMissed;
        primaryBasket = false;
        collider = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(MoveEnabled)
        {
            HorizontalPlatform();
        }
        float distance = Vector3.Distance (EggController.Instance.gameObject.transform.position, transform.position);
        if(distance > 10 && primaryBasket)
        {
            gameObject.SetActive(false);
        }
    }

    private void HorizontalPlatform()
    {
        if (transform.position.x > dirX2)
            moveRight = false;
        else if (transform.position.x < dirX1)
            moveRight = true;

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    private void OntossCalled()
    {
        if(primaryBasket)
        {
            collider.enabled = false;
        }
    }
    private void OntossMissed()
    {
        if(primaryBasket)
        {
            collider.enabled = true;
        }
    }

    private void OnDisable()
    {
        EggShoot.Instance.EggTossed -= OntossCalled;
        EggLife.Instance.EggCrack -= OntossMissed;
    }
}
