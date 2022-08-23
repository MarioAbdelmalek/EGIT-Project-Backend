using BLL.ModelsDto;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IEGITService
    {
        // Lun functions
        public List<LunDto> GetAllLuns();
        public void AddLun(LunDto lun);
        public LunDto GetLun(int id);
        public void DeleteLun(int id);
        public void UpdateLun(LunDto lun, int LunID);
        public int getTSpaceByStockId(int id);

        // Storage functions
        public List<StorageDto> GetAllStorages();
        public StorageDto GetStorage(int id);
        public void AddStorage(StorageDto storage);
        public void DeleteStorage(int id);
        public void UpdateStorage(StorageDto storage, int StorageID);
        public void CalculateRAM(StorageDto storage);


        //VM functions
        public List<VMDto> GetAllVMs();
        public VMDto GetVM(int VMID);
        public void AddVM(VMDto VM);
        public void UpdateVM(VMDto VM, int VMID);
        public void DeleteVM(int VMID);
        //vpn functions
        public List<VpnDto> GetAllVpns();
        public VpnDto GetVpn(int VpnID);
        public void AddVpn(VpnDto vpn);
        public void UpdateVpn(VpnDto vpn, int VpnID);
        public void DeleteVpn(int VpnID);


        void AddCluster(CreateClusterDto newCluster);
        void AddClient(CreateClientDto newClient);
        void AddNode(CreateNodeDto newNode);
        ClusterDto GetClusterByID(int ClusterID);
        ClientDto GetClientByID(int ClientID);
        NodeDto GetNodeByID(int NodeID);
        void UpdateCluster(int ClusterID, CreateClusterDto newCluster);
        void UpdateClient(int ClientID, CreateClientDto newClient);
        void UpdateNode(int NodeID, CreateNodeDto newNode);
        List<ClusterDto> GetAllClusters();
        List<ClientDto> GetAllClients();
        List<NodeDto> GetAllNodes();
        void DeleteCluster(int ClusterID);
        void DeleteClient(int ClientID);
        void DeleteNode(int NodeID);

    }
}