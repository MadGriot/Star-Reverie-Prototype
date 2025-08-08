using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform actionButtonPrefab;
    [SerializeField] private Transform actionButtonContainerTransform;
    // Start is called before the first frame update
    void Start()
    {
        ActorActionSystem.Instance.OnSelectedActorChanged += ActorActionSystem_OnSelectedActorChanged;
        CreateActorActionButtons();
    }

    private void ActorActionSystem_OnSelectedActorChanged(object sender, System.EventArgs e)
    {
        CreateActorActionButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateActorActionButtons()
    {
        foreach (Transform buttonTransform in actionButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }
        Actor selectedActor = ActorActionSystem.Instance.GetSelectedActor();
        
        foreach (BaseAction baseAction in selectedActor.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainerTransform);
            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButtonUI.SetBaseAction(baseAction);
        }
    }
}
