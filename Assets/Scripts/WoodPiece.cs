using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPiece : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Destroy(gameObject);
        }
    }}
