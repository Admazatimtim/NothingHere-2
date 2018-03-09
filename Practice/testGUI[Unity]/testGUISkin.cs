using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGUISkin : MonoBehaviour {
    /*
     * 运用GUISkin和GUIStyle，对前面的GUI、GUILayout等进行梳理。 
     * 
     */
    public GUISkin myGUISkin;
    public GUIStyle theGUIStyle;

    private Rect windowRect;

    void Start() {
        windowRect = new Rect(0, 0, 300, 500);
    }

    void OnGUI() {
        GUI.skin = myGUISkin;
        // static UnityEngine.Rect Window(Int32 id, UnityEngine.Rect clientRect, WindowFunction func, UnityEngine.GUIContent title, UnityEngine.GUIStyle style)
        // [窗口内容输出目标] = GUI.Window([窗口序号],[窗口空间信息（输入）],[窗口函数],[窗口标题名称]，[GUI样式（默认或已在上面声明)])
        windowRect = GUI.Window(16, windowRect, WindowFunc, "GUI样式测试窗口");
    }

    void WindowFunc(int winID) {
        GUI.DragWindow();//声明窗口允许拖动

        GUILayout.BeginVertical();
        GUILayout.Space(8);
        GUILayout.Label("这个Label用了Button样式", "Button");
        GUILayout.Button("这个Button用了GUISkin中的自定义样式", "testGUIStyle");
        GUILayout.FlexibleSpace();//创建自适应间距（使得最上和最下的控件分别置顶置底）
        GUILayout.Box("这个Button用了自设置样式theGUIStyle", theGUIStyle);
        GUILayout.EndVertical();
    }
}
