using System;
using TMPro;
using UnityEngine;


public class Buttonscript : MonoBehaviour
{
    public TMP_InputField time;
    public TMP_InputField speed;
    public TMP_InputField distance;
    public GameObject cube;
    public static GameObject Cube;
    float i=0;
    bool SpawnKey = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FixedUpdate()
    {
        if (Rules.Cube != null)
        {
            //�������������� ������������ ���� � �������� ���������.
            Rules.Cube.transform.Translate(-1 * Rules.Speed * Time.deltaTime, 0, 0);
            //��� ������������, ��� ������ �������� �������� ���������.
            //��������������� ��������� ����� ����������� ����.
            if (Rules.Cube.transform.position.x > Rules.StartPoint + Rules.Distance)
            {
                Destroy(Rules.Cube);
                SpawnKey = true;
                i = Time.time;
            }
            

        }
        //���� ������ �������� ����� ����� ����������� ���������� ����, �� ��������� �����.
        if (i + Rules.Time < Time.time && SpawnKey)
        {
            Rules.Cube = Instantiate(cube);
            SpawnKey = false;
        }
    }

    //�� ������� �� ������ ������������ ������� ��������� ���� �� ��������� ����� � ��������� ������ ���.
    public void ButtonClick()
    {
        Rules.Cube = Instantiate(cube);
        Rules.Time = float.Parse(time.text);
        Rules.Speed = float.Parse(speed.text);
        Rules.Distance = float.Parse(distance.text);
        Rules.StartPoint = Rules.Cube.transform.position.x;
    }

    //��������� ����� ��� ���������� ������ ��������� ����.
    static class Rules
    {
        public static float Time { get; set; } = 0;

        public static float Speed { get; set; } = 0;

        public static float Distance { get; set; } = 0;

        public static float StartPoint { get; set; } = 0;

        public static GameObject Cube { get; set; } = null;
    }
}

