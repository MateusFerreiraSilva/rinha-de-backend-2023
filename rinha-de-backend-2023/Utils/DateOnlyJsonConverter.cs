using System.Text.Json;
using System.Text.Json.Serialization;

namespace rinha_de_backend_2023.Utils;

public  class DateOnlyJsonConverter : JsonConverter<DateOnly>

{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var str = reader.GetString();

            return string.IsNullOrEmpty(str) ? default : DateOnly.FromDateTime(reader.GetDateTime());
        }
        catch (FormatException)
        {
            return default;
        }
        catch (InvalidOperationException)
        {
            return default;
        }
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        var isoDate = value.ToString("O");
        writer.WriteStringValue(isoDate);
    }
}