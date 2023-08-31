﻿using System.Text;
using YamlDotNet.Serialization;

namespace Infrastructure.Services;

public class YamlService : IYamlService
{
    public byte[] Write<T>(IList<T> registers)
    {
        var serializer = new SerializerBuilder().Build();

        string yamlString = serializer.Serialize(registers);

        return Encoding.UTF8.GetBytes(yamlString);
    }
}
