// Type: Castle.MicroKernel.Registration.AllTypes
// Assembly: Castle.Windsor, Version=2.5.1.0, Culture=neutral, PublicKeyToken=407dd0808d44fbdc
// Assembly location: C:\Users\BolovoKun\Desktop\Projeto Tcc\Projeto Tcc\bin\Debug\Castle.Windsor.dll

using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Castle.MicroKernel.Registration
{
  /// <summary>
  /// Describes a set of components to register in the kernel.
  /// 
  /// </summary>
  public static class AllTypes
  {
    /// <summary>
    /// Describes all the types based on <c>basedOn</c>.
    /// 
    /// </summary>
    /// <param name="basedOn">The base type.</param>
    /// <returns/>
    [Obsolete("Use AllTypes.FromAssembly...BasedOn(basedOn) instead.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static AllTypesOf Of(Type basedOn)
    {
      return new AllTypesOf(basedOn);
    }

    /// <summary>
    /// Describes all the types based on type T.
    /// 
    /// </summary>
    /// <typeparam name="T">The base type.</typeparam>
    /// <returns/>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Use AllTypes.FromAssembly...BasedOn<T>() instead.")]
    public static AllTypesOf Of<T>()
    {
      return new AllTypesOf(typeof (T));
    }

    /// <summary>
    /// Describes any types that are supplied.
    /// 
    /// </summary>
    /// 
    /// <returns/>
    [Obsolete("Use AllTypes.FromAssembly...Pick() instead.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static AllTypesOf Pick()
    {
      return AllTypes.Of<object>();
    }

    /// <summary>
    /// Prepares to register types from an assembly.
    /// 
    /// </summary>
    /// <param name="assemblyName">The assembly name.</param>
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    public static FromAssemblyDescriptor FromAssemblyNamed(string assemblyName)
    {
      return AllTypes.FromAssembly(ReflectionUtil.GetAssemblyNamed(assemblyName));
    }

    /// <summary>
    /// Prepares to register types from an assembly.
    /// 
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    public static FromAssemblyDescriptor FromAssembly(Assembly assembly)
    {
      if (assembly == (Assembly) null)
        throw new ArgumentNullException("assembly");
      else
        return new FromAssemblyDescriptor(assembly);
    }

    /// <summary>
    /// Prepares to register types from an assembly containing the type.
    /// 
    /// </summary>
    /// <param name="type">The type belonging to the assembly.</param>
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    public static FromAssemblyDescriptor FromAssemblyContaining(Type type)
    {
      if (type == (Type) null)
        throw new ArgumentNullException("type");
      else
        return new FromAssemblyDescriptor(type.Assembly);
    }

    /// <summary>
    /// Prepares to register types from an assembly containing the type.
    /// 
    /// </summary>
    /// <typeparam name="T">The type belonging to the assembly.</typeparam>
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    public static FromAssemblyDescriptor FromAssemblyContaining<T>()
    {
      return AllTypes.FromAssemblyContaining(typeof (T));
    }

    /// <summary>
    /// Prepares to register types from the assembly containing the code invoking this method.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    public static FromAssemblyDescriptor FromThisAssembly()
    {
      return AllTypes.FromAssembly(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Prepares to register types from assemblies found in a given directory that meet additional optional restrictions.
    /// 
    /// </summary>
    /// <param name="filter"/>
    /// <returns/>
    public static FromAssemblyDescriptor FromAssemblyInDirectory(AssemblyFilter filter)
    {
      if (filter == null)
        throw new ArgumentNullException("filter");
      else
        return new FromAssemblyDescriptor(ReflectionUtil.GetAssemblies((IAssemblyProvider) filter));
    }

    /// <summary>
    /// Prepares to register types from a list of types.
    /// 
    /// </summary>
    /// <param name="types">The list of types.</param>
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    public static FromTypesDescriptor From(IEnumerable<Type> types)
    {
      return new FromTypesDescriptor(types);
    }

    /// <summary>
    /// Prepares to register types from a list of types.
    /// 
    /// </summary>
    /// <param name="types">The list of types.</param>
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Obsolete("Use From(types) instead.")]
    public static FromTypesDescriptor Pick(IEnumerable<Type> types)
    {
      return new FromTypesDescriptor(types);
    }

    /// <summary>
    /// Prepares to register types from a list of types.
    /// 
    /// </summary>
    /// <param name="types">The list of types.</param>
    /// <returns>
    /// The corresponding <see cref="T:Castle.MicroKernel.Registration.FromDescriptor"/>
    /// </returns>
    public static FromTypesDescriptor From(params Type[] types)
    {
      return new FromTypesDescriptor((IEnumerable<Type>) types);
    }
  }
}
