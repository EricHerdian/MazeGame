using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour, IMove
{
    [SerializeField] private float speed = 0f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 direction;

    private void Update() {
        // Run //
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2;
        }

        // Animation //
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        PositionUpdate(direction);
        InputHandler();
    }

    public void InputHandler()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    public void PositionUpdate(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        
        // transform.position = new Vector3(
        //     transform.position.x + direction.x * Time.deltaTime * speed,
        //     transform.position.y + direction.y * Time.deltaTime * speed, 0
        // );
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Goal"){
            if(SceneManager.GetActiveScene().name == "SampleScene"){
                    SceneManager.LoadScene("SampleScene2", LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
    }
}