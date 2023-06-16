using System.Runtime.InteropServices;
using MySqlConnector.Protocol.Payloads;

namespace MySqlConnector.ColumnReaders;

internal sealed class BinarySignedInt64ColumnReader : IColumnReader
{
	internal static BinarySignedInt64ColumnReader Instance { get; } = new BinarySignedInt64ColumnReader();

	public object ReadValue(ReadOnlySpan<byte> data, ColumnDefinitionPayload columnDefinition)
	{
		return MemoryMarshal.Read<long>(data);
	}

	public int ReadInt32(ReadOnlySpan<byte> data, ColumnDefinitionPayload columnDefinition)
	{
		return checked((int) MemoryMarshal.Read<long>(data));
	}
}
