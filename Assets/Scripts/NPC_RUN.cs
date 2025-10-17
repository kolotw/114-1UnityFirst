using UnityEngine;
using UnityEngine.AI;

public class NPC_RUN : MonoBehaviour
{
    private NavMeshAgent 導航;
    private Animator 動畫器;
    public Transform 目標;
    public float 距離=0;
    void Start()
    {
        導航 = GetComponent<NavMeshAgent>();
        動畫器 = GetComponent<Animator>();
    }
    void Update()
    {
        if (目標 != null)
        {
            導航.SetDestination(目標.position);
            距離 = Vector3.Distance(目標.position, this.transform.position);
            if(距離 <= 3.1f)   { 動畫器.SetBool("isWalk",false); }
            else                       { 動畫器.SetBool("isWalk", true); }
        }
    }
}
