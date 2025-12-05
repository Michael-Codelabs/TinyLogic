using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using LibConstruct;
using UnityEngine;

namespace Tinylogic
{
  [XmlInclude(typeof(BoardSavaData))]
  public class BoardSavaData : StructureSaveData
  {
    [XmlElement]
    public PlacementBoardHostSaveData Board;
  }
  [XmlInclude(typeof(BoardBatchReaderSavaData))]
  public class BoardBatchReaderSavaData : LogicBatchReaderSaveData
  {
    [XmlElement]
    public PlacementBoardStructureSaveData Board;
  }
}
