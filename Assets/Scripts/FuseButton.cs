using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FuseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private float startTime;

    public UnityEvent fuseTriggered; 

    void Start()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        startTime = Time.time;
        StartCoroutine(ProcessFuse());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        ProgressRing.current.ringImage.enabled = false;
    }

    IEnumerator ProcessFuse()
    {
        Image ringImage = ProgressRing.current.ringImage;
        float elapsed;

        ringImage.enabled = true;

        while((elapsed = Time.time - startTime) < 2.0f) {
            ringImage.fillAmount = elapsed / 2.0f;
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("Fuse Triggered.");
        fuseTriggered.Invoke();
        ringImage.enabled = false;
    }
}
