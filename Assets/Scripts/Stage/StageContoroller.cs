using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageContoroller : MonoBehaviour
{
    [Header("障害物となるオブジェクト"), SerializeField]
    private GameObject[] _obstacles;

    [Header("障害物の基準の位置"), SerializeField]
    private Vector3 _center;

    [Header("障害物のy軸間隔の最小値, 最大値"), SerializeField]
    private Vector2 _randomRangeY;

    [Header("障害物のx,z軸間隔の最小値, 最大値"), SerializeField]
    private Vector2 _randomRangeXz;


    void Start()
    {
        CreateStage();
    }


    /// <summary>
    /// ステージに障害物を生成する
    /// </summary>
    void CreateStage()
    {
        Vector3 pos = _center;
        while (true)
        {
            var addObj = _obstacles[Random.Range(0, _obstacles.Length)];
            if (pos.y - addObj.transform.lossyScale.y <= 0) { break; }

            pos -= new Vector3(0, addObj.transform.lossyScale.y / 2, 0);

            var x = Random.Range(_randomRangeXz.x, _randomRangeXz.y);
            var z = Random.Range(_randomRangeXz.x, _randomRangeXz.y);
            Instantiate(addObj, pos + new Vector3(x, 0, z), Quaternion.identity);

            pos -= new Vector3(0, addObj.transform.lossyScale.y / 2 + Random.Range(_randomRangeY.x, _randomRangeY.y), 0);
        }
    }
}
