using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGUILayout : MonoBehaviour {

    public Rect areaA = new Rect(0, 0, 600, 150);
    public Rect areaB = new Rect(600, 200, 200, 200);
    public bool expandWidth = false;
    public float width = 50;
    public float maxWidth = 100;
    public float minWidth = 10;

    void OnGUI() {

        /*
         * GUILayout相比GUI，用法大致相同，
         *但各个控件能够自动排列布局，可以更加高效地使用。
         *虽然不像GUI那样可以精准布局，但仍可以用各种BeginXX();……EndXX();进行大致布局。
         *有种标记语言的感觉。
         */

        GUILayout.BeginArea(areaA);//开始一个区域，区域内的GUILayout会在选项的基础上，随着区域大小、位置的变化，动态变化
        //GUILayout可以配置多个GUILayoutOption[]参数
        GUILayout.Button("设置布局按钮宽度为300，高度为30", GUILayout.Width(300), GUILayout.Height(30));
        GUILayout.FlexibleSpace();//创建自适应间距（使得最上和最下的控件分别置顶置底）
        GUILayout.Button("设置布局按钮最小宽度为100，最小高度为20", GUILayout.MinWidth(100), GUILayout.MinHeight(20));
        GUILayout.Button("设置布局按钮最大宽度为400，最大高度为40", GUILayout.MaxWidth(400), GUILayout.MaxHeight(40));
        GUILayout.FlexibleSpace();//创建自适应间距
        GUILayout.Button("设置宽度不等于最宽按钮", GUILayout.ExpandWidth(false));
        GUILayout.Button("设置宽度等于最宽按钮", GUILayout.ExpandWidth(true));
        GUILayout.EndArea();

        GUILayout.BeginArea(areaB);
        #region 整体水平布局
        GUILayout.BeginHorizontal();//开始水平布局 
        #region 局部垂直布局左
        GUILayout.BeginVertical();//开始垂直布局 
        GUILayout.Label("Label_1", GUILayout.Width(width));
        GUILayout.Button("Button_1", GUILayout.ExpandWidth(expandWidth));
        GUILayout.EndVertical();//结束垂直布局
        #endregion
        #region 局部垂直布局右
        GUILayout.BeginVertical();//开始垂直布局 
        GUILayout.Box("Box_2", GUILayout.Width(width));
        GUILayout.Button("Button_2", GUILayout.MaxWidth(maxWidth), GUILayout.MinWidth(minWidth));
        GUILayout.EndVertical();//结束垂直布局
        #endregion
        GUILayout.EndHorizontal();//结束水平布局
        #endregion
        GUILayout.EndArea();
    }
}
