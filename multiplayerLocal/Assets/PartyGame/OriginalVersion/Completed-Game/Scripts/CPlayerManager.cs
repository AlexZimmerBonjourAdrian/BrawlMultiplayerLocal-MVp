using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<PlayerController> _PlayerList = new List<PlayerController>();
    private List<GameObject> _ListObject = new List<GameObject>();
    [SerializeField] private GameObject[] _AssetManager;
    private GameObject _obj;
    private Transform _serchTransform;
    

    public static CPlayerManager Inst
    {
        get
        {
            if(_inst == null)
            {
                GameObject obj = new GameObject("CPlayerManager");
                return obj.AddComponent<CPlayerManager>();
            }
            return _inst;
        }
    }
    private static CPlayerManager _inst;

    private void Awake()
    {
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
        
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = _PlayerList.Count - 1; i >= 0; i--)
        {
         if(_PlayerList[i]== null)
            {
                _PlayerList.RemoveAt(i);
            }
        }
        for(int i = _ListObject.Count -1; i >= 0;i--)
        {
            if(_ListObject[i]==null)
            {
                _ListObject.RemoveAt(i);
            }
        }

        
    }

    public void Spawn(Vector3 Pos)
    {
        
        if (_PlayerList.Count <= 2)
        {
           

            if(CGlobalValue.Inst.GetPlayerController() == 0)
            {
                GameObject obj = (GameObject)Instantiate(_AssetManager[0], Pos, Quaternion.identity);
                PlayerController newPlayer = obj.GetComponent<CPlayer_1>();
                newPlayer._PlayerCount = CGlobalValue.Inst.GetPlayerController();
                CGlobalValue.Inst.AsignControll();
                _PlayerList.Add(newPlayer);
                _obj = obj;
            }  
           else if(CGlobalValue.Inst.GetPlayerController() == 1)
            {
                GameObject obj = (GameObject)Instantiate(_AssetManager[1], Pos, Quaternion.identity);
                PlayerController newPlayer = obj.GetComponent<CPlayer_2>();
                newPlayer._PlayerCount = CGlobalValue.Inst.GetPlayerController();
                CGlobalValue.Inst.AsignControll();
                _PlayerList.Add(newPlayer);
                _obj = obj;
            }
            else if (CGlobalValue.Inst.GetPlayerController() == 2)
            {
                GameObject obj = (GameObject)Instantiate(_AssetManager[2], Pos, Quaternion.identity);
                PlayerController newPlayer = obj.GetComponent<CPlayer_3>();
                newPlayer._PlayerCount = CGlobalValue.Inst.GetPlayerController();
                CGlobalValue.Inst.AsignControll();
                _PlayerList.Add(newPlayer);
                _obj = obj;
            }

        }
    }

    
    public virtual void AsignControll()
    {

    }


}
