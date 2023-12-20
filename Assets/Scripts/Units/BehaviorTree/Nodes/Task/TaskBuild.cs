using UnityEngine;

using BehaviorTree;
using Photon.Pun;

public class TaskBuild: Node
{
    CharacterManager _manager;
    int _buildPower;

    public TaskBuild(UnitManager manager) : base()
    {
        _manager = (CharacterManager) manager;
        _buildPower = ((CharacterData) manager.Unit.Data).buildPower;
    }

    public override NodeState Evaluate()
    {
        object currentTarget = GetData("currentTarget");
        BuildingManager bm = ((Transform)currentTarget).GetComponent<BuildingManager>();
        bool finishedBuilding = bm.Build(_buildPower);
        if (finishedBuilding)
        {
            _manager.PV.RPC("SetIsConstructor", RpcTarget.All, false);
            _manager.PV.RPC("SetRendererVisibility", RpcTarget.All, true);
            ClearData("currentTarget");
        }

        _state = NodeState.SUCCESS;
        return _state;
    }
}
