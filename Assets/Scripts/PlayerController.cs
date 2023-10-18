using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private float speed = 30f;
    private float centerToEdge;
    private float move;
        
    // Start is called before the first frame update
     private void Start()
    {
        centerToEdge = 24f;
    }

    // Calls PlayerMovement method each frame
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * move);

        if (Mathf.Abs(transform.position.x) > centerToEdge)
        {
            float edge = centerToEdge;
            if(transform.position.x < 0f)
            {
                edge = -centerToEdge;
            }
            transform.position = new Vector3(edge, transform.position.y, transform.position.z);
        }
        
    }

    // Sets the move field to 1 or -1 besed on the x-value of the input's Vector 2
    private void OnMove(InputValue input)
    {
        Vector2 moveDirection = input.Get<Vector2>();
        move = moveDirection.x;
        Debug.Log(move);
    }

    private void OnFire()
    {
        Instantiate(projectile, transform.position + Vector3.up, projectile.transform.rotation);
        Debug.Log("Fire");
    }
}
