using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS.Docs.Markdown.Tests;

public static class Items
{
	public static readonly Item
		A,
		B,
		C;

	static Items()
	{
		A = new Item("A", null);
		B = A.Child("B");
		C = B.Child("C");
	}
}
public class Item
{
	public readonly Item? Parent;
	public readonly string Name;
	public Item(string name, Item? parent)
	{
		Name = name;
		Parent = parent;
	}
	public Item Child(string name)
	{
		return new(name, this);
	}
}
