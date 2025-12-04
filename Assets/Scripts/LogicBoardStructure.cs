using Assets.Scripts.GridSystem;
using Assets.Scripts.Networking;
using Assets.Scripts.Objects;
using LibConstruct;
using RootMotion.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tinylogic
{
  public class LogicBoardStructure : SmallGrid, IPlacementBoardHost
  {
    private BoardRef<LogicBoard> logicBoard;
    public LogicBoard Board => this.logicBoard?.Board;
    public List<BoxCollider> BoardColliders;
    public Transform BoardOrigin;
    public override ThingSaveData SerializeSave()
    {
      ThingSaveData saveData = new ThingSaveData();
      InitialiseSaveData(ref saveData);
      return saveData;
    }

    protected override void InitialiseSaveData(ref ThingSaveData savedData)
    {
      base.InitialiseSaveData(ref savedData);
      if (savedData is BoardSavaData data)
        data.Board = BoardHostHooks.SerializeBoard(this, this.Board);
    }

    public override void DeserializeSave(ThingSaveData savedData)
    {
      base.DeserializeSave(savedData);
      if (savedData is BoardSavaData data)
        BoardHostHooks.DeserializeBoard(this, data.Board, out this.logicBoard, this.BoardOrigin);
    }

    public override void OnFinishedLoad()
    {
      base.OnFinishedLoad();
      BoardHostHooks.OnFinishedLoadBoard(this, ref this.logicBoard, this.BoardOrigin);
    }

    public override void OnRegistered(Cell cell)
    {
      base.OnRegistered(cell);
      BoardHostHooks.OnRegisteredBoard(this, ref this.logicBoard, this.BoardOrigin);
    }

    public override void OnDestroy()
    {
      base.OnDestroy();
      BoardHostHooks.OnDestroyedBoard(this, this.logicBoard);
    }

    public override void SerializeOnJoin(RocketBinaryWriter writer)
    {
      base.SerializeOnJoin(writer);
      BoardHostHooks.SerializeBoardOnJoin(writer, this, this.Board);
    }

    public override void DeserializeOnJoin(RocketBinaryReader reader)
    {
      base.DeserializeOnJoin(reader);
      BoardHostHooks.DeserializeBoardOnJoin(reader, this, out this.logicBoard, this.BoardOrigin);
    }
    public IEnumerable<BoxCollider> CollidersForBoard(PlacementBoard board)
    {
      if (board == this.Board)
        return this.BoardColliders;
      return new List<BoxCollider>();
    }

    public IEnumerable<PlacementBoard> GetPlacementBoards()
    {
      yield return this.Board;
    }

    public void OnBoardStructureDeregistered(PlacementBoard board, IPlacementBoardStructure structure) { }

    public void OnBoardStructureRegistered(PlacementBoard board, IPlacementBoardStructure structure) { }
  }
}
