#pragma warning disable SA1402 // File may only contain a single class
using ProtoBuf;

namespace DanM.Core.Contracts;

[ProtoContract]
public class Dto<TValue>
{
	[ProtoMember(1)]
	public TValue Value { get; set; }

	public Dto()
	{
		// NOOP				
	}

	public Dto(TValue value)
	{
		this.Value = value;
	}
}

public class Dto
{
	public static Dto<TValue> FromValue<TValue>(TValue value) => new Dto<TValue>(value);
}
