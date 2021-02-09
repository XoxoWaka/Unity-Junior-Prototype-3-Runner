using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; //стартовая позиция для бэкграунда
    private float repeatWidth; //для размера холста бэкгранда

    private void Start()
    {
        startPos = transform.position; //стартовая позиция равна фактической стартовой позиции

        // кладем в переменную компонент BoxCollider у которого вызываем поле size по Х и делим его ровно пополам
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
    private void Update()
    {
        //если трансформ по Х мееньше чем стартовая позиция по Х - половнина длинны холста бэкграунда
        if (transform.position.x < startPos.x - repeatWidth) 
        {
            transform.position = startPos; //трансформ равен стартовой позиции то есть переместить в начальные координаты
        }
    }
}
