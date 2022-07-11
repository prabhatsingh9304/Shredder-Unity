using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform firPoint;
    public float mouseInput = 100f;
    private float xInput,yInput;
    public float projectileSpeed =30f;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootTarget();
        }   
    }
    void ShootTarget()
    {
        Debug.DrawRay(firPoint.position,firPoint.forward * 100,Color.red,1f);
        Ray ray = new Ray(firPoint.position,firPoint.forward);
        RaycastHit hitInfo;
        Physics.Raycast(ray,out hitInfo,100);
        var projectileobj = Instantiate(projectile,firPoint.position,Quaternion.identity);
        projectileobj.GetComponent<Rigidbody>().velocity = firPoint.forward.normalized * projectileSpeed;
        //projectileobj.transform.position = hitInfo.point;
        GameObject.Destroy(projectileobj,8);

    }

}
