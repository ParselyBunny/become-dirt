using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class Video : MonoBehaviour
{
    private VideoPlayer vp;

    private void Awake() {
        vp = GetComponent<VideoPlayer>();
    }
}
