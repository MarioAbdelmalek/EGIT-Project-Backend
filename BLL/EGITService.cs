using AutoMapper;
using BLL.ModelsDto;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class EGITService : IEGITService
    {
        private readonly IMapper mapper;
        IEGITRepository EGITRepository;

        public EGITService (IMapper mapper, IEGITRepository EGITRepository)
        {
            this.mapper = mapper;
            this.EGITRepository = EGITRepository;
        }

        public void AddClient(CreateClientDto newClient)
        {
            ClientDto c = new ClientDto
            {
                ClientName = newClient.ClientName,
                Bandwidth = newClient.Bandwidth,
                ClientSector = newClient.ClientSector,
                CurrentVMs = newClient.CurrentVMs,
                ISPID = newClient.ISPID,
                PublicIps = newClient.PublicIps,
                TotalVMs = newClient.TotalVMs,
                VPNClients = newClient.VPNClients
            };
            EGITRepository.AddClient(mapper.Map<Client>(c));
        }

        public void AddCluster(CreateClusterDto newCluster)
        {
            ClusterDto c = new ClusterDto { ClusterName = newCluster.ClusterName, ClusterType = newCluster.ClusterType };
            EGITRepository.AddCluster(mapper.Map<Cluster>(c));
        }

        public void AddNode(CreateNodeDto newNode)
        {
            NodeDto n = new NodeDto
            { 
                NodeName = newNode.NodeName,
                NodeType = newNode.NodeType,
                TotalCPUCores = newNode.TotalCPUCores,
                RemainingCPUCores = newNode.RemainingCPUCores,
                TotalRAM = newNode.TotalRAM,
                RemainingRAM = newNode.RemainingRAM,
                ClusterID = newNode.ClusterID
            };
            EGITRepository.AddNode(mapper.Map<Node>(n));
        }

        public void DeleteClient(int ClientID)
        {
            EGITRepository.DeleteClient(ClientID);
        }

        public void DeleteCluster(int ClusterID)
        {
            EGITRepository.DeleteCluster(ClusterID);
        }

        public void DeleteNode(int NodeID)
        {
            EGITRepository.DeleteNode(NodeID);
        }

        public List<ClientDto> GetAllClients()
        {
            var returnedClientsList = EGITRepository.GetAllClients();
            return mapper.Map<List<ClientDto>>(returnedClientsList);
        }

        public List<ClusterDto> GetAllClusters()
        {
            var returnedCLustersList = EGITRepository.GetAllClusters();
            return mapper.Map<List<ClusterDto>>(returnedCLustersList);
        }

        public List<NodeDto> GetAllNodes()
        {
            var returnedNodesList = EGITRepository.GetAllNodes();
            return mapper.Map<List<NodeDto>>(returnedNodesList);
        }

        public ClientDto GetClientByID(int ClientID)
        {
            Client returnedClient = EGITRepository.GetClientByID(ClientID);
            return mapper.Map<ClientDto>(returnedClient);
        }

        public ClusterDto GetClusterByID(int ClusterID)
        {
            Cluster returnedCluster = EGITRepository.GetClusterByID(ClusterID);
            return mapper.Map<ClusterDto>(returnedCluster);
        }

        public NodeDto GetNodeByID(int NodeID)
        {
            Node returnedNode = EGITRepository.GetNodeByID(NodeID);
            return mapper.Map<NodeDto>(returnedNode);
        }

        public void UpdateClient(int ClientID, CreateClientDto newClient)
        {
            ClientDto oldClient = GetClientByID(ClientID);
            if (oldClient != null)
            {
                oldClient.TotalVMs = newClient.TotalVMs;
                oldClient.Bandwidth = newClient.Bandwidth;
                oldClient.ClientName = newClient.ClientName;
                oldClient.ClientSector = newClient.ClientSector;
                oldClient.CurrentVMs = newClient.CurrentVMs;
                oldClient.ISPID = newClient.ISPID;
                oldClient.PublicIps = newClient.PublicIps;
                oldClient.VPNClients = newClient.VPNClients;
                EGITRepository.UpdateClient(mapper.Map<Client>(oldClient));
            }
        }

        public void UpdateCluster(int ClusterID, CreateClusterDto newCluster)
        {
            ClusterDto oldCluster = GetClusterByID(ClusterID);
            if (oldCluster != null)
            {
                oldCluster.ClusterName = newCluster.ClusterName;
                oldCluster.ClusterType = newCluster.ClusterType;
                EGITRepository.UpdateCluster(mapper.Map<Cluster>(oldCluster));
            }
        }

        public void UpdateNode(int NodeID, CreateNodeDto newNode)
        {
            NodeDto oldNode = GetNodeByID(NodeID);
            if (oldNode != null)
            {
                oldNode.NodeName = newNode.NodeName;
                oldNode.NodeType = newNode.NodeType;
                oldNode.TotalCPUCores = newNode.TotalCPUCores;
                oldNode.RemainingCPUCores = newNode.RemainingCPUCores;
                oldNode.TotalRAM = newNode.TotalRAM;
                oldNode.RemainingRAM = newNode.RemainingRAM;
                oldNode.ClusterID = newNode.ClusterID;
                EGITRepository.UpdateNode(mapper.Map<Node>(oldNode));
            }
        }

        //Lun functions
        public List<LunDto> GetAllLuns()
        {
            List<Lun> luns= EGITRepository.GetAllLuns();
            return mapper.Map<List<Lun>, List<LunDto>>(luns);
        }
        public void AddLun(LunDto lun)
        {
            EGITRepository.AddLun(mapper.Map<Lun>(lun));
        }
        public LunDto GetLun(int LunID)
        {
            Lun lun = EGITRepository.GetLun(LunID);
            return mapper.Map<LunDto>(lun);
        }
        public void DeleteLun(int LunID)
        {
            EGITRepository.DeleteLun(LunID);
        }
        public void UpdateLun(LunDto lun,int LunID)
        {

            LunDto newlun = GetLun(LunID);

            if (newlun != null)
            {
                newlun.LunName = lun.LunName;
                newlun.LunRSpace = lun.LunRSpace;
                newlun.LunTSpace = lun.LunTSpace;
                newlun.StorageID = lun.StorageID;
            }

          
            EGITRepository.UpdateLun(mapper.Map<Lun>(newlun));
        }
        public int getTSpaceByStockId(int StockID)
        {
            return EGITRepository.getTSpaceByStockId(StockID);
        }

        //Storage functions

        public List<StorageDto> GetAllStorages()
        {
            List<Storage> storages = EGITRepository.GetAllStorages();
            return mapper.Map<List<Storage>, List<StorageDto>>(storages);
        }
        public StorageDto GetStorage(int StorageID)
        {
            Storage storage = EGITRepository.GetStorage(StorageID);
            return mapper.Map<StorageDto>(storage);
        }
        public void AddStorage(StorageDto storage)

        {
            StorageDto newStorage = new StorageDto
            {
                StorageName = storage.StorageName,
                StorageRemainingRAM = storage.StorageRemainingRAM,
                StorageTotalRAM = storage.StorageTotalRAM

            };
            EGITRepository.AddStorage(mapper.Map<Storage>(storage));

        }
        public void DeleteStorage(int StorageID)
        {
            EGITRepository.DeleteStorage(StorageID);

        }
        public void UpdateStorage(StorageDto storage ,int StorageID)
        {
            StorageDto newStorage = GetStorage(StorageID);
            if (newStorage != null)
            {
                newStorage.StorageName = storage.StorageName;
                newStorage.StorageRemainingRAM = storage.StorageRemainingRAM;
                newStorage.StorageTotalRAM = storage.StorageTotalRAM;
            }
            EGITRepository.UpdateStorage(mapper.Map<Storage>(newStorage));
        }

        //VM functions
        public List<VMDto> GetAllVMs()
        {
            List<VM> VMs = EGITRepository.GetAllVMs();
            return mapper.Map<List<VMDto>>(VMs);
        }
        public VMDto GetVM(int VMID)
        {
            VM VM = EGITRepository.GetVM(VMID);
            return mapper.Map<VMDto>(VM);
        }
        public void AddVM(VMDto VM)
        {
            VMDto newVM = new VMDto
            {

                CpuCores = VM.CpuCores,
                Ram = VM.Ram,
                IP = VM.IP,
                Bandwidth = VM.Bandwidth,
                ClientID = VM.ClientID,
                NodeID = VM.NodeID,
                LunID = VM.LunID
            };
            EGITRepository.AddVM(mapper.Map<VM>(newVM));

        }
        public void UpdateVM(VMDto VM, int VMID)
        {
            VMDto newVM = GetVM(VMID);
            if (newVM != null)
            {
                newVM.CpuCores = VM.CpuCores;
                newVM.Ram = VM.Ram;
                newVM.IP = VM.IP;
                newVM.Bandwidth = VM.Bandwidth;
                newVM.ClientID = VM.ClientID;
                newVM.NodeID = VM.NodeID;
                newVM.LunID = VM.LunID;

            }
            EGITRepository.UpdateVM(mapper.Map<VM>(newVM));
        }
        public void DeleteVM(int VMID)
        {
            EGITRepository.DeleteVM(VMID);

        }

        // Vpn Functions
        public List<VpnDto> GetAllVpns()
        {
            List<Vpn> Vpns = EGITRepository.GetAllVpns();
            return mapper.Map<List<VpnDto>>(Vpns);
        }
        public VpnDto GetVpn(int VpnID)
        {
            Vpn vpn = EGITRepository.GetVpn(VpnID);
            return mapper.Map<VpnDto>(vpn);
        }
        public void AddVpn(VpnDto vpn)

        {
            VpnDto newVpn = new VpnDto
            {
                Username = vpn.Username,
                ClientID = vpn.ClientID


            };
            EGITRepository.AddVpn(mapper.Map<Vpn>(newVpn));

        }
        public void DeleteVpn(int VpnID)
        {
            EGITRepository.DeleteVpn(VpnID);

        }
        public void UpdateVpn(VpnDto vpn, int VpnID)
        {
            VpnDto newVpn = GetVpn(VpnID);
            if (newVpn != null)
            {
                newVpn.Username = vpn.Username;
                newVpn.ClientID = vpn.ClientID;
            }
            EGITRepository.UpdateVpn(mapper.Map<Vpn>(newVpn));
        }

    }
}
