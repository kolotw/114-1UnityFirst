using UnityEngine;
using UnityEngine.AI;

public class NPC_Go : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public Transform target;
    public float dis = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            
            dis = Vector3.Distance(target.position, agent.transform.position);
            if (dis <= 5.2f) 
            {                
                anim.SetBool("goal", true);
                agent.isStopped = true; agent.ResetPath();
            }
            else
            {
                agent.SetDestination(target.position);
                anim.SetBool("goal", false); return;
            }
            
        }
       
    }
}
