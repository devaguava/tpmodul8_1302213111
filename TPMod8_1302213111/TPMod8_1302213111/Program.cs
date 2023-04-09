// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        AppConfig config = new AppConfig();
        config.covid_convig.UbahSatuan();

        Console.Write($"Berapa suhu badan Anda saat ini? Dalam nilai {config.covid_convig.satuan_suhu} : ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) Anda terakhir memiliki gejala demam? ");
        int hari = int.Parse(Console.ReadLine());

        try
        {
            if(hari < 0)
            {
                throw new Exception("Invalid");
            }
            if(config.covid_convig.satuan_suhu == "celcius")
            {
                if(suhu >= 36.5 && suhu <= 37.5 && hari < config.covid_convig.batas_hari_demam)
                {
                    Console.WriteLine(config.covid_convig.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(config.covid_convig.pesan_ditolak);
                }
            }
            else
            {
                if (suhu >= 97.7 && suhu <= 99.5 && hari < config.covid_convig.batas_hari_demam)
                {
                    Console.WriteLine(config.covid_convig.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(config.covid_convig.pesan_ditolak);
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}