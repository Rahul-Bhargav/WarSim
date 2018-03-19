using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanelView : View
{
  public Button optionButton;

  public void ClearOptions()
  {
    foreach (Transform child in transform)
    {
      Destroy(child.gameObject);
    }
  }

  public void SpawnOptions(List<Option> options)
  {
    options.ForEach((option) =>
    {
      Button spawnedButton = GameObject.Instantiate(optionButton, Vector3.zero, Quaternion.identity);
      OptionView optionView = spawnedButton.GetComponent<OptionView>();
      optionView.SetProperties(option.name, option._id);
      RectTransform buttonTransform = spawnedButton.GetComponent<RectTransform>();
      buttonTransform.SetParent(transform);
      buttonTransform.SetPositionAndRotation(transform.position, transform.rotation);
    });
  }
}
