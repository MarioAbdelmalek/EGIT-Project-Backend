using BLL;
using EGITBackend.HubConfig;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGITBackend
{
    public sealed class SignalRService : BackgroundService
    {
        private IServiceProvider serviceProvider;

        private readonly IHubContext<EGITHub> EGITHub;
        public SignalRService(IServiceProvider serviceProvider, IHubContext<EGITHub> EGITHub)
        {
            this.serviceProvider = serviceProvider;
            this.EGITHub = EGITHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var hostedServices = scope.ServiceProvider.GetRequiredService<IEGITService>();
                    var lunList = hostedServices.GetAllLuns();
                    await EGITHub.Clients.All.SendAsync("UpdatedLuns", Newtonsoft.Json.
                        JsonConvert.SerializeObject(lunList));

                    var storageList = hostedServices.GetAllStorages();
                    await EGITHub.Clients.All.SendAsync("UpdatedStorages", Newtonsoft.Json.
                        JsonConvert.SerializeObject(storageList));

                    var clusterList= hostedServices.GetAllClusters();
                    await EGITHub.Clients.All.SendAsync("UpdatedClusters", Newtonsoft.Json.
                        JsonConvert.SerializeObject(clusterList));

                    var nodeList = hostedServices.GetAllNodes();
                    await EGITHub.Clients.All.SendAsync("UpdatedNodes", Newtonsoft.Json.
                        JsonConvert.SerializeObject(nodeList));

                    var vmList = hostedServices.GetAllVMs();
                    await EGITHub.Clients.All.SendAsync("UpdatedVMs", Newtonsoft.Json.
                        JsonConvert.SerializeObject(vmList));

                    var vpnList = hostedServices.GetAllVpns();
                    await EGITHub.Clients.All.SendAsync("UpdatedVPNs", Newtonsoft.Json.
                        JsonConvert.SerializeObject(vpnList));

                    var clientList = hostedServices.GetAllClients();
                    await EGITHub.Clients.All.SendAsync("UpdatedClients", Newtonsoft.Json.
                        JsonConvert.SerializeObject(clientList));


                }

                await Task.Delay(new TimeSpan(0, 0, 5));
            }
        }
    }
}
