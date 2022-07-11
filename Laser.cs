using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lr;
    private EnemyAI enmAI;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        enmAI =GetComponent<EnemyAI>();
        
    }

    // Update is called once per frame
    public void ShootLaser()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if(hit.collider || hit.transform.name == "Shredder")
            {
                lr.SetPosition(1,new Vector3(0,0,hit.distance));
            }
        }
        else
        {
            lr.SetPosition(1,new Vector3(0,0,enmAI.shootingRange));
        }   
    }
}
