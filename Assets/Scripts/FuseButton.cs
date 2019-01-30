using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FuseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Image ringImage;
    private float startTime;

    public UnityEvent fuseTriggered; 

    void Awake()
    {
        ringImage.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        startTime = Time.time;
        ringImage.enabled = true;
        StartCoroutine(ProcessFuse());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        ringImage.enabled = false;
    }

    IEnumerator ProcessFuse()
    {
        float elapsed;
        while((elapsed = Time.time - startTime) < 2.0f) {
            ringImage.fillAmount = elapsed / 2.0f;
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("Fuse Triggered.");
        fuseTriggered.Invoke();
        ringImage.enabled = false;
    }
}
