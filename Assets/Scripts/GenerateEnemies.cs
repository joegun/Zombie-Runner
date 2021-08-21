using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject Enemy;

    public int XPos;

    public int YPos;

    public int ZPos;

    public int EnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (EnemyCount < 10)
        {
            XPos = Random.Range(1, 50);
            ZPos = Random.Range(1, 50);
            Instantiate(Enemy, new Vector3(XPos, YPos, ZPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            EnemyCount++;
        }
    }
}
