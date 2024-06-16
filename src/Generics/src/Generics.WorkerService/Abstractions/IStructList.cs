namespace Generics.WorkerService.Abstractions;

/*
 * interface IClassList<T> where T : class
 * interface INullableClassList<T> where T : class?
 * interface INonNullList<T> where T : notnull
 * interface IFactory<T> where T : new() ==> struct implies new
 * interface IClassFactory<T> where T : class, new() ==> new must always be last
 * interface IUnmanagedService<T> where T : unmanaged ==> implies struct
 */
internal interface IStructList<T> where T : struct
{
}
