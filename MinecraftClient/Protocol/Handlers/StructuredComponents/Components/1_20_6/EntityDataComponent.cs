using System.Collections.Generic;
using MinecraftClient.Inventory.ItemPalettes;
using MinecraftClient.Protocol.Handlers.StructuredComponents.Core;

namespace MinecraftClient.Protocol.Handlers.StructuredComponents.Components._1_20_6;

public class EntityDataComponent(DataTypes dataTypes, ItemPalette itemPalette, SubComponentRegistry subComponentRegistry) 
    : StructuredComponent(dataTypes, itemPalette, subComponentRegistry)
{
    public Dictionary<string, object>? Nbt { get; set; }
    
    public override void Parse(Queue<byte> data)
    {
        Nbt = dataTypes.ReadNextNbt(data);
    }

    public override Queue<byte> Serialize()
    {
        var data = new List<byte>();
        data.AddRange(DataTypes.GetNbt(Nbt));
        return new Queue<byte>(data);
    }
}

public class BucketEntityDataComponent(DataTypes dataTypes, ItemPalette itemPalette, SubComponentRegistry subComponentRegistry) 
    : EntityDataComponent(dataTypes, itemPalette, subComponentRegistry) {}

public class BlockEntityDataComponent(DataTypes dataTypes, ItemPalette itemPalette, SubComponentRegistry subComponentRegistry) 
    : EntityDataComponent(dataTypes, itemPalette, subComponentRegistry) {}