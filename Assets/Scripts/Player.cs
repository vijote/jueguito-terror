using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;

    private string state = "Idle";
    private string verticalDirection = "Down";
    private string horizontalDirection = "Right";

    [SerializeField]
    private GameObject axe;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        SwingAxe(Input.GetKey(KeyCode.Space));
        Animate();
    }

    private void SwingAxe(bool keyPressed)
    {
        if (!keyPressed)
        {
            axe.SetActive(false);
            return;
        }

        state = "SwingingAxe";
        axe.SetActive(true);
        Debug.Log("chupame");
    }

    private void Move(float horizontalMovement, float verticalMovement)
    {
        if (horizontalMovement == 0 && verticalMovement == 0)
        {
            state = "Idle";
            return;
        };

        if (horizontalMovement == 0) horizontalDirection = null;

        if (verticalMovement == 0) verticalDirection = null;

        if (horizontalMovement > 0)
        {
            horizontalDirection = "Right";
        } else if (horizontalMovement < 0)
        {
            horizontalDirection = "Left";
        }

        if (verticalMovement > 0)
        {
            verticalDirection = "Up";
        }
        else if (verticalMovement < 0)
        {
            verticalDirection = "Down";
        }

        transform.Translate(speed * Time.deltaTime * horizontalMovement  * Vector2.right);
        transform.Translate(speed * Time.deltaTime * verticalMovement * Vector2.up);
        state = "Walk";
    }

    private void Animate()
    {
        string animationName = state;

        if(verticalDirection != null) animationName += verticalDirection;

        if (horizontalDirection != null) animationName += horizontalDirection;

        animator.Play(animationName);
    }
}
