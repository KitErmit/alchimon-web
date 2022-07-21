using System;
namespace AlchemonWeb.Services.Loaders
{
    public interface ISaver
    {
        void Save(string jsonSerialized);
    }
}

