using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        coinCount++;
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        coinCount--;
        if (coinCount <= 0)
        {
            GameObject timer = GameObject.Find("Timer");
            Destroy(timer);
            GameObject[] FireworkCol = GameObject.FindGameObjectsWithTag("Firework");

            if (FireworkCol.Length <= 0) return;
            foreach (GameObject gO in FireworkCol)
            {
                gO.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
