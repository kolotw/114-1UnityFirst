using UnityEngine;

public class FindNPC : MonoBehaviour
{
    public float 最長距離 = 5f;
    float 最短距離 = 10f;
    GameObject 目標敵人 = null;
    GameObject[] 所有敵人;
    public GameObject 玩家;
    public Vector3 原始瞄準點 = new Vector3(0, 1.625f, 1.825f);
    // Update is called once per frame
    void Update()
    {
        if (玩家 == null) 玩家 = GameObject.FindGameObjectWithTag("Player");

        所有敵人 = GameObject.FindGameObjectsWithTag("Enemy");
        if(所有敵人.Length == 0)
        {
            目標敵人 = null;
            return;
        }
        目標敵人 = null;
        最短距離 = 10f;
        foreach (GameObject 敵人 in 所有敵人)
        {
            float 距離 = Vector3.Distance(玩家.transform.position, 敵人.transform.position);
            if(距離 < 最短距離)
            {
                最短距離 = 距離;
                目標敵人 = 敵人;
            }
        }
        Vector3 瞄準位置 = 目標敵人.transform.position;
        瞄準位置.y = 1.45f;
        this.transform.position = 瞄準位置;

        if (最短距離 > 最長距離)
        {
            目標敵人 = null;
            this.transform.localPosition = 原始瞄準點;
        }
    }
}
