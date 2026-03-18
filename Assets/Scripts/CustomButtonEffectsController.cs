using UnityEngine;
using FGUIStarter;

public class CustomButtonEffectsController : MonoBehaviour
{
    [SerializeField] private CustomButton targetButton;
    [SerializeField] private Animation animationController;
    [SerializeField] private string animationName;
    [SerializeField] private bool playAnimationOnAwake = false;

    private AnimationState _state;
    
    private void Awake()
    {
        targetButton.onClick.AddListener(OnButtonClick); 
        _state = animationController[animationName];
        
        if(!playAnimationOnAwake) return;
        _state.wrapMode = WrapMode.Loop;
        animationController.Play(animationName);
    }
    
    private void OnDestroy()
    {
        targetButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        var animationLoopTime = Mathf.Repeat(_state.time, _state.length);
        _state.wrapMode = WrapMode.Once;
        _state.time = animationLoopTime;
    }
}