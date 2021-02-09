using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private PlayerController playerControllerScript; //создаем переменную для помещения в нее скрипта игрока.
    private int leftBound = -15;

    private void Start()
    {
        //в переменную для скрипта мы помещаем
        //GameObject.Find("Player") - находим в сцене объект с именем Player
        //и у этого объекта берем компонент PlayerController  то есть его скрипт
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        // у скрипта игрока обращаемся к публичной переменной gameOver и если она равно false то движемся
        // если gameOver = true то перестаем двигаться
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
