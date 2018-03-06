using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGUI : MonoBehaviour {

    public Rect area;
    public GUIContent mycontent;
    public GUIStyle mystyle;
    public float startX = 600;
    public float startY = 200;

    private int _count;
    private string _accountText = "TextField";
    private string _passwordText = "PasswordField";
    private string _text = "TextArea";
    private bool _toggle1 = false;
    private bool _toggle2 = false;
    private bool _toggle3 = false;
    private int _toolbar;
    private int _selectionGrid;
    private Vector2 _scrollPosition = Vector2.zero;
    private Rect _scrollArea = new Rect(0, 0, 2200, 2000);



    private  float StartX(float inputX = 0) {
        return startX + inputX;
    }
    private float StartY(float inputY = 0)
    {
        return startY + inputY;
    }

    void OnGUI() {
        GUI.Label(area, mycontent, mystyle);
        GUI.Label(new Rect(StartX(150), StartY(300), 200, 200), GUI.tooltip);
        GUI.Box(new Rect(StartX(25), StartY(), 300, 400), "Box");
        bool isButton = GUI.Button(new Rect(StartX(150), StartY(175), 70, 30), "Button");//按住不持续输入
        bool isReapeatButton = GUI.RepeatButton(new Rect(StartX(150), StartY(225), 70, 30), "RepeatButton");//按住持续输入
        if (isButton || isReapeatButton) {
            _count++;
        }
        GUI.Label(new Rect(StartX(150), StartY(400), 200, 200), "count:"+_count);
        _accountText = GUI.TextField(new Rect(StartX(100), StartY(100), 170, 20), _accountText, 20);//输入框，输入文字，最多10字
        _passwordText = GUI.PasswordField(new Rect(StartX(100), StartY(135), 170, 20), _passwordText, "*"[0]);//密码输入框
        _text = GUI.TextArea(new Rect(StartX(100), StartY(300), 170, 80), _text, 20);//输入空间，输入文字，区别于输入框，能够换行
        _toggle1 = GUI.Toggle(new Rect(StartX(75), StartY(270), 60, 15), _toggle1, "ToggleA");//选项点Y/N
        _toggle2 = GUI.Toggle(new Rect(StartX(150), StartY(270), 60, 15), _toggle2, "ToggleB");
        _toggle3 = GUI.Toggle(new Rect(StartX(225), StartY(270), 60, 15), _toggle3, "ToggleB");
        //工具栏，选项格
        if (_toggle1)
        {
            _toolbar = GUI.Toolbar(new Rect(StartX(25), StartY(-25), 300, 20), _toolbar, new string[] { "ToolA", "ToolB", "ToolC" });
        }
        else {
            _selectionGrid = GUI.SelectionGrid(new Rect(StartX(25), StartY(-45), 300, 40), _selectionGrid, new string[] { "SelectA", "SelectB", "SelectC","SelectD" },3/*单行最大数*/);
        }
        //滑动条，滚动条
        if (_toggle2)
        {
            startX = GUI.HorizontalSlider(new Rect(160, 100, 1000, 80), startX, 80.0f, 1000.0f);
            startY = GUI.VerticalSlider(new Rect(80, 180, 80, 1000), startY, 80.0f, 1000.0f);
        }
        else {
            startX = GUI.HorizontalScrollbar(new Rect(160, 100, 1000, 80), startX, 50.0f/*滚动图标的大小*/, 80.0f, 1000.0f);
            startY = GUI.VerticalScrollbar(new Rect(80, 180, 80, 400), startY, 50.0f, 80.0f, 400.0f);
        }
        //创建滚动视野
        if (_toggle3)
        {
            _scrollPosition = GUI.BeginScrollView(area/*View大小*/, _scrollPosition/*起始位置*/, _scrollArea/*可拖动范围*/);
            /*↓这之间的GUI都会在ScrollView中↓*/
            GUI.Button(new Rect(StartX(0), StartY(0), 50, 50), "0,0");
            GUI.Button(new Rect(StartX(0), StartY(100), 50, 50), "0,100");
            GUI.Button(new Rect(StartX(100), StartY(0), 50, 50), "100,0");
            GUI.Button(new Rect(StartX(100), StartY(100), 50, 50), "100,100");
            /*↑这之间的GUI都会在ScrollView中↑*/
            GUI.EndScrollView();
        }
        //创建窗口
        if (_count >= 100) {
            area = GUI.Window(0/*窗口ID*/, area, winFunc, "Reset");
        }
        if (_count < 0 )
        {
            area = GUI.ModalWindow(1, area, winFunc, "Done");//置顶窗口
        }
    }

    private void winFunc(int winID)
    {
        bool doRest = GUI.Button(new Rect(50, 50, 70, 30), "OK");
        GUI.DragWindow(); //使窗口可以被拖动
        if (doRest && winID == 0)
        {
            _count = -1;
        }
        else if(doRest && winID == 1)
        {
            _count = 0;
        }
    }

}
