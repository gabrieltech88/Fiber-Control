using Renci.SshNet;

namespace FiberControlApi.Data;

public class OltConnection
{
    private SshClient client;
    public string Ip { get; set; }
    public string User { get; set; }
    public string Password { get; set; }

    public OltConnection(string ip, string user, string password)
    {
        Ip = ip;
        User = user;
        Password = password;
    }

    public ShellStream CreateConnection()
    {
        client = new SshClient(Ip, User, Password);
        client.Connect();

        var shell = client.CreateShellStream("shell", 80, 24, 800, 600, 1024);

        if (client.IsConnected)
        {
            Console.WriteLine("Conexão realizada com sucesso");
            return shell;
        }

        throw new Exception("Faha ao conectar a OLT");
    }

    public void Disconnect()
    {
        client.Disconnect();
    }
}