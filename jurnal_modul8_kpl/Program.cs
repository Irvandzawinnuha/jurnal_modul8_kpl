using System;
using System.IO;
using System.Text.Json;


class BankTransferConfig
{
    public string Lang { get; set; }
    public TransferConfig Transfer { get; set; }
    public string[] Methods { get; set; }
    public ConfirmationConfig Confirmation { get; set; }
}

class TransferConfig
{
    public int Threshold { get; set; }
    public int LowFee { get; set; }
    public int HighFee { get; set; }
}

class ConfirmationConfig
{
    public string En { get; set; }
    public string Id { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
       
        string configPath = "bank_transfer_config.json";
        string configJson = File.ReadAllText(configPath);
        BankTransferConfig config = JsonSerializer.Deserialize<BankTransferConfig>(configJson);

        
        string lang = config.Lang;
        int threshold = config.Transfer.Threshold;
        int lowFee = config.Transfer.LowFee;
        int highFee = config.Transfer.HighFee;
        string[] methods = config.Methods;
        string enConfirmation = config.Confirmation.En;
        string idConfirmation = config.Confirmation.Id;

        
        Console.WriteLine(lang == "en" ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:");

       
        double transferAmount = double.Parse(Console.ReadLine());

        
        double transferFee;
        if (transferAmount <= threshold)
        {
            transferFee = lowFee;
        }
        else
        {
            transferFee = highFee;
        }
        double totalAmount = transferAmount + transferFee;

       
        Console.WriteLine(lang == "en" ? "Transfer fee = {0}" : "Biaya transfer = {0}", transferFee);
        Console.WriteLine(lang == "en" ? "Total amount = {0}" : "Total biaya = {0}", totalAmount);

        Console.WriteLine(lang == "en" ? "Select transfer method:" : "Pilih metode transfer:");
        for (int i = 0; i < methods.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, methods[i]);
        }

        
        int selectedMethod = int.Parse(Console.ReadLine());

        
        Console.WriteLine(lang == "en" ? "Please type \"{0}\" to confirm the transaction:" : "Ketik \"{0}\" untuk mengkonfirmasi transaksi:", enConfirmation);
        Console.WriteLine(lang == "en" ? "Please type \"{0}\" to confirm the transaction:" : "Ketik \"{0}\" untuk mengkonfirmasi transaksi:", idConfirmation);

        
        string confirmation = Console.ReadLine();

        
        if (confirmation.ToLower() == enConfirmation.ToLower() || confirmation.ToLower() == idConfirmation.ToLower())
        {
            Console.WriteLine(lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
        }
        else
        {
            Console.WriteLine(lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
        }
    }
}