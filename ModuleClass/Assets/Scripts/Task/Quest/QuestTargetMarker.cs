using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestTargetMarker : MonoBehaviour
{
    [SerializeField]
    private TaskTarget target;

    private Dictionary<Quest, Task> targetTasksByQuest = new Dictionary<Quest, Task>();
    private Transform cameraTransform;
    private Renderer renderer;

    private int currentRunningTargetTaskCount;

    [System.Serializable]
    private struct MarkerMaterialData
    {
        public Category category;
        public Material markerMaterial;
    }
}
