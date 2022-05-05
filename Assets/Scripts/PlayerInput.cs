using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Camera c;
    private Rigidbody rbody;
    private Vector3 moveDirection;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float Force;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        c = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        input();
        keepPlayerOnScreen();
        rotate();
    }
    private void FixedUpdate() {
        if (moveDirection == Vector3.zero) return;
        rbody.AddForce(moveDirection * Force,ForceMode.Force);
        rbody.velocity = Vector3.ClampMagnitude(rbody.velocity,maxSpeed);
    }
    private void input(){
        if(Touchscreen.current.primaryTouch.press.isPressed){

            Vector3 v = c.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue());
            
            moveDirection = v - transform.position ;
            moveDirection.z = 0f;
            moveDirection.Normalize();

        }
        else{
            moveDirection = Vector3.zero;
        }
    }
    private void keepPlayerOnScreen(){
        Vector3 x = transform.position;
        Vector3 viewPortPosition = c.WorldToViewportPoint(transform.position);
        if(viewPortPosition.x>1)
            x.x = -x.x + 0.1f;
        if(viewPortPosition.x<0)
            x.x = -x.x - 0.1f;
        if(viewPortPosition.y>1)
            x.y = -x.y + 0.1f;
        if(viewPortPosition.y<0)
            x.y = -x.y - 0.1f;
        transform.position = x;
    }

    private void rotate(){
        if (rbody.velocity == Vector3.zero) return;
        Quaternion LookTarget = Quaternion.LookRotation(rbody.velocity,Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, LookTarget, rotationSpeed*Time.deltaTime);
    }
}
