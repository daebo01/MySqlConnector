using System.Buffers.Text;
using MySqlConnector.Protocol.Payloads;

namespace MySqlConnector.ColumnReaders;

internal sealed class TextSignedInt32ColumnReader : IColumnReader
{
	internal static TextSignedInt32ColumnReader Instance { get; } = new TextSignedInt32ColumnReader();

	public object ReadValue(ReadOnlySpan<byte> data, ColumnDefinitionPayload columnDefinition)
	{
		return !Utf8Parser.TryParse(data, out int value, out var bytesConsumed) || bytesConsumed != data.Length ? throw new FormatException() : value;
	}

	public int ReadInt32(ReadOnlySpan<byte> data, ColumnDefinitionPayload columnDefinition)
	{
		return !Utf8Parser.TryParse(data, out int value, out var bytesConsumed) || bytesConsumed != data.Length ? throw new FormatException() : value;
	}
}
