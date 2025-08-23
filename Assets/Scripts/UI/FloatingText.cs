using MoreMountains.Feedbacks;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private MMF_Player _targetPlayer;

    public static FloatingText Instance { get; private set; }

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddSecondsFloating(string _valueToAdd)
    {
        MMF_FloatingText _floatingTextFeedback = _targetPlayer.GetFeedbackOfType<MMF_FloatingText>();
        _floatingTextFeedback.Value = _valueToAdd;
        _targetPlayer.PlayFeedbacks(this.transform.position);
    }
}
