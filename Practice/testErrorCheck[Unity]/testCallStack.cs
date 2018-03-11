using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCallStack : MonoBehaviour {
	
    private float _mCount = 0;
    private string _message = "";
    
	void Update () {
        _mCount += 1 * Time.deltaTime;
        if (_mCount >= 5) {
            FunctionA();
        }  
    }

    void FunctionA() {
        if (_mCount < 10)
        {
            _message = "";
        }
        else {
            FunctionB();
        }
    }

    void FunctionB() {
        string message = _mCount.ToString();
        FunctionC(message);
    }

    void FunctionC(string message) {
        _message = "数字是：" + message;
        _mCount = 0;
    }

    void OnGUI() {
        GUILayout.TextArea(_message, 200);
    }
}
