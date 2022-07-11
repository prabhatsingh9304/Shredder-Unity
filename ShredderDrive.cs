using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderDrive : MonoBehaviour
{
    public GameObject shreddermodel;
    public WheelCollider wc;
    [SerializeField] private float maxAcceleration = 20f;
    [SerializeField] private float turnSensitivity = 1f;
    [SerializeField] private float maxSteerAngle = 45f;
    [SerializeField] private float range = 100f;

    private float yInput;
    private float xInput;
    private Gyroscope gyroscope;
   private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }
    } 
    private void Update()
    {
        AnimateWheel();
        GetInput();

    }
    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    private void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
      /*  if(Input.GetButtonDown("Fire1"))
        {
            Shoot();         
        } */
      
    }
    private void Move()
    {
        yInput=Mathf.Clamp(yInput,-1,1);
        wc.motorTorque = yInput * maxAcceleration * 500 * Time.deltaTime;

    }
    private void Turn()
    {
        var steer = Mathf.Clamp(xInput,-1,1) * turnSensitivity * maxSteerAngle;
        //wc.steerAngle = steer;
        transform.Rotate(0f,steer,0f,Space.Self);
    }
    private void AnimateWheel()
    {
        wc.GetWorldPose(out var position,out var rotation);
        shreddermodel.transform.position = position;
        shreddermodel.transform.rotation = rotation;
    }
    /*private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(shreddermodel.transform.position,shreddermodel.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
        }
    } */ 
}
