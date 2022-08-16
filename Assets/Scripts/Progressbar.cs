using UnityEngine;
using UnityEngine.UI;


public class Progressbar : MonoBehaviour
{
   public Player Player;
   public Transform FinishPlatform;
   public Slider Slider;
   public float AcceptableFinishPlayerDistance = 1f;

    private float _startY;
    private float _minimumReachedY;

    private void Start()
    {
        _startY = Player.transform.position.y;
    }

    private void Update()
    {
        _minimumReachedY = Mathf.Min(_minimumReachedY, Player.transform.position.y);
        float FinishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY, FinishY + AcceptableFinishPlayerDistance, _minimumReachedY);
        Slider.value = t;
    }
}
