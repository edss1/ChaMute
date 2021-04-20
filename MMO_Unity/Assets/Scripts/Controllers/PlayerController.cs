using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    Animator anim;

    public enum PlayerState
    {
        Die,
        Idle,
        Move,
    }

    PlayerState _state = PlayerState.Idle;
    [SerializeField]
    float speed = 10.0f;

    Vector3 _destPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
            //nma.CalculatePath

            float moveDist = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
            nma.Move(dir.normalized * moveDist);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 15 * Time.deltaTime);
        }


        //애니메이션 처리
        //현재 게임 상태에 대한 정보를 넘겨준다
        anim.SetFloat("speed", speed);
        
     
    }

  
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {

            _destPos = hit.point;
            _state = PlayerState.Move;

            //Debug.Log($"Raycast Camera @{hit.collider.gameObject.name}");
        }

    }
}
