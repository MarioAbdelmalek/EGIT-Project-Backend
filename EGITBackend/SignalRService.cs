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

                    var updatedStorageList = hostedServices.GetUpdatedStorages();
                    if (updatedStorageList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedStorages", Newtonsoft.Json.JsonConvert.SerializeObject(updatedStorageList));
                    }

                    var updatedClusterList = hostedServices.GetUpdatedClusters();
                    if (updatedClusterList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedClusters", Newtonsoft.Json.JsonConvert.SerializeObject(updatedClusterList));
                    }

                    var updatedNodeList = hostedServices.GetUpdatedNodes();
                    if (updatedNodeList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedNodes", Newtonsoft.Json.JsonConvert.SerializeObject(updatedNodeList));
                    }


                    var updatedVMList = hostedServices.GetUpdatedVMs();
                    if (updatedVMList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedVMs", Newtonsoft.Json.JsonConvert.SerializeObject(updatedVMList));
                    }

                    var updatedVPNList = hostedServices.GetUpdatedVPNs();
                    if (updatedVPNList.Count != 0)
                    {
                        await EGITHub.Clients.All.SendAsync("UpdatedVPNs", Newtonsoft.Json.JsonConvert.SerializeObject(updatedVPNList));
                    }

                    var clientList = hostedServices.GetAllClients();
                    await EGITHub.Clients.All.SendAsync("UpdatedClients", Newtonsoft.Json.
                        JsonConvert.SerializeObject(clientList));
                }

                await Task.Delay(new TimeSpan(0, 0, 10));
            }
        }
    }
}
