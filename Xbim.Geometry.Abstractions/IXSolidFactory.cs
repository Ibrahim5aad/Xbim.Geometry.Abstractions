﻿using Xbim.Ifc4.Interfaces;

namespace Xbim.Geometry.Abstractions
{
    public interface IXSolidFactory : IXModelScoped
    {
        IXShape Build(IIfcSolidModel ifcSolid);
        IXShape Build(IIfcFacetedBrep ifcBrep);
        IXShape Build(IIfcFaceBasedSurfaceModel ifcSurfaceModel);
        IXSolid Build(IIfcCsgPrimitive3D ifcCsgPrimitive);
        IXSolid Build(IIfcExtrudedAreaSolid ifcExtrudedAreaSolid);

    }
}
