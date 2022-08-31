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
        public List<VMDto> GetLunVMs(int LunID);
        public List<StorageDto> GetAllStorages();
        public StorageDto GetStorage(int id);
        public List<LunDto> GetStorageLuns(int StorageID);
        public GenerateErrorDto AddStorage(CreateStorageDto storage);
        public GenerateErrorDto DeleteStorage(int id);
        public GenerateErrorDto UpdateStorage(CreateStorageDto storage, int StorageID);
        public GenerateErrorDto CalculateStorageSpace(int StorageID);
        public GenerateErrorDto CalculateLunSpace(int LunID);

        public List<VMDto> GetAllVMs();
        public VMDto GetVM(int VMID);
        public GenerateErrorDto AddVM(CreateVMDto VM);
        public GenerateErrorDto UpdateVM(UpdateVMDto VM, int VMID);
        public GenerateErrorDto DeleteVM(int VMID);

        public List<VpnDto> GetAllVpns();
        public VpnDto GetVpn(int VpnID);
        public GenerateErrorDto AddVpn(CreateVpnDto vpn);
        public GenerateErrorDto UpdateVpn(CreateVpnDto vpn, int VpnID);
        public GenerateErrorDto DeleteVpn(int VpnID);
        public GenerateErrorDto AddCluster(CreateClusterDto newCluster);
        public GenerateErrorDto AddClient(CreateClientDto newClient);
        public GenerateErrorDto AddNode(CreateNodeDto newNode);
        public ClusterDto GetClusterByID(int ClusterID);
        public List<ClusterDto> GetClustersByType(string ClusterType);
        public ClientDto GetClientByID(int ClientID);
        public NodeDto GetNodeByID(int NodeID);
        public GenerateErrorDto UpdateCluster(int ClusterID, CreateClusterDto newCluster);
        public GenerateErrorDto UpdateClient(int ClientID, CreateClientDto newClient);
        public GenerateErrorDto UpdateNode(int NodeID, CreateNodeDto newNode);
        public List<ClusterDto> GetAllClusters();
        public List<ClientDto> GetAllClients();
        public List<NodeDto> GetAllNodes();
        public List<VMDto> GetNodeVMs(int NodeID);
        public List<NodeDto> GetClusterNodes(int ClusterID);
        public GenerateErrorDto DeleteCluster(int ClusterID);
        public GenerateErrorDto DeleteClient(int ClientID);
        public GenerateErrorDto DeleteNode(int NodeID);
        public GenerateErrorDto CalculateClusterSpace(int ClusterID);
        public GenerateErrorDto CalculateNodeRemainingSpace(int NodeID);
        public List<ClusterDto> GetUpdatedClusters();
        public List<NodeDto> GetUpdatedNodes();
        public List<VMDto> GetUpdatedVMs();
        public List<StorageDto> GetUpdatedStorages();
        public List<LunDto> GetUpdatedLuns();
        public List<VpnDto> GetUpdatedVPNs();
        public List<ClientDto> GetUpdatedClients();

    }
}