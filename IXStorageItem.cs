﻿using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Geometry.Abstractions
{
    public interface IXStorageItem
    {
        string Key { get; }
        string Name { get; }
        bool IsTopLevel { get; }
        bool IsSubShape { get; }
        bool IsShape { get; }
        bool IsFree { get; }
        bool IsAssembly { get; }
        bool IsComponent { get; }
        bool IsCompound { get; }
        
        bool IsExternalRef { get; }
        bool IsSimpleShape { get; }
        bool IsReference { get; }
        bool IsNull { get; }
        IXStorageItem AddShape(string name, IXShape shape, bool expand = false);
        IXStorageItem AddComponent(string name, int shapeId, IXShape shape, IIfcObjectPlacement objPlacement, ILogger logger);
        IXStorageItem AddComponent(string name, IXStorageItem component, IIfcObjectPlacement objPlacement, ILogger logger);
        IXStorageItem AddComponent(string name, IXStorageItem component, XbimMatrix3D transform);
        IXStorageItem AddComponent(string name, int shapeId, IXShape shape);
        IXStorageItem AddSubShape(string name, IXShape shape, bool isExistingPart);
        int NbComponents { get; }
        IXVisualMaterial VisualMaterial { get; set; }
        IXShape Shape { get; set; }
        IEnumerable<IXStorageItem> Components { get; }
        IEnumerable<IXStorageItem> SubShapeStorageItems { get; }
        IEnumerable<IXShape> SubShapes { get; }
        IXStorageItem ReferredShape { get; }
        IXStorageItem AddAssembly(string subAssemblyName);
        IXStorageItem AddAssembly(string subAssemblyName, IIfcObjectPlacement placement);
        IXStorageItem AddAssembly(string subAssemblyName, XbimMatrix3D transform);
        bool IsStored { get; }
        double? Volume { get; set; }
        double? Area { get; set; }
        double? HeightMin { get; set; }
        double? HeightMax { get; set; }
       
        double? ThicknessMax { get; set; }
        void SetPlacement(IIfcObjectPlacement objectPlacement);
        /// <summary>
        /// The Ifc Entity label
        /// </summary>
        int IfcId { get; set; }
        /// <summary>
        /// The Ifc Type Id 
        /// </summary>
        short IfcTypeId { get; set; }
        /// <summary>
        /// The Name property of an IfcRoot object
        /// </summary>
        string IfcName { get; set; }
        string Classification { get; set; }
        bool HasOpenings { get; set; }
        bool HasProjections { get; set; }
        bool IsProduct { get; set; }
        bool IsShapeRepresentation { get; set; }
        bool IsShapeRepresentationMap { get; set; }
        bool IsGeometricRepresentationItem { get; set; }
        string IfcType { get; set; }
        int NbMaterialLayers { get; set; }
        void SetStringAttribute(string name, string value);
        string GetStringAttribute(string name);
        void SetIntAttribute(string name, int value);
        int GetIntAttribute(string name);
        void SetDoubleAttribute(string name, double? value);
        double? GetDoubleAttribute(string name);
        /// <summary>
        /// If this storage item is a material, returns all shapes assigned to this material
        /// </summary>
        IEnumerable<IXStorageItem> ShapesAssignedToMaterial { get; }
        void AddReference(IXStorageItem referred, XbimMatrix3D? transform);

    }
}