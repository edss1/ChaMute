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
using UnityEngine.AI;

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

    //현재 몬스터 갯수
    [SerializeField]
    int monsterCount = 0;
    int reserveCount = 0;

    //최대 몬스터 갯수
    [SerializeField]
    int keepMonsterCount = 0;

    public void AddMonsterCount(int value) { monsterCount += value; }
    public void SetKeepMonsterCount(int count) { keepMonsterCount = count; }


    private void Awake()
    {
        
    }
    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddMonsterCount;
        Managers.Game.OnSpawnEvent += AddMonsterCount;

        enemySpawnTime = 5.0f;
        spawnRangeScale = 20.0f;

        //원 지정
        spawnRangeScaleVec = new Vector3(spawnRangeScale, spawnRangeScale, spawnRangeScale);
        spawnRange = this.transform.Find("SpawnRange").gameObject;
        spawnRange.transform.localScale = spawnRangeScaleVec;

        
    }

    
    void Update()
    {
        while (reserveCount + monsterCount < keepMonsterCount)
        {
            StartCoroutine("ReserveSpawn");
        }
    }

    IEnumerator ReserveSpawn()
    {
        reserveCount++;

        yield return new WaitForSeconds(Random.Range(0, enemySpawnTime));
        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Unit/Enemy");
        NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();
        nma.radius = 0.2f;
        Vector3 randPos;

        while (true)
        {
            Vector3 randDir = Random.insideUnitSphere * Random.Range(0, spawnRangeScale);
            randDir.y = 0;
            randPos = transform.position + randDir;

            NavMeshPath path = new NavMeshPath();
            if (nma.CalculatePath(randPos, path))
                break;
        }

        obj.transform.position = randPos;
        reserveCount--;
    }
}
