using System;
using NaughtyAttributes;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "MusicPiece", menuName = "ScriptableObjects/Music Piece", order = 0)]
public class MusicPiece: ScriptableObject
{
#if UNITY_EDITOR
    [OnValueChanged(nameof(EditorGetDuration))]
#endif
    public AudioClip audioClip;
    // public int sampleRate;

    [Serializable]
    public struct RhythmSample
    {
        public int sample;
        public bool isMain;
    }

    public RhythmSample[] rhythmSamples;

    public float totalDuration;

#if UNITY_EDITOR
    [Button("获取时长")]
    private void EditorGetDuration()
    {
        Undo.RecordObject(this, "Audio Duration");
        totalDuration = audioClip.length;
    }
#endif
}
