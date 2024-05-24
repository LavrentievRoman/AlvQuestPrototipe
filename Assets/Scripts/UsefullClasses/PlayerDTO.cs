using AlvQuest_Editor;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BaseData
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite Icon { get; set; }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Description, Icon);
    }
}

public abstract class BaseDTO
{
    public BaseData BaseData { get; set; } = new BaseData();
    public override int GetHashCode()
    {
        return BaseData.GetHashCode();
    }
}

public class CharacterDTO : BaseDTO
{
    public int Level { get; set; }
    public int Xp { get; set; }
    public int Gold { get; set; }
    public int CharPoints { get; set; }
    public Dictionary<ECharacteristic, int> Characteristics { get; set; }
    public List<PerkDTO> Perks { get; set; }
    public Dictionary<EBodyPart, EquipmentDTO> Equipment { get; set; }
    public List<SpellDTO> Spells { get; set; }
}

public abstract class BaseEquippableEntityDTO : BaseDTO
{
    public List<BaseEffectDTO> Effects { get; set; } = new List<BaseEffectDTO>();
    public Dictionary<ECharacteristic, int> RequirementsForUse { get; set; } = new Dictionary<ECharacteristic, int>();
}

public class EquipmentDTO : BaseEquippableEntityDTO
{
    public EBodyPart BodyPart { get; set; }
}

public class PerkDTO : BaseEquippableEntityDTO
{
    
}

public class SpellDTO : BaseEquippableEntityDTO
{
    public Dictionary<EManaType, double> ManaCost { get; set; }
}

public abstract class BaseEffectDTO : BaseDTO
{
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class PPM_DTO : BaseEffectDTO
{
    public List<Dictionary<string, string>> Links { get; set; } = new List<Dictionary<string, string>>();
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = base.GetHashCode();
            hashCode ^= AlvQuestStatic.GetHashCode(Links);
            return hashCode;
        }
    }
}

public class TPM_DTO : BaseEffectDTO
{
    public LogicalModule_DTO TriggerLogicalModule_DTO { get; set; }
    public LogicalModule_DTO TickLogicalModule_DTO { get; set; }
    public int Duration { get; set; }
    public int MaxStack { get; set; }
    public List<Dictionary<string, string>> TriggerEvents { get; set; } = new List<Dictionary<string, string>>();
    public List<Dictionary<string, string>> TickEvents { get; set; } = new List<Dictionary<string, string>>();
    public List<Dictionary<string, string>> Links { get; set; } = new List<Dictionary<string, string>>();
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = base.GetHashCode();
            hashCode ^= TriggerLogicalModule_DTO.GetHashCode();
            hashCode ^= TickLogicalModule_DTO.GetHashCode();
            hashCode ^= Duration.GetHashCode();
            hashCode ^= MaxStack.GetHashCode();
            hashCode ^= AlvQuestStatic.GetHashCode(TriggerEvents);
            hashCode ^= AlvQuestStatic.GetHashCode(TickEvents);
            hashCode ^= AlvQuestStatic.GetHashCode(Links);
            return hashCode;
        }
    }

    public abstract class LogicalModule_DTO
    {
        
    }

    public class LM_01_deltaThreshold_DTO : LogicalModule_DTO
    {
        public double Threshold { get; set; }
    }

    public class LM_02_damageThreshold_DTO : LogicalModule_DTO
    {
        public EDamageType DamageType { get; set; }
        public double Threshold { get; set; }
        public LM_02_damageThreshold_DTO() { }
    }
}