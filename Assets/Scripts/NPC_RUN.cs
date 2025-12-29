using UnityEngine;
using TMPro;

public class NPC_RUN : MonoBehaviour
{    
    private Animator 動畫器;
    public Transform 目標;
    public float 距離=0;

    public GameObject 血條組件;
    public TextMeshPro 血量文字; 
    public int 血量 = 100;
    int 原始血量;
    public Transform 血條;
    public float 攻擊距離 = 1.2f;
    void Start()
    {
        動畫器 = GetComponent<Animator>();
        原始血量 = 血量;
        血量文字.text = 血量.ToString();
    }
    void Update()
    {
        血條組件.transform.forward = Camera.main.transform.forward;        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            血量--;
            血量文字.text = 血量.ToString();
            float 血量比例 = (float)血量 / (float)原始血量;            
            血條.localScale = new Vector3(血量比例,1,1);
            if (血量 == 0)
            {
                動畫器.SetTrigger("isDead");
                Destroy(this.gameObject, 7f);
            }
            else {
                動畫器.SetTrigger("isHit");
            }
        }
    }
}
