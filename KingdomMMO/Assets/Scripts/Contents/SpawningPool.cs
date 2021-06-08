//SpawningPool 스크립트
/*
 * 작성일자 : 2021-05-04                                 
스크립트 설명 : Enemy를 Spawn하는 스크립트
스크립트 사용법 : 

수정일자(1차) : 06-07     
수정내용(1차) : 몬스터 스폰이 안되는곳 추가 (spawnEreaExclusion 변수)
                                  
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

    //몬스터 젠이 안되는 범위 (spawnRangeScale *);
    [SerializeField]
    float spawnEreaExclusion = 0.6f;


    public void AddMonsterCount(int value) { monsterCount += value; }
    public void SetKeepMonsterCount(int count) { keepMonsterCount = count; }

    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddMonsterCount;
        Managers.Game.OnSpawnEvent += AddMonsterCount;

        enemySpawnTime = 5.0f;
        spawnRangeScale = 20.0f;
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

        //0~enemySpawnTime 사이의 시간 사이에 스폰타임을 정해 몬스터 스폰
        yield return new WaitForSeconds(Random.Range(0, enemySpawnTime));

        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Unit/Enemy");
        NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();
        nma.radius = 0.2f;
        Vector3 randPos;

        while (true)
        {
            Vector3 randDir = new Vector3(Random.insideUnitSphere.x * spawnRangeScale, 0, Random.insideUnitSphere.z * spawnRangeScale);

            //스폰 범위 조절
            if (Mathf.Abs(randDir.x) >= spawnRangeScale * spawnEreaExclusion || Mathf.Abs(randDir.z) >= spawnRangeScale * spawnEreaExclusion)
            {
                randPos = transform.position + randDir;
                NavMeshPath path = new NavMeshPath();
                if (nma.CalculatePath(randPos, path))
                    break;
            }
        }

        obj.transform.position = randPos;
        reserveCount--;
    }
}
