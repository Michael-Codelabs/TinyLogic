using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Networking;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using LibConstruct;
using UnityEngine;

namespace Tinylogic
{
  public class BoardBatchReader : LogicBatchReader, IPlacementBoardRelocatable
  {
    public PlacementBoard Board { get; set; }
    public PlacementBoard.BoardCell[] BoardCells { get; set; }

    public void OnStructureRelocated() { }

    private void Awake()
    {
      base.Awake();
      BoardStructureHooks.Awake(this);
    }

    public override CanConstructInfo CanConstruct()
    {
      return BoardStructureHooks.CanConstruct(this);
    }

    public override void OnDeregistered()
    {
      base.OnDeregistered();
      BoardStructureHooks.OnDeregistered(this);
    }

    public override ThingSaveData SerializeSave()
    {
      ThingSaveData saveData = new ThingSaveData();
      InitialiseSaveData(ref saveData);
      return saveData;
    }

    protected override void InitialiseSaveData(ref ThingSaveData savedData)
    {
      base.InitialiseSaveData(ref savedData);
      if (savedData is BoardBatchReaderSavaData data)
        data.Board = BoardStructureHooks.SerializeSave(this);
    }

    public override void DeserializeSave(ThingSaveData savedData)
    {
      base.DeserializeSave(savedData);
      if (savedData is BoardBatchReaderSavaData data)
        BoardStructureHooks.DeserializeSave(this, data.Board);
    }

    public override void SerializeOnJoin(RocketBinaryWriter writer)
    {
      base.SerializeOnJoin(writer);
      BoardStructureHooks.SerializeOnJoin(writer, this);
    }

    public override void DeserializeOnJoin(RocketBinaryReader reader)
    {
      base.DeserializeOnJoin(reader);
      BoardStructureHooks.DeserializeOnJoin(reader, this);
    }

    public override DelayedActionInstance AttackWith(Attack attack, bool doAction = true)
    {
      DynamicThing thing = Prefab.Find("ItemScrewdriver").AsDynamicThing;
      if (attack.SourceItem == thing)
        return BoardRelocateHooks.StructureAttackWith(this, attack, doAction, BoardRelocateHooks.NormalToolRelocateContinue(thing));
      return base.AttackWith(attack, doAction);
    }
  }
}
