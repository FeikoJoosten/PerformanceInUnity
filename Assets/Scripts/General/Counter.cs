using UnityEngine;
using System.Diagnostics;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private bool waitForCloner = false;

    private Stopwatch sp;
    private long total;
    private long num;
    private long last;
    private bool isCloningCompleted;

    private void Awake() {
        if(waitForCloner) {
            Cloner.OnSpawningCompleted += HandleOnClonerCompletedEvent;
        } else {
            HandleOnClonerCompletedEvent();
        }
    }

    private void HandleOnClonerCompletedEvent() {
        if(waitForCloner) Cloner.OnSpawningCompleted -= HandleOnClonerCompletedEvent;

        isCloningCompleted = true;
        sp = new Stopwatch();
        StartCoroutine(Log());
    }

    private void Update() {
        if(!isCloningCompleted) return;
        sp.Start();
    }

    private void LateUpdate() {
        if(!isCloningCompleted) return;
        sp.Stop();
        num++;
        last = sp.ElapsedTicks;
        total += last;
        sp.Reset();
    }

    private IEnumerator Log() {
        WaitForSeconds delay = new WaitForSeconds(1f);
        while(true) {
            yield return delay;
            if(num > 0) UnityEngine.Debug.Log("Last time: " + (float)last / Stopwatch.Frequency * 1000f + "ms. Average time: " + (float)(total / num) / Stopwatch.Frequency * 1000f + "ms.");
        }
    }
}
