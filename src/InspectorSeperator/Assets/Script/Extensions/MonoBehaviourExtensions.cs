using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

public static class MonoBehaviourExtensions {

	// Greatly inspired from:
	// http://answers.unity3d.com/questions/666127/how-do-i-generate-a-drop-down-list-of-functions-on.html

	/// <summary>
	/// 
	/// Returns all the methods with the given signature of a component.
	/// 
	/// </summary>
	/// <returns>The methods.</returns>
	/// <param name="mb">Mb.</param>
	/// <param name="returnType">Return type.</param>
	/// <param name="paramTypes">Parameter types.</param>
	/// <param name="flags">Flags.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static List<MethodInfo> GetMethods<T>(this T mb, Type returnType, Type[] paramTypes, BindingFlags flags) where T : UnityEngine.Component
	{
		return mb.GetType().GetMethods(flags)
			.Where(m => m.ReturnType == returnType)
				.Select(m => new { m, Params = m.GetParameters() })
				.Where(x =>
				       {
					return paramTypes == null ? // in case we want no params
						x.Params.Length == 0 :
							x.Params.Length == paramTypes.Length &&
							x.Params.Select(p => p.ParameterType).ToArray().IsEqualTo(paramTypes);
				})
				.Select(x => x.m)
				.ToList();
	}

	/// <summary>
	/// 
	/// Returns all the methods of a component.
	/// 
	/// </summary>
	/// <returns>The all methods.</returns>
	/// <param name="mb">Mb.</param>
	/// <param name="flags">Flags.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static List<MethodInfo> GetAllMethods<T>(this T mb, BindingFlags flags) where T : UnityEngine.Component
	{
		return mb.GetType().GetMethods(flags)
			.Select(m => new { m, Params = m.GetParameters() })
				.Select(x => x.m)
				.ToList();
	}

	/// <summary>
	/// 
	/// Returns all the methods with the given signature in every component of type T in the GameObject.
	/// 
	/// </summary>
	/// <returns>The methods.</returns>
	/// <param name="go">Go.</param>
	/// <param name="returnType">Return type.</param>
	/// <param name="paramTypes">Parameter types.</param>
	/// <param name="flags">Flags.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static List<MethodInfo> GetMethods<T>(this GameObject go, Type returnType, Type[] paramTypes, BindingFlags flags) where T : UnityEngine.Component 
	{
		var mbs = go.GetComponents<T>();
		List<MethodInfo> list = new List<MethodInfo>();
		
		foreach (var mb in mbs) {
			list.AddRange(mb.GetMethods(returnType, paramTypes, flags));
		}
		
		return list;
	}

	/// <summary>
	/// 
	/// Returns all the methods in every component of type T in the GameObject.
	/// 
	/// </summary>
	/// <returns>The all methods.</returns>
	/// <param name="go">Go.</param>
	/// <param name="flags">Flags.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static List<MethodInfo> GetAllMethods<T>(this GameObject go, BindingFlags flags) where T : UnityEngine.Component 
	{
		var mbs = go.GetComponents<T>();
		List<MethodInfo> list = new List<MethodInfo>();
		
		foreach (var mb in mbs) {
			list.AddRange(mb.GetAllMethods(flags));
		}
		
		return list;
	}

	/// <summary>
	/// 
	/// Determines if is equal to the specified list other.
	/// 
	/// </summary>
	/// <returns><c>true</c> if is equal to the specified list other; otherwise, <c>false</c>.</returns>
	/// <param name="list">List.</param>
	/// <param name="other">Other.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static bool IsEqualTo<T>(this IList<T> list, IList<T> other)
	{
		if (list.Count != other.Count) return false;
		for (int i = 0, count = list.Count; i < count; i++) {
			if (!list[i].Equals(other[i])) {
				return false;
			}
		}
		return true;
	}
}
