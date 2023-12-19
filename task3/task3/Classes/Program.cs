using System.IO.Ports;

namespace task3.Classes
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            ApplicationConfiguration.Initialize();
            SerialPort serialPort = new SerialPort("COM1", 9600);
            //serialPort.Open();
            SettingsForm FormSetting = new SettingsForm();
            Application.Run(FormSetting);
            if (FormSetting.isCorrect == true)
            {
                CheckersForm checkersForm = new CheckersForm();
                checkersForm.ShowDialog();
            }
            //serialPort.Close();
        }
    }
}