using DAL.Models;
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

        public int getTSpaceByStockId(int id)
        {
            return context.Luns.Where(t => t.StorageID == id).Sum(i => i.LunTotalRAM);

        }

        public void updateRSpace(Lun lun)
        {
            var luns = context.Luns.Where(p => p.LunID == lun.LunID).ToList();
            luns.ForEach(p => p.LunRemainingRAM = lun.LunRemainingRAM);
            context.SaveChanges();
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
            return context.Nodes.Where(n => n.ClusterID == ClusterID).ToList();
        }

    }
}
