using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;

    private string state;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Animate();
    }

    private void Move(float horizontalMovement, float verticalMovement)
    {
        if (horizontalMovement == 0 && verticalMovement == 0)
        {
            state = "Idle";
            return;
        };

        transform.Translate(Vector2.right * speed * horizontalMovement * Time.deltaTime);
        transform.Translate(Vector2.up * speed * verticalMovement * Time.deltaTime);
        state = "Walk";
    }

    private void Animate()
    {

        animator.Play(state);
    }
}
