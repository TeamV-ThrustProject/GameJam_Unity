using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int Delay;
    int t;
    [SerializeField]
    string[] ObjName;
    [SerializeField]
    GameObject[] ObstacleSpawnPos;
    [SerializeField]
    int Stage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t++;
        if (t % Delay==0)
            switch(Stage)
            {
                case 4:
                    Debug.Log("asdsada");
                    List<int> list = SpawnBearRunObject();
                    Shuffle(list);
                    for(int i=0;i<5;i++)
                    {
                        if (list[i] == 5) continue;
                        else
                            ObjectPoolManager.instance.GetObj(ObjName[list[i]]).transform.position =
                                ObstacleSpawnPos[i+2].transform.position;
                    }
                    break;
            }
    }

    List<int> SpawnBearRunObject()
    {
        List<int> list = new List<int>();

        int Slot = 5;
        int n = 2;
        int r = 0;

        while (Slot != 0)
        {
            Slot -= r;
            r = Random.Range(0, Slot);

            for (int i = 0; i < r; i++)
                list.Add(n);
            n++;
            if (n == 6)
            {
                for (int i = 0; i < Slot; i++)
                {
                    list.Add(n);
                }
                break;
            }
        }
        return list;
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


}
