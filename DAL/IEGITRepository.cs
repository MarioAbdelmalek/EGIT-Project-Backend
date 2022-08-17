using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IEGITRepository
    {
        void AddCluster(Cluster newCluster);
        void AddClient(Client newClient);
        void AddNode(Node newNode);
        void UpdateCluster(Cluster newCluster);
        void UpdateClient(Client newClient);
        void UpdateNode(Node newNode);
        Cluster GetClusterByID(int ClusterID);
        Client GetClientByID(int ClientID);
        Node GetNodeByID(int NodeID);
        List<Cluster> GetAllClusters();
        List<Client> GetAllClients();
        List<Node> GetAllNodes();
        void DeleteCluster(int ClusterID);
        void DeleteClient(int ClientID);
        void DeleteNode(int NodeID);
        //Lun Functions
        public List<Lun> getAllLuns();
        public void addLun(Lun lun);
        public Lun getLun(int id);
        public void deleteLun(int id);
        public void updateLun(Lun lun);
        public int getTSpaceByStockId(int id);

        //Storage functions

        public List<Storage> getAllStorages();
        public Storage getStorage(int id);
        public void addStorage(Storage storage);
        public void deleteStorage(int id);
        public void updateStorage(Storage storage);
    }
}
