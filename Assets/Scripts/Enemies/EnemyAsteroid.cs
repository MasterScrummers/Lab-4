using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroid : MonoBehaviour
{
    [SerializeField] float timeMin;
    [SerializeField] float timeMax;
    Vector2 direction;
    Tween asteroidTween;

    float xBorder = 10;
    float yBorder = 6;

    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        direction = randomizeDirection();
        asteroidTween = new Tween(transform, transform.position, direction, 0, Random.Range(timeMin, timeMax));
    }

    // Update is called once per frame
    void Update()
    {
        if (asteroidTween != null) 
        {
            if (Vector3.Distance(asteroidTween.Target.position, asteroidTween.EndPos) > 0.01f) {
                float timeFraction = (Time.time - asteroidTween.StartTime) / asteroidTween.Duration;
                asteroidTween.Target.position = Vector3.Lerp(asteroidTween.StartPos, asteroidTween.EndPos, timeFraction*timeFraction);
                transform.localScale = new Vector2(timeFraction * timeFraction, timeFraction * timeFraction);
            } else {
                asteroidTween.Target.position = asteroidTween.EndPos;
                asteroidTween = null;
                Destroy(gameObject);
            }
        }
    }

    Vector2 randomizeDirection()
    {
        float x = Random.Range(0, 2) == 0 ? xBorder : -xBorder;
        float y = Random.Range(-yBorder, yBorder);
        
        return new Vector2 (x, y);
    }
}
