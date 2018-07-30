using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    //Actor actor = new Actor();

    void Start()
    {
        //Actor actor = new Actor();
        var actor = new GameObject("Actor").AddComponent<Actor>();

        StartCoroutine(Delay(1.0f, () =>
        {
             Destroy(actor.gameObject);
        }));

        StartCoroutine(Delay(3.0f, () =>
        {
           // actor.Print();
            actor.PrintGameObject();
            //actor.PrintName();
        }));
    }

    private IEnumerator Delay(float duration, Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback();
    }
}
