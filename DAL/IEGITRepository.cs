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
        public List<Lun> GetAllLuns();
        void AddLun(Lun lun);
        Lun GetLun(int id);
        void DeleteLun(int id);
        void UpdateLun(Lun lun);
        int getTSpaceByStockId(int id);
        List<Storage> GetAllStorages();
        Storage GetStorage(int id);
        void AddStorage(Storage storage);
        void DeleteStorage(int id);
        void UpdateStorage(Storage storage);
        List<Node> GetClusterNodes(int ClusterID);
        List<VM> GetNodeVMs(int NodeID);
        public void CalculateRAM(Storage storage);

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

    }
}
