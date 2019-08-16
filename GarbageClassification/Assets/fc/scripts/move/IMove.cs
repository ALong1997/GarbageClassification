using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMove {
    void Init(GarbageMove gm);
    void Move(GarbageMove gm);

}