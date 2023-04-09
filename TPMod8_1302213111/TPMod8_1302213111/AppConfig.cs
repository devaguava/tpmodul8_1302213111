using System;
using System.Text.Json;

public class AppConfig
{
	public CovidConfig covid_convig;

	public const string filePath = @"covid_config.json";

	public AppConfig()
	{
		try
		{
			ReadConfigFile();
		}
		catch 
		{
			SetDefault();
			WriteNewConfigFile();
		}
	}

	private CovidConfig ReadConfigFile()
	{
		string configJsonData = File.ReadAllText(filePath);
		covid_convig = JsonSerializer.Deserialize<CovidConfig>(configJsonData);
		return covid_convig;
	}

	private void SetDefault()
	{
		string pesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
		string pesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
		covid_convig = new CovidConfig("celcius", 14, pesanDitolak, pesanDiterima);
	}

    private void WriteNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(covid_convig, options);
        File.WriteAllText(filePath, jsonString);
    }
}
