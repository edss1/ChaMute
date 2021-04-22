using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    PlayerStat _stat;
    Animator anim;

    public enum PlayerState
    {
        Die,
        Idle,
        Move,
        Skill,
    }

    PlayerState _state = PlayerState.Idle;


    Vector3 _destPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _stat = gameObject.GetComponent<PlayerStat>();
    }
    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

    }



    void Update()
    {

        switch(_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Move:
                UpdateMove();
                break;
        }
    }


    private void UpdateIdle()
    {
        //애니메이션 처리
        anim.SetFloat("speed", 0);

    }

    private void UpdateDie()
    {

    }
    
    private void UpdateMove()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            _state = PlayerState.Idle;
        }

        else
        {
            //TODO
            NavMeshAgent nma= gameObject.GetOrAddComponent<NavMeshAgent>();

            float moveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude);
            nma.Move(dir.normalized * moveDist);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 15 * Time.deltaTime);

            Debug.DrawRay(transform.position, dir.normalized, Color.green);
            if(Physics.Raycast(transform.position + Vector3.up*0.5f, dir, 1.0f, LayerMask.GetMask("Block")))
            {
                _state = PlayerState.Idle;
                return;
            }

        }


        //애니메이션 처리
        //현재 게임 상태에 대한 정보를 넘겨준다
        anim.SetFloat("speed", _stat.MoveSpeed);
        
     
    }

 
    int _mask = ((1<<(int)Define.Layer.Ground) | (1<<(int)Define.Layer.Monster));

    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, _mask))
        {

            _destPos = hit.point;
            _state = PlayerState.Move;

            if(hit.collider.gameObject.layer==(int)Define.Layer.Monster)
            {
                Debug.Log("Monster Click");

            }
            else
            {
                Debug.Log("Ground Click");
            }
            //Debug.Log($"Raycast Camera @{hit.collider.gameObject.name}");
        }
    }
}
