using UnityEngine;
using UnityEngine.AI;

public class NPC_Follow : MonoBehaviour
{
    private NavMeshAgent 導航;
    private Animator 動畫器;
    public Transform 目標;
    public float 距離=0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        導航 = GetComponent<NavMeshAgent>();
        動畫器 = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(目標 != null)
        {
            距離 = Vector3.Distance(目標.position, this.transform.position);
            if(距離 > 3.2f)
            {
                動畫器.SetBool("isWalk", true);
                導航.SetDestination(目標.position);
            }
            else
            {
                動畫器.SetBool("isWalk", false);
            }
        }
    }
}
