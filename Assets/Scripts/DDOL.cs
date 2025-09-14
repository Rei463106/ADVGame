using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ないとどうなるかで確かめる
        if (FindObjectsOfType<DDOL>().Length > 1)
        {
            // 重複しないように、既にある時は自分自身を破棄する
            //シングルトン？
            //クラスのインスタンスの数が1個以上？？
            Destroy(this.gameObject);
        }
        else
        {
            // 自分しかいない時は、自分を DontDestroyOnLoad に登録する
            //SystemをDDOLに実行時入れる
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
