using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private int health = 3;

    [SerializeField]
    private GameObject woodPrefab;

    public void ReceiveDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(woodPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    
}
