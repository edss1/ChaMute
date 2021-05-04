//Managers 스크립트
/*
 * 작성일자 : 2021-04-30                                 
스크립트 설명 : 각종 Manager를 관리하는 매니저
스크립트 사용법 :
                 
수정일자(1차) : 2021-05-04
수정내용(1차) : ObjectManager 추가
                                  
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성이 보장된다
    static Managers Instance { get { Init(); return s_instance; } } //유일한 매니저를 갖고온다


    //Manager 연결
    //GameManagerEx _game = new GameManagerEx();
    DataManager _data = new DataManager();
    //InputManager _input = new InputManager();
    //PoolManager _pool = new PoolManager();
    //ResourcesManager _resource = new ResourcesManager();
    //SceneManagerEx _scene = new SceneManagerEx();
    //SoundManager _sound = new SoundManager();
    //UIManager _ui = new UIManager();

    //public static GameManagerEx Game { get { return Instance._game; } }
    public static DataManager Data { get { return Instance._data; } }
    //public static InputManager Input { get { return Instance._input; } } //InputManager을 사용할때 Managers.Input를 이용하여 불러온다
    //public static PoolManager Pool { get { return Instance._pool; } }
    //public static ResourcesManager Resource { get { return Instance._resource; } }
    //public static SceneManagerEx Scene { get { return Instance._scene; } }
    //public static SoundManager Sound { get { return Instance._sound; } }
    //public static UIManager UI { get { return Instance._ui; } }

    void Start()
    {
        Init();

    }

    void Update()
    {
        //_input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            //@Managers Object를 찾는다
            GameObject go = GameObject.Find("@Managers");

            //@Managers 라는 Object가 없을경우
            if (go == null)
            {
                //@Managers Object를 생성한다
                go = new GameObject { name = "@Managers" };

                //Managers라는 C# Script를 추가한다
                go.AddComponent<Managers>();
            }

            //@Managers Object를 절대로 파괴되지 않게 설정 (Hierarchy 창에서 생성됨)
            DontDestroyOnLoad(go);

            s_instance = go.GetComponent<Managers>();

            s_instance._data.Init();
            //s_instance._pool.Init();
            //s_instance._sound.Init();
        }
    }

    public static void Clear()
    {
        //Sound.Clear();
        //Input.Clear();
        //Scene.Clear();
        //UI.Clear();
        //Pool.Clear();
    }
}
