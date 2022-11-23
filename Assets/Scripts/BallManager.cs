using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BallManager : MonoBehaviour
{
    [SerializeField] private MusicManager _musicManager;
    [SerializeField] private Transform _startPoint;  // 球的出生点
    [SerializeField] private Transform _endPoint;  // 球的结束点
    [SerializeField] private GameObject _redBallPrefab;  // 红球 prefab
    [SerializeField] private GameObject _whiteBallPrefab;  // 白球 prefab

    [SerializeField] private float _ballMoveSpeed;  // 球的运行速度

    private void Awake()
    {
        _musicManager.MusicPlaySample.AddListener(OnMusicPlaySample);
    }

    private void OnMusicPlaySample(int sample) => Debug.Log(sample);

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 startCenter = _startPoint.position;
        Gizmos.color = Color.blue * new Color(1, 1, 1, 0.6f);
        Gizmos.DrawSphere(startCenter, 0.1f);
        GUI.color = Color.blue;
        Handles.Label(startCenter, "球的生成点");

        Vector3 endCenter = _endPoint.position;
        Gizmos.color = Color.green * new Color(1, 1, 1, 0.6f);
        Gizmos.DrawSphere(endCenter, 0.1f);
        GUI.color = Color.green;
        Handles.Label(endCenter, "球的结束点");
    }
#endif
}
