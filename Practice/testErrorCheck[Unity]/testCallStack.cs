using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCallStack : MonoBehaviour {
	
    private float _mCount = 0;
    
	void Update () {
        _mCount += 1 * Time.deltaTime;
        if (_mCount >= 30) {
            FunctionA();
        }  
    }

    void FunctionA() {
        _mCount = 0;
        FunctionB();
    }

    void FunctionB() {
        string message = _mCount.ToString();
        FunctionC(message);
    }

    void FunctionC(string message) {
        GUILayout.TextArea("数字是："+message, 200);
    }
}
