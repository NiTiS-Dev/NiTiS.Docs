using NiTiS.IO;
using System;
using System.Collections.Generic;

namespace NiTiS.Docs;

public abstract class Docs<T>
	where T : IDocumentationType
{
	protected readonly List<T> documentations;
	public readonly Dictionary<Type, ITypeDocumentator<T>> TypeDocumentators;
	protected readonly Directory directory;
	public Docs(Directory directory)
	{
		this.directory = directory;
		TypeDocumentators = new(16);
		this.documentations = new(16);
	}
	public virtual void TypeDocumentator<D, TType>()
		where D : ITypeDocumentator<T>, new()
		=> TypeDocumentator(new D(), typeof(TType));
	public virtual void TypeDocumentator(ITypeDocumentator<T> documentator, Type? type)
	{
		TypeDocumentators[type ?? typeof(void)] = documentator;
	}
	public abstract void Document(params object[] objs);
	public abstract void Deploy();
}
