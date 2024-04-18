using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScaler : MonoBehaviour
{
    // void Start()
    // {
    //     float cameraHeight = Camera.main.orthographicSize;
    //     float cameraWidth = cameraHeight * Screen.width / Screen.height;

    //     gameObject.transform.localScale = Vector3.one * cameraHeight / 5.0f;
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            Debug.Log("OnCollisionEnter2D");
            collision.gameObject.SetActive(false);
            EggLife.Instance.EggDisabled(1);
            StartCoroutine(SpawnEggAgain());
            ScoreController.Instance.scoreIT = false;      
        }
        
    }

    private IEnumerator SpawnEggAgain()
    {
        yield return new WaitForSeconds(2f);
        EggController.Instance.SpawnEgg();
    }
}
