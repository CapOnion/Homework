using MoreMountains.Feedbacks;
using UnityEngine;

public class CameraImpulse : MonoBehaviour
{
    [SerializeField] private MMF_Player _targetPlayer;

    public static CameraImpulse Instance { get; private set; }

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void PlayCameraShake()
    {
        _targetPlayer.PlayFeedbacks(this.transform.position);
    }

}
