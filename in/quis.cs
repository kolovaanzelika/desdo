using System.ServiceProcess;

class Program
{
    static void Main(string[] args)
    {
        string serviceName = "MyService";
        ServiceController svc = new ServiceController(serviceName);

        try
        {
            if (svc.Status != ServiceControllerStatus.Stopped)
            {
                svc.Stop();
                svc.WaitForStatus(ServiceControllerStatus.Stopped);
            }

            // Uninstall the service (you would typically call an installer utility here)
            System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { "/u", typeof(Program).Assembly.Location });
            
            Console.WriteLine("Service uninstalled successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
