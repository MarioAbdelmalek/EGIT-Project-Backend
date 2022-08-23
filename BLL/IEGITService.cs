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
        public GenerateErrorDto AddLun(LunDto lun);
        public LunDto GetLun(int id);
        public GenerateErrorDto DeleteLun(int id);
        public GenerateErrorDto UpdateLun(LunDto lun, int LunID);
        public int getTSpaceByStockId(int id);

        // Storage functions
        public List<StorageDto> GetAllStorages();
        public StorageDto GetStorage(int id);
        public GenerateErrorDto AddStorage(StorageDto storage);
        public GenerateErrorDto DeleteStorage(int id);
        public GenerateErrorDto UpdateStorage(StorageDto storage, int StorageID);
        public GenerateErrorDto CalculateRAM(int StorageID);


        //VM functions
        public List<VMDto> GetAllVMs();
        public VMDto GetVM(int VMID);
        public GenerateErrorDto AddVM(VMDto VM);
        public GenerateErrorDto UpdateVM(VMDto VM, int VMID);
        public GenerateErrorDto DeleteVM(int VMID);
        //vpn functions
        public List<VpnDto> GetAllVpns();
        public VpnDto GetVpn(int VpnID);
        public GenerateErrorDto AddVpn(VpnDto vpn);
        public GenerateErrorDto UpdateVpn(VpnDto vpn, int VpnID);
        public GenerateErrorDto DeleteVpn(int VpnID);


        GenerateErrorDto AddCluster(CreateClusterDto newCluster);
        GenerateErrorDto AddClient(CreateClientDto newClient);
        GenerateErrorDto AddNode(CreateNodeDto newNode);
        ClusterDto GetClusterByID(int ClusterID);
        ClientDto GetClientByID(int ClientID);
        NodeDto GetNodeByID(int NodeID);
        GenerateErrorDto UpdateCluster(int ClusterID, CreateClusterDto newCluster);
        GenerateErrorDto UpdateClient(int ClientID, CreateClientDto newClient);
        GenerateErrorDto UpdateNode(int NodeID, CreateNodeDto newNode);
        List<ClusterDto> GetAllClusters();
        List<ClientDto> GetAllClients();
        List<NodeDto> GetAllNodes();
        GenerateErrorDto DeleteCluster(int ClusterID);
        GenerateErrorDto DeleteClient(int ClientID);
        GenerateErrorDto DeleteNode(int NodeID);

    }
}