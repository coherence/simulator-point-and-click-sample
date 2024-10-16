// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Coherence.Toolkit;
    using Coherence.Toolkit.Bindings;
    using Coherence.Entities;
    using Coherence.ProtocolDef;
    using Coherence.Brook;
    using Coherence.Toolkit.Bindings.ValueBindings;
    using Coherence.Toolkit.Bindings.TransformBindings;
    using Coherence.Connection;
    using Coherence.SimulationFrame;
    using Coherence.Interpolation;
    using Coherence.Log;
    using Logger = Coherence.Log.Logger;
    using UnityEngine.Scripting;
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_66694146d0cbe4600b7e26ae35719cfa_8fefd34f905e48328b6bf136d553392a : PositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(WorldPosition);
        public override string CoherenceComponentName => "WorldPosition";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(coherenceSync.coherencePosition); }
            set { coherenceSync.coherencePosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((WorldPosition)coherenceComponent).value;
            if (!coherenceSync.HasParentWithCoherenceSync) { value += floatingOriginDelta; }

            var simFrame = ((WorldPosition)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (WorldPosition)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new WorldPosition();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_66694146d0cbe4600b7e26ae35719cfa_289da209a36e4a87b3f4feb0900e18c9 : RotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(WorldOrientation);
        public override string CoherenceComponentName => "WorldOrientation";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(coherenceSync.coherenceRotation); }
            set { coherenceSync.coherenceRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((WorldOrientation)coherenceComponent).value;

            var simFrame = ((WorldOrientation)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (WorldOrientation)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new WorldOrientation();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_66694146d0cbe4600b7e26ae35719cfa_958d965c16644dc789fda6b56ec315ad : ScaleBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(GenericScale);
        public override string CoherenceComponentName => "GenericScale";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(coherenceSync.coherenceLocalScale); }
            set { coherenceSync.coherenceLocalScale = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((GenericScale)coherenceComponent).value;

            var simFrame = ((GenericScale)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (GenericScale)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new GenericScale();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_66694146d0cbe4600b7e26ae35719cfa_904e098f83e94b408580bb8551179799 : ColorBinding
    {   
        private global::Character CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::Character)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110);
        public override string CoherenceComponentName => "_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Color Value
        {
            get { return (UnityEngine.Color)(CastedUnityComponent.color); }
            set { CastedUnityComponent.color = (UnityEngine.Color)(value); }
        }

        protected override (UnityEngine.Color value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110)coherenceComponent).color;

            var simFrame = ((_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110)coherenceComponent).colorSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.color = Value;
            }
            else
            {
                update.color = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.colorSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _66694146d0cbe4600b7e26ae35719cfa_7769962969807975110();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_66694146d0cbe4600b7e26ae35719cfa_f1325b51f9cf4475a4141cd62e7eb598 : UIntBinding
    {   
        private global::Character CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::Character)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110);
        public override string CoherenceComponentName => "_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110";
        public override uint FieldMask => 0b00000000000000000000000000000010;

        public override System.UInt32 Value
        {
            get { return (System.UInt32)(CastedUnityComponent.clientId); }
            set { CastedUnityComponent.clientId = (System.UInt32)(value); }
        }

        protected override (System.UInt32 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110)coherenceComponent).clientId;

            var simFrame = ((_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110)coherenceComponent).clientIdSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_66694146d0cbe4600b7e26ae35719cfa_7769962969807975110)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.clientId = Value;
            }
            else
            {
                update.clientId = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.clientIdSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _66694146d0cbe4600b7e26ae35719cfa_7769962969807975110();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_66694146d0cbe4600b7e26ae35719cfa_c5fccec1ea2b4e8ca66b2da8c1397979 : BoolAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_66694146d0cbe4600b7e26ae35719cfa_1624268265457686190);
        public override string CoherenceComponentName => "_66694146d0cbe4600b7e26ae35719cfa_1624268265457686190";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override System.Boolean Value
        {
            get { return (System.Boolean)(CastedUnityComponent.GetBool(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetBool(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Boolean value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_66694146d0cbe4600b7e26ae35719cfa_1624268265457686190)coherenceComponent).IsMoving;

            var simFrame = ((_66694146d0cbe4600b7e26ae35719cfa_1624268265457686190)coherenceComponent).IsMovingSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_66694146d0cbe4600b7e26ae35719cfa_1624268265457686190)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.IsMoving = Value;
            }
            else
            {
                update.IsMoving = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.IsMovingSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _66694146d0cbe4600b7e26ae35719cfa_1624268265457686190();
        }    
    }

    [UnityEngine.Scripting.Preserve]
    public class CoherenceSync_66694146d0cbe4600b7e26ae35719cfa : CoherenceSyncBaked
    {
        private Entity entityId;
        private Logger logger = Coherence.Log.Log.GetLogger<CoherenceSync_66694146d0cbe4600b7e26ae35719cfa>();
        
        
        
        private IClient client;
        private CoherenceBridge bridge;
        
        private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
        {
            ["8fefd34f905e48328b6bf136d553392a"] = new Binding_66694146d0cbe4600b7e26ae35719cfa_8fefd34f905e48328b6bf136d553392a(),
            ["289da209a36e4a87b3f4feb0900e18c9"] = new Binding_66694146d0cbe4600b7e26ae35719cfa_289da209a36e4a87b3f4feb0900e18c9(),
            ["958d965c16644dc789fda6b56ec315ad"] = new Binding_66694146d0cbe4600b7e26ae35719cfa_958d965c16644dc789fda6b56ec315ad(),
            ["904e098f83e94b408580bb8551179799"] = new Binding_66694146d0cbe4600b7e26ae35719cfa_904e098f83e94b408580bb8551179799(),
            ["f1325b51f9cf4475a4141cd62e7eb598"] = new Binding_66694146d0cbe4600b7e26ae35719cfa_f1325b51f9cf4475a4141cd62e7eb598(),
            ["c5fccec1ea2b4e8ca66b2da8c1397979"] = new Binding_66694146d0cbe4600b7e26ae35719cfa_c5fccec1ea2b4e8ca66b2da8c1397979(),
        };
        
        private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings = new Dictionary<string, Action<CommandBinding, CommandsHandler>>();
        
        public CoherenceSync_66694146d0cbe4600b7e26ae35719cfa()
        {
        }
        
        public override Binding BakeValueBinding(Binding valueBinding)
        {
            if (bakedValueBindings.TryGetValue(valueBinding.guid, out var bakedBinding))
            {
                valueBinding.CloneTo(bakedBinding);
                return bakedBinding;
            }
            
            return null;
        }
        
        public override void BakeCommandBinding(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            if (bakedCommandBindings.TryGetValue(commandBinding.guid, out var commandBindingBaker))
            {
                commandBindingBaker.Invoke(commandBinding, commandsHandler);
            }
        }
        
        public override void ReceiveCommand(IEntityCommand command)
        {
            switch (command)
            {
                default:
                    logger.Warning($"CoherenceSync_66694146d0cbe4600b7e26ae35719cfa Unhandled command: {command.GetType()}.");
                    break;
            }
        }
        
        public override List<ICoherenceComponentData> CreateEntity(bool usesLodsAtRuntime, string archetypeName, AbsoluteSimulationFrame simFrame)
        {
            if (!usesLodsAtRuntime)
            {
                return null;
            }
            
            if (Archetypes.IndexForName.TryGetValue(archetypeName, out int archetypeIndex))
            {
                var components = new List<ICoherenceComponentData>()
                {
                    new ArchetypeComponent
                    {
                        index = archetypeIndex,
                        indexSimulationFrame = simFrame,
                        FieldsMask = 0b1
                    }
                };

                return components;
            }
    
            logger.Warning($"Unable to find archetype {archetypeName} in dictionary. Please, bake manually (coherence > Bake)");
            
            return null;
        }
        
        public override void Dispose()
        {
        }
        
        public override void Initialize(Entity entityId, CoherenceBridge bridge, IClient client, CoherenceInput input, Logger logger)
        {
            this.logger = logger.With<CoherenceSync_66694146d0cbe4600b7e26ae35719cfa>();
            this.bridge = bridge;
            this.entityId = entityId;
            this.client = client;        
        }
    }

}