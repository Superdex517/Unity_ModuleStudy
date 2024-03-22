using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestTargetMarker : MonoBehaviour
{
    [SerializeField]
    private TaskTarget target;
    [SerializeField]
    private MarkerMaterialData[] markerMaterialDatas;

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

    private void UpdateRunningTargetTaskCount(Task task, TaskState currentState, TaskState prevState)
    {
        if (currentState == TaskState.Running)
        {
            renderer.material = markerMaterialDatas.First(x => x.category == task.Category).markerMaterial;
            currentRunningTargetTaskCount++;
        }
        else
            currentRunningTargetTaskCount--;

        gameObject.SetActive(currentRunningTargetTaskCount != 0);
    }
}
