using System.Collections;
using UnityEngine;
using FGUIStarter;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private CustomButton targetButton;
    [SerializeField] private Slider slider;
    [SerializeField] private float slideTime = 1f;
    [SerializeField] private AudioSource audioSource;
    
    private Coroutine _coroutine;
    
    private void Awake()
    {
        targetButton.onClick.AddListener(OnButtonClick); 
    }
    
    private void OnDestroy()
    {
        targetButton.onClick.RemoveListener(OnButtonClick);
        StopCoroutine(_coroutine);
    }

    private void OnButtonClick()
    {
        _coroutine = StartCoroutine(FillSlider());
    }

    private IEnumerator FillSlider()
    {
        var startValue = slider.value;
        var elapsed = 0f;

        while (elapsed < slideTime)
        {
            elapsed += Time.deltaTime;
            var time = Mathf.Clamp01(elapsed / slideTime);
            slider.value = Mathf.Lerp(startValue, 1f, time);
            yield return null;
        }
        
        audioSource.Play();
    }
}