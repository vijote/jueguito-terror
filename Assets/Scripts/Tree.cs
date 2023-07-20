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
        Debug.Log("me estan pegando ayuda por favor me pegan");
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("dando madera");
        Instantiate(woodPrefab);
    }
}
