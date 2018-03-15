using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using SocketIO;
using strange.extensions.signal.impl;
using UnityEngine;

public class NetworkService : MonoBehaviour
{
  SocketIOComponent socket;

  public Signal<Options> OptionsRecievedSignal = new Signal<Options>();

  void Start()
  {
    socket = this.gameObject.GetComponent<SocketIOComponent>();

    // Listening to Events on the socket
    socket.On("SET_TURN", OnParentsReceived);
  }
  private void OnParentsReceived(SocketIOEvent obj)
  {
    String jsonData = obj.data.ToString();
    Options options = JsonConvert.DeserializeObject<Options>(jsonData);
    OptionsRecievedSignal.Dispatch(options);
  }

  public void GetTypes()
  {
    socket.Emit("INITIAL_TURN");
  }
}
