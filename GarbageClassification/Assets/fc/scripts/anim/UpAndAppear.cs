using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UpAndAppear : MonoBehaviour {
    // Use this for initialization
    void Start() {
        transform.DOLocalMoveY(200, 1);
        transform.GetComponent<Image>().DOColor(Color.clear, 1).OnComplete(() => this.gameObject.SetActive(false));
    }
	// Update is called once per frame
	void Update () {
		
	}
}
