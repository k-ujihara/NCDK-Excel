﻿using GraphMolWrap;

namespace RDKit
{
    public static partial class GraphMolWrapTools
    {
        public static void Clear(this RDProps rDProps)
            => rDProps.clear();
        public static void ClearComputedProps(this RDProps rDProps)
            => rDProps.clearComputedProps();

        public static void ClearProp(this RDProps rDProps, string key)
            => rDProps.clearProp(key);

        public static Dict GetDict(this RDProps rDProps)
            => rDProps.getDict();

        public static Str_Vect GetPropNames(this RDProps atom, bool includePrivate = false, bool includeComputed = false)
            => atom.getPropList(includePrivate, includeComputed);

        // GetPropsAsDict

        public static bool HasProp(this RDProps rDProps, string key)
            => rDProps.hasProp(key);

        public static void SetProp(this RDProps rDProps, string key, string val)
            => rDProps.setProp(key, val);
    }
}
