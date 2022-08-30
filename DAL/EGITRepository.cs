using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class EGITRepository : IEGITRepository
    {
        private readonly PostgreSqlContext context;

        public EGITRepository(PostgreSqlContext context)
        {
            this.context = context;

        }

        public List<Lun> GetAllLuns()
        {
            return context.Luns.ToList();
        }

        public Lun GetLun(int id)
        {
            return (Lun)context.Luns.FirstOrDefault(l => l.LunID == id);
        }

        public void AddLun(Lun lun)
        {
            context.Luns.Add(lun);
            context.SaveChanges();

        }

        public void DeleteLun(int id)
        {
            var entity = context.Luns.FirstOrDefault(t => t.LunID == id);
            context.Luns.Remove(entity);
            context.SaveChanges();
        }
        public void UpdateLun(Lun lun)
        {
            context.Luns.Update(lun);
            context.SaveChanges();
        }

        public List<Lun> GetStorageLuns(int StorageID)
        {
            return context.Luns.Where(t => t.StorageID == StorageID).ToList();

        }

        public List<VM> GetLunVMs(int LunID)
        {
            return context.VMs.Where(t => t.LunID == LunID).ToList();

        }


        public List<Storage> GetAllStorages()
        {
            return context.Storages.ToList();
        }

        public Storage GetStorage(int StorageID)
       {
            return (Storage)context.Storages.FirstOrDefault(l => l.StorageID == StorageID);
        }

        public void AddStorage(Storage storage)
        {
            context.Storages.Add(storage);
            context.SaveChanges();

        }

        public void UpdateStorage(Storage storage)
        {
            context.Storages.Update(storage);
            context.SaveChanges();
        }

        public void DeleteStorage(int id)
        {
            var entity = context.Storages.FirstOrDefault(t => t.StorageID == id);
            context.Storages.Remove(entity);
            context.SaveChanges();
        }
        public List<Vpn> GetAllVpns()
        {
            return context.Vpns.ToList();
        }
        public Vpn GetVpn(int VpnID)
        {
            return context.Vpns.FirstOrDefault(l => l.VpnID == VpnID);
        }

        public void AddVpn(Vpn vpn)
        {
            context.Vpns.Add(vpn);
            context.SaveChanges();

        }
        public void UpdateVpn(Vpn vpn)
        {
            context.Vpns.Update(vpn);
            context.SaveChanges();
        }

        public void DeleteVpn(int VpnID)
        {
            var entity = context.Vpns.FirstOrDefault(t => t.VpnID == VpnID);
            context.Vpns.Remove(entity);
            context.SaveChanges();
        }

        public List<VM> GetAllVMs()
        {
            return context.VMs.ToList();
        }
        public VM GetVM(int VMID)
        {
            return context.VMs.FirstOrDefault(l => l.VMID == VMID);
        }

        public void AddVM(VM VM)
        {
            context.VMs.Add(VM);
            context.SaveChanges();

        }
        public void UpdateVM(VM VM)
        {
            context.VMs.Update(VM);
            context.SaveChanges();
        }

        public void DeleteVM(int VMID)
        {
            var entity = context.VMs.FirstOrDefault(t => t.VMID == VMID);
            context.VMs.Remove(entity);
            context.SaveChanges();
        }

        public void AddCluster(Cluster newCluster)
        {
            context.Clusters.Add(newCluster);
            context.SaveChanges();
        }
        public void UpdateCluster(Cluster newCluster)
        {
            context.Clusters.Update(newCluster);
            context.SaveChanges();
        }
        public Cluster GetClusterByID(int ClusterID)
        {
            return context.Clusters.FirstOrDefault(c => c.ClusterID == ClusterID);
        }
        public List<Cluster> GetAllClusters()
        {
            return context.Clusters.ToList();
        }
        public void DeleteCluster(int ClusterID)
        {
            var returnedCluster = GetClusterByID(ClusterID);
            context.Clusters.Remove(returnedCluster);
            context.SaveChanges();
        }
        public void AddClient(Client newClient)
        {
            context.Clients.Add(newClient);
            context.SaveChanges();
        }
        public Client GetClientByID(int ClientID)
        {
            return context.Clients.FirstOrDefault(c => c.ClientID == ClientID);
        }
        public void UpdateClient(Client newClient)
        {
            context.Clients.Update(newClient);
            context.SaveChanges();
        }
        public List<Client> GetAllClients()
        {
            return context.Clients.ToList();
        }
        public void DeleteClient(int ClientID)
        {
            var returnedClient = GetClientByID(ClientID);
            context.Clients.Remove(returnedClient);
            context.SaveChanges();
        }
        public void AddNode(Node newNode)
        {
            context.Nodes.Add(newNode);
            context.SaveChanges();
        }
        public Node GetNodeByID(int NodeID)
        {
            return context.Nodes.FirstOrDefault(n => n.NodeID == NodeID);
        }
        public void UpdateNode(Node newNode)
        {
            context.Nodes.Update(newNode);
            context.SaveChanges();
        }
        public List<Node> GetAllNodes()
        {
            return context.Nodes.ToList();
        }
        public void DeleteNode(int NodeID)
        {
            var returnedNode = GetNodeByID(NodeID);
            context.Nodes.Remove(returnedNode);
            context.SaveChanges();
        }

        public List<Node> GetClusterNodes(int ClusterID)
        {
            return context.Nodes.Include("Cluster").Where(n => n.ClusterID == ClusterID).ToList();
        }

        public List<VM> GetNodeVMs(int NodeID)
        {
            return context.VMs.Where(vm => vm.NodeID == NodeID).ToList();
        }

        public List<VM> GetClientVMs(int ClientID)
        {
            return context.VMs.Where(vm => vm.ClientID == ClientID).ToList();
        }

        public List<Vpn> GetClientVPNs(int ClientID)
        {
            return context.Vpns.Where(vpn => vpn.ClientID == ClientID).ToList();
        }

        public List<Cluster> GetClustersByType(string ClusterType)
        {
            return context.Clusters.Where(c => c.ClusterType == ClusterType).ToList();
        }

        public List<Cluster> GetUpdatedClusters(DateTime dateTime)
        {
            List<Cluster> updatedClusterList = new List<Cluster>();
            updatedClusterList = context.Clusters.Where(c => c.LastUpdateTime > dateTime).ToList();
            return updatedClusterList;
        }

        public List<Node> GetUpdatedNodes(DateTime dateTime)
        {
            List<Node> updatedNodeList = new List<Node>();
            updatedNodeList = context.Nodes.Where(n => n.LastUpdateTime > dateTime).ToList();
            return updatedNodeList;
        }

        public List<VM> GetUpdatedVMs(DateTime dateTime)
        {
            List<VM> updatedVMList = new List<VM>();
            updatedVMList = context.VMs.Where(vm => vm.LastUpdateTime > dateTime).ToList();
            return updatedVMList;
        }

        public List<Storage> GetUpdatedStorages(DateTime dateTime)
        {
            List<Storage> updatedStorageList = new List<Storage>();
            updatedStorageList = context.Storages.Where(st => st.LastUpdateTime > dateTime).ToList();
            return updatedStorageList;
        }
        public List<Lun> GetUpdatedLuns(DateTime dateTime)
        {
            List<Lun> updatedLunList = new List<Lun>();
            updatedLunList = context.Luns.Where(l => l.LastUpdateTime > dateTime).ToList();
            return updatedLunList;
        }
        public List<Vpn> GetUpdatedVPNs(DateTime dateTime)
        {
            List<Vpn> updatedVPNList = new List<Vpn>();
            updatedVPNList = context.Vpns.Where(vpn => vpn.LastUpdateTime > dateTime).ToList();
            return updatedVPNList;
        }
    }
}
