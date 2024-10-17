// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using Coherence.ProtocolDef;
    using Coherence.Serializer;
    using Coherence.Brook;
    using Coherence.Entities;
    using Coherence.Log;
    using Coherence.Core;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEngine;

    public struct _66694146d0cbe4600b7e26ae35719cfa_1240684a5cbb46ee9451b159a1bc6bdf : IEntityCommand
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
            [FieldOffset(0)]
            public ByteArray name;
        }

        public static unsafe _66694146d0cbe4600b7e26ae35719cfa_1240684a5cbb46ee9451b159a1bc6bdf FromInterop(System.IntPtr data, System.Int32 dataSize) 
        {
            if (dataSize != 16) {
                throw new System.Exception($"Given data size is not equal to the struct size. ({dataSize} != 16) " +
                    "for command with ID 9");
            }

            var orig = new _66694146d0cbe4600b7e26ae35719cfa_1240684a5cbb46ee9451b159a1bc6bdf();
            var comp = (Interop*)data;
            orig.name = comp->name.Data != null ? System.Text.Encoding.UTF8.GetString((byte*)comp->name.Data, (int)comp->name.Length) : null;
            return orig;
        }

        public System.String name;
        
        public Entity Entity { get; set; }
        public MessageTarget Routing { get; set; }
        public uint Sender { get; set; }
        public uint GetComponentType() => 9;
        
        public IEntityMessage Clone()
        {
            // This is a struct, so we can safely return
            // a struct copy.
            return this;
        }
        
        public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToAbsoluteEntity(Entity, false, out var absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = absoluteEntity;
            return IEntityMapper.Error.None;
        }
        
        public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToRelativeEntity(Entity, false, out var relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = relativeEntity;
            return IEntityMapper.Error.None;
        }

        public HashSet<Entity> GetEntityRefs() {
            return default;
        }

        public void NullEntityRefs(Entity entity) {
        }
        
        public _66694146d0cbe4600b7e26ae35719cfa_1240684a5cbb46ee9451b159a1bc6bdf(
        Entity entity,
        System.String name
)
        {
            Entity = entity;
            Routing = MessageTarget.All;
            Sender = 0;
            
            this.name = name; 
        }
        
        public static void Serialize(_66694146d0cbe4600b7e26ae35719cfa_1240684a5cbb46ee9451b159a1bc6bdf commandData, IOutProtocolBitStream bitStream)
        {
            bitStream.WriteShortString(commandData.name);
        }
        
        public static _66694146d0cbe4600b7e26ae35719cfa_1240684a5cbb46ee9451b159a1bc6bdf Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
        {
            var dataname = bitStream.ReadShortString();
    
            return new _66694146d0cbe4600b7e26ae35719cfa_1240684a5cbb46ee9451b159a1bc6bdf()
            {
                Entity = entity,
                Routing = target,
                name = dataname
            };   
        }
    }

}