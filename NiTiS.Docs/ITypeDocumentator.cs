using System;

namespace NiTiS.Docs;

public interface ITypeDocumentator
{
	bool IsValidType(Type type);
}
public interface ITypeDocumentator<out T> : ITypeDocumentator
	where T : IDocumentationType
{
	T Documentate(object obj);
}
