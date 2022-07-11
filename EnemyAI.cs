using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    public float shootingRange = 100f;
    [SerializeField] Transform shootingPoint;
    float distanceTotarget = Mathf.Infinity;
    [SerializeField] float projectileSpeed=100f;
    public GameObject projectile;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTotarget = Vector3.Distance(target.position,transform.position);
        if(distanceTotarget<=shootingRange)
        {
            ShootTarget();
        }
        navMeshAgent.SetDestination(target.position);
        
    }
    void ShootTarget()
    {
        
        Debug.DrawRay(shootingPoint.position,shootingPoint.forward * 100,Color.red,1f);
        Ray ray = new Ray(shootingPoint.position,shootingPoint.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo,100))
        {

        }
        
        var projectileobj = Instantiate(projectile,shootingPoint.position,Quaternion.identity);
        projectileobj.GetComponent<Rigidbody>().velocity = (target.position - shootingPoint.position).normalized * projectileSpeed;

    }

}
