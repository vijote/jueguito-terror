using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";
    [SerializeField]
    private float movementSpeed = 0.0f;
    private Vector2 randomDirection = Vector2.zero;
    private GameObject player;
    public float stamina = 1000;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        InvokeRepeating("RandomDirection", 0.5f, 0.5f);
    }

    private void Update()
    {
        Move();
    }
    private void RandomDirection()
    {
        randomDirection= new Vector2(Random.Range(-10,10),Random.Range(-10,10));
        return;
    }
    private void Move()
    {
        if (player != null)
        {
            Vector2 directionToPlayer = player.transform.position - transform.position;
            if (Vector2.Distance(player.transform.position, transform.position) > 6)
            {
                movementSpeed = 2.0f;
                transform.Translate(randomDirection.normalized * movementSpeed * Time.deltaTime);
                if (stamina < 96)
                {
                    stamina += 10 * Time.deltaTime;
                }
                return;
            }
            if (Vector2.Distance(player.transform.position, transform.position) < 6 && Vector2.Distance(player.transform.position, transform.position) > 3)
            {
                if (stamina <= 100 && stamina >= 2)
                {
                    movementSpeed = 3f;
                    stamina -= 10 * Time.deltaTime;
                }
                else
                {
                    movementSpeed = 1.0f;
                }
            }
            if (Vector2.Distance(player.transform.position, transform.position) < 3)
            {
                if (stamina <= 100 && stamina >= 4)
                {
                    movementSpeed = 5.0f;
                    stamina -= 20 * Time.deltaTime;
                }
                else
                {
                    movementSpeed = 1.0f;
                }
            }
            transform.Translate(-directionToPlayer.normalized * movementSpeed * Time.deltaTime);
        }
        return;
    }
}
