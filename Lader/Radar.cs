

using UnityEngine;
using System.Collections;
using Games.LogicObj;
using System.Collections.Generic;
using GCGame.Table;
using Games.GlobeDefine;

public class Radar : MonoBehaviour
{
    private float m_mapTexWidth = 735;      // 地图图片宽度
    private float m_mapTexHeight = 735;     // 地图图片高
  

    private float MapScreenHalfWidth = 68;  // 显示区域宽度的一半
    private float MapScreenHalfHeight = 53; // 显示区域高度的一半

    public float UPDATE_DELAY = 0.5f;       // 更新延迟

    public GameObject MapClip;//加载出来的正常图片 在她的下面有所有的图标
    public GameObject ObjArrow;       // 主角箭头
    public GameObject FriendPoint;      //Friend Unit Radar Point, Never show up, just for Instance 
    public GameObject NeutralPoint; //Neutral Unit Radar Point, Never show up, just for Instance 
    public GameObject EnemyPoint;   //Enemy Unit Radar Point, Never show up, just for Instance 
    public GameObject OtherPoint;       //Other Unit Radar Point, Never show up, just for Instance 
    public UILabel LabelPos;       // 位置信息Label  坐标
    public GameObject TexTarget;      // 寻路目标位置提示图片
    public UILabel LabelSceneName; // 当前场景名
    public UILabel LabelChannel;   // 当前频道
    public UIPanel PanelMapClip;//下面是所有生成的标志点
    private Vector3 arrowPos = Vector3.zero;    //箭头的位置 
    private Vector3 arrowRot = Vector3.zero;   //箭头的旋转
    private Vector3 mapPos = Vector3.zero;   //地图位置

    /// <summary>
    /// 存储不同类型的标志点
    /// </summary>
	private List<UISprite> TexListFriend = new List<UISprite>();
    private List<UISprite> TexListNeutral = new List<UISprite>();
    private List<UISprite> TexListEnemy = new List<UISprite>();
    private List<UISprite> TexListOther = new List<UISprite>();

    private float m_scale = 1.0f;     // 当前地图与实际地形比例
    private bool m_bLoadMap = false;

    void Start()
    {
        //箭头不显示
        ObjArrow.SetActive(false);
        //不加载
        m_bLoadMap = false;
        //获取当前运行场景 数据

        //获取场景名字 和颜色

        //如果是 武神塔 藏经阁 需要进行一些特殊操作  //主角游戏中数据 //读出一个名字

        //读表过来的场景图片宽高 默认值735

        //场景地图逻辑宽度 

        //比例  表中图片宽度/表中规定逻辑宽度（场景实际宽高）

        //为空加载表中图片
        //不空 计算地图宽高 //加载出来的正常图片 //设置图片宽高 锚点

       
        //玩家箭头显示
       
        ///                                                                       当前场景实例+1
       
        //可以加载地图
      
        InvokeRepeating("UpdateMap", 0, UPDATE_DELAY);
    }

    void UpdateMap()
    {
        if (!m_bLoadMap)
        {
            return;
        }

        //找obj
        //箭头位置 依赖于玩家位置
        //给主角箭头位置

        //3d旋转跟2d相反

        //给箭头旋转
        //地图位置

        ///相对于父级位置

        ///
        ///如果玩家自动寻路                  自动寻路的数据                     是否自动寻路中标记位
        ///   //获取自动寻路路径  //拿寻路最后一个点  //目的地ui上显示 
        //其他  //不显示
      
            //MainPlayer在前面设置过位置，伙伴不显示，所以这两个排除
          
            //只显示如下三种类型
           
          
            //计算玩家跟交互物体的距离
          
            

        
        //每种类型结合  玩家


    }


    private void setTexColor(Obj_Character curChar, List<UISprite> texList, int index)
    {
       
    }

    // 将小点加入缓存列表
    void AddDotToList(List<UISprite> curList, int curIndex, GameObject instanceObj, Obj curShowObj, Color color)
    {
       
      
    }

    /// <summary>
    /// 逻辑位置转换地图位置
    /// </summary>
    /// <param name="curPos"></param>
    /// <returns></returns>
    Vector3 GetMapPos(Vector3 curPos)
    {
        //只传入  宽 高
        return GetMapPos(curPos.x, curPos.z);
    }

    // 逻辑位置转换地图位置  玩家位置乘以地图比例
    Vector3 GetMapPos(float xPos, float zPos)
    {
        Vector3 tempPos = Vector3.zero;
        tempPos.x = xPos * m_scale;
        tempPos.y = zPos * m_scale;
        //返回比例后的x,z
        return tempPos;
    }

    // Create a Radar Point
    GameObject CreateRadarPoint(GameObject obj, Vector3 targetPos)
    {
        if (null == obj)
            return null;

        GameObject newObj = (GameObject)GameObject.Instantiate(obj);
        if (null == newObj)
            return null;

        newObj.transform.parent = MapClip.transform;
        newObj.transform.localScale = Vector3.one;
        newObj.transform.localPosition = GetMapPos(targetPos);
        newObj.layer = MapClip.layer;
        newObj.SetActive(true);

        return newObj;
    }

    // 将不用的小点隐藏
    void DeActiveList(int useCount, List<UISprite> curList, Vector3 centerPos)
    {
        Vector3 finalPos = centerPos;//箭头
        for (int i = useCount; i < curList.Count; i++)
        {
            if (curList[i].color != GlobeVar.TRANSPARENT_COLOR)
            {
                finalPos.x = centerPos.x - MapScreenHalfWidth / 2 + Random.Range(0, MapScreenHalfWidth);
                finalPos.y = centerPos.y - MapScreenHalfHeight / 2 + Random.Range(0, MapScreenHalfHeight);
                curList[i].color = GlobeVar.TRANSPARENT_COLOR;
                curList[i].transform.localPosition = finalPos;
            }
        }
    }

}