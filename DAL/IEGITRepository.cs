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
        public List<Cluster> GetClustersByType(string ClusterType);
        List<Client> GetAllClients();
        List<Node> GetAllNodes();
        void DeleteCluster(int ClusterID);
        void DeleteClient(int ClientID);
        void DeleteNode(int NodeID);
        public List<Lun> GetAllLuns();
        public void AddLun(Lun lun);
        public Lun GetLun(int id);
        public void DeleteLun(int id);
        public void UpdateLun(Lun lun);
        List<Lun> GetStorageLuns(int StorageID);
        public List<VM> GetLunVMs(int LunID);

        public List<Storage> GetAllStorages();
        public Storage GetStorage(int id);
        public void AddStorage(Storage storage);
        public void DeleteStorage(int id);
        public void UpdateStorage(Storage storage);
        List<Node> GetClusterNodes(int ClusterID);
        List<VM> GetNodeVMs(int NodeID);
        List<VM> GetClientVMs(int ClientID);
        List<Vpn> GetClientVPNs(int ClientID);
        public List<VM> GetAllVMs();
        public VM GetVM(int VMID);
        public void AddVM(VM VM);
        public void UpdateVM(VM VM);
        public void DeleteVM(int VMID);

        public List<Vpn> GetAllVpns();
        public Vpn GetVpn(int VpnID);
        public void AddVpn(Vpn vpn);
        public void UpdateVpn(Vpn vpn);
        public void DeleteVpn(int VpnID);
        List<Cluster> GetUpdatedClusters(DateTime dateTime);
        List<Node> GetUpdatedNodes(DateTime dateTime);
        List<VM> GetUpdatedVMs(DateTime dateTime);
    }
}
