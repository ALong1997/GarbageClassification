using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制物体移动

public class Move : MonoBehaviour
{
    public bool IsDrop;
    public bool IsRise;

    Vector3 AllDistance;

    // Start is called before the first frame update
    void Start()
    {
        AllDistance = new Vector3(0, 750, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDrop)
        {
            transform.localPosition -= AllDistance * Time.deltaTime / Game.Difficulty[Game.Level];
        }

        if (IsRise)
        {
            transform.localPosition += AllDistance * Time.deltaTime / 0.5f;
        }
    }
}
