using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct CPUDetails
{
    // Поля структуры
    public string Purpose { get; } // Предназначение (например, "Игры", "Работа", "Сервер")
    public int PowerConsumption { get; } // Энергопотребление в ваттах (TDP)
    public string AdditionalFeatures { get; } // Дополнительные характеристики (например, поддержка "Overclocking")

    // Конструктор структуры
    public CPUDetails(string purpose, int powerConsumption, string additionalFeatures)
    {
        Purpose = purpose;
        PowerConsumption = powerConsumption;
        AdditionalFeatures = additionalFeatures;
    }

    // Метод для получения строкового представления структуры
    public string GetDetails()
    {
        return $"Purpose: {Purpose}, Power Consumption: {PowerConsumption}W, Features: {AdditionalFeatures}";
    }
}
