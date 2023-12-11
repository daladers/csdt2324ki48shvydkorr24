using System.IO.Ports;
using System.Text;

SerialPort serialPort = new SerialPort("COM3", 9600);
serialPort.Open();

StringBuilder receivedData = new StringBuilder();

serialPort.DataReceived += (sender, e) => {
    if (sender is SerialPort senderPort)
    {
        receivedData.Append(senderPort.ReadExisting());

        if (receivedData.ToString().Contains('\n'))
        {
            Console.WriteLine($"Received: {receivedData}");
            receivedData.Clear();
        }
    }
};

for (int i = 0; i < 5; i++)
{
    serialPort.Write($"task2 {i}\n");
    await Task.Delay(6000);
}

await Task.Delay(60000);
