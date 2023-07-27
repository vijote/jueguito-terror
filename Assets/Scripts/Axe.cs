using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(MakeDamage(collision));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
    }

    private IEnumerator MakeDamage(Collider2D collision)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Tree tree = collision.gameObject.GetComponent<Tree>();

            tree.ReceiveDamage(1);
            Debug.Log("making damage");
        }
    }
}
