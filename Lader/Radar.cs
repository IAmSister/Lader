

using UnityEngine;
using System.Collections;
using Games.LogicObj;
using System.Collections.Generic;
using GCGame.Table;
using Games.GlobeDefine;

public class Radar : MonoBehaviour
{
    private float m_mapTexWidth = 735;      // ��ͼͼƬ���
    private float m_mapTexHeight = 735;     // ��ͼͼƬ��
  

    private float MapScreenHalfWidth = 68;  // ��ʾ�����ȵ�һ��
    private float MapScreenHalfHeight = 53; // ��ʾ����߶ȵ�һ��

    public float UPDATE_DELAY = 0.5f;       // �����ӳ�

    public GameObject MapClip;//���س���������ͼƬ ���������������е�ͼ��
    public GameObject ObjArrow;       // ���Ǽ�ͷ
    public GameObject FriendPoint;      //Friend Unit Radar Point, Never show up, just for Instance 
    public GameObject NeutralPoint; //Neutral Unit Radar Point, Never show up, just for Instance 
    public GameObject EnemyPoint;   //Enemy Unit Radar Point, Never show up, just for Instance 
    public GameObject OtherPoint;       //Other Unit Radar Point, Never show up, just for Instance 
    public UILabel LabelPos;       // λ����ϢLabel  ����
    public GameObject TexTarget;      // Ѱ·Ŀ��λ����ʾͼƬ
    public UILabel LabelSceneName; // ��ǰ������
    public UILabel LabelChannel;   // ��ǰƵ��
    public UIPanel PanelMapClip;//�������������ɵı�־��
    private Vector3 arrowPos = Vector3.zero;    //��ͷ��λ�� 
    private Vector3 arrowRot = Vector3.zero;   //��ͷ����ת
    private Vector3 mapPos = Vector3.zero;   //��ͼλ��

    /// <summary>
    /// �洢��ͬ���͵ı�־��
    /// </summary>
	private List<UISprite> TexListFriend = new List<UISprite>();
    private List<UISprite> TexListNeutral = new List<UISprite>();
    private List<UISprite> TexListEnemy = new List<UISprite>();
    private List<UISprite> TexListOther = new List<UISprite>();

    private float m_scale = 1.0f;     // ��ǰ��ͼ��ʵ�ʵ��α���
    private bool m_bLoadMap = false;

    void Start()
    {
        //��ͷ����ʾ
        ObjArrow.SetActive(false);
        //������
        m_bLoadMap = false;
        //��ȡ��ǰ���г��� ����

        //��ȡ�������� ����ɫ

        //����� ������ �ؾ��� ��Ҫ����һЩ�������  //������Ϸ������ //����һ������

        //��������ĳ���ͼƬ��� Ĭ��ֵ735

        //������ͼ�߼���� 

        //����  ����ͼƬ���/���й涨�߼���ȣ�����ʵ�ʿ�ߣ�

        //Ϊ�ռ��ر���ͼƬ
        //���� �����ͼ��� //���س���������ͼƬ //����ͼƬ��� ê��

       
        //��Ҽ�ͷ��ʾ
       
        ///                                                                       ��ǰ����ʵ��+1
       
        //���Լ��ص�ͼ
      
        InvokeRepeating("UpdateMap", 0, UPDATE_DELAY);
    }

    void UpdateMap()
    {
        if (!m_bLoadMap)
        {
            return;
        }

        //��obj
        //��ͷλ�� ���������λ��
        //�����Ǽ�ͷλ��

        //3d��ת��2d�෴

        //����ͷ��ת
        //��ͼλ��

        ///����ڸ���λ��

        ///
        ///�������Զ�Ѱ·                  �Զ�Ѱ·������                     �Ƿ��Զ�Ѱ·�б��λ
        ///   //��ȡ�Զ�Ѱ··��  //��Ѱ·���һ����  //Ŀ�ĵ�ui����ʾ 
        //����  //����ʾ
      
            //MainPlayer��ǰ�����ù�λ�ã���鲻��ʾ�������������ų�
          
            //ֻ��ʾ������������
           
          
            //������Ҹ���������ľ���
          
            

        
        //ÿ�����ͽ��  ���


    }


    private void setTexColor(Obj_Character curChar, List<UISprite> texList, int index)
    {
       
    }

    // ��С����뻺���б�
    void AddDotToList(List<UISprite> curList, int curIndex, GameObject instanceObj, Obj curShowObj, Color color)
    {
       
      
    }

    /// <summary>
    /// �߼�λ��ת����ͼλ��
    /// </summary>
    /// <param name="curPos"></param>
    /// <returns></returns>
    Vector3 GetMapPos(Vector3 curPos)
    {
        //ֻ����  �� ��
        return GetMapPos(curPos.x, curPos.z);
    }

    // �߼�λ��ת����ͼλ��  ���λ�ó��Ե�ͼ����
    Vector3 GetMapPos(float xPos, float zPos)
    {
        Vector3 tempPos = Vector3.zero;
        tempPos.x = xPos * m_scale;
        tempPos.y = zPos * m_scale;
        //���ر������x,z
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

    // �����õ�С������
    void DeActiveList(int useCount, List<UISprite> curList, Vector3 centerPos)
    {
        Vector3 finalPos = centerPos;//��ͷ
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