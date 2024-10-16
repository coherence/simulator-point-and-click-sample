// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using Coherence.ProtocolDef;
    using Coherence.Serializer;
    using Coherence.SimulationFrame;
    using Coherence.Entities;
    using Coherence.Utils;
    using Coherence.Brook;
    using Coherence.Core;
    using Logger = Coherence.Log.Logger;
    using UnityEngine;
    using Coherence.Toolkit;

    public struct ConnectedEntity : ICoherenceComponentData
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
            [FieldOffset(0)]
            public Entity value;
            [FieldOffset(4)]
            public Vector3 pos;
            [FieldOffset(16)]
            public Quaternion rot;
            [FieldOffset(32)]
            public Vector3 scale;
        }

        public static unsafe ConnectedEntity FromInterop(IntPtr data, Int32 dataSize, InteropAbsoluteSimulationFrame* simFrames, Int32 simFramesCount)
        {
            if (dataSize != 44) {
                throw new Exception($"Given data size is not equal to the struct size. ({dataSize} != 44) " +
                    "for component with ID 6");
            }

            if (simFramesCount != 0) {
                throw new Exception($"Given simFrames size is not equal to the expected length. ({simFramesCount} != 0) " +
                    "for component with ID 6");
            }

            var orig = new ConnectedEntity();

            var comp = (Interop*)data;

            orig.value = comp->value;
            orig.pos = comp->pos;
            orig.rot = comp->rot;
            orig.scale = comp->scale;

            return orig;
        }


        public static uint valueMask => 0b00000000000000000000000000000001;
        public AbsoluteSimulationFrame valueSimulationFrame;
        public Entity value;
        public static uint posMask => 0b00000000000000000000000000000010;
        public AbsoluteSimulationFrame posSimulationFrame;
        public Vector3 pos;
        public static uint rotMask => 0b00000000000000000000000000000100;
        public AbsoluteSimulationFrame rotSimulationFrame;
        public Quaternion rot;
        public static uint scaleMask => 0b00000000000000000000000000001000;
        public AbsoluteSimulationFrame scaleSimulationFrame;
        public Vector3 scale;

        public uint FieldsMask { get; set; }
        public uint StoppedMask { get; set; }
        public uint GetComponentType() => 6;
        public int PriorityLevel() => 100;
        public const int order = -1;
        public uint InitialFieldsMask() => 0b00000000000000000000000000001111;
        public bool HasFields() => true;
        public bool HasRefFields() => true;


        public long[] GetSimulationFrames() {
            return null;
        }

        public int GetFieldCount() => 4;


        
        public HashSet<Entity> GetEntityRefs()
        {
            return new HashSet<Entity>()
            {
                this.value,
            };
        }

        public uint ReplaceReferences(Entity fromEntity, Entity toEntity)
        {
            uint refsMask = 0;

            if (this.value == fromEntity)
            {
                this.value = toEntity;
                refsMask |= 1 << 0;
            }

            FieldsMask |= refsMask;

            return refsMask;
        }
        
        public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper)
        {
            Entity absoluteEntity;
            IEntityMapper.Error err;
            err = mapper.MapToAbsoluteEntity(this.value, false, out absoluteEntity);

            if (err != IEntityMapper.Error.None)
            {
                return err;
            }

            this.value = absoluteEntity;
            return IEntityMapper.Error.None;
        }

        public IEntityMapper.Error MapToRelative(IEntityMapper mapper)
        {
            Entity relativeEntity;
            IEntityMapper.Error err;
            // We assume that the inConnection held changes with unresolved references, so the 'createMapping=true' is
            // there only because there's a chance that the parent creation change will be processed after this one
            // meaning there's no mapping for the parent yet. This wouldn't be necessary if mapping creation would happen
            // in the clientWorld via create/destroy requests while here we would only check whether mapping exists or not.
            var createParentMapping_value = true;
            err = mapper.MapToRelativeEntity(this.value, createParentMapping_value,
             out relativeEntity);

            if (err != IEntityMapper.Error.None)
            {
                return err;
            }

            this.value = relativeEntity;
            return IEntityMapper.Error.None;
        }

        public ICoherenceComponentData Clone() => this;
        public int GetComponentOrder() => order;
        public bool IsSendOrdered() => true;


        public AbsoluteSimulationFrame? GetMinSimulationFrame()
        {
            AbsoluteSimulationFrame? min = null;


            return min;
        }

        public ICoherenceComponentData MergeWith(ICoherenceComponentData data)
        {
            var other = (ConnectedEntity)data;
            var otherMask = other.FieldsMask;

            FieldsMask |= otherMask;
            StoppedMask &= ~(otherMask);

            if ((otherMask & 0x01) != 0)
            {
                this.valueSimulationFrame = other.valueSimulationFrame;
                this.value = other.value;
            }

            otherMask >>= 1;
            if ((otherMask & 0x01) != 0)
            {
                this.posSimulationFrame = other.posSimulationFrame;
                this.pos = other.pos;
            }

            otherMask >>= 1;
            if ((otherMask & 0x01) != 0)
            {
                this.rotSimulationFrame = other.rotSimulationFrame;
                this.rot = other.rot;
            }

            otherMask >>= 1;
            if ((otherMask & 0x01) != 0)
            {
                this.scaleSimulationFrame = other.scaleSimulationFrame;
                this.scale = other.scale;
            }

            otherMask >>= 1;
            StoppedMask |= other.StoppedMask;

            return this;
        }

        public uint DiffWith(ICoherenceComponentData data)
        {
            throw new System.NotSupportedException($"{nameof(DiffWith)} is not supported in Unity");
        }

        public static uint Serialize(ConnectedEntity data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
        {
            if (bitStream.WriteMask(data.StoppedMask != 0))
            {
                bitStream.WriteMaskBits(data.StoppedMask, 4);
            }

            var mask = data.FieldsMask;

            if (bitStream.WriteMask((mask & 0x01) != 0))
            {


                var fieldValue = data.value;



                bitStream.WriteEntity(fieldValue);
            }

            mask >>= 1;
            if (bitStream.WriteMask((mask & 0x01) != 0))
            {


                var fieldValue = (data.pos.ToCoreVector3());



                bitStream.WriteVector3(fieldValue, FloatMeta.NoCompression());
            }

            mask >>= 1;
            if (bitStream.WriteMask((mask & 0x01) != 0))
            {


                var fieldValue = (data.rot.ToCoreQuaternion());



                bitStream.WriteQuaternion(fieldValue, 32);
            }

            mask >>= 1;
            if (bitStream.WriteMask((mask & 0x01) != 0))
            {


                var fieldValue = (data.scale.ToCoreVector3());



                bitStream.WriteVector3(fieldValue, FloatMeta.NoCompression());
            }

            mask >>= 1;

            return mask;
        }

        public static ConnectedEntity Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
        {
            var stoppedMask = (uint)0;
            if (bitStream.ReadMask())
            {
                stoppedMask = bitStream.ReadMaskBits(4);
            }

            var val = new ConnectedEntity();
            if (bitStream.ReadMask())
            {

                val.value = bitStream.ReadEntity();
                val.FieldsMask |= ConnectedEntity.valueMask;
            }
            if (bitStream.ReadMask())
            {

                val.pos = bitStream.ReadVector3(FloatMeta.NoCompression()).ToUnityVector3();
                val.FieldsMask |= ConnectedEntity.posMask;
            }
            if (bitStream.ReadMask())
            {

                val.rot = bitStream.ReadQuaternion(32).ToUnityQuaternion();
                val.FieldsMask |= ConnectedEntity.rotMask;
            }
            if (bitStream.ReadMask())
            {

                val.scale = bitStream.ReadVector3(FloatMeta.NoCompression()).ToUnityVector3();
                val.FieldsMask |= ConnectedEntity.scaleMask;
            }

            val.StoppedMask = stoppedMask;

            return val;
        }


        public override string ToString()
        {
            return $"ConnectedEntity(" +
                $" value: { this.value }" +
                $" pos: { this.pos }" +
                $" rot: { this.rot }" +
                $" scale: { this.scale }" +
                $" Mask: { System.Convert.ToString(FieldsMask, 2).PadLeft(4, '0') }, " +
                $"Stopped: { System.Convert.ToString(StoppedMask, 2).PadLeft(4, '0') })";
        }
    }


}