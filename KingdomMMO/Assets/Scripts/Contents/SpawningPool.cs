//SpawningPool 스크립트
/*
 * 작성일자 : 2021-05-04                                 
스크립트 설명 : Enemy를 Spawn하는 스크립트
스크립트 사용법 : 
수정일자(1차) :      
수정내용(1차) : 
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    //스폰할 Enemy
    [SerializeField]
    private GameObject spawnEnemy;

    //스폰 시간
    [SerializeField]
    private float enemySpawnTime;

    //스폰할 범위 크기
    [SerializeField]
    private Vector3 spawnRangeScaleVec;
    private float spawnRangeScale;
    
    //스폰할 범위를 나타내는 원
    [SerializeField]
    private GameObject spawnRange;
    

    private List<GameObject> spawnList;


    private void Awake()
    {
        spawnList = new List<GameObject>();
    }
    void Start()
    {
        enemySpawnTime = 5.0f;
        spawnRangeScale = 20.0f;

        //원 지정
        spawnRangeScaleVec = new Vector3(spawnRangeScale, spawnRangeScale, spawnRangeScale);
        spawnRange = this.transform.Find("SpawnRange").gameObject;
        spawnRange.transform.localScale = spawnRangeScaleVec;

        
    }

    
    void Update()
    {
        
    }
}
