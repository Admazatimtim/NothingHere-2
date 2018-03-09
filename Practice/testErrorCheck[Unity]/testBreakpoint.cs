using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//用于Int32.TryParse(),但会导致Random.Range冲突，要手动写命名空间

public class testBreakpoint : MonoBehaviour {

    private float _mCount = 0f;
    private bool _isNear = false;
    private int _tryTime = 0;
    private int _setCount = -1;
    private string _outText = "猜对了!";
    private bool _start = false;
    public string mText = "抓数字100";
    public string mCount {
        get {
            return _mCount.ToString();
        }
    }

	void Start () {
        _mCount = UnityEngine.Random.Range(0, 100);
    }
	
	void Update () {
        if (_start) {
            Int32.TryParse(mText, out _setCount);
        }
        _start = false;
        if (_setCount <= 0)
        {
            return;
        }
        _mCount += 1 * Time.deltaTime;
        #region 需要打断点查看
        //do
        //{
        //    _isNear = false;
        //    _isNear = (Mathf.Abs(_mCount - _setCount) <= 1);
        //    ++_tryTime;
        //    if (_tryTime > 100){
        //        _isNear = true;
        //        _outText = "没猜对";
        //    }
        //} while (_isNear);
        //_tryTime = 0;
        //_setCount = -1;
        //mText = _outText;
        //_outText = "猜对了！";
        #endregion
        #region 正常体验
        _isNear = false;
        _isNear = (Mathf.Abs(_mCount - _setCount) <= 1);
        ++_tryTime;
        if (_tryTime > 100)
        {
            _isNear = true;
            _outText = "没猜对";
        }
        if (_isNear) {
            _tryTime = 0;
            _setCount = -1;
            mText = _outText;
            _outText = "猜对了！";
        }
        #endregion
    }

    void OnGUI() {
        GUILayout.BeginVertical();
        GUILayout.TextField(mText);
        _start = GUILayout.Button("开始");
        if (_setCount > 0) {
            GUILayout.Box(mCount);
        }
        GUILayout.EndVertical();
    }
}
