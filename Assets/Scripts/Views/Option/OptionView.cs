using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class OptionView : View {

  public string id {get; set;}

  public Text textUI;

  public Signal<string> OptionClickedSignal = new Signal<string>();

  protected override void Start()
  {
    base.Start();
    Button buttonComponent = this.gameObject.GetComponent<Button>();
    buttonComponent.onClick.AddListener(OnOptionClick);
  }

  public void OnOptionClick() {
    OptionClickedSignal.Dispatch(id);
  }

  public void SetProperties (string text, string id) {
    this.textUI.text = text;
    this.id = id;
  }
}
