using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class StartButtonView : View {

  public Signal startButtonClickedSignal = new Signal();

  public void OnClick() {
    startButtonClickedSignal.Dispatch();
  }
}
