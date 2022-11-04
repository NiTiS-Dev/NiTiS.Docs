using System;

namespace NiTiS.Docs;

public interface ITypeDocumentator
{
	bool IsValidType(Type type);
}
public interface ITypeDocumentator<T> : ITypeDocumentator
	where T : IDocumentationType
{
	string GetPath(object obj);
	T Documentate(Docs<T> docs, object obj);
}
