using BLL.ModelsDto;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IEGITService
    {
        public List<LunDto> GetAllLuns();
        public GenerateErrorDto AddLun(CreateLunDto lun);
        public LunDto GetLun(int id);
        public GenerateErrorDto DeleteLun(int id);
        public GenerateErrorDto UpdateLun(CreateLunDto lun, int LunID);
        public List<StorageDto> GetAllStorages();
        public StorageDto GetStorage(int id);
        public GenerateErrorDto AddStorage(CreateStorageDto storage);
        public GenerateErrorDto DeleteStorage(int id);
        public GenerateErrorDto UpdateStorage(CreateStorageDto storage, int StorageID);
        public GenerateErrorDto CalculateStorageRAM(int StorageID);
        public List<VMDto> GetAllVMs();
        public VMDto GetVM(int VMID);
        public GenerateErrorDto AddVM(CreateVMDto VM);
        public GenerateErrorDto UpdateVM(CreateVMDto VM, int VMID);
        public GenerateErrorDto DeleteVM(int VMID);
        //vpn functions

        public List<VpnDto> GetAllVpns();
        public VpnDto GetVpn(int VpnID);
        public GenerateErrorDto AddVpn(CreateVpnDto vpn);
        public GenerateErrorDto UpdateVpn(CreateVpnDto vpn, int VpnID);
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
        GenerateErrorDto CalculateClusterSpace(int ClusterID);
        GenerateErrorDto CalculateNodeRemainingSpace(int NodeID);
    }
}