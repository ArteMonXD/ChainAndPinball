using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetV6 : MonoBehaviour
{
    [SerializeField] private Transform letTransform;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private float speedMove;
    private Transform currentPoint;
    void Start()
    {
        currentPoint = point1;
    }
    void Update()
    {
        CheckAchievementPoint();
        LetMove();
    }
    private void CheckAchievementPoint()
    {
        if(letTransform.position == currentPoint.position)
        {
            if (currentPoint.Equals(point1))
            {
                currentPoint = point2;
            }
            else if (currentPoint.Equals(point2))
            {
                currentPoint = point1;
            }
            else
            {
                Debug.Log("Неудалось проверить соответствие");
            }
        }
    }
    private void LetMove()
    {
        letTransform.position = Vector3.MoveTowards(letTransform.position, currentPoint.position, speedMove * Time.deltaTime);
    }
}
