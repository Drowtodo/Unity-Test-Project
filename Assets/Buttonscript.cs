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
            //Осуществляется передвижение куба с заданной скоростью.
            Rules.Cube.transform.Translate(-1 * Rules.Speed * Time.deltaTime, 0, 0);
            //Куб уничтожается, как только проходит заданную дистанцию.
            //Устанавливается временнаю метка уничтожения куба.
            if (Rules.Cube.transform.position.x > Rules.StartPoint + Rules.Distance)
            {
                Destroy(Rules.Cube);
                SpawnKey = true;
                i = Time.time;
            }
            

        }
        //Если прошло заданное время после уничтожения последнего куба, то спавнится новый.
        if (i + Rules.Time < Time.time && SpawnKey)
        {
            Rules.Cube = Instantiate(cube);
            SpawnKey = false;
        }
    }

    //По нажатию на кнопку запоминаются правила поведения куба из текстовых полей и спавнится первый куб.
    public void ButtonClick()
    {
        Rules.Cube = Instantiate(cube);
        Rules.Time = float.Parse(time.text);
        Rules.Speed = float.Parse(speed.text);
        Rules.Distance = float.Parse(distance.text);
        Rules.StartPoint = Rules.Cube.transform.position.x;
    }

    //Вложенный класс для сохранения правил поведения куба.
    static class Rules
    {
        public static float Time { get; set; } = 0;

        public static float Speed { get; set; } = 0;

        public static float Distance { get; set; } = 0;

        public static float StartPoint { get; set; } = 0;

        public static GameObject Cube { get; set; } = null;
    }
}

