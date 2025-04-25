using UnityEngine;

public interface IConnectable
{
    bool IsConnected { get; }
    void Connect();
}
