using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody rgBody;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver = false;
    public Camera mainCamera;
    public Camera subCamera;
    public bool doubleJumpUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver) 
        { 
            rgBody.AddForce((Vector3.up.normalized * jumpForce), ForceMode.Impulse);
            isOnGround = false;
            doubleJumpUsed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            rgBody.AddForce((Vector3.up.normalized * jumpForce), ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            mainCamera.enabled = !mainCamera.enabled;
            subCamera.enabled = !subCamera.enabled;
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { isOnGround = true; }

        else if (collision.gameObject.CompareTag("Enemy")) { isGameOver = true; }
        
        
    }

    
}
