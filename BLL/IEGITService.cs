using BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IEGITService
    {
        // Lun functions
        public List<LunDto> getAllLuns();
        public void addLun(LunDto lun);
        public LunDto getLun(int id);
        public void deleteLun(int id);
        public void updateLun(LunDto lun);
        public int getTSpaceByStockId(int id);

        // Stock functions
        public List<StorageDto> getAllStorages();
        public StorageDto getStorage(int id);
        public void addStorage(StorageDto storage);
        public void deleteStorage(int id);
        public void updateStorage(StorageDto storage);

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