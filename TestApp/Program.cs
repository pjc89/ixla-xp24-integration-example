using System;
using System.Threading;
using System.Threading.Tasks;
using IXLA.Sdk.Xp24;
using IXLA.Sdk.Xp24.Protocol.Commands.Interface.Model;

namespace TestApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // cancellation token to break the loop ad stop the application
            var appCancellation = new CancellationTokenSource();
            var appStopped = appCancellation.Token;

            // handle ctrl+c to be able to close the connection gracefully
            Console.CancelKeyPress += async (sender, eventArgs) =>
            {
                // avoid killing the app
                eventArgs.Cancel = true;
                // stop the application
                appCancellation.Cancel();
            };

            // the machine client is written in such a way that prevents to execute commands in parallel
            // if you want to handle encoding and marking in parallel the simplest implementation would 
            // be to use a second instance (that connects to port 5556) where you send the commands for 
            // the encoder (connect2rfid and transmit2rfid)
            var client = new MachineClient();

            // the client raises interlock notification 
            client.OnInterlockNotification += (c, args) => Console.WriteLine("Interlock status changed");

            try
            {
                Console.WriteLine("Connecting...");
                await client.ConnectAsync(args[0], int.Parse(args[1]), appStopped);
                var machineApi = new MachineApi(client);

                var machineStatusResponse = await machineApi.GetMachineStatus();
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(machineStatusResponse));

                // I put a sample sjf file in the application binary folder. Just be careful 
                // that pens (most likely) will not be set correctly. Replace the passport sfj file 
                // with an sfj file that has pens correctly configured before trying to mark
                const string sfjFilePath = @"passport.sjf";

                // reset to be sure that the machine is in a consistent state at startup 
                await machineApi.ResetAsync();

                // load a new passport
                await machineApi.LoadPassportAsync();

                // load a new document
                await machineApi.LoadDocumentAsync("my_passport", await System.IO.File.ReadAllBytesAsync(sfjFilePath, appStopped));

                var loadedLayoutsResponse = await machineApi.GetLayoutsAsync();
                Console.WriteLine($"Loaded layouts: {string.Join(",", loadedLayoutsResponse.Layouts)}");

                // example for connecting / reading UID of a smart card 
                // await machineApi.Connect2RfId();
                // var transmitResponse = await machineApi.Transmit2RfId(0xff, 0xca, 0x00, 0x00, 0x00);
                // Console.WriteLine($"chip reply: {BitConverter.ToString(transmitResponse.ChipReply)}");

                // update some entities
                await machineApi.UpdateDocumentAsync(new Entity[]
                {
                    // these are entities present in passport.sjf 
                    new UpdateTextEntity("NAME1", "Pablo Julian"),
                    new UpdateTextEntity("SURNAME1", "Cirillo"),
                    new UpdateTextEntity("NATIONALITY1", "Argentina"),
                });

                // If you configured XY AutoPositioning patterns (using the web interface) you can use the "autoposition" 
                // command to select one of the configured patterns and obtain the offset by which entities need to be translated
                // to match the position of a preprinted marker in the passport 

                // var autoPosResponse = await machineApi.PerformAutoPosition("a_pre_configured_pattern");

                // mark layout
                // the offsetX and offsetY parameters can be retrieved using the "autoposition" command. 
                // I left them commented here because i didn't configure auto-position in the machine that I'm using for testing 
                await machineApi.MarkLayoutAsync("my_passport"
                    // ,offsetX: autoPosResponse.XOffset,
                    // offsetY: autoPosResponse.YOffset
                );

                // eject the passport
                await machineApi.EjectAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                try
                {
                    // graceful disconnect sends \r\n before disposing the stream
                    // to avoid hanging connections server side
                    Console.WriteLine("Graceful disconnect...");
                    await client.GracefulDisconnectAsync();
                }
                catch
                {
                }
            }
        }
    }
}