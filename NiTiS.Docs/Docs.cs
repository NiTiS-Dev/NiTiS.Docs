using NiTiS.IO;
using System.Collections.Generic;

namespace NiTiS.Docs;

public abstract class Docs<T>
	where T : IDocumentationType
{
	protected readonly List<T> documentations;
	protected readonly List<ITypeDocumentator<T>> documentators;
	protected readonly Directory directory;
	public Docs(Directory directory)
	{
		this.directory = directory;
		this.documentators = new(16);
		this.documentations = new(16);
	}
	public virtual void TypeDocumentator<D>()
		where D : ITypeDocumentator<T>, new()
		=> TypeDocumentator(new D());
	public virtual void TypeDocumentator(ITypeDocumentator<T> documentator)
	{
		documentators.Add(documentator);
	}
	public abstract void Document(params object[] objs);
	public abstract void Deploy();
}
