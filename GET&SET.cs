using System;

class DLMS
{
    int voltage = 230;
    int energy = 1000;
    int clock = 0;

    
    public void Get(string name)
    {
        if (name == "voltage") Console.WriteLine($"[GET] Voltage = {voltage}");
        else if (name == "energy") Console.WriteLine($"[GET] Energy = {energy}");
        else if (name == "clock") Console.WriteLine($"[GET] Clock = {clock}");
        else Console.WriteLine("[GET] Not found");
    }

    
    public void Set(string name, int newValue)
    {
        if (name == "voltage") { voltage = newValue; Console.WriteLine($"[SET] Voltage updated to {voltage}"); }
        else if (name == "energy") { energy = newValue; Console.WriteLine($"[SET] Energy updated to {energy}"); }
        else if (name == "clock") { clock = newValue; Console.WriteLine($"[SET] Clock updated to {clock}"); }
        else Console.WriteLine("[SET] Not found");
    }

    public void Action(string method)
    {
        if (method == "RESET")
        {
            voltage = energy = clock = 0;
            Console.WriteLine("[ACTION] Reset complete");
        }
        else if (method == "SYNC_TIME")
        {
            clock = DateTime.Now.Second;
            Console.WriteLine($"[ACTION] Clock synced to {clock}");
        }
        else Console.WriteLine("[ACTION] Unknown method");
    }
}

class Program
{
    static void Main()
    {
        DLMS d = new DLMS();

        d.Get("voltage");            
        d.Set("voltage", 240);       
        d.Action("RESET");           
        d.Action("SYNC_TIME");       
        d.Get("clock");              

        Console.ReadLine();
    }
}


