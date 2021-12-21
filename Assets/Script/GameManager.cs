using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ClrCnt;
    public GameObject BigJump;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, Vector3.zero, Quaternion.identity);
        Instantiate(ClrCnt, new Vector3((float)26.3748, (float)1.39, 0f), Quaternion.identity);
        Instantiate(ClrCnt, new Vector3((float)15.29, (float)33, 0f), Quaternion.identity);
        Instantiate(ClrCnt, new Vector3((float)24.47, (float)33, 0f), Quaternion.identity);
        Instantiate(BigJump, new Vector3((float)30, (float)4.84, 0f), Quaternion.identity);
        Instantiate(BigJump, new Vector3((float)-0.42, (float)22.29, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
