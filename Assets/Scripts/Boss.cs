using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";
    [SerializeField]
    private float movementSpeed = 4.0f;
    private GameObject player;
    [SerializeField]
    private string sceneToRestart = "SampleScene";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;

        if (Vector2.Distance(player.transform.position, transform.position) < 10){
            transform.Translate(directionToPlayer.normalized * movementSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToRestart);
        }
    }
}
